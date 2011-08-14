#ifndef __RADIO_H
#define __RADIO_H

#include <stdint.h>
#include "efm32_gpio.h"
#include "efm32_usart.h"
#include "hardware.h"

void RADIO_setup(void);
void RADIO_TX(uint8_t* payload, uint8_t length);

extern uint8_t progPayload[32];
extern uint8_t procPayload;

#endif /* __RADIO_H */