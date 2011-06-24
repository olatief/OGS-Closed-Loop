
#include "hardware.h"

#include <nordic_common.h>
#include <intrins.h>
#include <stdint.h>
#include <stdbool.h>
#include "hal_nrf.h"
#include "hal_nrf_hw.h"
#include "hal_adc.h"
#include "timer.h"
#include "led.h"

#define SIZEOFPROG 11

#define MAXLENGTH 30
#define MAXBLOCKS  4
#define CALC_PAYLOAD_PTR(bl) payload+bl*MAXPAYLOAD
 
// Global variables
data bool radio_busy;
void init_radio();
void init_adc();

data uint8_t acq_block;	 // current block thats acquiring data
data uint8_t payload[2][MAXLENGTH+1];
data uint8_t progPayload[15];

data uint8_t *ptr_payload;
data uint8_t cnt;
data uint8_t dataNeedsTx;
data bool procPayload = false;

data progAll *pAll;
data progStim pStim;
data progAlgo pAlgo;

uint16_t low_thresh = 500;
uint16_t high_thresh = 900;
uint8_t pktCount = 0;

void main()
{
  uint8_t is = 0;;
  acq_block = 0;
  P1DIR = ~((1<<6) | (1<<5) | (1<<3));
  P0CON = 0x66;

  #ifdef MCU_NRF24LU1P
     USBSLP = 0x01;  // disable usb
    // P0DIR = (1<<3)|(1<<1)|(1<<0);
	// P0ALT = 0x0F;
	// P0EXP = 0x02; // Slave SPI for P0
	// SSCONF = 0x01; //Enable slave SPI
	 
	 // Enable radio SPI
	 RFCTL = 0x10;
//	  I3FR = 1;             // rising edge SPI ready detect
	  P0_0 = 0;
//	  INTEXP = 0x01; //Slave SPI Interrupt
  #else
//  	P0DIR =  ~((1<<4)|(1<<0));
 // 	SPISCON0 = 0x40;
//	I3FR = 1;             // rising edge SPI ready detect
//	P1_4 = 1;
  //	INTEXP = 0x01; //Slave SPI Interrupt

  #endif

 // SPI = 1; // Enable SPI Interrupt


 //  ET0 = 1; // enable timer interrupt
  // EX0 = 1; 


 //  hal_digi_init();
//   hal_digi_write(0);


	for(is = 1; is <= 14; ++is)
	{
		prog_led(is);
	}

   	prog_led(0);

	init_radio();
	init_adc(); 
	initTimer();
	cnt = MAXLENGTH;
	dataNeedsTx = 0;
	hal_adc_start();
	procPayload = false;

	for(;;)
	{
		if(dataNeedsTx)
		{
			P1_4 = 1;
			++pktCount;
			payload[((acq_block^(0x01))&(0x01))][MAXLENGTH] = (isStimulating) + (pktCount&(0x7F)); 
			hal_nrf_write_tx_payload(payload[((acq_block^(0x01))&(0x01))],MAXLENGTH+1);
			P1_4 = 0;
			radio_busy = true;
			    // Toggle radio CE signal to start transmission 
		    CE_PULSE();
		
		    
		
		    // Wait for radio operation to finish
		    while(radio_busy);
			
			if(procPayload)
			{
				procPayload = false;
				pAll = (progAll *)progPayload;
			
				if(pAll->pType == PROGSTIM)
				{
					pStim = pAll->pStim;
					
					// g_Amplitude = pStim.Amplitude;

					if(0 == pStim.Freq)
					{
					   ET2 = 0;	  // disable timer2 interrupt
					   prog_led(pStim.Amplitude);	
					}
					else
					{
						ET2 = 1;
						progTimer(&pStim);
					}
				} 
				if(pAll->pType == PROGALGO)
				{
					pAlgo = pAll->pAlgo;
					low_thresh = pAlgo.low;
					high_thresh = pAlgo.high;
					progSD(&pAlgo);
				}	
			}
			dataNeedsTx = 0;
		}
	}
}

uint8_t lowThreshPassed = 0;
uint8_t highThreshPassed = 0;

void adc_irq() interrupt INTERRUPT_MISCIRQ	// should only be called for ADC, RNG is disabled
{ 	
	uint16_t tempVal;
		
		*ptr_payload = ADCDATH;
		++ptr_payload;
		*ptr_payload = ADCDATL;	   // big-endian storage
	  	++ptr_payload;

		tempVal = (ADCDATH << 8) + ADCDATL;

		if( tempVal > low_thresh)
		{
			lowThreshPassed = 1;
		} else {
			lowThreshPassed = 0;
			highThreshPassed = 0;
		}

		if(lowThreshPassed && !highThreshPassed && tempVal > high_thresh)
		{
				// P1_6 ^= 1;
				peakDetect();
				lowThreshPassed = 0;
				highThreshPassed = 1;
		}
		cnt -= 2; 
	
		if(cnt==0)
		{
			cnt = MAXLENGTH;
			acq_block &= 1;
			acq_block ^= 1; // toggle current acquisition block
			ptr_payload = payload[acq_block];  // reset data pointer
			dataNeedsTx = 1; 
		}	
}

void init_adc()
{
   hal_adc_set_input_channel(HAL_ADC_INP_AIN0);                     
   hal_adc_set_reference(HAL_ADC_REF_INT);                        
   hal_adc_set_acq_window(HAL_ADC_AQW_12US);
   hal_adc_set_input_mode(HAL_ADC_DIFF_AIN2);                             
   hal_adc_set_conversion_mode(HAL_ADC_CONTINOUS);               
   hal_adc_set_resolution(HAL_ADC_RES_12BIT);                          
   hal_adc_set_data_just(HAL_ADC_JUST_RIGHT);
   hal_adc_set_sampling_rate(HAL_ADC_16KSPS);
   
   MISC = 1; // Enable ADC interrupt through MISC interrupt 
}

void init_radio()
{
  // Enable the radio clock
  RFCKEN = 1;
  // Enable RF interrupt
  RF = 1;
    // Power up radio
  hal_nrf_set_power_mode(HAL_NRF_PWR_UP);

  	hal_nrf_enable_ack_payload(1);
	hal_nrf_enable_dynamic_payload(1);
	hal_nrf_setup_dynamic_payload(1); // Set up PIPE 0 to handle dynamic lengths
	hal_nrf_set_rf_channel(125); // 2525 MHz
   	hal_nrf_set_auto_retr(20, 250); // Retry 5x
    // Configure radio as primary receiver (PTX) 
  hal_nrf_set_operation_mode(HAL_NRF_PTX);
 
      // Set payload width to 32 bytes
//  hal_nrf_set_rx_payload_width(HAL_NRF_PIPE0, MAXLENGTH);
   // Enable global interrupt
  EA = 1;
}

// Radio interrupt
void rf_irq() interrupt INTERRUPT_RFIRQ
{
  uint8_t irq_flags;

  // Read and clear IRQ flags from radio
  irq_flags = hal_nrf_get_clear_irq_flags(); 

  switch(irq_flags)
  {
    // Transmission success
	case ( (1 << HAL_NRF_RX_DR) | (1 << HAL_NRF_TX_DS) ):	  // We rx payload packet
	   	procPayload = true;
	   	// Read payload
		while(!hal_nrf_rx_fifo_empty())
  	 	{
	    	hal_nrf_read_rx_payload(progPayload);
		}
	  	radio_busy = false;
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
      hal_nrf_flush_tx();
	  TEST_PIN ^= 1;
      radio_busy = false;
      break;
  }
}

