
#line 1 "..\hal\nrf24l01p\hal_nrf.c" /0











 
 


 
 
 
 
 
 
 
  
#line 1 "..\compiler\c51\stdint.h" /0











 
 








 
 
 
 
 
 
 
 typedef unsigned char uint8_t;         
 
 typedef signed char int8_t;           
 
 typedef unsigned int uint16_t;         
 
 typedef signed int int16_t;           
 
 typedef unsigned long uint32_t;        
 
 typedef signed long int32_t;          
 
 
 
 
 
 
 
 
#line 23 "..\hal\nrf24l01p\hal_nrf.c" /0
 
  
#line 1 "..\compiler\c51\stdbool.h" /0











 
 








 
 
 
 
 
 
 typedef unsigned char _Bool;  
 
 
 
 
 
 
 
#line 24 "..\hal\nrf24l01p\hal_nrf.c" /0
 
 
  
#line 1 "..\hal\nordic_common.h" /0











 
 



 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
#line 26 "..\hal\nrf24l01p\hal_nrf.c" /0
 
  
#line 1 "..\hal\nrf24l01p\hal_nrf.h" /0











 
 


 
 





















 
 
 
 
 
  
#line 1 "..\compiler\c51\stdint.h" /0











 
 








 
 
 
#line 25 "..\compiler\c51\stdint.h" /1
  
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
  
 
 
 
#line 44 "..\hal\nrf24l01p\hal_nrf.h" /0
#line 44 "..\hal\nrf24l01p\hal_nrf.h" /0
 
  
#line 1 "..\compiler\c51\stdbool.h" /0











 
 








 
 
 
#line 25 "..\compiler\c51\stdbool.h" /1
  
 
 
 
 
  
  
  
  
 
 
#line 45 "..\hal\nrf24l01p\hal_nrf.h" /0
#line 45 "..\hal\nrf24l01p\hal_nrf.h" /0
 
 
  
#line 1 "..\hal\nrf24l01p\hal_nrf_reg.h" /0











 
 







 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 


 
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
 
 
 
 
#line 27 "..\hal\nrf24l01p\hal_nrf.c" /0
 
 
 
 
 






 
 uint8_t hal_nrf_read_reg(uint8_t reg);
 







 
 uint8_t hal_nrf_write_reg(uint8_t reg, uint8_t value);
 










 
 uint16_t hal_nrf_read_multibyte_reg(uint8_t reg, uint8_t *pbuf);
 







 
 void hal_nrf_write_multibyte_reg(uint8_t reg, const uint8_t *pbuf, uint8_t length);
 



 
 typedef union {
 uint8_t value;
 struct {
 uint8_t prim_rx : 1;
 uint8_t pwr_up : 1;
 uint8_t crc0 : 1;
 uint8_t en_crc : 1;
 uint8_t mask_max_rt : 1;
 uint8_t mask_tx_ds : 1;
 uint8_t mask_rx_dr : 1;
 const uint8_t : 1;
 } bits;
 } config_t;
 




 
 typedef union {
 uint8_t value;
 struct {
 uint8_t pipe_0 : 1;
 uint8_t pipe_1 : 1;
 uint8_t pipe_2 : 1;
 uint8_t pipe_3 : 1;
 uint8_t pipe_4 : 1;
 uint8_t pipe_5 : 1;
 const uint8_t : 2;
 } bits;
 } en_pipes_t;
 



 
 typedef union {
 uint8_t value;
 struct {
 uint8_t aw : 2;
 const uint8_t : 6;
 } bits;
 } setup_aw_t;
 



 
 typedef union {
 uint8_t value;
 struct {
 uint8_t arc : 4;
 uint8_t ard : 4;
 } bits;
 } setup_retr_t;
 



 
 typedef union {
 uint8_t value;
 struct {
 uint8_t rf_ch : 7;
 const uint8_t : 1;
 } bits;
 } rf_ch_t;
 



 
 typedef union {
 uint8_t value;
 struct {
 const uint8_t : 1;
 uint8_t rf_pwr : 2;
 uint8_t rf_dr_high : 1;
 uint8_t pll_lock : 1;
 uint8_t rf_dr_low : 1;
 const uint8_t : 1;
 uint8_t cont_wave : 1;
 } bits;
 } rf_setup_t;
 



 
 typedef union {
 uint8_t value;
 struct {
 uint8_t rx_pw : 6;
 const uint8_t : 2;
 } bits;
 } rx_pw_t;
 



 
 typedef union {
 uint8_t value;
 struct {
 uint8_t en_dyn_ack : 1;
 uint8_t en_ack_pay : 1;
 uint8_t en_dpl : 1;
 const uint8_t : 5;
 } bits;
 } feature_t;
 
 void hal_nrf_set_operation_mode(hal_nrf_operation_mode_t op_mode)
 {
 config_t config;
 config.value = hal_nrf_read_reg (0x00);
 
 if(op_mode == HAL_NRF_PRX)
 {
 config.bits.prim_rx = 1;
 }
 else
 {
 config.bits.prim_rx = 0;
 }
 
 hal_nrf_write_reg (0x00, config.value);
 }
 
 void hal_nrf_set_power_mode(hal_nrf_pwr_mode_t pwr_mode)
 {
 config_t config;
 config.value = hal_nrf_read_reg (0x00);
 
 if(pwr_mode == HAL_NRF_PWR_UP)
 {
 config.bits.pwr_up = 1;
 }
 else
 {
 config.bits.pwr_up = 0;
 }
 
 hal_nrf_write_reg (0x00, config.value);
 }
 
 void hal_nrf_set_crc_mode(hal_nrf_crc_mode_t crc_mode)
 {
 config_t config;
 config.value = hal_nrf_read_reg (0x00);
 
 switch (crc_mode)
 {
 case HAL_NRF_CRC_OFF:
 config.bits.en_crc = 0;
 break;
 case HAL_NRF_CRC_8BIT:
 config.bits.en_crc = 1;
 config.bits.crc0 = 0;
 break;
 case HAL_NRF_CRC_16BIT:
 config.bits.en_crc = 1;
 config.bits.crc0 = 1;
 break;
 default:
 break;
 }
 
 hal_nrf_write_reg (0x00, config.value);
 }
 
 void hal_nrf_set_irq_mode(hal_nrf_irq_source_t int_source, _Bool irq_state)
 {
 config_t config;
 config.value = hal_nrf_read_reg (0x00);
 
 switch (int_source)
 {
 case HAL_NRF_MAX_RT:
 config.bits.mask_max_rt = irq_state ? 0 : 1;
 break;
 case HAL_NRF_TX_DS:
 config.bits.mask_tx_ds = irq_state ? 0 : 1;
 break;
 case HAL_NRF_RX_DR:
 config.bits.mask_rx_dr = irq_state ? 0 : 1;
 break;
 }
 
 hal_nrf_write_reg (0x00, config.value);
 }
 
 uint8_t hal_nrf_get_clear_irq_flags(void)
 {
 uint8_t retval;
 
 retval = hal_nrf_write_reg (0x07, (0x40|0x20|0x10));
 
 return (retval & (0x40|0x20|0x10));
 }
 
 uint8_t hal_nrf_clear_irq_flags_get_status(void)
 {
 uint8_t retval;
 
 
 retval = hal_nrf_write_reg (0x07, (0x40|0x20|0x10)) & (0x40|0x20|0x10);
 retval |= hal_nrf_read_reg (0x07) & (0x08|0x04|0x02|0x01);
 
 return (retval);
 }
 
 
 void hal_nrf_clear_irq_flag(hal_nrf_irq_source_t int_source)
 {
 hal_nrf_write_reg (0x07, ((uint8_t) (1<<( (uint8_t) (int_source) ))));
 }
 
 uint8_t hal_nrf_get_irq_flags(void)
 {
 return hal_nrf_nop() & (0x40|0x20|0x10);
 }
 
 void hal_nrf_open_pipe(hal_nrf_address_t pipe_num, _Bool auto_ack)
 {
 en_pipes_t en_rxaddr;
 en_pipes_t en_aa;
 en_rxaddr.value = hal_nrf_read_reg (0x02);
 en_aa.value = hal_nrf_read_reg (0x01);
 
 switch(pipe_num)
 {
 case HAL_NRF_PIPE0:
 case HAL_NRF_PIPE1:
 case HAL_NRF_PIPE2:
 case HAL_NRF_PIPE3:
 case HAL_NRF_PIPE4:
 case HAL_NRF_PIPE5:
 en_rxaddr.value = en_rxaddr.value | ((uint8_t) (1<<( (uint8_t) (pipe_num) )));
 
 if(auto_ack)
 {
 en_aa.value = en_aa.value | ((uint8_t) (1<<( (uint8_t) (pipe_num) )));
 }
 else
 {
 en_aa.value = en_aa.value & ~((uint8_t) (1<<( (uint8_t) (pipe_num) )));
 }
 break;
 
 case HAL_NRF_ALL:
 en_rxaddr.value = (uint8_t)(~(0x40|0x80));
 
 if(auto_ack)
 {
 en_aa.value = (uint8_t)(~(0x40|0x80));
 }
 else
 {
 en_aa.value = 0;
 }
 break;
 
 case HAL_NRF_TX:
 default:
 break;
 }
 
 hal_nrf_write_reg (0x02, en_rxaddr.value);
 hal_nrf_write_reg (0x01, en_aa.value);
 }
 
 void hal_nrf_close_pipe(hal_nrf_address_t pipe_num)
 {
 en_pipes_t en_rxaddr;
 en_pipes_t en_aa;
 en_rxaddr.value = hal_nrf_read_reg (0x02);
 en_aa.value = hal_nrf_read_reg (0x01);
 
 switch(pipe_num)
 {
 case HAL_NRF_PIPE0:
 case HAL_NRF_PIPE1:
 case HAL_NRF_PIPE2:
 case HAL_NRF_PIPE3:
 case HAL_NRF_PIPE4:
 case HAL_NRF_PIPE5:
 en_rxaddr.value = en_rxaddr.value & ~((uint8_t) (1<<( (uint8_t) (pipe_num) )));
 en_aa.value = en_aa.value & ~((uint8_t) (1<<( (uint8_t) (pipe_num) )));
 break;
 
 case HAL_NRF_ALL:
 en_rxaddr.value = 0;
 en_aa.value = 0;
 break;
 
 case HAL_NRF_TX:
 default:
 break;
 }
 
 hal_nrf_write_reg (0x02, en_rxaddr.value);
 hal_nrf_write_reg (0x01, en_aa.value);
 }
 
 void hal_nrf_set_address(const hal_nrf_address_t address, const uint8_t *addr)
 {
 switch(address)
 {
 case HAL_NRF_TX:
 case HAL_NRF_PIPE0:
 case HAL_NRF_PIPE1:
 hal_nrf_write_multibyte_reg(0x20 + 0x0A + (uint8_t) address, addr, hal_nrf_get_address_width());
 break;
 case HAL_NRF_PIPE2:
 case HAL_NRF_PIPE3:
 case HAL_NRF_PIPE4:
 case HAL_NRF_PIPE5:
 hal_nrf_write_reg (0x0A + (uint8_t) address, *addr);
 break;
 
 case HAL_NRF_ALL:
 default:
 break;
 }
 }
 
 uint8_t hal_nrf_get_address(uint8_t address, uint8_t *addr)
 {
 switch (address)
 {
 case HAL_NRF_PIPE0:
 case HAL_NRF_PIPE1:
 case HAL_NRF_TX:
 return (uint8_t)hal_nrf_read_multibyte_reg (address, addr);
 default:
 *addr = hal_nrf_read_reg(0x0A + address);
 return 1;
 }
 }
 
 void hal_nrf_set_auto_retr(uint8_t retr, uint16_t delay)
 {
 setup_retr_t setup_retr;
 setup_retr.bits.ard = (delay >> 8);
 setup_retr.bits.arc = retr;
 
 hal_nrf_write_reg (0x04, setup_retr.value);
 }
 
 void hal_nrf_set_address_width(hal_nrf_address_width_t aw)
 {
 setup_aw_t setup_aw;
 setup_aw.bits.aw = (uint8_t)aw - 2;
 
 hal_nrf_write_reg (0x03, setup_aw.value);
 }
 
 uint8_t hal_nrf_get_address_width (void)
 {
 return hal_nrf_read_reg (0x03) + 2;
 }
 
 void hal_nrf_set_rx_payload_width(uint8_t pipe_num, uint8_t pload_width)
 {
 hal_nrf_write_reg (0x11 + pipe_num, pload_width);
 }
 
 uint8_t hal_nrf_get_pipe_status(uint8_t pipe_num)
 {
 en_pipes_t en_rxaddr;
 en_pipes_t en_aa;
 uint8_t en_rx_r, en_aa_r;
 
 en_rxaddr.value = hal_nrf_read_reg (0x02);
 en_aa.value = hal_nrf_read_reg (0x01);
 
 switch (pipe_num)
 {
 case 0:
 en_rx_r = en_rxaddr.bits.pipe_0;
 en_aa_r = en_aa.bits.pipe_0;
 break;
 case 1:
 en_rx_r = en_rxaddr.bits.pipe_1;
 en_aa_r = en_aa.bits.pipe_1;
 break;
 case 2:
 en_rx_r = en_rxaddr.bits.pipe_2;
 en_aa_r = en_aa.bits.pipe_2;
 break;
 case 3:
 en_rx_r = en_rxaddr.bits.pipe_3;
 en_aa_r = en_aa.bits.pipe_3;
 break;
 case 4:
 en_rx_r = en_rxaddr.bits.pipe_4;
 en_aa_r = en_aa.bits.pipe_4;
 break;
 case 5:
 en_rx_r = en_rxaddr.bits.pipe_5;
 en_aa_r = en_aa.bits.pipe_5;
 break;
 default:
 en_rx_r = 0;
 en_aa_r = 0;
 break;
 }
 
 return (uint8_t)(en_aa_r << 1) + en_rx_r;
 }
 
 uint8_t hal_nrf_get_auto_retr_status(void)
 {
 return hal_nrf_read_reg(0x08);
 }
 
 uint8_t hal_nrf_get_packet_lost_ctr(void)
 {
 return ((hal_nrf_read_reg(0x08) & (0x80|0x40|0x20|0x10)) >> 4);
 }
 
 uint8_t hal_nrf_get_rx_payload_width(uint8_t pipe_num)
 {
 uint8_t pw;
 
 switch (pipe_num)
 {
 case 0:
 pw = hal_nrf_read_reg (0x11);
 break;
 case 1:
 pw = hal_nrf_read_reg (0x12);
 break;
 case 2:
 pw = hal_nrf_read_reg (0x13);
 break;
 case 3:
 pw = hal_nrf_read_reg (0x14);
 break;
 case 4:
 pw = hal_nrf_read_reg (0x15);
 break;
 case 5:
 pw = hal_nrf_read_reg (0x16);
 break;
 default:
 pw = 0;
 break;
 }
 
 return pw;
 }
 
 void hal_nrf_set_rf_channel(uint8_t channel)
 {
 rf_ch_t rf_ch;
 rf_ch.bits.rf_ch = channel;
 hal_nrf_write_reg (0x05, rf_ch.value);
 }
 
 void hal_nrf_set_output_power(hal_nrf_output_power_t power)
 {
 rf_setup_t rf_setup;
 rf_setup.value = hal_nrf_read_reg (0x06);
 
 rf_setup.bits.rf_pwr = (uint8_t)power;
 
 hal_nrf_write_reg (0x06, rf_setup.value);
 }
 
 void hal_nrf_set_datarate(hal_nrf_datarate_t datarate)
 {
 rf_setup_t rf_setup;
 rf_setup.value = hal_nrf_read_reg (0x06);
 
 switch (datarate)
 {
 case HAL_NRF_250KBPS:
 rf_setup.bits.rf_dr_low = 1;
 rf_setup.bits.rf_dr_high = 0;
 break;
 case HAL_NRF_1MBPS:
 rf_setup.bits.rf_dr_low = 0;
 rf_setup.bits.rf_dr_high = 0;
 break;
 case HAL_NRF_2MBPS:
 default:
 rf_setup.bits.rf_dr_low = 0;
 rf_setup.bits.rf_dr_high = 1;
 break;
 }
 
 hal_nrf_write_reg (0x06, rf_setup.value);
 }
 
  _Bool hal_nrf_rx_fifo_empty(void)
 {
 return (_Bool)((hal_nrf_read_reg(0x17) >> 0) & 1);
 }
 
  _Bool hal_nrf_rx_fifo_full(void)
 {
 return (_Bool)((hal_nrf_read_reg(0x17)>> 1) & 1);
 }
 
  _Bool hal_nrf_tx_fifo_empty(void)
 {
 return (_Bool)((hal_nrf_read_reg(0x17) >> 4) & 1);
 }
 
  _Bool hal_nrf_tx_fifo_full(void)
 {
 return (_Bool)((hal_nrf_read_reg(0x17) >> 5) & 1);
 }
 
 uint8_t hal_nrf_get_tx_fifo_status(void)
 {
 return ((hal_nrf_read_reg(0x17) & ((1<<5)|(1<<4))) >> 4);
 }
 
 uint8_t hal_nrf_get_rx_fifo_status(void)
 {
 return (hal_nrf_read_reg(0x17) & ((1<<1)|(1<<0)));
 }
 
 uint8_t hal_nrf_get_fifo_status(void)
 {
 return hal_nrf_read_reg(0x17);
 }
 
 uint8_t hal_nrf_get_transmit_attempts(void)
 {
 return (hal_nrf_read_reg(0x08) & (0x08|0x04|0x02|0x01));
 }
 
  _Bool hal_nrf_get_carrier_detect(void)
 {
 return hal_nrf_read_reg(0x09) & 1;
 }
 
 void hal_nrf_activate_features(void)
 {return;}
 
 void hal_nrf_setup_dynamic_payload (uint8_t setup)
 {
 en_pipes_t dynpd;
 dynpd.value = setup & ~0xC0;
 
 hal_nrf_write_reg (0x1C, dynpd.value);
 }
 
 void hal_nrf_enable_dynamic_payload(_Bool enable)
 {
 feature_t feature;
 feature.value = hal_nrf_read_reg (0x1D);
 feature.bits.en_dpl = (enable) ? 1 : 0;
 
 hal_nrf_write_reg (0x1D, feature.value);
 }
 
 void hal_nrf_enable_ack_payload(_Bool enable)
 {
 feature_t feature;
 feature.value = hal_nrf_read_reg (0x1D);
 feature.bits.en_ack_pay = (enable) ? 1 : 0;
 
 hal_nrf_write_reg (0x1D, feature.value);
 }
 
 void hal_nrf_enable_dynamic_ack(_Bool enable)
 {
 feature_t feature;
 feature.value = hal_nrf_read_reg (0x1D);
 feature.bits.en_dyn_ack = (enable) ? 1 : 0;
 
 hal_nrf_write_reg (0x1D, feature.value);
 }
 
 void hal_nrf_write_tx_payload(const uint8_t *tx_pload, uint8_t length)
 {
 hal_nrf_write_multibyte_reg(0xA0, tx_pload, length);
 }
 
 void hal_nrf_write_tx_payload_noack(const uint8_t *tx_pload, uint8_t length)
 {
 hal_nrf_write_multibyte_reg(0xB0, tx_pload, length);
 }
 
 void hal_nrf_write_ack_payload(uint8_t pipe, const uint8_t *tx_pload, uint8_t length)
 {
 hal_nrf_write_multibyte_reg(0xA8 | pipe, tx_pload, length);
 }
 
 uint8_t hal_nrf_read_rx_payload_width()
 {
 return hal_nrf_read_reg(0x60);
 }
 
 uint16_t hal_nrf_read_rx_payload(uint8_t *rx_pload)
 {
 return hal_nrf_read_multibyte_reg(((uint8_t) (HAL_NRF_RX_PLOAD)), rx_pload);
 }
 
 uint8_t hal_nrf_get_rx_data_source(void)
 {
 return ((hal_nrf_nop() & (0x08|0x04|0x02)) >> 1);
 }
 
 void hal_nrf_reuse_tx(void)
 {
  do { RFCSN = 0; } while(((_Bool)0));
 hal_nrf_rw(0xE3);
  do { RFCSN = 1; } while(((_Bool)0));
 }
 
  _Bool hal_nrf_get_reuse_tx_status(void)
 {
 return (_Bool)((hal_nrf_get_fifo_status() & (1<<6)) >> 6);
 }
 
 void hal_nrf_flush_rx(void)
 {
  do { RFCSN = 0; } while(((_Bool)0));
 hal_nrf_rw(0xE2);
  do { RFCSN = 1; } while(((_Bool)0));
 }
 
 void hal_nrf_flush_tx(void)
 {
  do { RFCSN = 0; } while(((_Bool)0));
 hal_nrf_rw(0xE1);
  do { RFCSN = 1; } while(((_Bool)0));
 }
 
 uint8_t hal_nrf_nop(void)
 {
 uint8_t retval;
 
  do { RFCSN = 0; } while(((_Bool)0));
 retval = hal_nrf_rw(0xFF);
  do { RFCSN = 1; } while(((_Bool)0));
 
 return retval;
 }
 
 void hal_nrf_set_pll_mode(_Bool pll_lock)
 {
 rf_setup_t rf_setup;
 rf_setup.value = hal_nrf_read_reg (0x06);
 rf_setup.bits.pll_lock = (pll_lock) ? 1 : 0;
 
 hal_nrf_write_reg(0x06, rf_setup.value);
 }
 
 void hal_nrf_enable_continious_wave (_Bool enable)
 {
 rf_setup_t rf_setup;
 rf_setup.value = hal_nrf_read_reg (0x06);
 rf_setup.bits.cont_wave = (enable ? 1 : 0);
 
 hal_nrf_write_reg(0x06, rf_setup.value);
 }
 
 uint8_t hal_nrf_read_reg(uint8_t reg)
 {
 uint8_t temp;
 
  do { RFCSN = 0; } while(((_Bool)0));
 
  do{RFDAT = reg; RFSPIF = 0;} while(((_Bool)0));
 while((!RFSPIF)) {}
 temp = RFDAT;
 
  do{RFDAT = 0; RFSPIF = 0;} while(((_Bool)0));
 while((!RFSPIF)) {}
 temp = RFDAT;
 
  do { RFCSN = 1; } while(((_Bool)0));
 
 return temp;
 }
 
 uint8_t hal_nrf_write_reg(uint8_t reg, uint8_t value)
 {
 uint8_t retval;
 
 
 
 uint8_t volatile dummy;
 
  do { RFCSN = 0; } while(((_Bool)0));
 
  do{RFDAT = (0x20 + reg); RFSPIF = 0;} while(((_Bool)0));
 while((!RFSPIF)) {}
 retval = RFDAT;
 
  do{RFDAT = value; RFSPIF = 0;} while(((_Bool)0));
 while((!RFSPIF)) {}
 dummy = RFDAT;
 
  do { RFCSN = 1; } while(((_Bool)0));
 
 return retval;
 }
 
 

















 
 uint16_t hal_nrf_read_multibyte_reg(uint8_t reg, uint8_t *pbuf)
 {
 uint8_t ctr, length;
 uint8_t memtype;
 uint8_t read_byte;  
  _Bool first_round;
 first_round = ((_Bool)1);
 
 memtype = *(uint8_t*)(&pbuf);
 
 switch(reg)
 {
 case HAL_NRF_PIPE0:
 case HAL_NRF_PIPE1:
 case HAL_NRF_TX:
 length = ctr = hal_nrf_get_address_width();
  do { RFCSN = 0; } while(((_Bool)0));
 hal_nrf_rw(0x0A + reg);
 break;
 
 case HAL_NRF_RX_PLOAD:
 if( (reg = hal_nrf_get_rx_data_source()) < 7)
 {
 length = ctr = hal_nrf_read_rx_payload_width();
  do { RFCSN = 0; } while(((_Bool)0));
 hal_nrf_rw(0x61);
 }
 else
 {
 ctr = length = 0;
 }
 break;
 
 default:
 ctr = length = 0;
 break;
 }
 
 if (memtype == 0x00)
 {
 uint8_t data *buf = (uint8_t data *)pbuf;
  do { do{RFDAT = 0; RFSPIF = 0;} while(((_Bool)0)); if (first_round == ((_Bool)0)) { *buf = read_byte; buf++; } else { first_round = ((_Bool)0); } while((!RFSPIF)){} read_byte = RFDAT; } while (--ctr); *buf = read_byte;
 }
 else if (memtype == 0x01)
 {
 uint8_t xdata *buf = (uint8_t xdata *)pbuf;
  do { do{RFDAT = 0; RFSPIF = 0;} while(((_Bool)0)); if (first_round == ((_Bool)0)) { *buf = read_byte; buf++; } else { first_round = ((_Bool)0); } while((!RFSPIF)){} read_byte = RFDAT; } while (--ctr); *buf = read_byte;
 }
 else if (memtype == 0xFE)
 {
 uint8_t pdata *buf = (uint8_t pdata *)pbuf;
  do { do{RFDAT = 0; RFSPIF = 0;} while(((_Bool)0)); if (first_round == ((_Bool)0)) { *buf = read_byte; buf++; } else { first_round = ((_Bool)0); } while((!RFSPIF)){} read_byte = RFDAT; } while (--ctr); *buf = read_byte;
 }
 else
 {
 uint8_t *buf = (uint8_t *)pbuf;
  do { do{RFDAT = 0; RFSPIF = 0;} while(((_Bool)0)); if (first_round == ((_Bool)0)) { *buf = read_byte; buf++; } else { first_round = ((_Bool)0); } while((!RFSPIF)){} read_byte = RFDAT; } while (--ctr); *buf = read_byte;
 }
 
  do { RFCSN = 1; } while(((_Bool)0));
 
 return (((uint16_t) reg << 8) | length);
 }
 
 








 void hal_nrf_write_multibyte_reg(uint8_t cmd, const uint8_t *pbuf, uint8_t length)



 {
 uint8_t memtype;
 uint8_t next;
 uint8_t volatile dummy;
 
 memtype = *(uint8_t*)(&pbuf);
 
  do { RFCSN = 0; } while(((_Bool)0));
  do{RFDAT = cmd; RFSPIF = 0;} while(((_Bool)0));
 
 if (memtype == 0x00)
 {
 const uint8_t data *buf = (const uint8_t data *)pbuf;
  do { next = *buf; buf++; while((!RFSPIF)) {} dummy = RFDAT; do{RFDAT = next; RFSPIF = 0;} while(((_Bool)0)); } while (--length);
 }
 else if (memtype == 0x01)
 {
 const uint8_t xdata *buf = (const uint8_t xdata *)pbuf;
  do { next = *buf; buf++; while((!RFSPIF)) {} dummy = RFDAT; do{RFDAT = next; RFSPIF = 0;} while(((_Bool)0)); } while (--length);
 }
 else if (memtype == 0xFE)
 {
 const uint8_t pdata *buf = (const uint8_t pdata *)pbuf;
  do { next = *buf; buf++; while((!RFSPIF)) {} dummy = RFDAT; do{RFDAT = next; RFSPIF = 0;} while(((_Bool)0)); } while (--length);
 }
 else
 {
 const uint8_t *buf = (const uint8_t *)pbuf;
  do { next = *buf; buf++; while((!RFSPIF)) {} dummy = RFDAT; do{RFDAT = next; RFSPIF = 0;} while(((_Bool)0)); } while (--length);
 }
 
 while((!RFSPIF)) {}  
 dummy = RFDAT;
  do { RFCSN = 1; } while(((_Bool)0));
 }
