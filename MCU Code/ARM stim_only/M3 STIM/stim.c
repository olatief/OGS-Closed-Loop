#include "stim.h"
#include "efm32_cmu.h"
#include "efm32_timer.h"
#include "intrinsics.h"

void reprogStimTimers(PROG_TypeDef prog)
{
  if(prog.enable)
  {
    stopStim();
  } else {
    calcTimerParams(prog.period, prog.posPulseWidth);
    startStim();
  }
}

/* all parameter inputs are in us */
TIMER_CCParams_TypeDef calcTimerParams(uint32_t period, uint32_t pulseWidth)
{
  uint32_t timerFreq;
  uint32_t topCount;
  uint32_t negCount;
  uint32_t posCount;
  uint32_t durationCount;
  
  TIMER_CCParams_TypeDef ret; 
  
  uint32_t oldTimerPS = ((TIMER0->CTRL & _TIMER_CTRL_PRESC_MASK)>>_TIMER_CTRL_PRESC_SHIFT);
  uint32_t newTimerPS = oldTimerPS;
  
  if(period > 1000000)
    period = 1000000;
  if(pulseWidth > period/2)
    pulseWidth = period/2;
  
  timerFreq = CMU_ClockFreqGet(cmuClock_TIMER0) >> oldTimerPS;
  
  topCount = (uint64_t)period * (uint64_t)timerFreq/1000000;
  
  durationCount = pulseWidth * timerFreq/1000000;

  /* check if timer will overflow with given parameters */
  newTimerPS = topCount >> 16;
  
  if( newTimerPS != 0 ) /* checks if > 2^16) */
  {
    topCount >>= newTimerPS;
    durationCount >>= newTimerPS;
    newTimerPS += oldTimerPS;
    
  TIMER0->CTRL &= ~(_TIMER_CTRL_PRESC_MASK); // clear current prescaler
  TIMER0->CTRL |= (newTimerPS << _TIMER_CTRL_PRESC_SHIFT); // set new prescaler

  }
  posCount = topCount-durationCount;
  negCount = durationCount;
  
  ret.Top = topCount;
  ret.CC0 = posCount;
  ret.CC1 = negCount;
  
  TIMER_CompareBufSet(TIMER0, 0, posCount-1);
  TIMER_CompareBufSet(TIMER0, 1, negCount-1);
  TIMER_TopBufSet(TIMER0, topCount-1);
  return ret;
}

void stopStim(void)
{
  // TODO: Disable DAC
  TIMER_Enable(TIMER0, false);
}


void startStim(void)
{
  
  TIMER_Enable(TIMER0, true);
}

/* TODO: not efficient if statement */
uint32_t divideRound(uint32_t u, uint32_t v)
{
  uint32_t res = u/v;
  
  if( (res+1)*v - u < u-res*v)
  {
    ++res;
  }
  
  return res;
}

uint32_t gcd(uint32_t u, uint32_t v)
{
    int shift;
 
     /* GCD(0,x) := x */
     if (u == 0 || v == 0)
       return u | v;
 
     /* Let shift := lg K, where K is the greatest power of 2
        dividing both u and v. */
     for (shift = 0; ((u | v) & 1) == 0; ++shift) {
         u >>= 1;
         v >>= 1;
     }
 
     while ((u & 1) == 0)
       u >>= 1;
 
     /* From here on, u is always odd. */
     do {
         while ((v & 1) == 0)  /* Loop X */
           v >>= 1;
 
         /* Now u and v are both odd, so diff(u, v) is even.
            Let u = min(u, v), v = diff(u, v)/2. */
         if (u < v) {
             v -= u;
         } else {
             uint32_t diff = u - v;
             u = v;
             v = diff;
         }
         v >>= 1;
     } while (v != 0);
 
     return u << shift;
}
