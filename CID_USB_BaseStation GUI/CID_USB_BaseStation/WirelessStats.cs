using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Linq.Expressions;

namespace CID_USB_BaseStation
{
    public sealed class WirelessStats
    {
        private static readonly WirelessStats instance = new WirelessStats();
        private long startTime;
        private long stopTime;
        private long numDroppedPackets;
        private long numSuccessRxPackets;
        public Action<Action> _synchronousInvoker = null;
        public static WirelessStats Instance { get { return instance; } }  // Singleton Pattern
        public long StartTime { set; get; }
        public long StopTime { set; get; }
      

        public long NumDroppedPackets 
            {
                get { return numDroppedPackets; }
                set
                {
                    numDroppedPackets = value;
                }
            }
        public long NumSuccessRxPackets { 
            get { return numSuccessRxPackets; }
            set
            {
                numSuccessRxPackets = value;
            }
        }
        
        private WirelessStats() {  }

        public void Reset()
        {
            startTime = System.DateTime.Now.Ticks;
            stopTime = -1;

            NumDroppedPackets = 0;
            NumSuccessRxPackets = 0;
        }
    }
}
