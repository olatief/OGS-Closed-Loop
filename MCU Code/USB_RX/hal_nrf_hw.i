
#line 1 "..\hal\nrf24lu1p\hal_nrf_hw.c" /0











 
 





 
 
  
#line 1 "..\compiler\c51\stdint.h" /0











 
 








 
 
 
 
 
 
 
 typedef unsigned char uint8_t;         
 
 typedef signed char int8_t;           
 
 typedef unsigned int uint16_t;         
 
 typedef signed int int16_t;           
 
 typedef unsigned long uint32_t;        
 
 typedef signed long int32_t;          
 
 
 
 
 
 
 
 
#line 21 "..\hal\nrf24lu1p\hal_nrf_hw.c" /0
 
  
#line 1 "..\hal\nrf24l01p\hal_nrf.h" /0











 
 


 
 





















 
 
 
 
 
  
#line 1 "..\compiler\c51\stdint.h" /0











 
 








 
 
 
#line 25 "..\compiler\c51\stdint.h" /1
  
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
  
 
 
 
#line 44 "..\hal\nrf24l01p\hal_nrf.h" /0
#line 44 "..\hal\nrf24l01p\hal_nrf.h" /0
 
  
#line 1 "..\compiler\c51\stdbool.h" /0











 
 








 
 
 
 
 
 
 typedef unsigned char _Bool;  
 
 
 
 
 
 
 
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
 
 
 
 
#line 22 "..\hal\nrf24lu1p\hal_nrf_hw.c" /0
 
  
#line 1 "..\compiler\common\nrf24lu1p.h" /0
 
#line 2 "..\compiler\common\nrf24lu1p.h" /1
  
 
 
  
  
 
 
 
  
 
 
  
  
 
 
#line 23 "..\hal\nrf24lu1p\hal_nrf_hw.c" /0
#line 23 "..\hal\nrf24lu1p\hal_nrf_hw.c" /0
 
 
 uint8_t hal_nrf_rw(uint8_t value)
 {
 RFDAT = value;
 RFSPIF = 0;      
 
 while(!RFSPIF) {};  
 return RFDAT;    
 }
 
 
