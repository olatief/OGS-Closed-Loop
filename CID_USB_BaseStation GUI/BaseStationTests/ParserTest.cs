using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using CID_USB_BaseStation;

namespace BaseStationTests
{
    [TestFixture]
    public class ParserTest
    {
        [Test]
        public void realStartPositionsTestHandle14bitPattern()
        {
            Parser testParser = new Parser();
            int [] testVals = {100, 102, 100+204,102+204};
            List<int> result = testParser.realStartPositions( testVals.ToList<int>() );

            Assert.AreEqual(100, result[0]);
        }

        [Test]
        public void parseThreePackets()
        {
            byte[] buf1 = new byte[32];
            byte[] buf2 = new byte[32];
            byte[] buf3 = new byte[32];

            // set counts so they're in order
            buf1[30]=13;
            buf2[30]=14;
            buf3[30]=15;

            buf1[8]=0x02;
            buf1[9]=0xAA;
            buf1[15] = 0x55;
            buf1[16] = 0x55;
            buf1[17] = 0x55;

            // 204 bits in between
            buf2[4]=0x2A;
            buf2[5]=0xA0;

            buf2[29] = 0x02;
            buf3[0] = 0xAA;
            buf3[25] = 0x2A;
            buf3[26] = 0xA0;

            Packet pkt1 = new Packet(buf1);
            Packet pkt2 = new Packet(buf2);
            Packet pkt3 = new Packet(buf3);

            Parser testParser = new Parser();
            

/*
            List<byte[]> blocks1 = testParser.ExtractBlocks(pkt1);
            List<byte[]> blocks2 = testParser.ExtractBlocks(pkt2);
            List<byte[]> blocks3 = testParser.ExtractBlocks(pkt3);

            Assert.AreEqual(0, blocks1.Count);
            Assert.AreEqual(2, blocks2.Count);
           // Assert.AreEqual(0x55, blocks2[1][8]);
            */
        }
        
        /*[Test]
        public void realStartPositionPerfTests()
        {
            Parser testParser = new Parser();
            List<int> startPos;
            List<int> realStartPos;

            for (int i = 0; i < 1000; i++)
            {
                startPos = new List<int> { 0, 10, 12, 214, 216, 418, 422 };
                realStartPos = testParser.realStartPositions(startPos);
            }
        }*/
        [Test]
        public void realStartPositionTests()
        {
            Parser testParser = new Parser();
            List<int> startPos = new List<int>{ 10, 12, 214, 230, 418 };
            List<int> realStartPos;
            realStartPos = testParser.realStartPositions(startPos);

            Assert.AreEqual(10, realStartPos[0]);
            Assert.AreEqual(214, realStartPos[1]);
            Assert.AreEqual(418, realStartPos[2]);

            startPos = new List<int> {0, 10, 12, 214, 216, 418, 422};
            realStartPos = testParser.realStartPositions(startPos);
            Assert.AreEqual(10, realStartPos[0]);
            Assert.AreEqual(214, realStartPos[1]);
        }
        [Test]
        public void realStartPositionEmptyTests()
        {
            Parser testParser = new Parser();
            List<int> startPos = new List<int>();

            List<int> realStartPos = testParser.realStartPositions(startPos);

            Assert.AreEqual(0, realStartPos.Count); 
        }
        [Test]
        public void findStartPatterninPacketTestRealData()
        {
            byte[] testBuffer = new byte[32]; // initialize to all 0x00
            Parser testParser = new Parser();

            testBuffer[27] = 0x4F;
            testBuffer[28] = 0x55;
            testBuffer[29] = 0xE1; 

            List<int> results = testParser.findStartPatterninPacket(new Packet(testBuffer));

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(7, results[0]);
        }
        [Test]
        public void findStartPositionsTest()
        {
            Parser test = new Parser();
            
            // lots of start patterns
            List<int> temp = test.findStartPositions( new byte[]{0x02, 0xAA, 0xAA, 0x09});
            Assert.AreEqual(5, temp.Count);
            Assert.AreEqual(6, temp[0]);
            Assert.AreEqual(12, temp[3]);
            Assert.AreEqual(14, temp[4]);
            // No Start bits
            temp = test.findStartPositions(new byte[] { 0x02, 0xA5, 0xA5, 0x09 });
            Assert.AreEqual(0, temp.Count);

            //shifted by 1 
            temp = test.findStartPositions(new byte[] { 0x05, 0x54, 0x04, 0x02 });
            Assert.AreEqual(5, temp[0]);
        }

        [Test]
        public void findStartPatterninPacketTest()
        {
            byte[] testBuffer = new byte[32]; // initialize to all 0x00
            Parser testParser = new Parser();
            
            testBuffer[10] = 0x02;
            testBuffer[11] = 0xAA;

            // same pattern shifted left 1 bit
            testBuffer[20] = 0x05;
            testBuffer[21] = 0x54;
            testBuffer[22] = 0x04;

            List<int> results = testParser.findStartPatterninPacket(new Packet(testBuffer));

            Assert.AreEqual(2, results.Count);
            Assert.AreEqual(10 * 8 + 6, results[0]);
            Assert.AreEqual(20 * 8 + 5, results[1]);

        }

        //TODO: add tests for start pattern on packet boundaries
    }
}
