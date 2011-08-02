using System;
using System.Collections.Generic;
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

        private byte[] rawBuffer; // buffer of all values
        private byte[] dataBuffer; // buffer of only data

        public byte[] RawBuffer { get { return rawBuffer; } }
        public byte[] DataBuffer { 
            get {
                byte[] retval = new byte[dataBuffer.Length];
                dataBuffer.CopyTo(retval, 0);
                return retval; 
            } }

     //   private int[] adcVals;
     //  public int[] AdcVals { get { return adcVals; } }

        public Packet(EndpointDataEventArgs e) : this(e.Buffer) { }

        public Packet() :  this(new byte[maxLength])
        {
            // init Empty Packet;
        }

        public byte reverseBits(byte val)
        {
            int retVal = 0;

            for (int i = 0; i < 8; i++) // we only care about the lfirst 10 bits
            {
                retVal += (int)(((val >> i) & 1) << (7 - i)); // reverse the bit order
            }

            return (byte)retVal;
        }
        public Packet( byte [] buffer)
        {
            byte info;

            this.rawBuffer = new byte [maxLength];
            this.dataBuffer = new byte[infoIndex];
            
            // reverses each byte in the packet contents so the bytes are in the right order.
            for (int i = 0; i < infoIndex; i++)
            {
                this.dataBuffer[i] = reverseBits(buffer[i]);
            }

            info = buffer[infoIndex];
            this.isStimulating = ((info) & (0x80)) != 0; // if right most bit is set to 1 then its stimulating
            this.count = (byte)( 0x7F & info);
            
           // adcVals = ParsePacket();
            lastPacket = this;
        }

        public int calculateMissedPacketsBetween(int lastPacketCount)
        {
            int missedPackets = this.count - lastPacketCount - 1;

            if (this.Count <= lastPacketCount) // check for overflow since count only goes to 128;
            {
                missedPackets += 128;
            }

            return missedPackets;
        }

        public int calculateMissedPacketsBetween(Packet LastPacket)
        {
            return calculateMissedPacketsBetween(LastPacket.Count);
        }

        private List<int> ParsePacket()
        {
            List<int> parsedValues = new List<int>();

            int tempValue;
            for (int i = 0; i < maxLength/2; i++)
            {
                tempValue = this.dataBuffer[2 * i + 1] + (this.dataBuffer[2 * i] << 8);

                parsedValues[i] = 2048 - tempValue;
            }

            return parsedValues;
        }
    }
}
