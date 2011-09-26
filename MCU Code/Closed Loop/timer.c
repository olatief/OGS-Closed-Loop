#include "hardware.h"
#include "timer.h"
#include "led.h"

#define PERIOD_MS 100
#define TIMER_TWO_PS 8	 // Pre-scaler fot rimer 2 to get lower stimulation frequencies


static xdata uint16_t timer_high = 0;
static xdata uint16_t timer_low = 0;
static xdata uint8_t bHighState = 0;
static xdata uint16_t IEI = 400;
static xdata uint8_t nStage = 5;

static data uint16_t tick = 0;
static data uint8_t nStageCount = 0;
static uint8_t timer2scaler = TIMER_TWO_PS;
static uint8_t pulsesOn = 10;
static uint8_t pulsesOnCount = 10;
static uint8_t pulsesOff = 10;
static uint8_t pulsesOffCount = 10;
static uint8_t cycles = 3;
static uint8_t cyclesCount = 3;
static data uint8_t g_Amplitude = 0;

static uint8_t outputDisabled = 0;
uint8_t isStimulating = 0;

void SeizureDetected();
void startStim();
void stopStim();

void progSD(progAlgo* pAlgo)
{
	IEI = pAlgo->IEI;
	nStage = pAlgo->nStage;
}

void peakDetect() // called when threshold reached
{
	 if(tick > 0)  // last detection was less than IEI (ms) ago
	 {
	 	--nStageCount;
		if(nStageCount == 0) // seizure detected
		{
			SeizureDetected();	
		}		
	 } else {  // reset nStage
	 	nStageCount = nStage;
	 }

	 tick = IEI;  // reset tick

}

uint8_t DetectionLock = 0;

void SeizureDetected()
{	
	nStageCount = nStage;
	// DO STUFF
	startStim();
}

void startStim()
{
	isStimulating = 0x80;
	outputDisabled = 0;
	pulsesOffCount = pulsesOff;
	pulsesOnCount = pulsesOn;
	cyclesCount = cycles;
	T2I0 = 1; // Turn on timer 2
    ET2 = 1; // Enable timer 2 interrupt

}

void stopStim()
{
	isStimulating = 0;
	T2I0 = 0; // Turn off timer 2
    ET2 = 0; // Disable timer 2 interrupt
}

void progTimer(progStim *pStim)
{
	xdata uint32_t period = 0;
	xdata uint32_t period_us = (uint32_t)1e6/((uint32_t)pStim->Freq);


	period = (uint32_t)period_us*(uint32_t)2/3; // its (2/3)/8
	timer_high = pStim->DC*period/100;
	timer_low = (period - timer_high);
	timer_high = 2^16-timer_high/TIMER_TWO_PS;	
	timer_low = 2^16-timer_low/TIMER_TWO_PS;

	pulsesOff = pStim->PulseOff;
	pulsesOn = pStim->PulseOn;
	cycles = pStim->Cycles;
	g_Amplitude = pStim->Amplitude;
	startStim();
}

void initTimer()
{
 //	progTimer(30, 10);
/* Configure Timer 2 */
     
   CRCL = 0xF0;
   CRCH = 0xF0;
    
   CCEN = 0x02;  // Compare enabled
      /*T2CON: */
   T2PS = 1; // CLK/24 , no reload
   T2R1 = 1;
  // T2CM = 1;	
   T2I0 = 1; // Turn on timer
    ET2 = 1; // Enable timer 2 interrupt

/** Timer 0 Setup **/

	TMOD = 0x01; // 16 bit timer for TMR0;
	TH0 = 0x7F;
	TL0 = 0xFF;
	TR0 = 1; // 	Tmr0 run control (start)
	ET0 = 1; // Enable timer0 interrupt
	return;
}

void timer0() interrupt INTERRUPT_T0 // Seizure detection IEI counter (tick)
{
	TH0 = 0x7F;
	TL0 = 0xFF;

	if(tick != 0)
	{
		--tick;
	}

//	P1_6 ^= 1; 
}

void timer2() interrupt INTERRUPT_T2 // controls stimulation waveform
{
	--timer2scaler;
	if( 0 == timer2scaler )
	{
		if(bHighState)
		{
			CRCL = timer_low&0xFF;
			CRCH = timer_low>>8;
		//	prog_led(g_Amplitude);
			
			if(!outputDisabled) prog_led(g_Amplitude); // P1_6 = 1;
					
		} 
		else 
		{
			CRCL = timer_high&0xFF;
			CRCH = timer_high>>8;
			prog_led(0);
		//	P1_6 = 0;

			if(!outputDisabled)
			{
				--pulsesOnCount;
				if(0 == pulsesOnCount)
				{
					pulsesOnCount = pulsesOn;
					if(0 != pulsesOff)
					{
						// ET2 = 0;
						outputDisabled = 1;
					} else {
						if(cycles != 0)	 // run infinte amount of times if cycles is 0
						{
							--cyclesCount;
							if(0 == cyclesCount)
							{
								cyclesCount = cycles;
								stopStim();
							}
						}
					}
				}
			} else {
				--pulsesOffCount;
				if(0 == pulsesOffCount)
				{
					pulsesOffCount = pulsesOff;
					outputDisabled = 0;

					if(cycles != 0)	 // run infinte amount of times if cycles is 0
					{
						--cyclesCount;
						if(0 == cyclesCount)
						{
							cyclesCount = cycles;
							stopStim();
						}
					}
				}
			}
		}
		 
		timer2scaler = TIMER_TWO_PS; // scales timer by a factor of 8
		bHighState^=1;
	}
	
	TF2 = 0;			
}