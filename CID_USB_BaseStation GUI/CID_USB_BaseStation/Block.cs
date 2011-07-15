using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CID_USB_BaseStation
{
    public class Block
    {
        private int offset = 0; // which bit of the first byte does the start pattern begin.
        private int[] adcVals = null;
        private byte[] buffer = new byte[]{};
        
        public int Offset { get { return offset; } }
        public byte[] Buffer { get { return buffer; } }
        public enum BlockType { FullBlock, PartialBlock};

        private BlockType blockType = BlockType.PartialBlock;
        public static Block ExtractFromByteArray(byte[] buf, int startBitPos, int endBitPos)
        {
            
            return null;
        }

        public Block()
        {

        }
        

        public Block(byte[] buf, int offset)
        {
            this.buffer = buf;
            this.offset = offset;
        }

        public int[] extract16ChanValues()
        {
            if (adcVals != null) // dont bother recalculating it if we already figured it out
            {
                return adcVals;
            }

            throw new NotImplementedException();

            return null;
        }
    }
}
