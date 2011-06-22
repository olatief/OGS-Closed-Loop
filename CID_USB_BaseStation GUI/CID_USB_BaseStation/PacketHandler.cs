using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CID_USB_BaseStation
{
    class PacketHandler
    {
        private static DataLogger logger = DataLogger.Instance;
        private byte deviceId = 0;
        private Packet lastPacket = null;
        private int missedPackets;

        public static DataLogger Logger { get { return PacketHandler.logger; } }


        public PacketHandler()
        {
            WirelessStats.Instance.Reset();  
        }

        public void ParseNewPacket(Packet receivedPacket)
        {
            int [] parsedValues;
            if (lastPacket != null)
            {
                missedPackets = receivedPacket.Count - lastPacket.Count - 1;

                if (receivedPacket.Count <= lastPacket.Count) // check for overflow since count only goes to 128;
                {
                    missedPackets += 128;
                }

                if (missedPackets == 0)
                {
                    WirelessStats.Instance.NumSuccessRxPackets++;
                }
                else
                {
                    WirelessStats.Instance.NumDroppedPackets += missedPackets;
                }
               
                parsedValues = parseSingleChan(receivedPacket);
                Scope.CurrentScope.AddRawADCtoQueue(parsedValues);
            }
            lastPacket = receivedPacket;

            return ;
        }

        private int[] parseSingleChan(Packet pkt)
        {
            int[] parsedValues = new int[15];
            int tempValue;
            for (int i = 0; i < parsedValues.Length; i++)
            {
                tempValue = pkt.Buffer[2*i+1] + (pkt.Buffer[2*i] << 8);
              /*  if (tempValue >= 512)
                {
                    tempValue = -tempValue;
                }
               * */
                parsedValues[i] = 2048-tempValue;
                logger.LogLine(parsedValues[i]);
            }

            return parsedValues;
        }

        private Int32[] bitsToInt(ref UInt16[] arr)
        {
            Int32[] val = new Int32[16];
            Int32 tmpVal = 0;

            for (short i = 0; i < val.Length; ++i)
            {
                tmpVal = 0;

                for (short j = 2; j < 11; ++j)
                {
                    tmpVal += ((arr[12 * i + j]) << (10 - j));
                }

                if (1 == arr[12 * i + 1]) // negative # (2's complement)
                {
                    tmpVal = -1 * tmpVal;
                }

                val[i] = tmpVal;
            }
            return val;
        }
    }
}
