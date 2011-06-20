#include "hardware.h"
#include "led.h"
#include <intrins.h>

void prog_led(uint8_t amp)
{
	uint8_t il = 0;

	if(amp>14)
		amp = 14;

	amp = (amp<<1);
	P1_6 = 0;

	for(il = 1; il<amp; ++il)
	{
		_nop_();
		_nop_();
		P1_6 ^= 0x01;			
	}

}