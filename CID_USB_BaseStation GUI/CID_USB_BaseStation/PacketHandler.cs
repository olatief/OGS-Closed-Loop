using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CID_USB_BaseStation
{
    class PacketHandler
    {
        //private static DataLogger instance;

        private byte deviceId = 0;
        private Packet lastPacket = null;
        private int missedPackets;
        private bool initialized = false;

        public int ParseNew(Packet receivedPacket)
        {
            missedPackets = receivedPacket.Count - lastPacket.Count;

            if (receivedPacket.Count <= lastPacket.Count) // check for overflow since count only goes to 128;
            {
                missedPackets += 128;
            }

            lastPacket = receivedPacket;

            return missedPackets;
        }
    }
}
