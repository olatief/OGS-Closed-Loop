using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace CID_USB_BaseStation
{
    
    delegate void stAssignVal(Int32 val);

    enum pktType : byte { Stim = 1, Algo = 2, All = 3 };

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
     struct progStim
    {
        public byte Amplitude;
        public byte DC;
        public byte Freq;
        public byte PulseOn;
        public byte PulseOff;
        public byte Cycles;
    };

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
     struct progAlgo
    {
        public UInt16 high;
        public UInt16 low;
        public byte IEI;
        public byte nStage;
        public byte delay;

    };

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct progAll
    {
        public pktType pType;
        public progStim pStim;
        public progAlgo pAlgo;
    };

    struct Validator
    {
        public Int32 min;
        public Int32 max ;
        public stAssignVal AssignVal;
      //  public Int32 defaultval;
    }

    class progParams
    {
        

        private byte[] progBytes = new byte[11];
        
    }
}
