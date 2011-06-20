using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CID_USB_BaseStation
{
    public static class WirelessStats
    {
        private static long startTime;
        private static long stopTime;
        private static long numDroppedPackets;
        private static long numSuccessRxPackets;

        public static long StartTime { set; get; }
        public static long StopTime { set; get; }
        public static long NumDroppedPackets { set; get; }
        public static long NumSuccessRxPackets { set; get; }

        public static void Reset()
        {
            StartTime = System.DateTime.Now.Ticks;
            StopTime = -1;

            NumDroppedPackets = 0;
            NumSuccessRxPackets = 0;
        }
    }
}
