using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibUsbDotNet.Main;

namespace CID_USB_BaseStation
{
    public class Packet
    {
        private static uint maxLength = 32;
        private static int infoIndex = 30;
        private static Packet lastPacket = null; // Pointer to the last packet that was processed by this class. Takes care of start bits occuring on Packet boundaries
        
        public static uint MaxLength 
        {
            get { return maxLength; } 
            set 
            {
                if (value == 0 || value > 64)
                {
                    throw new ArgumentOutOfRangeException("MaxLength", maxLength, "Invalid size for buffer");
                } else {
                    maxLength = value;
                }
            } 
        }

        private byte count;
        private bool isStimulating;
        private List<int> startPos = new List<int>();
        
        public byte Count { get { return count; } set { count = value; } }
        public bool IsStimulating { get { return isStimulating; } }

        private byte[] buffer;
        public byte[] Buffer { get { return buffer; } }
        private int[] adcVals;
        public int[] AdcVals { get { return adcVals; } }

        public Packet(EndpointDataEventArgs e) : this(e.Buffer) { }

        public Packet() :  this(new byte[maxLength])
        {
            // init Empty Packet;
        }

        public Packet( byte [] buffer)
        {
            byte info;

            this.buffer = new byte [maxLength];
            Array.Copy(buffer, this.buffer, maxLength);

            info = buffer[infoIndex];
            this.isStimulating = !(((info) & (0x80)) == 0); // if right most bit is set to 1 then its stimulating
            this.count = (byte)( 0x7F & info);
            
            adcVals = ParsePacket();
            lastPacket = this;
        }

        public int calculateMissedPacketsBetween(Packet LastPacket)
        {
            int missedPackets = this.count - LastPacket.count - 1;

            if (this.Count <= LastPacket.Count) // check for overflow since count only goes to 128;
            {
                missedPackets += 128;
            }

            return missedPackets;
        }

        private int[] ParsePacket()
        {
            int[] parsedValues = new int[15];
            int tempValue;
            for (int i = 0; i < parsedValues.Length; i++)
            {
                tempValue = this.buffer[2 * i + 1] + (this.buffer[2 * i] << 8);
                /*  if (tempValue >= 512)
                  {
                      tempValue = -tempValue;
                  }
                 * */

                parsedValues[i] = 2048 - tempValue;

                DataLogger.Instance.LogLine(parsedValues[i]);
            }

            return parsedValues;
        }
    }
}
