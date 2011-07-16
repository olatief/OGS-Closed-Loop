using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CID_USB_BaseStation
{
    public class Parser
    {
        public const int blockSize = 204; // Size of 16 channel acquisition (16*12bits = 204)
        Packet LastPacket = new Packet();
       // private const bool isMCULittleEndian = true; // x86 is little endian  
        const UInt16 pattern = 0x0AAA; // TODO: figure out endianness of 8051
        const UInt16 patternLength = 12; // # of bits
        const UInt16 patternMask = (1<<(patternLength)) - 1;

        UInt32[] preShifts = new UInt32[22];
        UInt32[] masks = new UInt32[22];

        public Parser()
        {
            // Adapted from: http://stackoverflow.com/questions/1572290/fastest-way-to-scan-for-bit-pattern-in-a-stream-of-bits

            for (int i = 0; i <= (32 - patternLength); i++) // There's a total of 32-patternLength masks we need to test for every int
            {
                preShifts[i] = (UInt32)(pattern << i);
                masks[i] = (UInt32)(patternMask << i);   

            }
        }

        public List<int> findStartPatterninPacket(Packet rxPacket)
        {
            return findStartPatterninPacket(rxPacket.DataBuffer);
        }

        public List<int> findStartPatterninBlock(Block toBeSearched)
        {
            return findStartPatterninPacket(toBeSearched.Buffer);
        }

        public List<int> findStartPatterninPacket(IList<byte> rxBytes)
        {
            List<int> startPositions = new List<int>();
            List<int> foundLocations = new List<int>();

            for (int i = 0; i < rxBytes.Count - 3; i += 3)
            {
                foundLocations = findStartPositions(new byte[] { rxBytes[i], rxBytes[i + 1], rxBytes[i + 2], rxBytes[i + 3] });
                foreach (int loc in foundLocations)
                {
                    startPositions.Add(8 * i + loc);
                }
            }
            return startPositions;
        }

        // We assume that the input positions are pre-sorted in ascending order
        public List<int> realStartPositions(List<int> startPositions)
        {
            List<int> realStartPos = new List<int> { };
            List<int> longestChain = new List<int>();
            List<int> nextLongestChain = new List<int>();

            
            if (startPositions.Count == 0 || (startPositions[startPositions.Count - 1] - startPositions[0]) < blockSize)
            {
                return new List<int> { }; // give back an empty list if no block is found
            }

            // Generate chains of possible start positions, the laziest way possible
            List<List<int>> chains = new List<List<int>>();

            for (int i = 0; i < startPositions.Count-1; i++)
            {
                
                int resultidx = startPositions.FindIndex(i,delegate(int val) { return val == startPositions[i] + blockSize; });
                if (resultidx != -1)
                {
                    List<int> chain = new List<int>();
                    chain.Add(startPositions[i]);
                    do
                    {
                        chain.Add(startPositions[resultidx]);
                        resultidx = startPositions.FindIndex(resultidx, delegate(int val) { return val == startPositions[resultidx] + blockSize; });
                    } while(resultidx != -1);
                    chains.Add(chain);
                }
            }

            // Find the longest chain. This should be the real packet start locations
            // TODO: if we find lots of issues with 14 toggles that look like two start patterns together then we might have to use more than two packets together
            int maxChainLength = 0;

            foreach (List<int> chain in chains)
            {
                if (maxChainLength < chain.Count)
                {
                    //assign last local max to be the next longest chain
                    nextLongestChain = longestChain;

                    maxChainLength = chain.Count;
                    longestChain = chain;
                }
            }

            if (longestChain.Count == nextLongestChain.Count) 
            {
                // This means that there are two possible chains that can both be legit blocks (14 bit problem). 
                // The way we handle it is by returning nothing and waiting for more data to decide.
                return new List<int>();
            }

            return longestChain;
        }

        
        // Return value of an Empty list indicates that no start pattern was found
        public List<int> findStartPositions(byte[] values)
        {
            int i = 0;
            List<int> startPositions = new List<int>(2); // This is because sometimes the start pattern can be 2 bits apart
            if (values.Length != 4)
            {
                throw new ArgumentException("Search area is not 4 values. In function: startPosition");
            }

            UInt32 combinedBytes = (UInt32)((values[0] << 24) + (values[1] << 16) + (values[2] << 8) + values[3]);

            for (i = 32-patternLength; i >= 0; i--)
            {
                if ((combinedBytes & masks[i]) == preShifts[i]) startPositions.Add(32 - (i + patternLength)); // We want the position where the start pattern starts.
            }

            return startPositions;
        }

        public List<Block> ExtractFullBlocks(Packet pkt)
        {
            
           List<int> startPos = realStartPositions(findStartPatterninPacket(pkt));
            
           List<Block> blocks = new List<Block>();

           if (startPos.Count <= 1) return blocks; // if there were no start positions found give back an empty block
           

           for (int i = 0; i < startPos.Count - 1; i++)
           {
               byte[] bufTemp = new byte[26]; // 204 bits total to store the entire block.
               
              //blocks.Add(new Block(
           }

            return blocks;
        }

        private Block leftOverBlock = new Block();
        private int lastPacketCount = 0;
        private object parseLock = new object();
 
        public List<Block> ParseNewPacket(Packet rxPacket)
        {
            lock (parseLock) // argghhh!!!!
            {
                List<Block> validBlocks = new List<Block>();
                Block blockforProcessing = new Block(rxPacket);

                if (rxPacket.calculateMissedPacketsBetween(lastPacketCount) == 0)
                {
                    // we need to combine two packets just in case the start pattern was on the boundary so the search routine can find it.
                    blockforProcessing = Block.combineBlocks(leftOverBlock, rxPacket.DataBuffer);
                }
                else
                {
                    // Discard left over block from the last packet if there are missing packets in between since they wont match up anyways
                    blockforProcessing = new Block(rxPacket); 
                }

                lastPacketCount = rxPacket.Count;
                List<int> startPosFound = findStartPatterninBlock(blockforProcessing);
                

                if (startPosFound.Count == 0) // means no start bits were found. should rarely come here. Need to test this more
                {
                    leftOverBlock = new Block(); // set it to an empty block so we start from scratch next time
                    return validBlocks; // returns 0 blocks
                }

                List<int> realStartPosFound = realStartPositions(startPosFound);

                if (realStartPosFound.Count > 0) // means we found some legit start patterns
                {

                    validBlocks = GenerateBlocks(blockforProcessing, realStartPosFound);
                    leftOverBlock = new Block(blockforProcessing);

                    leftOverBlock.removeBits(realStartPosFound[realStartPosFound.Count - 1]); // discard the part of the packet we already processed
                    return validBlocks;
                }
                else // most likely reason for coming here is because it found startpatterns two bits apart and cant figure out the real block to process 
                {
                    if (blockforProcessing.Buffer.Count > 30 * 30) // after 10 packets
                    {
                        // for some reason sometimes it never finds a valid start pattern so this tells it to just start over and discard everything from before.
                        leftOverBlock = new Block();

                    }
                    else
                    {
                        leftOverBlock = blockforProcessing; // keeps on adding packets to leftoverblock so we can gather data to eventually make a decision
                    }
                    return validBlocks; // returns 0 blocks
                }
            }
        }

        public List<Block> GenerateBlocks(Block blockforProcessing, List<int> realStartPosFound)
        {
            List<Block> Blocks = new List<Block>();

            for (int i = 0; i < realStartPosFound.Count-1; i++) // we ignore the last value on purpose since its not the beginning of a valid block
            {
                Blocks.Add(new Block(blockforProcessing.Buffer,realStartPosFound[i]));
                
            }

            return Blocks;
        }
    }
}
