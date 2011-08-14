#ifndef __PROGTYPES_H
#define __PROGTYPES_H

#include <stdint.h>

typedef struct
{
  uint8_t enable;
  uint16_t period;
  uint16_t posPulseWidth;
  uint16_t negPulseWidth;
  uint16_t amplitude;
} PROG_TypeDef;

#endif /* __PROGTYPES_H */