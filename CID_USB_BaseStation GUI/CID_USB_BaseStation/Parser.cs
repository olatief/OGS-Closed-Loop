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
        private const bool isKeilLittleEndian = true; // x86 is little endian so this tells us if its the same as the target platform we're receiveing data from
        UInt16 pattern = 0x02AA; // TODO: figure out endianness of 8051
        UInt32[] preShifts = new UInt32[22];
        UInt32[] masks = new UInt32[22];

        public Parser()
        {
            // Adapted from: http://stackoverflow.com/questions/1572290/fastest-way-to-scan-for-bit-pattern-in-a-stream-of-bits
            byte[] prePattern = { 0x02, 0xAA };
            prePattern[0] = 0x02;  // 0b 0000 0010
            prePattern[1] = 0xAA;  // 0b 1010 1010;

            for (int i = 0; i < 22; i++) // There's a total of 32-10 = 22 masks we need to test for every int
            {
                preShifts[i] = (UInt32)(pattern << i);
                masks[i] = (UInt32)(0x03FF << i);   // mask for 10 bit patterns

            }
        }

        public List<int> findStartPatterninPacket(Packet rxPacket)
        {
            List<int> retVal;

            if (rxPacket.calculateMissedPacketsBetween(LastPacket) == 0)
            {
                byte[] searchBuffer = new byte[33];

                Array.Copy(LastPacket.Buffer, searchBuffer, 30);
                Array.Copy(rxPacket.Buffer, 0, searchBuffer, 30, 3);

                retVal = findStartPatterninPacket(searchBuffer);
            }
            else
            {

                retVal = new List<int>();
            }

            LastPacket = rxPacket;
            return retVal;
        }

        // We assume that the input positions are pre-sorted in ascending order
        public List<int> realStartPositions(List<int> startPositions)
        {
            List<int> realStartPos = new List<int> { };

            if (startPositions.Count == 0 || (startPositions[startPositions.Count - 1] - startPositions[0]) < blockSize)
            {
                return new List<int> { }; // give back an empty list if no block is found
            }

            // Generate chains of possible start positions, the laziest way possible
            List<List<int>> chains = new List<List<int>>();

            for (int i = 0; i < startPositions.Count-2; i++)
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

            int maxChainLength = 0;
            foreach (List<int> chain in chains)
            {
                if (maxChainLength < chain.Count)
                {
                    maxChainLength = chain.Count;
                    realStartPos = chain;
                }
            }

            return realStartPos;
        }

        public List<int> findStartPatterninBlock(Block toBeSearched)
        {
            return findStartPatterninPacket(toBeSearched.Buffer);
        }

        public List<int> findStartPatterninPacket(IList<byte> rxBytes)
        {
            List<int> startPositions = new List<int>();
            List<int> foundLocations = new List<int>();

            for (int i = 0; i < rxBytes.Count-3; i += 3) 
            {
                foundLocations = findStartPositions(new byte[] { rxBytes[i], rxBytes[i+1], rxBytes[i+2], rxBytes[i+3] } );
                foreach(int loc in foundLocations)
                {
                    startPositions.Add(8 * i + loc);
                }
            }
            return startPositions;
        }
        // Return value of -1 indicates that no start pattern was found
        public List<int> findStartPositions(byte[] values)
        {
            int i = 0;
            List<int> startPositions = new List<int>(2); // This is because sometimes the start pattern can be 2 bits apart
            if (values.Length != 4)
            {
                throw new ArgumentException("Search area is not 4 values. In function: startPosition");
            }

            UInt32 combinedBytes = (UInt32)((values[0] << 24) + (values[1] << 16) + (values[2] << 8) + values[3]);

            for (i = 21; i >= 0; i--)
            {
                if ((combinedBytes & masks[i]) == preShifts[i]) startPositions.Add(32-(i+10)); // We want the position where the start pattern starts.
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
               
               blocks.Add(new Block(
           }

            return blocks;
        }

        private byte[] mergePackets(Packet pkt1, Packet pkt2)
        {
            byte[] retVal = pkt1.Buffer;
            pkt2.Buffer.CopyTo(retVal,30);

            return retVal;
        }

        private List<byte> combinedPacketBuffer = new List<byte>();
        private List<byte> leftOverBlock = new List<byte>();

        public int[] ParseNewPacket(Packet rxPacket)
        {
            combinedPacketBuffer.Clear(); 
            // we need to combine two packets just in case the start pattern was on the boundary so the search routine can find it.
            if (rxPacket.calculateMissedPacketsBetween(LastPacket) == 0)
            {
                combinedPacketBuffer.AddRange(leftOverBlock); // Discard left over block from the last packet if there are missing packets in between since they wont match up anyways
            }

            combinedPacketBuffer.AddRange(rxPacket.Buffer);

            //List<int> realStartPosFound = realStartPositions(findStartPatterninBlock(combinedPacketBuffer));

            return null;
        }
    }
}
