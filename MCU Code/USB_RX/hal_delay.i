
#line 1 "..\hal\hal_delay.c" /0











 
 









 
 
  
#line 1 "..\hal\hal_delay.h" /0
 
 
  
#line 1 "..\compiler\c51\stdint.h" /0











 
 








 
 
 
 
 
 
 
 typedef unsigned char uint8_t;         
 
 typedef signed char int8_t;           
 
 typedef unsigned int uint16_t;         
 
 typedef signed int int16_t;           
 
 typedef unsigned long uint32_t;        
 
 typedef signed long int32_t;          
 
 
 
 
 
 
 
 
#line 3 "..\hal\hal_delay.h" /0
 
 





 
 void delay_us(uint16_t us);
 


 
 void delay_ms(uint16_t ms);
 
 
 
#line 25 "..\hal\hal_delay.c" /0
 
  
#line 1 "..\compiler\common\memdefs.h" /0
 
 
 
 
 
 
 
 
#line 9 "..\compiler\common\memdefs.h" /1
 
  
  
  
  
  
  
  
  
 
 
 
  
 
 
 
 
  
 
 
  
 
 
 
#line 33 "..\compiler\common\memdefs.h" /0
 
 
#line 26 "..\hal\hal_delay.c" /0
 
 
 
 
 
  
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
 
 
 
 
#line 31 "..\hal\hal_delay.c" /0
 
 
#line 33 "..\hal\hal_delay.c" /1
  
 
 
#line 36 "..\hal\hal_delay.c" /0
 
 void delay_us(uint16_t us)
 {
 do
 {
 _nop_();
 _nop_();
 _nop_();
 _nop_();
 _nop_();
 } while (--us);
 }
 
 void delay_ms(uint16_t ms)
 {
 do
 {
 delay_us(250);
 delay_us(250);
 delay_us(250);
 delay_us(250);
 } while (--ms);
 }
 
 
