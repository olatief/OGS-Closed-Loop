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
        private List<byte> buffer = new List<byte>();

        public int Offset { get { return offset; } set { offset = value; } }
        public List<byte> Buffer { get { return buffer; } }
        public enum BlockType { FullBlock, PartialBlock};

        private BlockType blockType = BlockType.PartialBlock;
        public static Block ExtractFromByteArray(byte[] buf, int startBitPos, int endBitPos)
        {
            
            return null;
        }

        public Block()
        {

        }

        public Block(Packet rxPacket) : this(new List<byte>(rxPacket.Buffer), 0) { }
        
        public Block(Block block1)
        {
            // copies values
            this.buffer = new List<byte>(block1.buffer);
            this.offset = block1.offset;
        }
        public Block(List<byte> buf, int offset)
        {
            // checks if we can discard bytes we dont need. potentially saves memory?
            if (offset > 7)
            {
                int count = offset/8;
                buf.RemoveRange(0,count);
                offset = offset - count * 8;
            }

            this.buffer = buf;
            this.offset = offset;
        }
        /// <summary>
        /// Remove the unneeded bits from a block and recalculates offset, Useful for generating the leftover blocks</summary>
        /// <param name="numBitstoRemove"> Number of bits to remove</param>
        /// 
        public void removeBits(int numBitstoRemove)
        {
            int count = numBitstoRemove >> 3; // divide by 8
            offset = numBitstoRemove - (count<<3); // find remainder for offset

            if (count > buffer.Count)
            {
                throw new NotImplementedException();
            }
            buffer.RemoveRange(0,count);
           
        }

        
        public static Block combineBlocks(Block block1, IList<byte> buffer)
        {
            Block retBlock = new Block();
            retBlock.Buffer.AddRange(block1.Buffer);
            retBlock.Buffer.AddRange(buffer);

            retBlock.Offset = block1.offset;

            return retBlock;
        }
        public static Block combineBlocks(Block block1, Block block2)
        {
            return combineBlocks(block1,block2.Buffer);
        }



        public int[] extract16ChanValues()
        {
            if (adcVals != null) // dont bother recalculating it if we already figured it out
            {
                return adcVals;
            }

            throw new NotImplementedException();

        }
    }
}
