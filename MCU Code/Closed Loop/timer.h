#include <stdint.h>

extern uint8_t isStimulating;
void progSD(progAlgo *pAlgo);
void progTimer(progStim *pStim);
void initTimer();
void peakDetect();