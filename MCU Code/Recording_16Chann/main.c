#include <reg24le1.h>
#include <intrins.h>
#include <stdint.h>

#include <nordic_common.h> 

#include "hal_nrf.h"
#include "hal_nrf_hw.h"
#include "hal_spi.h"

#define MAXLENGTH 30 // This is how	many bytes are allocated for the raw data
#define MAXBLOCKS  3
#define CALC_PAYLOAD_PTR(bl) payload+bl*MAXPAYLOAD

void init_radio();
void init_pwm();

 sbit P0_0 = P0^0;
  sbit P0_4 = P0^4;
  sbit P0_5 = P0^5;
  sbit P1_6 = P1^6;
  sbit P0_7 = P0^7;
  sbit P1_4 = P1^4;
  sbit P1_5 = P1^5;
  sbit P1_7 = P1^7;

data uint8_t g_Amplitude = 0;
data uint8_t g_acq_block;	 // current block thats acquiring data
data uint8_t blockToSend;
data uint8_t volatile data payload[2][MAXLENGTH+1];

uint8_t volatile data * volatile ptr_payload;
uint8_t volatile data g_cnt;
uint8_t volatile data g_dataNeedsTx;

 // Global variables
bool radio_busy;

//#define DEBUG
//#define FOURPIN
uint8_t data pktCount = 0;

#ifdef DEBUG

xdata uint16_t timer_high = 0;
xdata uint16_t timer_low = 0;
void progTimer(uint8_t Freq, uint8_t DC);

#endif
void main()
{
// 0 = output
	#ifdef FOURPIN
	P0DIR &= ~(1<<4);
	#else
	
	P1_5 = 0;
	P1_4 = 0;
	#endif
//	P0DIR &= ~( (1<<7) | (1<<5) );  	// SMOSI, SSCK

//	P1DIR &= ~(1<<6);
 #ifndef DEBUG
	hal_spi_slave_preload(0xAA);
	hal_spi_slave_preload(0xAA);
	// VERY IMPORTANT: we need to ensure we sample a byte on a clock transition from high to low (MODE 1 or MODE 2) should do this
	hal_spi_slave_init( HAL_SPI_MODE_1, HAL_SPI_LSB_MSB);

	SPISCON0 &= ~ (1<<4);	// Enable irqSpiSlaveDone

//	    P1_6 = 0;
 #else

 	progTimer(240, 50);	
	   CRCL = 0xF0;
   CRCH = 0xF0;
	   CCEN = 0x02;  // Compare enabled
      /*T2CON: */
   T2PS = 1; // CLK/24 , no reload
   T2R1 = 1;
  // T2CM = 1;	
   T2I0 = 1; // Turn on timer
    ET2 = 1; // Enable timer 2 interrupt	
 #endif	

   g_cnt = 30;  
   	RFCKEN = 1;	   // Enable the radio clock
    
	init_radio();
	init_pwm();
#ifndef	DEBUG
	SPI = 1;
#endif	
    // Enable global interrupt
	EA = 1;


    for(;;)
    {
//	g_dataNeedsTx = 1;
		if(1 == g_dataNeedsTx)
		{

			P1_5 = 1;
			++pktCount;
			blockToSend = ((g_acq_block^(0x01))&(0x01));
			payload[blockToSend][MAXLENGTH] = (pktCount&(0x7F));
			hal_nrf_write_tx_payload_noack(payload[blockToSend],MAXLENGTH+1);
			P1_5 = 0;
	
			radio_busy = true;
	
			CE_PULSE();
	
			while(radio_busy);			\
	
			g_dataNeedsTx = 0;
		}
    }

}

void init_pwm()
{
    PWMDC0 =  0x0F; // 50% Duty Cycle for 5 bit period
	PWMDC1 =  0x0F; // 50% Duty Cycle for 5 bit period
	PWMCON |= (0<<2); // set prescaler to (0+1)=1. same as ~516kHz square wave
	PWMCON |= 0x01; // Enables PWM0, freq=CCLK/31, 5 bit period
	
}	

#ifdef DEBUG
T2_ISR()
{
   volatile uint8_t data test = 0x55;

	P1_4=1;
	test = SPISSTAT;

 //	test = ;// hal_spi_slave_rw(0xAA);
//	test = SPISDAT;
	*ptr_payload = SPISDAT;
	++ptr_payload;

	--g_cnt;

	if(0 == g_cnt)
	{
		g_cnt = MAXLENGTH;
		g_acq_block = (g_acq_block&(0x01))^(0x01); // toggle current acquisition block
		ptr_payload = payload[g_acq_block];
		g_dataNeedsTx = 1;
	}
	P1_4 = 0;

	
		CRCL = timer_low&0xFF;
		CRCH = timer_low>>8;
  
	
	TF2 = 0;	
}

void progTimer(uint8_t Freq, uint8_t DC)
{
	data uint32_t period = 0;
	xdata uint32_t period_us = (uint32_t)1e6/((uint32_t)Freq);
	period = (uint32_t)period_us*(uint32_t)2/3;
	timer_high = DC*period/100;
	timer_low = period - timer_high;
	timer_high = 2^16-timer_high;	
	timer_low = 2^16-timer_low;
}

#endif

SER_ISR()
{
	uint8_t volatile data test;
	
	P1_4=1;
	test = SPISSTAT;

	*ptr_payload = (uint8_t)SPISDAT;
	++ptr_payload;

	--g_cnt;

	if(0 == g_cnt)
	{
		g_cnt = MAXLENGTH;
		g_acq_block = (g_acq_block&(0x01))^(0x01); // toggle current acquisition block
		ptr_payload = payload[g_acq_block];
		g_dataNeedsTx = 1;

	}
	P1_4 = 0;
//	P1 ^= (1<<6);
}

void init_radio()
{
  // Enable the radio clock
  RFCKEN = 1;
  // Enable RF interrupt
  RF = 1;
    // Power up radio
  hal_nrf_set_power_mode(HAL_NRF_PWR_UP);

  	hal_nrf_enable_ack_payload(0);
	hal_nrf_enable_dynamic_ack(1);	// Lets us use the no_ack cmd
//	hal_nrf_enable_dynamic_payload(1);
//	hal_nrf_setup_dynamic_payload(1); // Set up PIPE 0 to handle dynamic lengths
	hal_nrf_set_rf_channel(125); // 2525 MHz
   	hal_nrf_set_auto_retr(0, 250); // Retry 5x
 
    // Configure radio as primary receiver (PTX) 
  hal_nrf_set_operation_mode(HAL_NRF_PTX);
 
      // Set payload width to 32 bytes
//  hal_nrf_set_rx_payload_width(HAL_NRF_PIPE0, MAXLENGTH);

}

// Radio interrupt
void rf_irq() interrupt INTERRUPT_RFIRQ
{
  uint8_t irq_flags;
  //uint8_t retval;
	  uint8_t dummy;
  P1_5 = 1;
  // Read and clear IRQ flags from radio
  /** irq_flags = hal_nrf_get_clear_irq_flags();  **/
  /**   retval = hal_nrf_write_reg (STATUS, (BIT_6|BIT_5|BIT_4)); **/

/*lint -esym(550,dummy) symbol not accessed*/
/*lint -esym(438,dummy) last assigned value not used*/
/*lint -esym(838,dummy) previously assigned value not used*/
  

  CSN_LOW();

  HAL_NRF_HW_SPI_WRITE((W_REGISTER + STATUS));
  while(HAL_NRF_HW_SPI_BUSY) {}
  irq_flags = HAL_NRF_HW_SPI_READ();

  HAL_NRF_HW_SPI_WRITE((BIT_6|BIT_5|BIT_4));
  while(HAL_NRF_HW_SPI_BUSY) {}
  dummy = HAL_NRF_HW_SPI_READ();

  CSN_HIGH();

  irq_flags = irq_flags & (BIT_6|BIT_5|BIT_4);
  /* end */
  switch(irq_flags)
  {
    // Transmission success
    case ( (1 << HAL_NRF_RX_DR) | (1 << HAL_NRF_TX_DS) ):	  // We rx payload packet
//	   	procPayload = true;
	   	// Read payload
		while(!hal_nrf_rx_fifo_empty())
  	 	{
	    //	hal_nrf_read_rx_payload(progPayload);
		}
	  	radio_busy = false;
		break;
	case (1 << HAL_NRF_TX_DS):
      radio_busy = false;
      // Data has been sent
      break;
    // Transmission failed (maximum re-transmits)
    case (1 << HAL_NRF_MAX_RT):
      // When a MAX_RT interrupt occurs the TX payload will not be removed from the TX FIFO. 
      // If the packet is to be discarded this must be done manually by flushing the TX FIFO.
      // Alternatively, CE_PULSE() can be called re-starting transmission of the payload.
      // (Will only be possible after the radio irq flags are cleared) 
     
	 /* hal_nrf_flush_tx();	*/
	 CSN_LOW();
	  SPIRDAT = FLUSH_TX;
  while(!(SPIRSTAT & 0x02)) // wait for byte transfer finished
  {
  }
  CSN_HIGH();
  /* end */
      radio_busy = false;
      break;
  }
  
  P1_5 = 0;
}