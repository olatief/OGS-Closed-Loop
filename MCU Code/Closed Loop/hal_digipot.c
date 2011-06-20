#include "hardware.h"


uint8_t hal_digi_init()
{
	hal_spi_master_init(SPI_CLK_DIV2, HAL_SPI_MODE_0, HAL_SPI_MSB_LSB);
	// hal_spi_clkdivider_t ck, hal_spi_mode_t mode, hal_spi_byte_order_t bo);

	return 0;
}

uint8_t hal_digi_write(uint16_t value)
{
   uint8_t byte0 = (value>>8)&(0x03); // first 2 bits
   uint8_t byte1 = (value)&(0xFF);
  
//  	POT_CS = 0; 
   hal_spi_master_read_write(byte0);
   hal_spi_master_read_write(byte1);
  // POT_CS = 1;
   return 0;
}