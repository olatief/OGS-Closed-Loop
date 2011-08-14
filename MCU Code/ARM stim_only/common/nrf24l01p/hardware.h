#ifndef __HARDWARE_H
#define __HARDWARE_H


/* Setup where RFCS pin is connected */
#define RFCS_N        3 
#define RFCS        (1<<RFCS_N)   
#define RFCS_PORT   gpioPortD

/* Setup where RFCE pin is connected */
#define RFCE_N        4 
#define RFCE        (1<<RFCE_N)   
#define RFCE_PORT   gpioPortD

/* Setup where RFIRQ pin is connected */
#define RFIRQ_N        5 
#define RFIRQ        (1<<RFIRQ_N)  
#define RFIRQ_PORT   gpioPortD

#define NRF_USART_SPI   USART1   /* which usart module are we using for the nrf24l01+ spi */


#endif /* __HARDWARE_H */