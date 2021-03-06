
/**************************************************************************
 * Copyright (c) 2008 by Ronin Capital, LLC
 *
 * All Rights Reserved
 *************************************************************************/


#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <signal.h>
#include <ctype.h>
#include <time.h>
#include <arpa/inet.h>
#include <pthread.h>
#include <unistd.h>
#include <sys/time.h>

#include "message_queue.h"
#include "parser_func.h"
#include "dart_constants.h"
#include "config_loader.h"
#include "ex_config_helper.h"
#include "fix_handler.h"
#include "fix_trans.h"
#include "connection_interface.h"
#include "mailer.h"
#include "debug_logger.h"
#include "rom_handler.h"
#include "rom_fix_trans_funcs.h"
#include "connection_interface.h"
#include "master_config.h"
#include "debug_logger.h"
#include "lifecycle_master.h"


static con_interface *client_con = 0;
static int *set_cpus(char *cfg_cpu, int cfg_cpu_len, int *ncpus)
{
	int i = 1;
	char *off = cfg_cpu;
	int cur_len = cfg_cpu_len;
	while ((off = memchr(off, ',', cur_len)) != NULL) {
		++i;
		off += 1;
		cur_len = cfg_cpu_len - (off - cfg_cpu);
	}
	*ncpus = i;
	int *cpus = calloc(i * sizeof(int), 1);
	char *cpu_tok = cfg_cpu;
	char *c = memchr(cpu_tok, ',', cfg_cpu_len);
	int j = 0;
	cur_len = cfg_cpu_len;
	while (c) {
		cpus[j] = atoi(cpu_tok);
		cpu_tok = c + 1;
		cur_len = cfg_cpu_len - (cpu_tok - cfg_cpu);
		++j;
		c = memchr(cpu_tok, ',', cur_len);
	}
	if (j < i) {
		cpus[j] = atoi(cpu_tok);
	}
	return cpus;
}


typedef struct gs_parser {
	sbureau_match* mpids;
	sbureau_match* algos;
	char* is_canada;
	int clen;
}gsp;

void from_gset(dart_order_obj * doj, void *a);


int build_gset_offsets(struct async_parse_args *apa)
{
	//con_interface* con = (con_interface*)apa->ds_book;
	return 0;
}

void glob_on_connect(async_parse_args* ap, int is_connected,
		char *log, int len)
{
	char *name = ap->in_args->name;
	int name_len = ap->in_args->name_len;
	send_debug_message("Connection: %s, is connected: %d ?\n", name,
			is_connected);
    if (ap->ds_book == NULL && is_connected == 2) {
        int found =
            get_obj_by_client_id(ap->gk, name, name_len, (void **) &client_con);
        if (found <= 0) {
            client_con = init_client_con(name, name_len,
                                          1, ap->gk,
                                          ap->ass, ap->sock,
                                          ap, 16384);
	    ap->ds_book = client_con;
            set_obj_by_client_id(ap->gk, name, name_len, ap->ds_book);
            ((con_interface *) ap->ds_book)->can_send_orders = 1;
            ((con_interface *) ap->ds_book)->ass = ap->ass;
            ((con_interface *) ap->ds_book)->do_oats_balance =
                ap->in_args->do_balance;
            client_con->can_send_orders = 1;
        } else {
            client_con->ap = ap;
            ap->ds_book = client_con;
            client_con->sock = ap->sock;
            client_con->ass = ap->ass;
            client_con->can_send_orders = 1;
        }
    } else if (ap->ds_book != NULL) {
        con_interface *ci = (con_interface *) ap->ds_book;
        if (ci->ap == NULL) {
            ci->ap = ap;
        }
        if (contains_obj(ap->gk, name, name_len)) {
            // Do nothing
        } else {
            set_obj_by_client_id(ap->gk, name, name_len, ap->ds_book);
        }
    }
	con_interface *ci = (con_interface *) ap->ds_book;
	if (ci) {
		if (ci->ap == NULL) {
			ci->ap = ap;
		}
		ci->on_connect(ci, is_connected);
		ci->do_oats_balance = ap->in_args->do_balance;
		if (is_connected) {
			ci->sock = ap->read_wrapper->sock;
			add_connection(ci->ass, name,
					name_len, (async_parse_args *) ci->ap);
		} else {
			ci->sock = -1;
			name = ap->in_args->name;
			name_len = ap->in_args->name_len;
		}
	}
}
static void gset_on_connect(struct connection_interface *ci, int is_connected)
{
	on_connect(ci, is_connected);
}
static ff_desc* create_gset_ff_out_array(int* len, char* dir, int d_len)
{
	char* full_path = calloc(1, d_len + 9);
	ff_desc* ffd = calloc(16, sizeof(struct fix_file_desc));
	memcpy(full_path, dir, d_len);
	memcpy(full_path + d_len, "NewOrder", 8);
	ffd[0].filename = full_path;
	full_path = calloc(1, d_len + 7);
	memcpy(full_path, dir, d_len);
	memcpy(full_path + d_len, "Cancel", 6);
	ffd[1].filename = full_path;
	full_path = calloc(1, d_len + 8);
	memcpy(full_path, dir, d_len);
	memcpy(full_path + d_len, "Replace", 7);
	ffd[2].filename = full_path;
	full_path = calloc(1, d_len + 8);
	memcpy(full_path, dir, d_len);
	memcpy(full_path + d_len, "GapFill", 7);
	ffd[3].filename = full_path;
	full_path = calloc(1, d_len + 6);
	memcpy(full_path, dir, d_len);
	memcpy(full_path + d_len, "Logon", 5);
	ffd[4].filename = full_path;
	full_path = calloc(1, d_len + 8);
	memcpy(full_path, dir, d_len);
	memcpy(full_path + d_len, "Logout", 6);
	ffd[5].filename = full_path;
	full_path = calloc(1, d_len + 16);
	memcpy(full_path, dir, d_len);
	memcpy(full_path + d_len, "ResendReq", 9);
	ffd[6].filename = full_path;
	full_path = calloc(1, d_len + 16);
	memcpy(full_path, dir, d_len);
	memcpy(full_path + d_len, "MLegNew", 7);
	ffd[7].filename = full_path;
	full_path = calloc(1, d_len + 8);
	memcpy(full_path, dir, d_len);
	memcpy(full_path + d_len, "TestReq", 7);
	ffd[8].filename = full_path;
	full_path = calloc(1, d_len + 16);
	memcpy(full_path, dir, d_len);
	memcpy(full_path + d_len, "MLegReplace", 11);
	ffd[9].filename = full_path;
	full_path = calloc(1, d_len + 16);
	memcpy(full_path, dir, d_len);
	memcpy(full_path + d_len, "Heartbeat", 9);
	ffd[10].filename = full_path;
	*len = 11;
	return ffd;
}

static ff_desc* create_gset_ff_in_array(int* len, char* dir, int d_len)
{
	char* full_path = calloc(1, d_len + 16);
	ff_desc* ffd = calloc(10, sizeof(struct fix_file_desc));
	memcpy(full_path, dir, d_len);
	memcpy(full_path + d_len, "FixToRomExe", 11);
	ffd[0].filename = full_path;
	ffd[0].fix_type = 0x38;
	full_path = calloc(1, d_len + 16);
	memcpy(full_path, dir, d_len);
	memcpy(full_path + d_len, "FixToRomCnlRej", 14);
	ffd[1].filename = full_path;
	ffd[1].fix_type = 0x39;
	full_path = calloc(1, d_len + 16);
	memcpy(full_path, dir, d_len);
	memcpy(full_path + d_len, "FixToRomNORej", 13);
	ffd[2].filename = full_path;
	ffd[2].fix_type = 0x44;
	full_path = calloc(1, d_len + 16);
	memcpy(full_path, dir, d_len);
	memcpy(full_path + d_len, "FixToRomLogon", 13);
	ffd[3].filename = full_path;
	ffd[3].fix_type = 0x41;
	full_path = calloc(1, d_len + 16);
	memcpy(full_path, dir, d_len);
	memcpy(full_path + d_len, "FixToRomSecDef", 14);
	ffd[4].filename = full_path;
	ffd[4].fix_type = 0x64;
	full_path = calloc(1, d_len + 16);
	memcpy(full_path, dir, d_len);
	memcpy(full_path + d_len, "FixToRomMail", 12);
	ffd[5].filename = full_path;
	ffd[5].fix_type = 0x42;
	//New
	full_path = calloc(1, d_len + 16);
	memcpy(full_path, dir, d_len);
	memcpy(full_path + d_len, "FixToRomBizRej", 14);
	ffd[6].filename = full_path;
	ffd[6].fix_type = 0x6A;
	//
	full_path = calloc(1, d_len + 16);
	memcpy(full_path, dir, d_len);
	memcpy(full_path + d_len, "FixToRomSesRej", 14);
	ffd[7].filename = full_path;
	ffd[7].fix_type = 0x33;
	//done
	*len = 8;
	return ffd;
}

void create_gs_parser(ex_config* ex, con_interface* con)
{
	gsp* gp = calloc(1, sizeof(struct gs_parser));
	int ret_len = 0;
	char* mpid_mapper = get_val_for_tag(ex->dc, "FIX SERVER", 10,
			"MPID Map", 8, &ret_len);
	if(ret_len <= 0) {
		mpid_mapper = "GSMPID.map";
	}
	gp->mpids = create_service_bureau_matcher(mpid_mapper);
	char* algo_mapper = get_val_for_tag(ex->dc, "FIX SERVER", 10,
			"algos", 5, &ret_len);
	if(ret_len <=0 ) {
		algo_mapper = "GSAlgos.map";
	}
	gp->algos = create_service_bureau_matcher(algo_mapper);
	gp->is_canada = get_val_for_tag(ex->dc, "FIX SERVER", 10,
			"Canadian", 8, &ret_len);
	if(ret_len > 0) {
		gp->clen  = ret_len;
	} else {
		gp->is_canada = 0x0;
		gp->clen = 0;
	}
	con->sym_trans = gp;
}
int on_gset_enter_order(con_interface * ci, dart_order_obj * doj,
		struct async_parse_args *ap) {return 0;}

int on_gset_cancel_order(con_interface * ci, dart_order_obj * doj) {return 0;}

void on_gset_replace_order(con_interface * ci, dart_order_obj * doj) {}

void create_connection(con_interface * con, char *filename, int name_len,
		gatekeeper * gk)
{

	ex_config *ex = init_config(filename, name_len);
	struct init_args *fix_args = load_fix_config(filename, name_len);
	reset_con_interface(con, 8192,
			(char *) ex->mod_name, ex->mod_name_len,
			fix_args->target_comp, fix_args->tc_len,
			send_fix_logon, build_gset_offsets,
			on_gset_enter_order, on_gset_cancel_order,
			on_gset_replace_order, gk, (char *) ex->dest_id,
			ex->dest_id_len);
	con->client_mess_parse = parse_fix_message;
	con->ci_parse_v = 0;
	con->on_connect = gset_on_connect;
	con->ci_obj_callback= from_gset;
	con->connection_conf = ex;
	con->can_send_orders = 0;
	con->session_conf = fix_args;
	add_int_orderids(con);
	int ret_len = 0;
	char* directory = get_val_for_tag(ex->dc, "FIX SERVER", 10,
			"directory", 9, &ret_len);
	int out_len = 0;
	int in_len = 0;
	ff_desc* out_types = create_gset_ff_out_array(&out_len,directory, ret_len);
	ff_desc* in_types = create_gset_ff_in_array(&in_len,directory, ret_len);
	trans_t* t = create_translator(out_types,out_len,
			in_types, in_len);
	con->parser = t;
	create_gs_parser(ex, con);
	con->tg = token_creation_func(con->dest_id, con->dest_len);
	ret_len = 0;
    char* flipper = get_val_for_tag(ex->dc, "FIX SERVER", 10,
            "Account.map", 9, &ret_len);
    if(ret_len <=0 ) {
        con->sbm = create_service_bureau_matcher("Account.map");
    } else {
        con->sbm = create_service_bureau_matcher(flipper);
    }
}


static void log_values(char* message, int mlen, con_interface* ci)
{
	char* data = calloc(mlen +1, 1);
	memcpy(data, message, mlen);
        struct rolling_log_message *m1 =
            malloc(sizeof(struct rolling_log_message));
        m1->data = data;
        m1->len = mlen;
        m1->name = calloc(10, 1);
        memcpy(m1->name, "KRM22Demo", 9);
        m1->name_len = 9;
        m1->file_name = calloc(10, 1);
        memcpy(m1->file_name, "KRM22Demo", 9);
        m1->file_name_len = 9;
        dart_rolling_log(m1);
}

static void handle_ex_report(dart_order_obj* doj, con_interface* ci)
{
    int clr_len = 0;
    char* flipper = get_mpid_for_clr_acct(ci->sbm,
            getpval(doj, 38),
            getplen(doj, 38),
            &clr_len);
    if(flipper) {
	    send_debug_message("Account is good: %s \n", flipper);
    }
    if(clr_len > 0) {
	    if(client_con) {
		    send_debug_message("Found the client!!!!\n");
		    set_rom_field(doj, 0, "S",1);
		client_con->ci_iovec_sender(doj->positions,
                                                         DART_SEND_LEN,
							 client_con->module_name,
							 client_con->module_name_len,
                                                          client_con,client_con->sock);

	    }
	    set_rom_field(doj, 0, "S",1);
	    set_rom_field(doj, ROM_SENDER, "SUMDROP",7);
	    databuf_t* cur_off = databuf_alloc(2048);
            copy_iovecs_to_buff(doj->positions, DART_SEND_LEN, cur_off, 0);
	record_raw_message("SUMDROP", 7, cur_off->rd_ptr, databuf_unread(cur_off), '1');
	    /*dart_order_obj* rhs = get_gk_obj(ci->gk);
	    set_rom_field(rhs, ROM_CLORDID, getpval(doj, 15), getplen(doj, 15));
	    set_rom_field(rhs, ROM_TYPE, getpval(doj, 8), getplen(doj, 15));*/
	  /*
	   *
	   *
  2 54,8
  3 55,10
  4 38,6
  5 44,7
  6 40,16
  7 59,9
  8 150,14
  9 31,88
 10 32,84
 11 434,63
 12 151,49
 13 1,24
 14 30,26
 15 6,51
 16 76,40
 17 60,50
 18 17,54
 19 654,17
 20 442,66
 21 9730,69
 22 442,66
 23 41,120
 24 200,60
 25 201,62
 26 202,64
 27 205,122
 28 14,48
 29 440,36
 30 77,38
 31 37,16
 32 20,75
  
		databuf_destroy(message);*/

    }
}
static void handle_email_req(dart_order_obj* doj, con_interface* con)
{
	send_biz_message(getpval(doj, 26), getplen(doj, 26), "News Flash from Goldman!",
			24);
}

void from_gset(dart_order_obj * doj, void *a)
{
	async_parse_args *apa = (async_parse_args*) a;
	if (doj && apa) {
		doj->dest = apa->ds_book;
		con_interface *ci = (con_interface *) apa->ds_book;
		switch(doj->type) {
			case 0x38:
				handle_ex_report(doj, ci);
				//execution report
				break;
			case 0x39:
				handle_cnl_rpl_rej(doj, ci);
				//cnl_rep_rej
				break;
			case 0x42:
				handle_email_req(doj, ci);
				break;
			case 0x4A43:
				//Logon Response Positive
				ci->can_send_orders = 1;
				ci->connected = 1;
				break;
			default:
				break;
		}
	}
}

static unsigned long gen_build_off(char *data, unsigned long size,
        unsigned long byte_offset,
        unsigned long *seq_num, void* book)
{
    return size;
}

static char *gen_resend_pad(unsigned long seq, char *rom, size_t * len)
{
    return NULL;
}

static void reset_seq(struct init_args *in_args)
{
    sequence_req *sr =
        create_sequence_request(in_args->name, in_args->name_len,
                in_args,
                gen_build_off,
                gen_resend_pad, in_args);
    clean_seq(sr);
}
static void set_reset_time(struct init_args *in, master_config * mc)
{
    in->reset_time->reset_hour = mc->reset_hour;
    in->reset_time->reset_min = mc->reset_min;
    in->reset_time->create_new = mc->create_new;
    in->reset_time->new_incoming = 0;
    in->reset_time->new_outgoing = 0;
    in->reset_time->reset_day = 7;
    in->reset_time->last_logon = 0;
    send_debug_message("Do we CreateNew? %d \n", mc->create_new);
    if (mc->create_new) {
        reset_seq(in);
    }
}
void switchboard(dart_order_obj * doj, void *a)
{
    async_parse_args *ap = (async_parse_args *) a;
    if (doj && ap) {
        doj->sender = ap->ds_book;
        char *rtype = doj->positions[0].iov_base;
        switch (rtype[0]) {
        case 'E':
            break;
        case 'C':
            break;
        case 'c':
            break;
        case 'R':
            break;
        case 'H':
            break;
        case 'P':
            {
                send_debug_message("P message received\n");
                break;
            }
        default:
            {
                long addr = (long)doj;
                send_debug_message("Unknown order Address: %d\n", addr);
                destroy_gk_obj(ap->gk, doj);
            }
            break;
        }
    }
}
int main(int argc, char** argv) 
{
	rec_args* ra = init_recorder(64, 32, "./",2);
	int len = strlen(argv[1]);
	struct init_args *fix_args = load_fix_config(argv[1], len);
	master_config *main_cfg = init_mconfig(argv[1], len);
	if(main_cfg->dir_len > 0) {
		reset_default_directory(ra, main_cfg->dir, main_cfg->dir_len);
	}
	int ncpus = 0;
	char *re_routers = "dest_route_tbl.map";
	int *cpus = set_cpus(main_cfg->cpus, main_cfg->cpu_len, &ncpus);
	gatekeeper *gk = create_gatekeeper(8192, (char *) main_cfg->mod_name,
			main_cfg->mod_name_len,
			NULL, main_cfg->create_new,
			re_routers, NULL);
	async_server_con_set * async_server =
		start_async_server(gk, ra,
				ncpus, 0,cpus, 64);
	cycle_master* cm = create_lifecycle_master(async_server, gk, main_cfg);
	sleep(5);
	queue_t users = create_sized_queue(256);
	
        struct init_args *in = calloc(1, sizeof(struct init_args));
	in->name = calloc(1, 10);
	memcpy(in->name, "SUMDROP", 7);
        in->name_len = 7;
	in->username = calloc(1, 10);
	memcpy(in->username, "SUMDROP", 7);
	in->un_len = 7;
	in->password = calloc(1, 10);
	memcpy(in->password, "SUMDROP", 7);
        in->p_len = 7;
        in->do_balance = 0;
	in->reset_time = calloc(1, sizeof(struct seq_reset_time));
	set_reset_time(in, main_cfg);
        enqueue(users, in);

        add_async_listener(async_server, gk, main_cfg, main_cfg->mod_name,
                           main_cfg->mod_name_len,
                           main_cfg->server_port,
                           users,
                           main_cfg->server_ip,
                           main_cfg->server_ip_len,
                           main_cfg->end_hour,
                           main_cfg->end_min,
                           main_cfg->end_day,
                           0,
                           glob_on_connect,
                           ph_parse_rom_message,
                           0,
                           ci_async_write_callback,
                           ph_build_non_fix_rom_pos, switchboard);
	/**/
	con_interface *con = create_empty_interface();
        time_t now;
        time(&now);
	int create_new = ll_before_reset_time(fix_args, now);
	send_debug_message("Did we want to create New? %d \n", create_new);
	if(create_new) {
	    sequence_req* sr = create_sequence_request(fix_args->name,//sender_comp,
                                 fix_args->name_len,//sc_len,
                                 fix_args,
                                 build_fix_offsets,
                                 create_fix_resend_pad, con);
		clean_seq(sr);
	}
	/* i.e. processing the first in our list */
	start_dart_mail_service(main_cfg->mail_server,
			main_cfg->mail_server_len,
			main_cfg->biz_group,
			main_cfg->b_len,
			main_cfg->tech_group,
			main_cfg->t_len,
			main_cfg->end_hour,
			main_cfg->end_min, main_cfg->end_day);
	create_connection(con,"drop.dat", 8, gk); 
	char* header = "#Record ID,Office,Account,Account Type,Exchange,Symbol,Cusip,Put/Call,Buy/Sell,Quantity,Contract YYYY/MM,Strike,Expiration Date,Trade Price,Currency,Net Amount,Firm";
	int headerlen = strlen(header);
	log_values(header,headerlen,con);
	con->ass = async_server;
	//reload_config(con->connection_conf);
	//reload_init_args(con->session_conf);
	int worked = async_connection(async_server,
			con->connection_conf->mod_name,
			con->connection_conf->mod_name_len,
			con->connection_conf->fix_port,
			con->connection_conf->fix_ip,
			con->connection_conf->fix_ip_len,
			con->connection_conf->end_hour,
			con->connection_conf->end_min,
			con->connection_conf->end_day,
			con->connection_conf->heart_beat_int,
			con,
			glob_on_connect,
			con->client_mess_parse,
			con->session_conf,
			con->connect,
			con,
			ci_async_write_callback,
			con->ci_parse_v, con->ci_obj_callback);
	if(worked == 0) {
		{
			if(con->recon_wrapper == 0) {
				con->recon_wrapper = add_timer(con->ass, 0,
						0, 30, 0, con,async_reconnect_t);
			} else {
				add_back_recon_timer(con->ass, con->recon_wrapper);
			}
		}
	}
	join_n_clean(async_server);
	destroy_life_cycle_master(cm);
	destroy_master_config(main_cfg);
	return 1 ;
}
