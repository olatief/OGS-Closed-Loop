
#line 1 "..\hal\nrf24lu1p\hal_usb.c" /0











 
 


 
  
#line 1 "..\compiler\common\nrf24lu1p.h" /0
 
 
 
 
#line 5 "..\compiler\common\nrf24lu1p.h" /1
  
  
 
#line 8 "..\compiler\common\nrf24lu1p.h" /0
 
 
  
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
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
#line 10 "..\compiler\common\nrf24lu1p.h" /0
 
 
 
  
#line 1 "\Users\Omar\Dropbox\OGS-Closed-Loop\MCU Code\compiler\common\isrdef24lu1p.h" /0
 
#line 2 "\Users\Omar\Dropbox\OGS-Closed-Loop\MCU Code\compiler\common\isrdef24lu1p.h" /1
 
  


 
  


 
  


 
  


 
  


 
  


 
  


 
  


 
  


 
  


 
  


 
  


 
 
#line 52 "\Users\Omar\Dropbox\OGS-Closed-Loop\MCU Code\compiler\common\isrdef24lu1p.h" /0
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
#line 13 "..\compiler\common\nrf24lu1p.h" /0
 
  
#line 1 "\Users\Omar\Dropbox\OGS-Closed-Loop\MCU Code\compiler\common\memdefs.h" /0
 
 
 
 
 
 
 
 
#line 9 "\Users\Omar\Dropbox\OGS-Closed-Loop\MCU Code\compiler\common\memdefs.h" /1
 
  
  
  
  
  
  
  
  
 
 
 
  
 
 
 
 
  
 
 
  
 
 
 
#line 33 "\Users\Omar\Dropbox\OGS-Closed-Loop\MCU Code\compiler\common\memdefs.h" /0
 
 
#line 14 "..\compiler\common\nrf24lu1p.h" /0
 
 
 
#line 17 "..\hal\nrf24lu1p\hal_usb.c" /0
 
  
#line 1 "..\compiler\c51\stdint.h" /0











 
 








 
 
 
 
 
 
 
 typedef unsigned char uint8_t;         
 
 typedef signed char int8_t;           
 
 typedef unsigned int uint16_t;         
 
 typedef signed int int16_t;           
 
 typedef unsigned long uint32_t;        
 
 typedef signed long int32_t;          
 
 
 
 
 
 
 
 
#line 18 "..\hal\nrf24lu1p\hal_usb.c" /0
 
 
#line 20 "..\hal\nrf24lu1p\hal_usb.c" /1
  
 
#line 22 "..\hal\nrf24lu1p\hal_usb.c" /0
 
  
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
 
 
 
 
#line 23 "..\hal\nrf24lu1p\hal_usb.c" /0
 
 
 
  
#line 1 "..\hal\nordic_common.h" /0











 
 



 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
#line 26 "..\hal\nrf24lu1p\hal_usb.c" /0
 
  
#line 1 "..\hal\nrf24lu1p\hal_usb_desc.h" /0











 
 


 
 
 
 
 
  
#line 1 "..\compiler\c51\stdint.h" /0











 
 








 
 
 
#line 25 "..\compiler\c51\stdint.h" /1
  
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
  
 
 
 
#line 21 "..\hal\nrf24lu1p\hal_usb_desc.h" /0
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
 
 
 
#line 27 "..\hal\nrf24lu1p\hal_usb.c" /0
 
  
#line 1 "..\hal\nrf24lu1p\usb.h" /0











 
 


 
 
 
 
 
  
#line 1 "..\compiler\c51\stdint.h" /0











 
 








 
 
 
#line 25 "..\compiler\c51\stdint.h" /1
  
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
  
 
 
 
#line 21 "..\hal\nrf24lu1p\usb.h" /0
#line 21 "..\hal\nrf24lu1p\usb.h" /0
 
 
  
#line 1 "..\hal\nrf24lu1p\hal_usb.h" /0











 
 





























































 
 
 
 
 
  
#line 1 "..\compiler\c51\stdint.h" /0











 
 








 
 
 
#line 25 "..\compiler\c51\stdint.h" /1
  
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
  
 
 
 
#line 80 "..\hal\nrf24lu1p\hal_usb.h" /0
#line 80 "..\hal\nrf24lu1p\hal_usb.h" /0
 
  
#line 1 "..\compiler\c51\stdbool.h" /0











 
 








 
 
 
 
 
 
 typedef unsigned char _Bool;  
 
 
 
 
 
 
 
#line 81 "..\hal\nrf24lu1p\hal_usb.h" /0
 
 
  
#line 1 "..\hal\nrf24lu1p\hal_usb_desc.h" /0











 
 


 
 
 
#line 19 "..\hal\nrf24lu1p\hal_usb_desc.h" /1
  
 
  
 
 
  
  
  
  
  
  
  
  
  
  
  
  
  
 
 
  
  
  
  
  
  
  
  
  
  
  
 
  
  
  
  
 
 
  
  
  
  
  
  
  
  
  
  
  
  
 
 
  
  
  
 
  
  
  
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
#line 83 "..\hal\nrf24lu1p\hal_usb.h" /0
#line 83 "..\hal\nrf24lu1p\hal_usb.h" /0
 
  
#line 1 "config.h" /0











 
 



 
 
 
 
 
 
 
 
 
 
 
#line 84 "..\hal\nrf24lu1p\hal_usb.h" /0
 
  
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
 
 
#line 85 "..\hal\nrf24lu1p\hal_usb.h" /0
 
 
 
#line 88 "..\hal\nrf24lu1p\hal_usb.h" /1
 
 
#line 90 "..\hal\nrf24lu1p\hal_usb.h" /0
 
 
 
 
 



 
 
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
 
 
#line 28 "..\hal\nrf24lu1p\hal_usb.c" /0
 
  
#line 1 "..\hal\hal_delay.h" /0
 
 
  
#line 1 "..\compiler\c51\stdint.h" /0











 
 








 
 
 
#line 25 "..\compiler\c51\stdint.h" /1
  
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
  
 
 
 
#line 3 "..\hal\hal_delay.h" /0
#line 3 "..\hal\hal_delay.h" /0
 
 





 
 void delay_us(uint16_t us);
 


 
 void delay_ms(uint16_t ms);
 
 
 
#line 29 "..\hal\nrf24lu1p\hal_usb.c" /0
 
 
 
 
  
#line 1 "..\hal\nrf24lu1p\usb_map.h" /0











 
 








 
 
 
 
 
 
 
 
#line 30 "..\hal\nrf24lu1p\usb_map.h" /1
  
  
 
#line 33 "..\hal\nrf24lu1p\usb_map.h" /0
 
 
 
   xdata volatile uint8_t out5buf[0x20] _at_ 0xC440;
   xdata volatile uint8_t in5buf[0x20]  _at_ 0xC480;
   xdata volatile uint8_t out4buf[0x20] _at_ 0xC4C0;
   xdata volatile uint8_t in4buf[0x20]  _at_ 0xC500;
   xdata volatile uint8_t out3buf[0x20] _at_ 0xC540;
   xdata volatile uint8_t in3buf[0x20]  _at_ 0xC580;
   xdata volatile uint8_t out2buf[0x20] _at_ 0xC5C0;
   xdata volatile uint8_t in2buf[0x20]  _at_ 0xC600;
   xdata volatile uint8_t out1buf[0x20] _at_ 0xC640;
   xdata volatile uint8_t in1buf[0x20]  _at_ 0xC680;
   xdata volatile uint8_t out0buf[0x20] _at_ 0xC6C0;
   xdata volatile uint8_t in0buf[0x20]  _at_ 0xC700;
   xdata volatile uint8_t out8data                         _at_ 0xC760;
   xdata volatile uint8_t in8data                          _at_ 0xC768;
   xdata volatile uint8_t out8bch                          _at_ 0xC770;
   xdata volatile uint8_t out8bcl                          _at_ 0xC771;
   xdata volatile uint8_t bout1addr                        _at_ 0xC781;
   xdata volatile uint8_t bout2addr                        _at_ 0xC782;
   xdata volatile uint8_t bout3addr                        _at_ 0xC783;
   xdata volatile uint8_t bout4addr                        _at_ 0xC784;
   xdata volatile uint8_t bout5addr                        _at_ 0xC785;
   xdata volatile uint8_t binstaddr                        _at_ 0xC788;
   xdata volatile uint8_t bin1addr                         _at_ 0xC789;
   xdata volatile uint8_t bin2addr                         _at_ 0xC78A;
   xdata volatile uint8_t bin3addr                         _at_ 0xC78B;
   xdata volatile uint8_t bin4addr                         _at_ 0xC78C;
   xdata volatile uint8_t bin5addr                         _at_ 0xC78D;
   xdata volatile uint8_t isoerr                           _at_ 0xC7A0;
   xdata volatile uint8_t zbcout                           _at_ 0xC7A2;
   xdata volatile uint8_t ivec                             _at_ 0xC7A8;
   xdata volatile uint8_t in_irq                           _at_ 0xC7A9;
   xdata volatile uint8_t out_irq                          _at_ 0xC7AA;
   xdata volatile uint8_t usbirq                           _at_ 0xC7AB;
   xdata volatile uint8_t in_ien                           _at_ 0xC7AC;
   xdata volatile uint8_t out_ien                          _at_ 0xC7AD;
   xdata volatile uint8_t usbien                           _at_ 0xC7AE;
   xdata volatile uint8_t usbbav                           _at_ 0xC7AF;
   xdata volatile uint8_t ep0cs                            _at_ 0xC7B4;
   xdata volatile uint8_t in0bc                            _at_ 0xC7B5;
   xdata volatile uint8_t in1cs                            _at_ 0xC7B6;
   xdata volatile uint8_t in1bc                            _at_ 0xC7B7;
   xdata volatile uint8_t in2cs                            _at_ 0xC7B8;
   xdata volatile uint8_t in2bc                            _at_ 0xC7B9;
   xdata volatile uint8_t in3cs                            _at_ 0xC7BA;
   xdata volatile uint8_t in3bc                            _at_ 0xC7BB;
   xdata volatile uint8_t in4cs                            _at_ 0xC7BC;
   xdata volatile uint8_t in4bc                            _at_ 0xC7BD;
   xdata volatile uint8_t in5cs                            _at_ 0xC7BE;
   xdata volatile uint8_t in5bc                            _at_ 0xC7BF;
   xdata volatile uint8_t out0bc                           _at_ 0xC7C5;
   xdata volatile uint8_t out1cs                           _at_ 0xC7C6;
   xdata volatile uint8_t out1bc                           _at_ 0xC7C7;
   xdata volatile uint8_t out2cs                           _at_ 0xC7C8;
   xdata volatile uint8_t out2bc                           _at_ 0xC7C9;
   xdata volatile uint8_t out3cs                           _at_ 0xC7CA;
   xdata volatile uint8_t out3bc                           _at_ 0xC7CB;
   xdata volatile uint8_t out4cs                           _at_ 0xC7CC;
   xdata volatile uint8_t out4bc                           _at_ 0xC7CD;
   xdata volatile uint8_t out5cs                           _at_ 0xC7CE;
   xdata volatile uint8_t out5bc                           _at_ 0xC7CF;
   xdata volatile uint8_t usbcs                            _at_ 0xC7D6;
   xdata volatile uint8_t togctl                           _at_ 0xC7D7;
   xdata volatile uint8_t usbfrml                          _at_ 0xC7D8;
   xdata volatile uint8_t usbfrmh                          _at_ 0xC7D9;
   xdata volatile uint8_t fnaddr                           _at_ 0xC7DB;
   xdata volatile uint8_t usbpair                          _at_ 0xC7DD;
   xdata volatile uint8_t inbulkval                        _at_ 0xC7DE;
   xdata volatile uint8_t outbulkval                       _at_ 0xC7DF;
   xdata volatile uint8_t inisoval                         _at_ 0xC7E0;
   xdata volatile uint8_t outisoval                        _at_ 0xC7E1;
   xdata volatile uint8_t isostaddr                        _at_ 0xC7E2;
   xdata volatile uint8_t isosize                          _at_ 0xC7E3;
   xdata volatile uint8_t setupbuf[8]                      _at_ 0xC7E8;
   xdata volatile uint8_t out8addr                         _at_ 0xC7F0;
   xdata volatile uint8_t in8addr                          _at_ 0xC7F8;
 
 
#line 33 "..\hal\nrf24lu1p\hal_usb.c" /0
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 static packetizer_t i_packetizer;
 static hal_usb_cb_endpoint_t i_endpoint_in_isr[5];
 static hal_usb_cb_endpoint_t i_endpoint_out_isr[5];
 
 static hal_usb_device_req req;
 hal_usb_t g_hal_usb;
 static uint8_t stall_data_size0;
 
 void hal_usb_init(_Bool usb_disconnect, hal_usb_cb_device_req_t device_req, hal_usb_cb_reset_t reset, hal_usb_cb_resume_t resume, hal_usb_cb_suspend_t suspend)
 {
 
 g_hal_usb.descs.dev = &g_usb_dev_desc;
 g_hal_usb.descs.conf = &g_usb_conf_desc;
 g_hal_usb.descs.string = &g_usb_string_desc;
 
 
 g_hal_usb.descs.string_zero[0] = 0x04;
 g_hal_usb.descs.string_zero[1] = 0x03;
 g_hal_usb.descs.string_zero[2] = 0x09;
 g_hal_usb.descs.string_zero[3] = 0x04;
 
 
 g_hal_usb.state = DEFAULT;
 g_hal_usb.bm_state = 0;
 stall_data_size0 = 0;
 
 
 g_hal_usb.current_config = 0;
 g_hal_usb.current_alt_interface = 0;
 
 
 g_hal_usb.device_req = device_req;
 g_hal_usb.reset = reset;
 g_hal_usb.resume = resume;
 g_hal_usb.suspend = suspend;
 
 
 if(usb_disconnect)
 {
 usbcs |= 0x08;  
 delay_ms(50);
 usbcs &= ~(0x08);  
 }
 
 
 USBWU = 1;  
 USB = 1;  
 
 usbien = 0x1d;  
 
 in_ien = 0x01;
 in_irq = 0x1f;
 out_ien = 0x01;
 out_irq = 0x1f;
 
 
 bout1addr = 16;
 bout2addr = 32;
 bout3addr = 48;
 bout4addr = 64;
 bout5addr = 80;
 
 binstaddr = 0xc0;
 bin1addr = 16;
 bin2addr = 32;
 bin3addr = 48;
 bin4addr = 64;
 bin5addr = 80;
 
 
 inbulkval = 0x01;
 outbulkval = 0x01;
 inisoval = 0x00;
 outisoval = 0x00;
 }
 
 void hal_usb_endpoint_stall(uint8_t ep_num, _Bool stall)
 {
 uint8_t temp;
 uint8_t xdata *cs_ptr;
 
 temp = 2 * ((ep_num & 0x7f) - 1);
 
 
 if((ep_num & 0x80 ) == 0x80)  
 {
 
 cs_ptr = (uint8_t xdata*)(&in1cs + temp);
 }
 else  
 {
 
 cs_ptr = (uint8_t xdata*)(&out1cs + temp);
 }
 
 if(stall == ((_Bool)1))
 {
 
 *cs_ptr = 0x01;
 }
 else
 {
 
 *cs_ptr = 0x00;
 }
 }
 
 uint8_t hal_usb_get_address()
 {
 return fnaddr;
 }
 
 void hal_usb_endpoint_config(uint8_t ep_num, uint8_t ep_size, hal_usb_cb_endpoint_t endpoint_isr)
 {
 uint8_t xdata *bc_ptr;
 uint8_t temp = (ep_num & 0x7f) - 1;
 uint8_t stemp = 1 << (ep_num & 0x7f);
 
 
 ep_size = 0;
 
 if((ep_num & 0x80 ) == 0x80)  
 {
 i_endpoint_in_isr[temp] = endpoint_isr;
 if(endpoint_isr != (void*)0)
 {
 
 in_ien |= stemp; 
 inbulkval |= stemp;
 }
 else
 {
 
 in_ien &= ~stemp;
 inbulkval &= ~stemp;
 }
 }
 else  
 {
 i_endpoint_out_isr[temp] = endpoint_isr;
 if(endpoint_isr != (void*)0)
 {
 
 out_ien |= stemp;
 outbulkval |= stemp;
 
 
 bc_ptr = (uint8_t xdata *)(&out0bc + (ep_num * 2 ));
 *bc_ptr = 0xff;
 }
 else
 {
 
 out_ien &= ~stemp;
 outbulkval &= ~stemp;
 }
 }
 }
 
 void hal_usb_wakeup()
 {
 
 if((g_hal_usb.bm_state & 0x02) == 0x02)
 {
 USBCON = 0x40;   
 delay_ms(1);     
 USBCON = 0x00;
 }
 }
 
 void hal_usb_reset()
 {
 SWRST = 1;   
 }
 
 hal_usb_state_t hal_usb_get_state()
 {
 return g_hal_usb.state;
 }
 
 void hal_usb_send_data(uint8_t ep_num, uint8_t* array, uint8_t count)
 {
 uint8_t i;
 
 uint8_t xdata *buf_ptr;
 uint8_t xdata *bc_ptr;
 
 
 buf_ptr = (uint8_t xdata *)(in0buf - (( ep_num & 0x7f) * 128));
 bc_ptr = (uint8_t xdata *)(&in0bc + ((ep_num & 0x7f ) * 2));
 
 
 for( i = 0; i < count; i++ )
 {
 buf_ptr[i] = array[i];
 }
 
 
 *bc_ptr = count;
 }
 
 void hal_usb_bus_disconnect()
 {
 usbcs |= 0x08;  
 }
 
 void hal_usb_bus_connect()
 {
 usbcs &= ~(0x08);  
 }
 
 void hal_usb_sleep()
 {
 USBSLP = 1;
 }
 
 static void packetize(uint8_t *data_ptr, uint8_t data_size)
 {
 i_packetizer.data_ptr = data_ptr;
 i_packetizer.data_size = data_size;
 i_packetizer.pkt_size = g_hal_usb.descs.dev->bMaxPacketSize0;
 }
 
 
 static void packetizer_isr_ep0_in(void) 
 {
 uint8_t size, i;
 
 
 if(i_packetizer.data_size == 0)
 {        
 if (stall_data_size0 == 1)
 {
  do { ep0cs |= 0x10; } while(0);
 }
 else
 {
 stall_data_size0 = 1;
 in0bc = 0;
  do { ep0cs = 0x02; } while(0);
 }       
 return;
 }
 
 size = ((i_packetizer.data_size) < (i_packetizer.pkt_size) ? (i_packetizer.data_size) : (i_packetizer.pkt_size));
 
 
 for(i = 0; i < size; i++)
 {
 in0buf[i] = i_packetizer.data_ptr[i];
 }
 
 if (size < i_packetizer.pkt_size)
 stall_data_size0 = 1;
 
 
 in0bc = size;
 
 
 i_packetizer.data_ptr += size;
 i_packetizer.data_size -= size;
 
 return;
 }
 
 
 static void usb_process_dev_req_cb_response(void)
 {
 uint8_t *data_ptr;
 uint8_t data_size;
 hal_usb_dev_req_resp_t ret = g_hal_usb.device_req(&req, &data_ptr, &data_size);
 
 switch(ret)
 {
 case DATA:
 packetize((uint8_t *)data_ptr, ((req.wLength) < (data_size) ? (req.wLength) : (data_size)));
 packetizer_isr_ep0_in();
 break;
 case NO_RESPONSE:
 break;
 case EMPTY_RESPONSE:
 case NAK:
  do { ep0cs = 0x02; } while(0);
 break;
 case ACK:
 out0bc = 0xff;
 break;
 case STALL:
 default:
  do { ep0cs = 0x11; } while(0);
 break;
 }
 }
 
 static void usb_process_get_status(void)
 {
 uint8_t xdata *ptr;
 
 if(g_hal_usb.state == ADDRESSED)
 {
 if(req.wIndex != 0x00)
 {
  do { ep0cs = 0x11; } while(0);
 }
 else
 {
 in0buf[0] = in0buf[1] = 
 ((g_hal_usb.descs.conf->conf.bmAttributes & 0x40 ) >> 6);  
 in0bc = 0x02;
 }
 }
 else if(g_hal_usb.state == CONFIGURED)
 {
 in0buf[1] = 0x00;
 switch(req.bmRequestType)
 {
 case 0x80:  
 if((g_hal_usb.bm_state & 0x02 ) == 0x02)
 {
 in0buf[0] = 0x02;
 }
 else
 {
 in0buf[0] = 0x00;
 }
 
 in0buf[0] |= ((g_hal_usb.descs.conf->conf.bmAttributes & 0x40 ) >> 6);  
 in0bc = 0x02;
 break;
 case 0x81:  
 in0buf[0] = 0x00;
 in0bc = 0x02;
 break;
 case 0x82:  
 if((req.wIndex & 0x80) == 0x80)  
 {
 ptr = (uint8_t xdata*)(&in1cs + 2 * ((req.wIndex & 0x7f) - 1 ));
 }
 else
 {
 ptr = (uint8_t xdata*)(&out1cs + 2 * ( (req.wIndex & 0x7f) - 1 ));
 }
 
 in0buf[0] = *ptr & 0x01;
 in0bc = 0x02;
 break;
 default:
  do { ep0cs = 0x11; } while(0);
 break;
 }  
 }
 else
 {
 
  do { ep0cs = 0x11; } while(0);
 }
 }
 
 static void usb_process_get_descriptor(void)
 {
 
 switch(req.wValueMsb)
 {
 case 0x01:
 packetize((uint8_t *)g_hal_usb.descs.dev,
  ((req.wLength) < (sizeof(hal_usb_dev_desc_t)) ? (req.wLength) : (sizeof(hal_usb_dev_desc_t))));
 packetizer_isr_ep0_in();
 break;
 case 0x02:
 
 packetize((uint8_t *)g_hal_usb.descs.conf,
  ((req.wLength) < (sizeof(usb_conf_desc_templ_t)) ? (req.wLength) : (sizeof(usb_conf_desc_templ_t))));
 packetizer_isr_ep0_in();
 break;
 case 0x03:
 
 if(req.wValueLsb == 0x00)
 {
 packetize(g_hal_usb.descs.string_zero, ((req.wLength) < (sizeof(g_hal_usb.descs.string_zero)) ? (req.wLength) : (sizeof(g_hal_usb.descs.string_zero))));
 packetizer_isr_ep0_in();
 }
 else
 {
 if((req.wValueLsb - 1 ) < 2)
 {
 packetize((uint8_t *)(g_hal_usb.descs.string->idx[req.wValueLsb-1]),
  ((req.wLength) < (g_hal_usb.descs.string->idx[req.wValueLsb-1][0]) ? (req.wLength) : (g_hal_usb.descs.string->idx[req.wValueLsb-1][0])));
 packetizer_isr_ep0_in();
 }
 else
 {
  do { ep0cs = 0x11; } while(0);
 }
 }
 break;
 case 0x04:
 case 0x05:
 case 0x06:
 case 0x07:
 case 0x08:
  do { ep0cs = 0x11; } while(0);
 break;
 default:
 usb_process_dev_req_cb_response();
 break;
 }
 }
 
 static void isr_sudav(void)
 {
 
 req.bmRequestType = setupbuf[0];
 req.bRequest = setupbuf[1];
 req.wValueLsb = setupbuf[2];
 req.wValueMsb = setupbuf[3];
 req.wIndex = setupbuf[4];
 req.wLength = setupbuf[6];
 if (setupbuf[7] > 0)
 {
 req.wLength = 0xff;  
 }
 
 
 if((req.bmRequestType & 0x60) == 0x00)
 {
 switch(req.bRequest)
 {
 case 0x06:
 usb_process_get_descriptor();
 break;
 case 0x00:
 usb_process_get_status();
 break;           
 case 0x01:
 case 0x03: 
 switch(req.bmRequestType)
 {
 case 0x00:  
 if(req.wValueLsb == 0x01)
 {
 if (req.bRequest == 0x01) 
 g_hal_usb.bm_state &= ~(0x02);
 else
 g_hal_usb.bm_state |= 0x02;
  do { ep0cs = 0x02; } while(0);
 }
 else
 {
  do { ep0cs = 0x11; } while(0);
 }
 break;
 
 case 0x02:  
 if(req.wValueLsb == 0x00)
 {
 if (req.bRequest == 0x01) 
 hal_usb_endpoint_stall(req.wIndex, ((_Bool)0));
 else
 hal_usb_endpoint_stall(req.wIndex, ((_Bool)1));
  do { ep0cs = 0x02; } while(0);
 }
 else 
 {
  do { ep0cs = 0x11; } while(0);
 }
 break;
 case 0x01:  
 default:
  do { ep0cs = 0x11; } while(0);
 break;
 }
 break;
 
 case 0x05:
 g_hal_usb.state = ADDRESSED;
 g_hal_usb.current_config = 0x00;
 break;
 case 0x08:
 switch(g_hal_usb.state)
 {
 case ADDRESSED:
 in0buf[0] = 0x00;
 in0bc = 0x01;
 break;
 case CONFIGURED:
 in0buf[0] = g_hal_usb.current_config;
 in0bc = 0x01;
 break;
 default:
  do { ep0cs = 0x11; } while(0);
 break;
 }
 break;
 case 0x09:
 switch(req.wValueLsb)
 {
 case 0x00:
 g_hal_usb.state = ADDRESSED;
 g_hal_usb.current_config = 0x00;
  do { ep0cs = 0x02; } while(0);
 break;
 case 0x01:
 g_hal_usb.state = CONFIGURED;
 g_hal_usb.bm_state |= 0x01;
 g_hal_usb.current_config = 0x01;
  do { ep0cs = 0x02; } while(0);
 break;
 default:
  do { ep0cs = 0x11; } while(0);
 break;
 }
 break;
 case 0x0a:  
 in0buf[0] = g_hal_usb.current_alt_interface;
 in0bc = 0x01;
 break;
 case 0x07:
 case 0x0b:  
 case 0x0c:    
 default:
  do { ep0cs = 0x11; } while(0);
 break;
 };
 } 
 
 else if((req.bmRequestType & 0x60 ) == 0x20)   
 {
 if(req.wLength != 0 && ((req.bmRequestType & 0x80) == 0x00))
 {
 
 
 out0bc = 0xff;
 }
 else
 {
 usb_process_dev_req_cb_response();
 }
 
 } 
 else   
 {
  do { ep0cs = 0x11; } while(0);
 }
 }
 
 static void isr_suspend(void)
 {
 uint8_t allow_remote_wu = 0;
 g_hal_usb.bm_state &= ~(0x04);  
 
 if( g_hal_usb.state == CONFIGURED )
 {
 if( ( g_hal_usb.bm_state & 0x02 ) == 0x02 )
 {
 allow_remote_wu = 1;
 }
 }
 
 g_hal_usb.state = SUSPENDED;
 
 if( g_hal_usb.suspend != (void*)0 )
 {
 g_hal_usb.suspend(allow_remote_wu);
 }
 }
 
 static void isr_usbreset(void)
 {
 g_hal_usb.state = DEFAULT;
 g_hal_usb.current_config = 0;
 g_hal_usb.current_alt_interface = 0;
 g_hal_usb.bm_state = 0;
 if( g_hal_usb.reset != (void*)0 ) g_hal_usb.reset();
 }
 
 
  void usb_wu_isr(void) interrupt 11  
 {
 
 
 uint8_t t;
 
 
 
 
 
 if( ( usbcs & 0x80 ) == 0x80 )
 {
 
 usbcs = 0x80;
 
 
 if( ( g_hal_usb.bm_state & 0x02 ) == 0x02 )
 {
 
 
 usbcs |= 0x02;
 
 
 _nop_();
 _nop_();
 
 t = usbcs;
 
 
 t &= ~0x02;
 
 
 t |= 0x01;
 
 
 
 usbcs = t;
 
#line 663 "..\hal\nrf24lu1p\hal_usb.c" /1
 
 
#line 665 "..\hal\nrf24lu1p\hal_usb.c" /0
 delay_ms(7);  
 
 
 usbcs &= ~0x01;  
 }
 }
 else 
 {
 
 g_hal_usb.bm_state |= 0x04;
 }
 
 if((g_hal_usb.bm_state & 0x01 ) == 0x01)
 {
 g_hal_usb.state = CONFIGURED;
 }
 else
 {
 g_hal_usb.state = DEFAULT;
 }
 
 
 g_hal_usb.resume();
 }
 
 
 static void usb_process_ep_response(uint8_t ret, uint8_t xdata* cs_ptr, uint8_t xdata* bc_ptr)
 {
 if( ret == 0xff )  
 {
 *bc_ptr = 0xff;
 }
 else if( ( ret & 0x80 ) == 0x80 )   
 {
 *cs_ptr = 0x01;
 }
 else if( ( ret & 0x60 ) == 0x60 )  
 {
 *cs_ptr = 0x02;
 }
 else if( ret == 0 )  
 {
 *bc_ptr = 0;
 }
 else
 {
 *bc_ptr = ret;
 }
 }
 
  void usb_isr(void) interrupt 12
 {
 uint8_t ep;
 uint8_t ret;
 uint8_t xdata *cs_ptr;
 uint8_t xdata *buf_ptr;
 uint8_t xdata *bc_ptr;
 
 switch(ivec)
 {
 case 0x00:
 usbirq = 0x01;
 isr_sudav();
 break;
 case 0x04:
 usbirq = 0x02;
 break;
 case 0x08:
 usbirq = 0x04;
 i_packetizer.data_ptr = (void*)0;
 i_packetizer.data_size = 0;
 i_packetizer.pkt_size = 0;
 stall_data_size0 = 0;
 break;
 case 0x0C:
 usbirq = 0x08;
 isr_suspend();
 break;
 case 0x10:
 usbirq = 0x10;
 isr_usbreset();
 break;
 case 0x18:
 in_irq = 0x01;
 packetizer_isr_ep0_in();
 break;
 case 0x1C:
 out_irq = 0x01;
 i_packetizer.data_size = 0;
 usb_process_dev_req_cb_response();
 break;
 case 0x20:
 case 0x28:
 case 0x30:
 case 0x38:
 case 0x40:
 
 ep = (ivec - 0x18 ) >> 3; 
 
 in_irq = ( 1 << ep );
 
 cs_ptr = (uint8_t xdata*)(&in1cs + 2 * ((ep & 0x7f) - 1 ));
 buf_ptr = (uint8_t xdata *)(in0buf - (( ep & 0x7f) * 128));
 bc_ptr = (uint8_t xdata *)(&in0bc + ((ep & 0x7f ) * 2));
 
 
 
 usb_process_ep_response(0x60, cs_ptr, bc_ptr);
 break;
 case 0x24:
 case 0x2C:
 case 0x34:
 case 0x3C:
 case 0x44:
 
 ep = (ivec - 0x1C) >> 3;           
 
 
 out_irq = ( 1 << ep );
 
 cs_ptr = (uint8_t xdata*)(&out1cs + 2 * ( (ep & 0x7f) - 1 ));
 buf_ptr = (uint8_t xdata *)(out0buf - (ep * 128 ));
 bc_ptr = (uint8_t xdata *)(&out0bc + (ep * 2 ));
 
 
 
 ret = ep_1_out_cb(buf_ptr,bc_ptr);
 usb_process_ep_response(ret, cs_ptr, bc_ptr);
 break;
 default:
 break;
 };
 }
