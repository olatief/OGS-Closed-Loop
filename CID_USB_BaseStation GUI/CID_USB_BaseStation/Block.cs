using System;
using System.Collections;
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
        public List<byte> Buffer { get { return new List<byte>(buffer); } } // we return a copy of the buffer so it doesnt accidently get modified
        public enum BlockType { DataBlock, PartialBlock};

        private BlockType blockType = BlockType.PartialBlock;

        public List<int> Parse()
        {
            List <int> adcVals = new List<int>();

            if(offset > 8)
                throw new ArgumentOutOfRangeException("Offset should be less than 8 to parse block");
            
            RealignBlock();
            
            //handles first 16 values
            for (int i = 0; i < 24; i+=3)
            {
                 adcVals.Add( (int)( (buffer[i] << 4) + (buffer[i+1] >> 4)) );
                
                 adcVals.Add( (int)( ((buffer[i+1]<<8)&(0xF00)) + (buffer[i + 2])) ); 
            }

            //handles 17th value
            adcVals.Add((int)((buffer[24] << 4) + (buffer[25] >> 4)));

            if (adcVals[0] != 0xAAA)
            {
                throw new ArgumentException("Block.Parse(): First 12 bits in block do not match start pattern");
            }

            for (int i = 0; i < adcVals.Count; i++)
            {
                adcVals[i] = Convert12bitToAdcVal(adcVals[i]);
            }
            return adcVals; 
        }

        public int Convert12bitToAdcVal(int rawVal)
        {
            int tempVal = rawVal >> 2 ;
            /*
            for (int i = 0; i < 10; i++) // we only care about the lfirst 10 bits
            {
                tempVal += ((rawVal >> i) & 1)<<(9-i); // reverse the bit order
            }
            */
            
            if( tempVal>512 ) // negative # (2's complement)
            {
                tempVal = (512-tempVal);
            }

            return tempVal;
        }
        private void RealignBlock()
        {

            if(offset == 0)
                return; // Our work here is done
            
            for (int i = 0; i < buffer.Count-1; i++)
            {
                buffer[i] = (byte) ( (buffer[i] << offset) + (buffer[i+1] >> (8-offset)) );
            }

            offset = 0;
        }

        public Block()
        {
        }

        public Block(Packet rxPacket) : this((new List<byte>( rxPacket.DataBuffer)), 0) { }
        
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
            retBlock.buffer.AddRange(block1.buffer);
            retBlock.buffer.AddRange(buffer);

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
