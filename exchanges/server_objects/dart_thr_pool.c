/**************************************************************************
 * Copyright (c) 2008 by Ronin Capital, LLC
 *
 * All Rights Reserved
 *************************************************************************/
#ifndef _GNU_SOURCE
#define _GNU_SOURCE
#endif
#include <stdlib.h>
#include <pthread.h>
#include <signal.h>
#include <errno.h>
#include <unistd.h>
#include <sys/time.h>
#include <stdio.h>
#include <string.h>

#include "dart_thr_pool.h"
#include "message_queue.h"
#include "transaction_recorder.h"
#include "debug_logger.h"
#include "dart_obj_factory.h"
#define POOL_WAIT 0x01
#define POOL_DESTROY 0x02

static volatile int lock_val = 0;

struct job {
    struct job *next;
    void *(*job_func) (void *);
    void *job_arg;
};

struct active {
    struct active *next;
    pthread_t active_tid;
};

struct thr_pool {
    thr_pool_t *pool_forw;
    thr_pool_t *pool_back;
    pthread_spinlock_t pool_mutex;
    struct active *pool_active;
    queue_t jobs;
    pthread_attr_t pool_attr;
    int pool_flags;
    int pool_linger;
    int pool_min;
    int pool_max;
    int *cpus;
    int pool_num_thr;
    int pool_idle;
    dof_t *job_fact;
};

static int dart_thr_pool_lock()
{
    while (__sync_val_compare_and_swap(&lock_val, 0, 1) == 1) {
        //do nothing
    }
    return 0;
}

static int dart_thr_pool_unlock()
{
    return __sync_fetch_and_sub(&lock_val, 1);
}

struct thr_pool_wrapper {
    int thread_num;
    thr_pool_t *thr;
};

static thr_pool_t *thr_pools = NULL;

static pthread_mutex_t thr_pool_lock = PTHREAD_MUTEX_INITIALIZER;

static void *worker_thread_2(void *);

void job_create_func(queue_t glob, queue_t q, int num)
{
    size_t jsize = sizeof(struct job);
    size_t size = num * jsize;
    char *blob = calloc(size, 1);
    if (blob) {
        char *glob_off = blob;
        size_t offset = 0;
        enqueue(glob, blob);
        while (offset < size) {
            struct job *doj = (struct job *) glob_off;
            glob_off += jsize;
            offset += jsize;
            enqueue(q, doj);
        }

    }
}

void job_destroy_func(void *j)
{
    struct job *job = (struct job *) j;
    free(job);
}

void job_clear_obj(void *obj)
{
    struct job *j = (struct job *) obj;
    memset(j, '\0', sizeof(struct job));
}

static int create_worker(struct thr_pool_wrapper *pool)
{
    int error;
    pthread_t l_thread;
    error =
        pthread_create(&l_thread, &pool->thr->pool_attr, worker_thread_2,
                       pool);
    return error;
}

static void *worker_thread_2(void *arg)
{
    struct thr_pool_wrapper *wp = (struct thr_pool_wrapper *) arg;
    thr_pool_t *pool = wp->thr;
    struct job *j;
    void *(*func) (void *);
    struct active a;
    sigset_t blocks;
    sigemptyset(&blocks);
    sigaddset(&blocks, SIGPIPE);
    pthread_sigmask(SIG_BLOCK, &blocks, NULL);
    pthread_t thread = pthread_self();
    cpu_set_t cpuset;
    a.active_tid = thread;
    CPU_ZERO(&cpuset);
    if (pool->cpus != NULL) {
        int l_thr = 0;
        l_thr = *(pool->cpus + wp->thread_num);
        CPU_SET(l_thr, &cpuset);
        int s = pthread_setaffinity_np(thread, sizeof(cpu_set_t), &cpuset);
        if (s != 0) {
            if (s == EFAULT) {
                send_debug_message
                    ("Invalid mem addr: %d Thread: %d, cpu: %d.", s,
                     wp->thread_num, l_thr);
            } else if (s == EINVAL) {
                send_debug_message
                    ("Bad processor or cpu: %d Thread: %d, cpu: %d.", s,
                     wp->thread_num, l_thr);
            } else if (s == ESRCH) {
                send_debug_message("Bad Thread: %d Thread: %d, cpu: %d.",
                                   s, wp->thread_num, l_thr);
            } else {
                send_debug_message
                    ("Unknown error: %d Thread: %d, cpu: %d.", s,
                     wp->thread_num, l_thr);
            }
        } else {
            send_debug_message("Thread number: %d, cpu affinity: %d.",
                               wp->thread_num, l_thr);
        }
    } else {
        send_debug_message("CPUS value was null.");
    }
    while (1) {
        dart_thr_pool_lock();
        if (!is_empty(pool->jobs)) {
            element_t e = pop_front(pool->jobs);
            j = (struct job *) e->d;
            func = j->job_func;
            arg = j->job_arg;
            a.next = pool->pool_active;
            pool->pool_active = &a;
            destroy_elem(pool->job_fact, j);
            free_element(pool->jobs, e);
            dart_thr_pool_unlock();
            func(arg);
        } else {
            dart_thr_pool_unlock();
        }
        if (pool->pool_flags & POOL_DESTROY) {
            break;
        }
    }
    pthread_sigmask(SIG_UNBLOCK, &blocks, NULL);
    return (NULL);
}

static void clone_attributes(pthread_attr_t * new_attr,
                             pthread_attr_t * old_attr)
{
    struct sched_param param;
    void *attr;
    size_t size;
    int value;

    pthread_attr_init(new_attr);
    if (old_attr != NULL) {
        pthread_attr_getstack(old_attr, &attr, &size);
        pthread_attr_setstack(new_attr, NULL, size);

        pthread_attr_getscope(old_attr, &value);
        pthread_attr_setscope(new_attr, value);

        pthread_attr_getinheritsched(old_attr, &value);
        pthread_attr_setinheritsched(new_attr, value);

        pthread_attr_getschedpolicy(old_attr, &value);
        pthread_attr_setschedpolicy(new_attr, value);

        pthread_attr_getschedparam(old_attr, &param);
        pthread_attr_setschedparam(new_attr, &param);

        pthread_attr_getguardsize(old_attr, &size);
        pthread_attr_setguardsize(new_attr, size);
    }
    pthread_attr_setdetachstate(new_attr, PTHREAD_CREATE_DETACHED);
}

thr_pool_t *thr_pool_create(int min_threads, int max_threads, int linger,
                            int *cpus, int set_affinity)
{
    thr_pool_t *pool;
    int ret_val = 0;
    if (min_threads > max_threads || max_threads < 1) {
        errno = EINVAL;
        return NULL;
    }
    if ((pool = malloc(sizeof(*pool))) == NULL) {
        errno = ENOMEM;
        return NULL;
    }
    ret_val =
        pthread_spin_init(&pool->pool_mutex, PTHREAD_PROCESS_PRIVATE);
    pool->job_fact =
        create_dart_obj_fact(50, &job_destroy_func, &job_create_func,
                             &job_clear_obj);
    pool->pool_active = NULL;
    pool->jobs = create_sized_queue(100);
    pool->pool_flags = 0;
    pool->pool_linger = linger;
    pool->pool_min = min_threads;
    pool->pool_max = max_threads;
    pool->pool_num_thr = 0;
    pool->pool_idle = 0;
    if (cpus == NULL) {
        pool->cpus = NULL;
    } else {
        pool->cpus = malloc(max_threads * sizeof(int));
        memcpy(pool->cpus, cpus, (max_threads * sizeof(int)));
    }
    clone_attributes(&pool->pool_attr, NULL);

    pthread_mutex_lock(&thr_pool_lock);
    if (thr_pools == NULL) {
        pool->pool_forw = pool;
        pool->pool_back = pool;
        thr_pools = pool;
    } else {
        thr_pools->pool_back->pool_forw = pool;
        pool->pool_forw = thr_pools;
        pool->pool_back = thr_pools->pool_back;
        thr_pools->pool_back = pool;
    }
    pthread_mutex_unlock(&thr_pool_lock);
    return pool;
}

int thr_pool_queue(thr_pool_t * pool, void *(*func) (void *), void *arg)
{
    struct job *j = get_obj(pool->job_fact);
    j->next = NULL;
    j->job_func = func;
    j->job_arg = arg;
    dart_thr_pool_lock();
    enqueue(pool->jobs, j);
    if (pool->pool_num_thr < pool->pool_max) {
        struct thr_pool_wrapper *tpw =
            malloc(sizeof(struct thr_pool_wrapper));
        tpw->thread_num = pool->pool_num_thr;
        tpw->thr = pool;
        if (create_worker(tpw) == 0) {
            pool->pool_num_thr++;
        }
    }
    dart_thr_pool_unlock();
    return 0;
}

void thr_pool_destroy(thr_pool_t * pool)
{
    struct active *activep;
    struct job *j;
    element_t temp;

    pool->pool_flags |= POOL_DESTROY;

    for (activep = pool->pool_active; activep != NULL;
         activep = activep->next) {
        pthread_cancel(activep->active_tid);
    }

    pthread_mutex_lock(&thr_pool_lock);
    if (thr_pools == pool) {
        thr_pools = pool->pool_forw;
    }
    if (thr_pools == pool) {
        thr_pools = NULL;
    } else {
        pool->pool_back->pool_forw = pool->pool_forw;
        pool->pool_forw->pool_back = pool->pool_back;
    }
    pthread_mutex_unlock(&thr_pool_lock);

    element_t e = dequeue(pool->jobs);
    while (e != NULL) {
        temp = e;
        e = temp->next;
        j = (struct job *) temp->d;
        free(j);
        free_element(pool->jobs, temp);
    }
    destroy_queue(pool->jobs);
    pthread_attr_destroy(&pool->pool_attr);
    free(pool);
}
