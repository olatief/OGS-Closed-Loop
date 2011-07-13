#ifndef HARDWARE_H
#define HARDWARE_H

#ifdef MCU_NRF24LE1
#include <reg24le1.h>
#endif

#ifdef MCU_NRF24LU1P
#include <Nordic\reg24lu1.h>
#endif

#include <stdint.h>
#include <hal_spi.h>

sbit P0_0 = P0^0;
sbit P0_4 = P0^4;
sbit P0_5 = P0^5;
sbit P0_6 = P0^6;
sbit P0_7 = P0^7;

sbit LED_CTRL_PIN = P0^6;
sbit P1_4 = P1^4;
sbit TEST_PIN = P1^5;
sbit P1_6 = P1^6;

 typedef enum { PROGSTIM = 1, PROGALGO, PROGALL } pktType;

        typedef struct
        {
             uint8_t Amplitude;
             uint8_t DC;
			 uint8_t Freq;
			 uint8_t PulseOn;
        	 uint8_t PulseOff;
        	 uint8_t Cycles;
        } progStim;

        typedef struct 
        {
            uint16_t high;
            uint16_t low;
            uint16_t IEI;
            uint8_t nStage;
			uint8_t delay;
        } progAlgo;

        typedef struct 
        {
            pktType pType;
            progStim pStim;
            progAlgo pAlgo;
        } progAll;

uint8_t hal_digi_init();
uint8_t hal_digi_write(uint16_t value);

#endif