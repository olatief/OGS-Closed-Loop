/* Copyright (c) 2009 Nordic Semiconductor. All Rights Reserved.
 *
 * The information contained herein is confidential property of Nordic
 * Semiconductor ASA.Terms and conditions of usage are described in detail
 * in NORDIC SEMICONDUCTOR STANDARD SOFTWARE LICENSE AGREEMENT.
 *
 * Licensees are granted free, non-transferable use of the information. NO
 * WARRENTY of ANY KIND is provided. This heading must NOT be removed from
 * the file.
 *
 * $LastChangedRevision: 230 $
 */

/** @file
 * @brief Implementation of #hal_nrf_rw.
 *
 * @details #hal_nrf_rw is an SPI function which is hardware dependent. This file
 * contains an implementation for nRF24LE1.
 */

#include <stdint.h>
#include "hal_nrf.h"
#include "hal_nrf_hw.h"

#include "efm32.h"
#include "efm32_gpio.h"

uint8_t hal_nrf_rw(uint8_t value)
{
  USART_Tx(NRF_USART_SPI, value);
  return USART_Rx(NRF_USART_SPI);
  
    /*
  SPIRDAT = value;
  while(!(SPIRSTAT & 0x02)) // wait for byte transfer finished
  {
  }
  return SPIRDAT;             // return SPI read value
  */
  
}
