
#line 1 "usb_desc_bulk.c" /0











 
 



 
  
#line 1 "config.h" /0











 
 



 
 
 
 
 
 
 
 
 
 
 
#line 18 "usb_desc_bulk.c" /0
 
 




 
 
 
 
 
  
#line 1 "usb_desc_bulk.h" /0











 
 



 
 
 
 
  
#line 1 "..\hal\nrf24lu1p\hal_usb_desc.h" /0











 
 


 
 
 
 
 
  
#line 1 "..\compiler\c51\stdint.h" /0











 
 








 
 
 
 
 
 
 
 typedef unsigned char uint8_t;         
 
 typedef signed char int8_t;           
 
 typedef unsigned int uint16_t;         
 
 typedef signed int int16_t;           
 
 typedef unsigned long uint32_t;        
 
 typedef signed long int32_t;          
 
 
 
 
 
 
 
 
#line 21 "..\hal\nrf24lu1p\hal_usb_desc.h" /0
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 typedef struct {
 volatile uint8_t bLength;
 volatile uint8_t bDescriptorType;
 volatile uint16_t bcdUSB;
 volatile uint8_t bDeviceClass;
 volatile uint8_t bDeviceSubClass;
 volatile uint8_t bDeviceProtocol;
 volatile uint8_t bMaxPacketSize0;
 volatile uint16_t idVendor;
 volatile uint16_t idProduct;
 volatile uint16_t bcdDevice;
 volatile uint8_t iManufacturer;
 volatile uint8_t iProduct;
 volatile uint8_t iSerialNumber;
 volatile uint8_t bNumConfigurations;
 } hal_usb_dev_desc_t;
 
 typedef struct {
 volatile uint8_t bLength;
 volatile uint8_t bDescriptorType;
 volatile uint16_t wTotalLength;
 volatile uint8_t bNumInterfaces;
 volatile uint8_t bConfigurationValue;
 volatile uint8_t iConfiguration;
 volatile uint8_t bmAttributes;
 volatile uint8_t bMaxPower;
 } hal_usb_conf_desc_t;
 
 typedef struct {
 volatile uint8_t bLength;
 volatile uint8_t bDescriptorType;
 volatile uint8_t bInterfaceNumber;
 volatile uint8_t bAlternateSetting;
 volatile uint8_t bNumEndpoints;
 volatile uint8_t bInterfaceClass;
 volatile uint8_t bInterfaceSubClass;
 volatile uint8_t bInterfaceProtocol;
 volatile uint8_t iInterface;
 } hal_usb_if_desc_t;
 
 typedef struct {
 volatile uint8_t bLength;
 volatile uint8_t bDescriptorType;
 volatile uint8_t bEndpointAddress;
 volatile uint8_t bmAttributes;
 volatile uint16_t wMaxPacketSize;
 volatile uint8_t bInterval;
 } hal_usb_ep_desc_t;
 
 typedef struct {
 volatile uint8_t bLength;
 volatile uint8_t bDescriptorType;
 volatile uint16_t bcdHID;
 volatile uint8_t bCountryCode;
 volatile uint8_t bNumDescriptors;
 volatile uint8_t bDescriptorType2;
 volatile uint16_t wDescriptorLength;
 } hal_usb_hid_desc_t;
 
 typedef struct {
 volatile uint8_t* desc;
 } hal_usb_string_desc_t;
 
 typedef struct {
 volatile uint8_t bLength;
 volatile uint8_t bDescriptorType;
 } hal_usb_common_desc_t;
 
 
 
#line 21 "usb_desc_bulk.h" /0
 
 
 
 
 
 
 
 
 
 
 
 
 typedef struct
 {
 hal_usb_conf_desc_t conf;
 hal_usb_if_desc_t if0;
 hal_usb_ep_desc_t ep1in;
 hal_usb_ep_desc_t ep1out;
 } usb_conf_desc_templ_t;
 
 typedef struct { 
 volatile uint8_t* idx[2]; 
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
 
 
#line 29 "usb_desc_bulk.c" /0
 
 
 code hal_usb_dev_desc_t g_usb_dev_desc = {
 sizeof(hal_usb_dev_desc_t), 
  0x01, 
  ((((0x0200)&0xFF)<<8)|(((0x0200)>>8)&0xFF)),        
 0xff,                
 0xff,                
 0xff,                
  32, 
  ((((6421)&0xFF)<<8)|(((6421)>>8)&0xFF)),          
  ((((0x0909)&0xFF)<<8)|(((0x0909)>>8)&0xFF)),        
  ((((0x0001)&0xFF)<<8)|(((0x0001)>>8)&0xFF)),        
 0x01,                
 0x02,                
 0x00,                
 0x01                 
 };
 
 code usb_conf_desc_templ_t g_usb_conf_desc = 
 {
 {
 sizeof(hal_usb_conf_desc_t),
  0x02,
  ((((sizeof(usb_conf_desc_templ_t))&0xFF)<<8)|(((sizeof(usb_conf_desc_templ_t))>>8)&0xFF)),
 1,             
 1,             
 2,             
 0xE0,          
 50,            
 },
 
 {
 sizeof(hal_usb_if_desc_t),
  0x04,
 0,             
 0,             
 2,             
 0xff,          
 0x00,          
 0xff,          
 0x00,          
 },
 
 {
 sizeof(hal_usb_ep_desc_t),
  0x05,
 0x82,                    
  0x02,  
  ((((64)&0xFF)<<8)|(((64)>>8)&0xFF)),      
 0x06                     
 },
 
 {
 sizeof(hal_usb_ep_desc_t),
  0x05,
 0x02,                    
  0x02,  
  ((((64)&0xFF)<<8)|(((64)>>8)&0xFF)),      
 0x06                     
 },
 };
 
 
 
 code uint8_t g_usb_string_desc_1[] = 
 {
 sizeof("Nordic Semiconductor") * 2, 0x03,
 'N', 00,
 'o', 00,
 'r', 00,
 'd', 00,
 'i', 00,
 'c', 00,
 ' ', 00,
 'S', 00,
 'e', 00,
 'm', 00,
 'i', 00,
 'c', 00,
 'o', 00,
 'n', 00,
 'd', 00,
 'u', 00,
 'c', 00,
 't', 00,
 'o', 00,
 'r', 00 
 };
 
 
 
 code uint8_t g_usb_string_desc_2[] = 
 {
 sizeof("CID Wifi Headstage RX ") * 2, 0x03,
 'C', 00,
 'I', 00,
 'D', 00,
 ' ', 00,
 'W', 00,
 'i', 00,
 'f', 00,
 'i', 00,
 ' ', 00,
 'H', 00,
 'e', 00,
 'a', 00,
 'd', 00,
 's', 00,
 't', 00,
 'a', 00,
 'g', 00,
 'e', 00,
 ' ', 00,
 'R', 00,
 'X', 00,
 ' ', 00
 };
 
 code usb_string_desc_templ_t g_usb_string_desc = {   
 g_usb_string_desc_1,   
 g_usb_string_desc_2,   
 };
 
 
 code uint8_t string_zero[] = {0x04, 0x03, 0x09, 0x04} ;
