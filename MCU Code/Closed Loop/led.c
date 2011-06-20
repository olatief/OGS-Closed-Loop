#include "hardware.h"
#include "led.h"
#include <intrins.h>

void prog_led(uint8_t amp)
{
	uint8_t il = 0;

	if(amp>14)
		amp = 14;

	amp = (amp<<1);
	LED_CTRL_PIN = 0;

	for(il = 1; il<amp; ++il)
	{
		_nop_();
		_nop_();
		LED_CTRL_PIN ^= 0x01;			
	}

}