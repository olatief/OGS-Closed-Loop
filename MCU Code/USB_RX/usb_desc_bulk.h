/* Copyright (c) 2009 Nordic Semiconductor. All Rights Reserved.
 *
 * The information contained herein is confidential property of Nordic 
 * Semiconductor ASA.Terms and conditions of usage are described in detail 
 * in NORDIC SEMICONDUCTOR STANDARD SOFTWARE LICENSE AGREEMENT. 
 *
 * Licensees are granted free, non-transferable use of the information. NO
 * WARRENTY of ANY KIND is provided. This heading must NOT be removed from
 * the file.
 *              
 * $LastChangedRevision: 5718 $
 */

/** @file
 * Header file for the Bootloader USB descriptor
 *
 */
#ifndef USB_DESC_BULK_H__
#define USB_DESC_BULK_H__

#include "hal_usb_desc.h"

#define USB_DESC_TEMPLATE 

//------------------------------------------ 
// Vendor ID and Product ID definitions 
//------------------------------------------ 
#define VID   0x1915 
#define PID   0x0909 

#define USB_STRING_DESC_COUNT 2

typedef struct
{
    hal_usb_conf_desc_t conf;
    hal_usb_if_desc_t if0;
    hal_usb_ep_desc_t ep1in;
    hal_usb_ep_desc_t ep1out;
} usb_conf_desc_templ_t;

typedef struct { 
     volatile uint8_t* idx[USB_STRING_DESC_COUNT]; 
} usb_string_desc_templ_t; 

extern code usb_string_desc_templ_t g_usb_string_desc; 
extern code usb_conf_desc_templ_t g_usb_conf_desc;
extern code hal_usb_dev_desc_t g_usb_dev_desc;

typedef struct { 
     hal_usb_dev_desc_t* dev; 
     usb_conf_desc_templ_t* conf; 
     usb_string_desc_templ_t* string; 
     uint8_t string_zero[4]; 
} usb_descs_templ_t;

extern code uint8_t g_usb_string_desc_1[];
extern code uint8_t g_usb_string_desc_2[];
extern code uint8_t string_zero[4];

#endif  // USB_DESC_TEMPL_H__
