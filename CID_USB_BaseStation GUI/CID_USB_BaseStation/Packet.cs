using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibUsbDotNet.Main;

namespace CID_USB_BaseStation
{
    class Packet
    {
        private static uint maxLength = 32;
        private static int infoIndex = 30;

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

        public byte Count { get { return count; } set { count = value; } }
        public bool IsStimulating { get { return isStimulating; } }

        private byte[] buffer;
        public byte[] Buffer { get { return buffer; } }

        public Packet(EndpointDataEventArgs e)
        {
            byte info;

            this.buffer = new byte [maxLength];
            Array.Copy(e.Buffer, this.buffer, maxLength);

            info = buffer[infoIndex];
            this.isStimulating = !(((info) & (0x80)) == 0); // if right most bit is set to 1 then its stimulating
            this.count = (byte)( 0x7F & info);
        }
    }
}
