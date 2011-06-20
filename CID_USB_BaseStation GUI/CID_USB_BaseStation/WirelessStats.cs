using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CID_USB_BaseStation
{
    public static class WirelessStats
    {

        public static long startTime;
        public static long stopTime;
        public static long numDroppedPackets;
        public static long numSuccessRxPackets;

        public static void Reset()
        {
            startTime = System.DateTime.Now.Ticks;
            stopTime = -1;
        }
    }
}
