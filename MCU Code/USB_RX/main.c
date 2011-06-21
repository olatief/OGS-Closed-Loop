#include <Nordic\reg24lu1.h>
#include <intrins.h>
#include <stdint.h>
#include <stdio.h>

#include "usb.h"
#include "hal_usb.h"
#include "hal_usb_desc.h"
#include "usb_cmds.h"
#include "config.h"
  
#include "cklf.h"   
#include "cpu.h"   

#include "nordic_common.h"  

#include "hal_nrf.h"
#include "hal_nrf_hw.h"

#include "usb_map.h"

#define SIZEOFPROG 11
#define PKTLENGTH 32

 // Calculate buffer location in USB-controller
#define CALCULATE_BUF_IN_PTR(ep) (uint8_t xdata *)(in0buf - (( ep & 0x7f) * 128))
#define CALCULATE_BUF_OUT_PTR(ep) (uint8_t xdata *)(out0buf - (ep * 128 ))

// Calculate byte count register location in USB-controller
#define CALCULATE_BC_OUT_PTR(ep) (uint8_t xdata *)(&out0bc + (ep * 2 ))
#define CALCULATE_BC_IN_PTR(ep) (uint8_t xdata *)(&in0bc + ((ep & 0x7f ) * 2))

#define MSB(x) (x>>8)
#define LSB(x) (x&(0xFF))

static hal_usb_dev_req_resp_t device_req_cb(hal_usb_device_req* req, uint8_t** data_ptr, uint16_t* size) reentrant;   
static void suspend_cb(uint8_t allow_remote_wu) reentrant;   
static void resume_cb() reentrant;   
static void reset_cb() reentrant;   
static code uint8_t ep_1_in_cb(uint8_t *adr_ptr, uint8_t* size) reentrant;   
//static code uint8_t ep_1_out_cb(uint8_t *adr_ptr, uint8_t* size) reentrant; 

static void usb_process_get_descriptor(hal_usb_device_req* req, uint8_t** data_ptr, uint16_t* size, hal_usb_dev_req_resp_t* resp);
static void usb_wait_for_configuration(void);
static void radio_init();
 
//app_states_t app_susp_wd(void); 

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
static bool ep1_sent, ep2_sent, ep2_rx; 
static uint8_t *e_arr;
static uint8_t e_size;
// Global variables
data bool radio_busy;
//data uint8_t temp = 0;
data uint8_t block = 0;
data uint8_t byteCnt = 0;
data uint8_t blockAcquired = 0;
data uint8_t blockNeedsSending = 0;
data uint8_t payload[2][PKTLENGTH];


uint8_t data ackPayload[SIZEOFPROG];
// uint8_t payload[2][30];
  sbit P0_0 = P0^0;
  sbit P0_4 = P0^4;
  sbit P0_5 = P0^5;
  sbit P0_6 = P0^6;
  sbit P0_7 = P0^7;

void main(void) 
{
	data app_states_t app_state = APP_INIT;  
	CLKCTL = 0;                                 // Reset clock control register
	P0DIR = (1<<3)|(1<<1)|(1<<0);
//	P0DIR = 0x18;                               // Output: P0.0 - P0.2, Input: P0.3 - P0.5   
  //	P0ALT = 0;                                  // All general I/O   
  //	P0 = 0;
   /* 
	 P0ALT = 0x0F;
	 P0EXP = 0x02; // Slave SPI for P0
	 SSCONF = 0x01; //Enable slave SPI
	 */
	CE_LOW();                                   // Radio chip enable low   
  	RFCTL = 0x10;                               // Internal MCU to radio SPI enable    
  	RFCKEN = 1;                                 // Radio clk enable   
  	RF = 1;                                     // Radio IRQ enable
										// Enable global interrupt
  
	/** USB-init **/
	usbpair |= 0x01;
	hal_usb_init(true, device_req_cb, reset_cb, resume_cb, suspend_cb);
	hal_usb_endpoint_config(0x82, 32, ep_1_in_cb);
	hal_usb_endpoint_config(0x02, 32, ep_1_out_cb);
	
	ep1_sent = true;   
  	ep2_sent = true;   
  	usb_state = USB_AWAKE;   
	

	EA = 1;
	usb_wait_for_configuration();               // Wait until USB enumerated
	
	byteCnt = PKTLENGTH;
	
	payload[1][PKTLENGTH-1] = 0xAA;
	payload[0][PKTLENGTH-1] = 0xAA;

	for(;;)
	{
		switch(app_state)
		{
		  case APP_INIT:
		  	app_state = app_init();
			break;   
	      case APP_NORMAL:                                                        // Normal state   
	        app_state = app_normal();   
	        break;   
	      case APP_SUSP_WE:                                                       // PC suspend state, remote wakeup enabled   
	      case APP_SUSP_WD:                                                       // PC suspend state, remote wakeup disabled   
	       // P0_4=1;
			app_state = app_susp_we();
		//	P0_4=0;   
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
	
	if(ep2_rx) // process data we got over USB
	{
		ep2_rx = false;

		hal_nrf_write_ack_payload(0, ackPayload, SIZEOFPROG);
	//	hal_usb_send_data(2, "\x00\x00", 2);	
	}

  	if(blockNeedsSending) // process data from Wireless
	{
		blockNeedsSending = 0;

	/*   hal_usb_send_data(1,  payload[0], 31); */
	    P0_5=1;
    // Calculate the buffer pointer and byte count pointer

	    buf_ptr = CALCULATE_BUF_IN_PTR(2);
	    bc_ptr = CALCULATE_BC_IN_PTR(2);
		
		if( 0 == block )
		{
		//	buf_ptr = buf_ptr + 31; 
		}
	    // Copy the data into the USB controller
	    for( i = 0; i < PKTLENGTH; ++i )
	    {
	        buf_ptr[i] = payload[block][i];
	    }
    
//	    buf_ptr[30] = block + (0xAA);
    	*bc_ptr = PKTLENGTH;
		// Set the number of bytes we want to send to USB-host. This also trigger sending of data to USB-host.
    	

		if(block)
		{
			block = 0;
		} else {
		 	block = 1;
		}
		P0_5=0;
		/********/
    	/*
		// Write payload to radio USB FIFO
    	hal_usb_send_data(1, payload[(block^0x01)], 31);
		blockNeedsSending = 0;*/
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
   /*
   	I3FR = 1;             // rising edge SPI ready detect
  	INTEXP = 0x01; //Slave SPI Interrupt
	SPI = 1; // Enable SPI Interrupt
	 */
	hal_nrf_enable_ack_payload(1);
	hal_nrf_enable_dynamic_payload(1);
	hal_nrf_setup_dynamic_payload(1 << 0); // Set up PIPE 0 to handle dynamic lengths
	hal_nrf_set_rf_channel(125); // 2525 MHz
	hal_nrf_set_operation_mode(HAL_NRF_PRX);  		// Configure radio as primary receiver (PTX) 
	//hal_nrf_set_rx_payload_width(HAL_NRF_PIPE0, 30);	// Set payload width to 30 bytes
	hal_nrf_set_power_mode(HAL_NRF_PWR_UP);	 		// Power up radio
	CE_HIGH();	   // Enable receiver
	
	return APP_NORMAL; 	
}

app_states_t app_susp_we(void)   
{   
//  wdp_host_rx_setup(WDP_RX_SUSPEND);          // Set up WDP low power receive mode   
	
	usb_wakeup();
	return APP_NORMAL;
	CE_LOW();
	hal_nrf_set_power_mode(HAL_NRF_PWR_DOWN);	 		// Power up radio
	
  	RFCKEN = 0;  	// disable the radio clock    
  //  usb_wakeup();   
 //   return APP_NORMAL;    
      
  // Minimize the powerconsumption by powering down the MCU    
  cklf_gpio_wakeup(0x0000, 0x0000);           // GPIO wakeup off   
  cklf_rtc_disable();   
  cklf_rtc_init(0x00, 0x1FFF);                // Setup power down timeout to app. 1 s   
  cpu_pwr_down();                             // MCU goto sleep   
          
  WUF = 0;                                    // Clear WU flag   
   
  return APP_SUSP_WE;      
} 
	
	void slave_spi() interrupt INTERRUPT_SPI
	{
	 // P0_5 = 1;
	  
	  if(byteCnt==0)
	  {
		byteCnt = PKTLENGTH;
		block^=0x01; // switch block
		blockNeedsSending = 1;
	  }
	
	  byteCnt = (byteCnt - 1);
	 
	  payload[block][byteCnt] = SSDATA;
	//  P0_5 = 0;
	}  				
// Rado interrupt 
void rf_irq() interrupt INTERRUPT_RFIRQ
{
  uint8_t irq_flags;
  uint8_t data *pbuf = payload[block];
  uint8_t data ctr = 0;
  
  P0_5=1;
  // Read and clear IRQ flags from radio
    CSN_LOW();
  // retval = hal_nrf_rw(W_REGISTER + reg);

  RFDAT = W_REGISTER + STATUS;
  RFSPIF = 0;     // ! IMPORTANT ! Clear RF SPI ready flag
                  // after data written to RFDAT..
  while(!RFSPIF); // wait for byte transfer finished
    
  irq_flags = RFDAT;   // return SPI read value


  RFDAT = (BIT_6|BIT_5|BIT_4);
  RFSPIF = 0;     // ! IMPORTANT ! Clear RF SPI ready flag
                  // after data written to RFDAT..
  while(!RFSPIF); // wait for byte transfer finished
    
  // retval = RFDAT;   // return SPI read value

 //  hal_nrf_rw(value);
  CSN_HIGH();						 
  irq_flags = irq_flags & (BIT_6|BIT_5|BIT_4);
 // irq_flags = hal_nrf_get_clear_irq_flags(); 
  

  // If data received
  if(irq_flags & (1<<HAL_NRF_RX_DR))
  {
    // Read payload
   // while(!hal_nrf_rx_fifo_empty())
   // {
	     // hal_nrf_read_rx_payload(payload[0]);
		 //hal_nrf_read_multibyte_reg( (uint8_t)HAL_NRF_RX_PLOAD, payload[0]);
		if( (hal_nrf_get_rx_data_source()) < 7)
	      {
	        ctr = hal_nrf_read_rx_payload_width();
	        CSN_LOW();
	        hal_nrf_rw(R_RX_PAYLOAD);
	      }
	      else
	      {
	        ctr = 0;
	      }
	  
		   
		 while(ctr--)
	  	{
			RFDAT = 0;
  			RFSPIF = 0;     // ! IMPORTANT ! Clear RF SPI ready flag
                  // after data written to RFDAT..
  			while(!RFSPIF); // wait for byte transfer finished
    
  		  //return RFDAT;   // return SPI read value
	    	*pbuf++ = RFDAT;
	  	}

  		CSN_HIGH();
		
    // Write received payload[0] to port 0
//	P0=(payload[0]&(1<<5));
	   blockNeedsSending = 1;
	//}
	
  }
  P0_5=0;
}
																	  
static void radio_init()
{
	  // Enable radio SPI
  	RFCTL = 0x10; 
	/** RF init **/
	RF = 1;	 		// Enable RF interrupt
  	RFCKEN = 1;  	// Enable the radio clock

  	hal_nrf_set_operation_mode(HAL_NRF_PRX);  		// Configure radio as primary receiver (PRX) 
//	hal_nrf_set_rx_payload_width(HAL_NRF_PIPE0, 30);	// Set payload width to 3 bytes
/*	hal_nrf_set_power_mode(HAL_NRF_PWR_UP);	 		// Power up radio
	CE_HIGH();	   // Enable receiver 
*/
	return;
}

void usb_wakeup(void)   
{   
  hal_usb_wakeup();
 // radio_init();   
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
  USBSLP = 1; // Disable USB clock (auto clear)   
  
  if (allow_remote_wu == 1)   
  {   
    // Enable wake-up on USB and USBWU (bit3:0=1010)   
    // Enable MCU_WU (bit5:4=10 ) on RTC   
    WUCONF = (BIT_5 | BIT_3 | BIT_1);   
    usb_state = USB_REM_WU_ENABLE;   
  }   
  else   
  {   
    // Enable wake-up on USB and USBWU (bit3:0=1010)   
    WUCONF = (BIT_3 | BIT_1);   
    usb_state = USB_REM_WU_DISABLE;   
  } 
}

static void resume_cb() reentrant   
{ 
//  radio_init();  
  ep1_sent = true;   
  usb_state = USB_AWAKE;   
}

static void reset_cb() reentrant   
{ 
//	radio_init();  
  ep1_sent = true;  
  usb_state = USB_AWAKE;    
}
 
static code uint8_t ep_1_in_cb(uint8_t *adr_ptr, uint8_t* size) reentrant   
{  
  ep1_sent = true;   
  return 0x60; // NAK   
}

uint8_t ep_1_out_cb( uint8_t xdata *adr_ptr, uint8_t xdata *size) reentrant   
{
	static uint8_t xdata *buf_ptr;   
	static uint8_t i = 0; 
	
	buf_ptr = CALCULATE_BUF_OUT_PTR(2); 
  	ep2_rx = true;
  	//e_size = *size;
 	// ep2_adr = adr_ptr


	for(i = 0; i < SIZEOFPROG; ++i)
	{
		ackPayload[i] = buf_ptr[i];
	}  
	return 0xff; // clear OUT1 busy   
}  