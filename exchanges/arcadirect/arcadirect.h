/**************************************************************************
 * Copyright (c) 2008 by Ronin Capital, LLC
 *
 * All Rights Reserved
 *************************************************************************/

#ifndef _UTPDIRECT_H__
#define _UTPDIRECT_H__

#if defined(__cplusplus)
extern "C" {
#endif

#include "common_structs.h"
#include "ex_config_helper.h"

int send_ad_logon(struct parse_args *pa);
unsigned long parse_addirect(const char *message,
                            unsigned long len,
                            int *cut_con, struct parse_con *pc);
orderbook* init_ad(const char* config, struct init_args *fix_args,
                    ex_config* ex, int (*get_is_ad_connected)());
void ad_rom_helper_func(void* r, struct message * mess, void* b);
void create_ad_obj_func(queue_t glob, queue_t q, int num);
void create_databuffs(queue_t glob, queue_t q, int num);
void clear_db(void* db);
void destroy_ad_obj(void* d);
#if defined(__cplusplus)
}
#endif
#endif                          //_CLIENT_MANAGER_H__
