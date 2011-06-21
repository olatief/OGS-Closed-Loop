
#line 1 "main.c" /0
  
#line 1 "C:\Keil\C51\INC\Nordic\reg24lu1.h" /0







 
 
 
 
 
 
 
 
 sfr   P0           = 0x80;
 sfr   SP           = 0x81;
 sfr   DPL          = 0x82;
 sfr   DPH          = 0x83;
 sfr   DPL1         = 0x84;
 sfr   DPH1         = 0x85;
 sfr   PCON         = 0x87;
 sfr   TCON         = 0x88;
 sfr   TMOD         = 0x89;
 sfr   TL0          = 0x8A;
 sfr   TL1          = 0x8B;
 sfr   TH0          = 0x8C;
 sfr   TH1          = 0x8D;
 sfr   CKCON        = 0x8E;
 sfr   RFCON        = 0x90;
 sfr   DPS          = 0x92;
 sfr   P0DIR        = 0x94;
 sfr   P0ALT        = 0x95;
 sfr   S0CON        = 0x98;
 sfr   S0BUF        = 0x99;
 sfr   IEN2         = 0x9A;
 sfr   USBCON       = 0xA0;
 sfr   CLKCTL       = 0xA3;
 sfr   PWRDWN       = 0xA4;
 sfr   WUCONF       = 0xA5;
 sfr   INTEXP       = 0xA6;
 sfr   IEN0         = 0xA8;
 sfr   IP0          = 0xA9;
 sfr   S0RELL       = 0xAA;
 sfr   REGXH        = 0xAB;
 sfr   REGXL        = 0xAC;
 sfr   REGXC        = 0xAD;
 sfr   RSTRES       = 0xB1;
 sfr   SMDAT        = 0xB2;
 sfr   SMCTL        = 0xB3;
 sfr   TICKDV       = 0xB5;
 sfr   IEN1         = 0xB8;
 sfr   IP1          = 0xB9;
 sfr   S0RELH       = 0xBA;
 sfr   SSCONF       = 0xBC;
 sfr   SSDATA       = 0xBD;
 sfr   SSSTAT       = 0xBE;
 sfr   IRCON        = 0xC0;
 sfr   CCEN         = 0xC1;
 sfr   CCL1         = 0xC2;
 sfr   CCH1         = 0xC3;
 sfr   CCL2         = 0xC4;
 sfr   CCH2         = 0xC5;
 sfr   CCL3         = 0xC6;
 sfr   CCH3         = 0xC7;
 sfr   T2CON        = 0xC8;
 sfr   P0EXP        = 0xC9;
 sfr   CRCL         = 0xCA;
 sfr   CRCH         = 0xCB;
 sfr   TL2          = 0xCC;
 sfr   TH2          = 0xCD;
 sfr   PSW          = 0xD0;
 sfr   WDCON        = 0xD8;
 sfr   USBSLP       = 0xD9;
 sfr   ACC          = 0xE0;
 sfr   RFDAT        = 0xE5;
 sfr   RFCTL        = 0xE6;
 sfr   AESCS        = 0xE8;
 sfr   MD0          = 0xE9;
 sfr   MD1          = 0xEA;
 sfr   MD2          = 0xEB;
 sfr   MD3          = 0xEC;
 sfr   MD4          = 0xED;
 sfr   MD5          = 0xEE;
 sfr   ARCON        = 0xEF;
 sfr   B            = 0xF0;
 sfr   AESKIN       = 0xF1;
 sfr   AESIV        = 0xF2;
 sfr   AESD         = 0xF3;
 sfr   AESIA1       = 0xF5;
 sfr   AESIA2       = 0xF6;
 sfr   FSR          = 0xF8;
 sfr   FPCR         = 0xF9;
 sfr   FCR          = 0xFA;
 
 
 
 
 
 sfr16 CC1          = 0xC2;
 sfr16 CC2          = 0xC4;
 sfr16 CC3          = 0xC6;
 sfr16 CRC          = 0xCA;
 sfr16 T2           = 0xCC;
 
 




 
 
 
 
 
 
 
 
 
 
 sbit  MCDIS        = FSR^7;
 sbit  STP          = FSR^6;
 sbit  WEN          = FSR^5;
 sbit  RDYN         = FSR^4;
 sbit  INFEN        = FSR^3;
 sbit  RDIS         = FSR^2;
 sbit  RDEND        = FSR^1;
 sbit  WPEN         = FSR^0;
 
 
 sbit  CY           = PSW^7;
 sbit  AC           = PSW^6;
 sbit  F0           = PSW^5;
 sbit  RS1          = PSW^4;
 sbit  RS0          = PSW^3;
 sbit  OV           = PSW^2;
 sbit  F1           = PSW^1;
 sbit  P            = PSW^0;
 
 
 sbit  TF1          = TCON^7;
 sbit  TR1          = TCON^6;
 sbit  TF0          = TCON^5;
 sbit  TR0          = TCON^4;
 sbit  IE1          = TCON^3;
 sbit  IT1          = TCON^2;
 sbit  IE0          = TCON^1;
 sbit  IT0          = TCON^0;
 
 
 sbit  SM0          = S0CON^7;
 sbit  SM1          = S0CON^6;
 sbit  SM20         = S0CON^5;
 sbit  REN0         = S0CON^4;
 sbit  TB80         = S0CON^3;
 sbit  RB80         = S0CON^2;
 sbit  TI0          = S0CON^1;
 sbit  RI0          = S0CON^0;
 
 
 sbit  T2PS         = T2CON^7;
 sbit  I3FR         = T2CON^6;
 sbit  I2FR         = T2CON^5;
 sbit  T2R1         = T2CON^4;
 sbit  T2R0         = T2CON^3;
 sbit  T2CM         = T2CON^2;
 sbit  T2I1         = T2CON^1;
 sbit  T2I0         = T2CON^0;
 
 
 sbit  EA           = IEN0^7;
 
 sbit  ET2          = IEN0^5;
 sbit  ES0          = IEN0^4;
 sbit  ET1          = IEN0^3;
 sbit  EX1          = IEN0^2;
 sbit  ET0          = IEN0^1;
 sbit  EX0          = IEN0^0;
 
 
 sbit  EXEN2        = IEN1^7;
 
 sbit  WUIRQ        = IEN1^5;
 sbit  USB          = IEN1^4;
 sbit  USBWU        = IEN1^3;
 sbit  SPI          = IEN1^2;
 sbit  RF           = IEN1^1;
 sbit  RFSPI        = IEN1^0;
 
 
 sbit  EXF2         = IRCON^7;
 sbit  TF2          = IRCON^6;
 sbit  WUF          = IRCON^5;
 sbit  USBF         = IRCON^4;
 sbit  USBWUF       = IRCON^3;
 sbit  SPIF         = IRCON^2;
 sbit  RFF          = IRCON^1;
 sbit  RFSPIF       = IRCON^0;
 
 
 sbit  SWRST        = USBCON^7;
 sbit  WU           = USBCON^6;
 sbit  SUSPEND      = USBCON^5;
 sbit  IV4          = USBCON^4;
 sbit  IV3          = USBCON^3;
 sbit  IV2          = USBCON^2;
 sbit  IV1          = USBCON^1;
 sbit  IV0          = USBCON^0;
 
 
 sbit  P00          = P0^0;
 sbit  P01          = P0^1;
 sbit  P02          = P0^2;
 sbit  P03          = P0^3;
 sbit  MCSN         = P0^3;
 sbit  SCSN         = P0^3;
 sbit  P04          = P0^4;
 sbit  P05          = P0^5;
 
 
 sbit  RFCE         = RFCON^0;
 sbit  RFCSN        = RFCON^1;
 sbit  RFCKEN       = RFCON^2;
 
 
 sbit  BD           = WDCON^7;
 
 
 sbit  GO           = AESCS^0;
 sbit  DECR         = AESCS^1;
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
#line 1 "main.c" /0
 
  
#line 1 "C:\Keil\C51\INC\intrins.h" /0






 
 
 
 
 
 extern void          _nop_     (void);
 extern bit           _testbit_ (bit);
 extern unsigned char _cror_    (unsigned char, unsigned char);
 extern unsigned int  _iror_    (unsigned int,  unsigned char);
 extern unsigned long _lror_    (unsigned long, unsigned char);
 extern unsigned char _crol_    (unsigned char, unsigned char);
 extern unsigned int  _irol_    (unsigned int,  unsigned char);
 extern unsigned long _lrol_    (unsigned long, unsigned char);
 extern unsigned char _chkfloat_(float);
 
 extern void          _push_    (unsigned char _sfr);
 extern void          _pop_     (unsigned char _sfr);
 
 
 
 
#line 2 "main.c" /0
 
  
#line 1 "..\compiler\c51\stdint.h" /0











 
 








 
 
 
 
 
 
 
 typedef unsigned char uint8_t;         
 
 typedef signed char int8_t;           
 
 typedef unsigned int uint16_t;         
 
 typedef signed int int16_t;           
 
 typedef unsigned long uint32_t;        
 
 typedef signed long int32_t;          
 
 
 
 
 
 
 
 
#line 3 "main.c" /0
 
  
#line 1 "C:\Keil\C51\INC\stdio.h" /0






 
 
 
 
 
 
 
 
 
 
#line 17 "C:\Keil\C51\INC\stdio.h" /1
  
 
#line 19 "C:\Keil\C51\INC\stdio.h" /0
 
 
 
 typedef unsigned int size_t;
 
 
 #pragma SAVE
 #pragma REGPARMS
 extern char _getkey (void);
 extern char getchar (void);
 extern char ungetchar (char);
 extern char putchar (char);
 extern int printf   (const char *, ...);
 extern int sprintf  (char *, const char *, ...);
 extern int vprintf  (const char *, char *);
 extern int vsprintf (char *, const char *, char *);
 extern char *gets (char *, int n);
 extern int scanf (const char *, ...);
 extern int sscanf (char *, const char *, ...);
 extern int puts (const char *);
 
 #pragma RESTORE
 
 
 
#line 4 "main.c" /0
 
 
  
#line 1 "..\hal\nrf24lu1p\usb.h" /0











 
 


 
 
 
 
 
  
#line 1 "..\compiler\c51\stdint.h" /0











 
 








 
 
 
#line 25 "..\compiler\c51\stdint.h" /1
  
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
  
 
 
 
#line 21 "..\hal\nrf24lu1p\usb.h" /0
#line 21 "..\hal\nrf24lu1p\usb.h" /0
 
 
  
#line 1 "\Users\Omar\Dropbox\OGS-Closed-Loop\MCU Code\hal\nrf24lu1p\hal_usb.h" /0











 
 





























































 
 
 
 
 
  
#line 1 "..\compiler\c51\stdint.h" /0











 
 








 
 
 
#line 25 "..\compiler\c51\stdint.h" /1
  
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
  
 
 
 
#line 80 "\Users\Omar\Dropbox\OGS-Closed-Loop\MCU Code\hal\nrf24lu1p\hal_usb.h" /0
#line 80 "\Users\Omar\Dropbox\OGS-Closed-Loop\MCU Code\hal\nrf24lu1p\hal_usb.h" /0
 
  
#line 1 "..\compiler\c51\stdbool.h" /0











 
 








 
 
 
 
 
 
 typedef unsigned char _Bool;  
 
 
 
 
 
 
 
#line 81 "\Users\Omar\Dropbox\OGS-Closed-Loop\MCU Code\hal\nrf24lu1p\hal_usb.h" /0
 
 
  
#line 1 "\Users\Omar\Dropbox\OGS-Closed-Loop\MCU Code\hal\nrf24lu1p\hal_usb_desc.h" /0











 
 


 
 
 
 
 
  
#line 1 "..\compiler\c51\stdint.h" /0











 
 








 
 
 
#line 25 "..\compiler\c51\stdint.h" /1
  
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
  
 
 
 
#line 21 "\Users\Omar\Dropbox\OGS-Closed-Loop\MCU Code\hal\nrf24lu1p\hal_usb_desc.h" /0
#line 21 "\Users\Omar\Dropbox\OGS-Closed-Loop\MCU Code\hal\nrf24lu1p\hal_usb_desc.h" /0
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
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
 
 
 
#line 83 "\Users\Omar\Dropbox\OGS-Closed-Loop\MCU Code\hal\nrf24lu1p\hal_usb.h" /0
 
  
#line 1 "config.h" /0











 
 



 
 
 
 
 
 
 
 
 
 
 
#line 84 "\Users\Omar\Dropbox\OGS-Closed-Loop\MCU Code\hal\nrf24lu1p\hal_usb.h" /0
 
  
#line 1 "usb_desc_bulk.h" /0











 
 



 
 
 
 
  
#line 1 "..\hal\nrf24lu1p\hal_usb_desc.h" /0











 
 


 
 
 
#line 19 "..\hal\nrf24lu1p\hal_usb_desc.h" /1
  
 
  
 
 
  
  
  
  
  
  
  
  
  
  
  
  
  
 
 
  
  
  
  
  
  
  
  
  
  
  
 
  
  
  
  
 
 
  
  
  
  
  
  
  
  
  
  
  
  
 
 
  
  
  
 
  
  
  
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
#line 21 "usb_desc_bulk.h" /0
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
 
 
#line 85 "\Users\Omar\Dropbox\OGS-Closed-Loop\MCU Code\hal\nrf24lu1p\hal_usb.h" /0
 
 
 
#line 88 "\Users\Omar\Dropbox\OGS-Closed-Loop\MCU Code\hal\nrf24lu1p\hal_usb.h" /1
 
 
#line 90 "\Users\Omar\Dropbox\OGS-Closed-Loop\MCU Code\hal\nrf24lu1p\hal_usb.h" /0
 
 
 
 
 



 
 
 typedef enum  { 
 ATTACHED,    
 POWERED,     
 DEFAULT,     
 ADDRESSED,   
 CONFIGURED,  
 SUSPENDED    
 } hal_usb_state_t;
 


 
 
 typedef struct {
 uint8_t  bmRequestType;  

















 uint8_t  bRequest;        
 
 uint8_t wValueMsb;       
 uint8_t wValueLsb;       
 uint8_t wIndex;          
 uint8_t wLength;         
 
 } hal_usb_device_req;
 

 
 
 typedef enum {
 STALL,          
 NAK,            
 ACK,            
 NO_RESPONSE,    
 DATA,           
 EMPTY_RESPONSE  
 } hal_usb_dev_req_resp_t;
 
 uint8_t ep_1_out_cb(uint8_t xdata *, uint8_t xdata *) reentrant;
 





 
 
 typedef hal_usb_dev_req_resp_t (*hal_usb_cb_device_req_t)(hal_usb_device_req* device_req, uint8_t ** data_ptr, uint8_t* size) reentrant;
 






 
 typedef uint8_t (*hal_usb_cb_endpoint_t)(uint8_t* adr_ptr, uint8_t* size) reentrant;
 


 
 
 typedef void (*hal_usb_cb_resume_t)();
 



 
 
 typedef void (*hal_usb_cb_suspend_t)(uint8_t allow_remote_wu) reentrant;
 


 
 typedef void (*hal_usb_cb_reset_t)();
 


 
 
 typedef struct {
 usb_descs_templ_t descs;      
 uint8_t  bm_state;              
 uint8_t current_config;         
 uint8_t current_alt_interface;  
 hal_usb_state_t state;        
 
 hal_usb_cb_device_req_t device_req;
 hal_usb_cb_reset_t      reset;
 hal_usb_cb_resume_t     resume;
 hal_usb_cb_suspend_t    suspend;
 } hal_usb_t;
 







 
 void hal_usb_init(
  _Bool usb_disconnect,
 hal_usb_cb_device_req_t device_req,
 hal_usb_cb_reset_t      reset,
 hal_usb_cb_resume_t     resume,
 hal_usb_cb_suspend_t    suspend);
 




 
 void hal_usb_send_data(uint8_t ep_in_num, uint8_t* buffer, uint8_t bytes_to_send);
 





 
 void hal_usb_endpoint_config(uint8_t ep_num, uint8_t ep_size, hal_usb_cb_endpoint_t endpoint_isr);
 



 
 void hal_usb_endpoint_stall(uint8_t ep_num, _Bool stall);
 


 
 hal_usb_state_t hal_usb_get_state();
 
 
 uint8_t hal_usb_get_address();
 
 
 void hal_usb_wakeup();
 
 
 void hal_usb_reset();
 
 
 void hal_usb_bus_disconnect();
 
 
 void hal_usb_bus_connect();
 
 
 void hal_usb_sleep();
 
 extern hal_usb_t g_hal_usb;
 
 
 
#line 23 "..\hal\nrf24lu1p\usb.h" /0
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 typedef struct
 {
 uint8_t *data_ptr;
 uint8_t data_size;
 uint8_t pkt_size;
 } packetizer_t;
 
 
#line 6 "main.c" /0
 
  
#line 1 "..\hal\nrf24lu1p\hal_usb.h" /0











 
 





























































 
 
 
#line 78 "..\hal\nrf24lu1p\hal_usb.h" /1
  
 
  
  
 
  
  
  
 
 
 
 
 
  
  
  
 



 
 
 
 
 
 
 
 
 
 
 


 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 

 
 
 
 
 
 
 
 
 
 
 
 
 





 
 
 
 






 
 
 


 
 
 
 



 
 
 
 


 
 
 


 
 
 
 
 
 
 
 
 
 
 
 
 
 
 







 
 
 
 
 
 
 
 




 
 
 





 
 
 



 
 
 


 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
#line 270 "..\hal\nrf24lu1p\hal_usb.h" /0
 
#line 7 "main.c" /0
 
  
#line 1 "..\hal\nrf24lu1p\hal_usb_desc.h" /0











 
 


 
 
 
#line 19 "..\hal\nrf24lu1p\hal_usb_desc.h" /1
  
 
  
 
 
  
  
  
  
  
  
  
  
  
  
  
  
  
 
 
  
  
  
  
  
  
  
  
  
  
  
 
  
  
  
  
 
 
  
  
  
  
  
  
  
  
  
  
  
  
 
 
  
  
  
 
  
  
  
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
#line 8 "main.c" /0
#line 8 "main.c" /0
 
  
#line 1 "usb_cmds.h" /0











 
 



 
 
 
 
 typedef enum
 {
 CMD_FIRMWARE_VERSION = 1,
 CMD_FLASH_WRITE_INIT,          
 CMD_FLASH_READ,
 CMD_FLASH_ERASE_PAGE,
 CMD_FLASH_SET_PROTECTED,
 CMD_FLASH_SELECT_HALF
 } usb_command_t;
 
 
#line 9 "main.c" /0
 
  
#line 1 "config.h" /0











 
 



 
 
#line 19 "config.h" /1
  
 
  
  
  
  
  
 
 
#line 10 "main.c" /0
#line 10 "main.c" /0
 
 
  
#line 1 "..\hal\nrf24lu1p\cklf.h" /0











 
 






 
 
 
 
  
#line 1 "..\compiler\c51\stdint.h" /0











 
 








 
 
 
#line 25 "..\compiler\c51\stdint.h" /1
  
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
  
 
 
 
#line 24 "..\hal\nrf24lu1p\cklf.h" /0
#line 24 "..\hal\nrf24lu1p\cklf.h" /0
 
 



 
 void cklf_regxc_write(uint8_t addr, uint16_t val);
 



 
 uint16_t cklf_regxc_read(uint8_t addr);
 


 
 void cklf_rtc_disable(void);
 



 
 void cklf_rtc_init(uint8_t cnt_h, uint16_t cnt_l);
 




 
 uint16_t cklf_rtc_read_lsw(void);
 




 
 uint8_t cklf_rtc_read_msb(void);
 




 
 void cklf_rtc_wait(void);
 


 
 void cklf_wdog_init(uint16_t cnt);
 



 
 void cklf_wdog_feed(void);
 



 
 void cklf_gpio_wakeup(uint16_t wcon1, uint16_t wcon0);
 
 
 
#line 12 "main.c" /0
 
  
#line 1 "..\hal\nrf24lu1p\cpu.h" /0











 
 





 
 
 
 
  
#line 1 "..\compiler\c51\stdint.h" /0











 
 








 
 
 
#line 25 "..\compiler\c51\stdint.h" /1
  
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
  
 
 
 
#line 23 "..\hal\nrf24lu1p\cpu.h" /0
#line 23 "..\hal\nrf24lu1p\cpu.h" /0
 
 


 
 void cpu_pwr_down(void);
 




 
 void cpu_set_clock_frequency(uint8_t cf);
 
 
 
#line 13 "main.c" /0
 
 
  
#line 1 "..\hal\nordic_common.h" /0











 
 



 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
#line 15 "main.c" /0
 
 
  
#line 1 "..\hal\nrf24l01p\hal_nrf.h" /0











 
 


 
 





















 
 
 
 
 
  
#line 1 "..\compiler\c51\stdint.h" /0











 
 








 
 
 
#line 25 "..\compiler\c51\stdint.h" /1
  
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
  
 
 
 
#line 44 "..\hal\nrf24l01p\hal_nrf.h" /0
#line 44 "..\hal\nrf24l01p\hal_nrf.h" /0
 
  
#line 1 "..\compiler\c51\stdbool.h" /0











 
 








 
 
 
#line 25 "..\compiler\c51\stdbool.h" /1
  
 
 
 
 
  
  
  
  
 
 
#line 45 "..\hal\nrf24l01p\hal_nrf.h" /0
#line 45 "..\hal\nrf24l01p\hal_nrf.h" /0
 
 
  
#line 1 "\Users\Omar\Dropbox\OGS-Closed-Loop\MCU Code\hal\nrf24l01p\hal_nrf_reg.h" /0











 
 







 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 


 
 typedef enum {
 HAL_NRF_MAX_RT = 4,      
 HAL_NRF_TX_DS,           
 HAL_NRF_RX_DR            
 } hal_nrf_irq_source_t;
 
 


 
 typedef enum {
 HAL_NRF_PTX,             
 HAL_NRF_PRX              
 } hal_nrf_operation_mode_t;
 


 
 typedef enum {
 HAL_NRF_PWR_DOWN,        
 HAL_NRF_PWR_UP           
 } hal_nrf_pwr_mode_t;
 


 
 typedef enum {
 HAL_NRF_18DBM,           
 HAL_NRF_12DBM,           
 HAL_NRF_6DBM,            
 HAL_NRF_0DBM             
 } hal_nrf_output_power_t;
 


 
 typedef enum {
 HAL_NRF_1MBPS,           
 HAL_NRF_2MBPS,           
 HAL_NRF_250KBPS          
 } hal_nrf_datarate_t;
 


 
 typedef enum {
 HAL_NRF_CRC_OFF,     
 HAL_NRF_CRC_8BIT,    
 HAL_NRF_CRC_16BIT    
 } hal_nrf_crc_mode_t;
 


 
 typedef enum {
 HAL_NRF_TX_PLOAD = 7,    
 HAL_NRF_RX_PLOAD,         
 HAL_NRF_ACK_PLOAD
 } hal_nrf_pload_command_t;
 




 
 
 
 
 
 
 
 
 
 
 
 
 
 
 


 
 typedef enum {
 HAL_NRF_PIPE0 = 0,           
 HAL_NRF_PIPE1,               
 HAL_NRF_PIPE2,               
 HAL_NRF_PIPE3,               
 HAL_NRF_PIPE4,               
 HAL_NRF_PIPE5,               
 HAL_NRF_TX,                  
 HAL_NRF_ALL = 0xFF           

 
 } hal_nrf_address_t;
 


 
 typedef enum {
 HAL_NRF_AW_3BYTES = 3,       
 HAL_NRF_AW_4BYTES,           
 HAL_NRF_AW_5BYTES            
 } hal_nrf_address_width_t;
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
#line 47 "..\hal\nrf24l01p\hal_nrf.h" /0
 
  
#line 1 "..\hal\nrf24lu1p\hal_nrf_hw.h" /0











 
 







 
 
 
 
  
#line 1 "..\compiler\common\nrf24lu1p.h" /0
 
 
 
 
#line 5 "..\compiler\common\nrf24lu1p.h" /1
  
  
 
#line 8 "..\compiler\common\nrf24lu1p.h" /0
 
 
  
#line 1 "C:\Keil\C51\INC\Nordic\reg24lu1.h" /0







 
 
#line 10 "C:\Keil\C51\INC\Nordic\reg24lu1.h" /1
  
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 




 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
  
  
  
  
  
  
  
  
  
  
  
  
 
 
 
 
 
  
  
  
  
  
  
  
  
  
  
  
  
 
 
 
 
 
 
#line 10 "..\compiler\common\nrf24lu1p.h" /0
#line 10 "..\compiler\common\nrf24lu1p.h" /0
 
 
 
  
#line 1 "\Users\Omar\Dropbox\OGS-Closed-Loop\MCU Code\compiler\common\isrdef24lu1p.h" /0
 
#line 2 "\Users\Omar\Dropbox\OGS-Closed-Loop\MCU Code\compiler\common\isrdef24lu1p.h" /1
 
  


 
  


 
  


 
  


 
  


 
  


 
  


 
  


 
  


 
  


 
  


 
  


 
 
#line 52 "\Users\Omar\Dropbox\OGS-Closed-Loop\MCU Code\compiler\common\isrdef24lu1p.h" /0
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
#line 13 "..\compiler\common\nrf24lu1p.h" /0
 
  
#line 1 "\Users\Omar\Dropbox\OGS-Closed-Loop\MCU Code\compiler\common\memdefs.h" /0
 
 
 
 
 
 
 
 
#line 9 "\Users\Omar\Dropbox\OGS-Closed-Loop\MCU Code\compiler\common\memdefs.h" /1
 
  
  
  
  
  
  
  
  
 
 
 
  
 
 
 
 
  
 
 
  
 
 
 
#line 33 "\Users\Omar\Dropbox\OGS-Closed-Loop\MCU Code\compiler\common\memdefs.h" /0
 
 
#line 14 "..\compiler\common\nrf24lu1p.h" /0
 
 
 
#line 25 "..\hal\nrf24lu1p\hal_nrf_hw.h" /0
 
 


 
 
 


 
 
 


 
 
 


 
 
 


 
 
 


 
 
 


 
 
 


 
 






 
 
 
 
#line 48 "..\hal\nrf24l01p\hal_nrf.h" /0
 
 
 
 
 
 









 
 void hal_nrf_set_irq_mode(hal_nrf_irq_source_t int_source, _Bool irq_state);
 



 
 void hal_nrf_activate_features(void);
 


 
 void hal_nrf_enable_dynamic_payload(_Bool enable);
 


 
 void hal_nrf_enable_ack_payload(_Bool enable);
 


 
 void hal_nrf_enable_dynamic_ack(_Bool enable);
 





 
 void hal_nrf_setup_dynamic_payload(uint8_t setup);
 


 
 uint8_t hal_nrf_read_rx_payload_width(void);
 





 
 void hal_nrf_write_ack_payload(uint8_t pipe, const uint8_t *tx_pload, uint8_t length);
 








 
 uint8_t hal_nrf_get_clear_irq_flags(void);
 
 uint8_t hal_nrf_clear_irq_flags_get_status(void);
 





 
 void hal_nrf_clear_irq_flag(hal_nrf_irq_source_t int_source);
 




 
 void hal_nrf_set_crc_mode(hal_nrf_crc_mode_t crc_mode);
 







 
 void hal_nrf_open_pipe(hal_nrf_address_t pipe_num, _Bool auto_ack);
 




 
 void hal_nrf_close_pipe(hal_nrf_address_t pipe_num);
 






 
 void hal_nrf_set_address(const hal_nrf_address_t address, const uint8_t *addr);
 










 
 uint8_t hal_nrf_get_address (uint8_t address, uint8_t *addr);
 






 
 void hal_nrf_set_auto_retr(uint8_t retr, uint16_t delay);
 





 
 void hal_nrf_set_address_width(hal_nrf_address_width_t address_width);
 



 
 uint8_t hal_nrf_get_address_width (void);
 






 
 void hal_nrf_set_rx_payload_width(uint8_t pipe_num, uint8_t pload_width);
 









 
  _Bool hal_nrf_get_irq_mode(uint8_t int_source);
 









 
 uint8_t hal_nrf_get_irq_flags(void);
 









 
 uint8_t hal_nrf_get_pipe_status(uint8_t pipe_num);
 








 
 uint8_t hal_nrf_get_auto_retr_status(void);
 




 
 uint8_t hal_nrf_get_packet_lost_ctr(void);
 







 
 uint8_t hal_nrf_get_rx_payload_width(uint8_t pipe_num);
 
 
 
 
 
 





 
 void hal_nrf_set_operation_mode(hal_nrf_operation_mode_t op_mode);
 




 
 void hal_nrf_set_power_mode(hal_nrf_pwr_mode_t pwr_mode);
 




 
 void hal_nrf_set_rf_channel(uint8_t channel);
 




 
 void hal_nrf_set_output_power(hal_nrf_output_power_t power);
 





 
 void hal_nrf_set_datarate(hal_nrf_datarate_t datarate);
 
 
 
 









 
 uint8_t hal_nrf_get_tx_fifo_status(void);
 








 
  _Bool hal_nrf_tx_fifo_empty(void);
 








 
  _Bool hal_nrf_tx_fifo_full(void);
 









 
 uint8_t hal_nrf_get_rx_fifo_status(void);
 










 
  _Bool hal_nrf_rx_fifo_empty(void);
 








 
  _Bool hal_nrf_rx_fifo_full(void);
 





 
 uint8_t hal_nrf_get_transmit_attempts(void);
 








 
  _Bool hal_nrf_get_carrier_detect(void);
 
 
 





 
 uint8_t hal_nrf_get_rx_data_source(void);
 






 
 uint16_t hal_nrf_read_rx_payload(uint8_t *rx_pload);
 







 
 void hal_nrf_write_tx_payload(const uint8_t *tx_pload, uint8_t length);
 










 
 void hal_nrf_write_tx_payload_noack(const uint8_t *tx_pload, uint8_t length);
 




 
 void hal_nrf_reuse_tx(void);
 







 
  _Bool hal_nrf_get_reuse_tx_status(void);
 




 
 void hal_nrf_flush_rx(void);
 




 
 void hal_nrf_flush_tx(void);
 





 
 uint8_t hal_nrf_nop(void);
 
 
 
 
 
 





 
 void hal_nrf_set_pll_mode(_Bool pll_lock);
 





 
 void hal_nrf_set_lna_gain(_Bool lna_gain);
 




 
 void hal_nrf_enable_continious_wave (_Bool enable);
 
 
 
 
 
 
 
 







 
 uint8_t hal_nrf_rw(uint8_t value);
 
 
 
 
#line 17 "main.c" /0
 
  
#line 1 "..\hal\nrf24lu1p\hal_nrf_hw.h" /0











 
 







 
 
 
#line 24 "..\hal\nrf24lu1p\hal_nrf_hw.h" /1
  
  
 


 
  
 


 
  
 


 
  
 


 
  
 


 
  
 


 
  
 


 
  
 


 
  






 
 
#line 74 "..\hal\nrf24lu1p\hal_nrf_hw.h" /0
 
 
#line 18 "main.c" /0
 
 
  
#line 1 "..\hal\nrf24lu1p\usb_map.h" /0











 
 








 
 
 
 
 
#line 27 "..\hal\nrf24lu1p\usb_map.h" /1
  
  
 
#line 30 "..\hal\nrf24lu1p\usb_map.h" /0
 
 
 
 
 
 
   extern xdata volatile uint8_t out5buf[0x20] ; 
   extern xdata volatile uint8_t in5buf[0x20]  ; 
   extern xdata volatile uint8_t out4buf[0x20] ; 
   extern xdata volatile uint8_t in4buf[0x20]  ; 
   extern xdata volatile uint8_t out3buf[0x20] ; 
   extern xdata volatile uint8_t in3buf[0x20]  ; 
   extern xdata volatile uint8_t out2buf[0x20] ; 
   extern xdata volatile uint8_t in2buf[0x20]  ; 
   extern xdata volatile uint8_t out1buf[0x20] ; 
   extern xdata volatile uint8_t in1buf[0x20]  ; 
   extern xdata volatile uint8_t out0buf[0x20] ; 
   extern xdata volatile uint8_t in0buf[0x20]  ; 
   extern xdata volatile uint8_t out8data                         ; 
   extern xdata volatile uint8_t in8data                          ; 
   extern xdata volatile uint8_t out8bch                          ; 
   extern xdata volatile uint8_t out8bcl                          ; 
   extern xdata volatile uint8_t bout1addr                        ; 
   extern xdata volatile uint8_t bout2addr                        ; 
   extern xdata volatile uint8_t bout3addr                        ; 
   extern xdata volatile uint8_t bout4addr                        ; 
   extern xdata volatile uint8_t bout5addr                        ; 
   extern xdata volatile uint8_t binstaddr                        ; 
   extern xdata volatile uint8_t bin1addr                         ; 
   extern xdata volatile uint8_t bin2addr                         ; 
   extern xdata volatile uint8_t bin3addr                         ; 
   extern xdata volatile uint8_t bin4addr                         ; 
   extern xdata volatile uint8_t bin5addr                         ; 
   extern xdata volatile uint8_t isoerr                           ; 
   extern xdata volatile uint8_t zbcout                           ; 
   extern xdata volatile uint8_t ivec                             ; 
   extern xdata volatile uint8_t in_irq                           ; 
   extern xdata volatile uint8_t out_irq                          ; 
   extern xdata volatile uint8_t usbirq                           ; 
   extern xdata volatile uint8_t in_ien                           ; 
   extern xdata volatile uint8_t out_ien                          ; 
   extern xdata volatile uint8_t usbien                           ; 
   extern xdata volatile uint8_t usbbav                           ; 
   extern xdata volatile uint8_t ep0cs                            ; 
   extern xdata volatile uint8_t in0bc                            ; 
   extern xdata volatile uint8_t in1cs                            ; 
   extern xdata volatile uint8_t in1bc                            ; 
   extern xdata volatile uint8_t in2cs                            ; 
   extern xdata volatile uint8_t in2bc                            ; 
   extern xdata volatile uint8_t in3cs                            ; 
   extern xdata volatile uint8_t in3bc                            ; 
   extern xdata volatile uint8_t in4cs                            ; 
   extern xdata volatile uint8_t in4bc                            ; 
   extern xdata volatile uint8_t in5cs                            ; 
   extern xdata volatile uint8_t in5bc                            ; 
   extern xdata volatile uint8_t out0bc                           ; 
   extern xdata volatile uint8_t out1cs                           ; 
   extern xdata volatile uint8_t out1bc                           ; 
   extern xdata volatile uint8_t out2cs                           ; 
   extern xdata volatile uint8_t out2bc                           ; 
   extern xdata volatile uint8_t out3cs                           ; 
   extern xdata volatile uint8_t out3bc                           ; 
   extern xdata volatile uint8_t out4cs                           ; 
   extern xdata volatile uint8_t out4bc                           ; 
   extern xdata volatile uint8_t out5cs                           ; 
   extern xdata volatile uint8_t out5bc                           ; 
   extern xdata volatile uint8_t usbcs                            ; 
   extern xdata volatile uint8_t togctl                           ; 
   extern xdata volatile uint8_t usbfrml                          ; 
   extern xdata volatile uint8_t usbfrmh                          ; 
   extern xdata volatile uint8_t fnaddr                           ; 
   extern xdata volatile uint8_t usbpair                          ; 
   extern xdata volatile uint8_t inbulkval                        ; 
   extern xdata volatile uint8_t outbulkval                       ; 
   extern xdata volatile uint8_t inisoval                         ; 
   extern xdata volatile uint8_t outisoval                        ; 
   extern xdata volatile uint8_t isostaddr                        ; 
   extern xdata volatile uint8_t isosize                          ; 
   extern xdata volatile uint8_t setupbuf[8]                      ; 
   extern xdata volatile uint8_t out8addr                         ; 
   extern xdata volatile uint8_t in8addr                          ; 
 
 
#line 20 "main.c" /0
 
 
 
 
 
 
 
 
 
 
 
 
 
 
#error *** WARNING C317 IN LINE 33 OF main.c: attempt to redefine macro 'MSB'
 
#error *** WARNING C317 IN LINE 34 OF main.c: attempt to redefine macro 'LSB'
 
 static hal_usb_dev_req_resp_t device_req_cb(hal_usb_device_req* req, uint8_t** data_ptr, uint16_t* size) reentrant;   
 static void suspend_cb(uint8_t allow_remote_wu) reentrant;   
 static void resume_cb() reentrant;   
 static void reset_cb() reentrant;   
 static code uint8_t ep_1_in_cb(uint8_t *adr_ptr, uint8_t* size) reentrant;   
 
 
 static void usb_process_get_descriptor(hal_usb_device_req* req, uint8_t** data_ptr, uint16_t* size, hal_usb_dev_req_resp_t* resp);
 static void usb_wait_for_configuration(void);
 static void radio_init();
 
 
 
 typedef enum 
 { 
 USB_AWAKE, 
 USB_REM_WU_ENABLE, 
 USB_REM_WU_DISABLE, 
 } usb_state_t; 
 
 typedef enum   
 { 
 APP_INIT = 0,     
 APP_NORMAL,   
 APP_SUSP_WE ,   
 APP_SUSP_WD,     
 } app_states_t;   
 
 app_states_t app_init(void);
 static app_states_t app_normal(void);   
 app_states_t app_susp_we(void);  
 usb_state_t usb_get_state();
 
 void usb_wakeup(void);
 
 static data volatile usb_state_t usb_state;
 static _Bool ep1_sent, ep2_sent, ep2_rx; 
 static uint8_t *e_arr;
 static uint8_t e_size;
 
 data _Bool radio_busy;
 
 data uint8_t block = 0;
 data uint8_t byteCnt = 0;
 data uint8_t blockAcquired = 0;
 data uint8_t blockNeedsSending = 0;
 data uint8_t payload[2][32];
 
 
 uint8_t data ackPayload[11];
 
 sbit P0_0 = P0^0;
 sbit P0_4 = P0^4;
 sbit P0_5 = P0^5;
 sbit P0_6 = P0^6;
 sbit P0_7 = P0^7;
 
 void main(void) 
 {
 data app_states_t app_state = APP_INIT;  
 CLKCTL = 0;                                  
 P0DIR = (1<<3)|(1<<1)|(1<<0);
 
 
 




 
  do { RFCE = 0; } while(((_Bool)0));                                    
 RFCTL = 0x10;                                
 RFCKEN = 1;                                  
 RF = 1;                                      
 
 
 
 usbpair |= 0x01;
 hal_usb_init(((_Bool)1), device_req_cb, reset_cb, resume_cb, suspend_cb);
 hal_usb_endpoint_config(0x82, 32, ep_1_in_cb);
 hal_usb_endpoint_config(0x02, 32, ep_1_out_cb);
 
 ep1_sent = ((_Bool)1);   
 ep2_sent = ((_Bool)1);   
 usb_state = USB_AWAKE;   
 
 
 EA = 1;
 usb_wait_for_configuration();                
 
 byteCnt = 32;
 
 payload[1][32-1] = 0xAA;
 payload[0][32-1] = 0xAA;
 
 for(;;)
 {
 switch(app_state)
 {
 case APP_INIT:
 app_state = app_init();
 break;   
 case APP_NORMAL:                                                         
 app_state = app_normal();   
 break;   
 case APP_SUSP_WE:                                                        
 case APP_SUSP_WD:                                                        
 
 app_state = app_susp_we();
 
 break;   
 default:   
 break;
 }
 }
 
 return;
 }
 
 static app_states_t app_normal(void)   
 {
 usb_state_t data temp_state = usb_get_state();
 uint8_t i = 0;
 uint8_t xdata *buf_ptr;
 uint8_t xdata *bc_ptr;
 
 if(temp_state == USB_REM_WU_ENABLE)   
 {   
 return APP_SUSP_WE;    
 }   
 
 if(temp_state == USB_REM_WU_DISABLE)   
 {   
 return APP_SUSP_WD;    
 }
 
 if(ep2_rx)  
 {
 ep2_rx = ((_Bool)0);
 
 hal_nrf_write_ack_payload(0, ackPayload, 11);
 
 }
 
 if(blockNeedsSending)  
 {
 blockNeedsSending = 0;
 
 
 P0_5=1;
 
 
 buf_ptr = (uint8_t xdata *)(in0buf - (( 2 & 0x7f) * 128));
 bc_ptr = (uint8_t xdata *)(&in0bc + ((2 & 0x7f ) * 2));
 
 if( 0 == block )
 {
 
 }
 
 for( i = 0; i < 32; ++i )
 {
 buf_ptr[i] = payload[block][i];
 }
 
 
 *bc_ptr = 32;
 
 
 
 if(block)
 {
 block = 0;
 } else {
 block = 1;
 }
 P0_5=0;
 



 
 }
 
 return APP_NORMAL; 
 }
 
 app_states_t app_init(void)
 {
 if(usb_get_state() == USB_REM_WU_ENABLE)   
 {   
 return APP_SUSP_WE;    
 }   
 
 if(usb_get_state() == USB_REM_WU_DISABLE)   
 {   
 return APP_SUSP_WD;    
 }




 
 hal_nrf_enable_ack_payload(1);
 hal_nrf_enable_dynamic_payload(1);
 hal_nrf_setup_dynamic_payload(1 << 0);  
 hal_nrf_set_rf_channel(125);  
 hal_nrf_set_operation_mode(HAL_NRF_PRX);  		 
 
 hal_nrf_set_power_mode(HAL_NRF_PWR_UP);	 		 
  do { RFCE = 1; } while(((_Bool)0));	    
 
 return APP_NORMAL; 	
 }
 
 app_states_t app_susp_we(void)   
 {   
 
 
 usb_wakeup();
 return APP_NORMAL;
  do { RFCE = 0; } while(((_Bool)0));
 hal_nrf_set_power_mode(HAL_NRF_PWR_DOWN);	 		 
 
 RFCKEN = 0;  	 
 
 
 
 
 cklf_gpio_wakeup(0x0000, 0x0000);            
 cklf_rtc_disable();   
 cklf_rtc_init(0x00, 0x1FFF);                 
 cpu_pwr_down();                              
 
 WUF = 0;                                     
 
 return APP_SUSP_WE;      
 } 
 
 void slave_spi() interrupt 10
 {
 
 
 if(byteCnt==0)
 {
 byteCnt = 32;
 block^=0x01;  
 blockNeedsSending = 1;
 }
 
 byteCnt = (byteCnt - 1);
 
 payload[block][byteCnt] = SSDATA;
 
 }  				
 
 void rf_irq() interrupt 9
 {
 uint8_t irq_flags;
 uint8_t data *pbuf = payload[block];
 uint8_t data ctr = 0;
 
 P0_5=1;
 
  do { RFCSN = 0; } while(((_Bool)0));
 
 
 RFDAT = 0x20 + 0x07;
 RFSPIF = 0;      
 
 while(!RFSPIF);  
 
 irq_flags = RFDAT;    
 
 
 RFDAT = (0x40|0x20|0x10);
 RFSPIF = 0;      
 
 while(!RFSPIF);  
 
 
 
 
  do { RFCSN = 1; } while(((_Bool)0));						 
 irq_flags = irq_flags & (0x40|0x20|0x10);
 
 
 
 
 if(irq_flags & (1<<HAL_NRF_RX_DR))
 {
 
 
 
 
 
 if( (hal_nrf_get_rx_data_source()) < 7)
 {
 ctr = hal_nrf_read_rx_payload_width();
  do { RFCSN = 0; } while(((_Bool)0));
 hal_nrf_rw(0x61);
 }
 else
 {
 ctr = 0;
 }
 
 
 while(ctr--)
 {
 RFDAT = 0;
 RFSPIF = 0;      
 
 while(!RFSPIF);  
 
 
 *pbuf++ = RFDAT;
 }
 
  do { RFCSN = 1; } while(((_Bool)0));
 
 
 
 blockNeedsSending = 1;
 
 
 }
 P0_5=0;
 }
 
 static void radio_init()
 {
 
 RFCTL = 0x10; 
 
 RF = 1;	 		 
 RFCKEN = 1;  	 
 
 hal_nrf_set_operation_mode(HAL_NRF_PRX);  		 
 


 
 return;
 }
 
 void usb_wakeup(void)   
 {   
 hal_usb_wakeup();
 
 usb_state = USB_AWAKE;   
 }   
 
 usb_state_t usb_get_state()   
 {   
 return usb_state;   
 }
 
 void usb_wait_for_configuration(void)   
 {   
 volatile hal_usb_state_t usb_hal_state;   
 do   
 {   
 usb_hal_state = hal_usb_get_state();   
 }   
 while(usb_hal_state != CONFIGURED);   
 }
 
 static hal_usb_dev_req_resp_t device_req_cb(hal_usb_device_req* req, uint8_t** data_ptr, uint16_t* size) reentrant
 {
 hal_usb_dev_req_resp_t retval;  
 uint8_t reply[] = "Ping!";
 
 *data_ptr = reply;
 *size = 6;
 retval = DATA;
 
 return retval;
 }
 
 static void suspend_cb(uint8_t allow_remote_wu) reentrant   
 {   
 USBSLP = 1;  
 
 if (allow_remote_wu == 1)   
 {   
 
 
 WUCONF = (0x20 | 0x08 | 0x02);   
 usb_state = USB_REM_WU_ENABLE;   
 }   
 else   
 {   
 
 WUCONF = (0x08 | 0x02);   
 usb_state = USB_REM_WU_DISABLE;   
 } 
 }
 
 static void resume_cb() reentrant   
 { 
 
 ep1_sent = ((_Bool)1);   
 usb_state = USB_AWAKE;   
 }
 
 static void reset_cb() reentrant   
 { 
 
 ep1_sent = ((_Bool)1);  
 usb_state = USB_AWAKE;    
 }
 
 static code uint8_t ep_1_in_cb(uint8_t *adr_ptr, uint8_t* size) reentrant   
 {  
 ep1_sent = ((_Bool)1);   
 return 0x60;  
 }
 
 uint8_t ep_1_out_cb( uint8_t xdata *adr_ptr, uint8_t xdata *size) reentrant   
 {
 static uint8_t xdata *buf_ptr;   
 static uint8_t i = 0; 
 
 buf_ptr = (uint8_t xdata *)(out0buf - (2 * 128 )); 
 ep2_rx = ((_Bool)1);
 
 
 
 
 for(i = 0; i < 11; ++i)
 {
 ackPayload[i] = buf_ptr[i];
 }  
 return 0xff;  
 }  
