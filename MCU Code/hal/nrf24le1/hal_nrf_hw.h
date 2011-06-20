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
 * $LastChangedRevision: 133 $
 */

/** @file
 * @brief Macros and hardware includes for nRF24LE1
 * @ingroup hal_nrf24le1
 *
 * @{
 * @name Hardware dependencies
 * @{
 *
 */

#ifndef HAL_NRF_LE1_H__
#define HAL_NRF_LE1_H__

#include <nrf24le1.h>

/** Macro that set radio's CSN line LOW.
 *
 */
#define CSN_LOW() do {RFCSN = 0; } while(0)

/** Macro that set radio's CSN line HIGH.
 *
 */
#define CSN_HIGH() do {RFCSN = 1; } while(0)

/** Macro that set radio's CE line LOW.
 *
 */
#define CE_LOW() do {RFCE = 0;} while(0)

/** Macro that set radio's CE line HIGH.
 *
 */
#define CE_HIGH() do {RFCE = 1;} while(false)

/** Macro for writing the radio SPI data register.
 *
 */
#define HAL_NRF_HW_SPI_WRITE(d) do{SPIRDAT = (d);} while(0)

/** Macro for reading the radio SPI data register.
 *
 */
#define HAL_NRF_HW_SPI_READ() SPIRDAT

/** Macro specifyng the radio SPI busy flag.
 *
 */
#define HAL_NRF_HW_SPI_BUSY (!(SPIRSTAT & 0x02))

/**
 * Pulses the CE to nRF24L01p for at least 10 us
 */
#define CE_PULSE() do { \
  uint8_t count; \
  count = 20; \
  CE_HIGH();  \
  while(count--) \
    ; \
  CE_LOW();  \
  } while(0)

#endif // HAL_NRF_LE1_H__

/** @} */
/** @} */
