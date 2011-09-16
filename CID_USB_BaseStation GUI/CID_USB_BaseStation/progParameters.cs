using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace CID_USB_BaseStation
{
    
    delegate void stAssignVal(Int32 val);

    enum PktType : byte { Stim = 1, Algo = 2, All = 3 };

    internal enum SystemType : byte
    {
        OGS = 0,
        SixteenChan,
        ElecStimOnly
    };

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct ProgElecStim
    {
        public byte pktInfo;
        public UInt16 Amplitude;
        public UInt16 Period;
        public UInt16 PosPulse;
        public UInt16 NegPulse;

    };

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
     struct ProgStim
    {
        public byte Amplitude;
        public byte DC;
        public byte Freq;
        public byte PulseOn;
        public byte PulseOff;
        public byte Cycles;

    };

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
     struct ProgAlgo
    {
        public UInt16 high;
        public UInt16 low;
        public byte IEI;
        public byte nStage;
        public byte delay;

    };

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct ProgAll
    {
        public PktType pType;
        public ProgStim pStim;
        public ProgAlgo pAlgo;
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
