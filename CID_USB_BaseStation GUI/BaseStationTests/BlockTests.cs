using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using CID_USB_BaseStation;

namespace BaseStationTests
{
    [TestFixture]
    class BlockTests
    {
    
        [SetUp]
        public void Init()
        {
        }

        [Test]
        public void CombineBlockTest()
        {
            byte[] buf1 = new byte[26];

            buf1[0] = 0xAA;
            buf1[1] = 0xA1;
            buf1[2] = 0xF5;
            buf1[3] = 0x01;
            buf1[4] = 0x55;
            buf1[24] = 0x24;
            buf1[25] = 0x1A;

            byte[] buf2 = new byte[12];

            buf2[8] = 0x02;
            buf2[9] = 0xAA;
            buf2[0] = 0x53;
            buf2[2] = 0x25;
            buf2[11] = 0x15;

            Block testBlockIn = new Block(buf2.ToList(), 5);

            Block combinedBlock = Block.combineBlocks(testBlockIn, buf1);

            Assert.AreEqual(12 + 26, combinedBlock.Buffer.Count);
            Assert.AreEqual(5, combinedBlock.Offset);
            Assert.AreEqual(0x1a, combinedBlock.Buffer[37]);

        }
        [Test]
        public void ParseTestEasy()
        {
            byte[] buf1 = new byte[30];

            buf1[0]=0xAA;
            buf1[1]=0xA1;
            buf1[2] = 0xF5;
            buf1[3] = 0x01;
            buf1[4] = 0x55;
            buf1[24] = 0x24;
            buf1[25] = 0x1A;
            Block testBlock = new Block( buf1.ToList(), 0);
            List<int> result = testBlock.Parse();

            Assert.AreEqual(17, result.Count);
            Assert.AreEqual(testBlock.Convert12bitToAdcVal(0xAAA), result[0]);
            Assert.AreEqual(testBlock.Convert12bitToAdcVal(0x1f5), result[1]);
            Assert.AreEqual(testBlock.Convert12bitToAdcVal(0x015), result[2]);
            Assert.AreEqual(testBlock.Convert12bitToAdcVal(0x241), result[16]);
        }

        [Test]
        public void ParseTestHard()
        {
            byte[] buf1 = new byte[30];

            buf1[0] = 0x0A;
            buf1[1] = 0xAA;
            buf1[2] = 0x1F;
            buf1[3] = 0x50;
            buf1[4] = 0x15;
            buf1[24] = 0x02;
            buf1[25] = 0x41;
            Block testBlock = new Block(buf1.ToList(), 4);
            List<int> result = testBlock.Parse();

            Assert.AreEqual(17, result.Count);
            Assert.AreEqual(testBlock.Convert12bitToAdcVal(0xAAA), result[0]);
            Assert.AreEqual(testBlock.Convert12bitToAdcVal(0x1f5), result[1]);
            Assert.AreEqual(testBlock.Convert12bitToAdcVal(0x015), result[2]);
            Assert.AreEqual(testBlock.Convert12bitToAdcVal(0x241), result[16]);
        }

        [Test]
        public void Convert12bitTo10Test()
        {
            Block testBlock = new Block();

            int val1 = testBlock.Convert12bitToAdcVal(4000);
            int val2 = testBlock.Convert12bitToAdcVal(2976);
            int val3 = testBlock.Convert12bitToAdcVal(3488);
            int val4 = testBlock.Convert12bitToAdcVal(3872);

            Assert.AreEqual(23, val1);
            Assert.AreEqual(23, val2);
            Assert.AreEqual(22, val3);

            Assert.AreEqual(19, val4);

        }

        [Test]
        public void RealignTest()
        {

            byte[] buf1 = new byte[32];
            byte result;
            int offset = 3;
            buf1[8] = 0xFF;
            buf1[9] = 0xAA;
            buf1[15] = 0x53;
            buf1[16] = 0x25;
            buf1[17] = 0x15;

            result = (byte)((buf1[8] << offset) + (buf1[9] >> (8 - offset)));
           Assert.AreEqual(0xFD, result);
        }
        [Test]
        public void RemoveBitsTest()
        {
            byte []  buf1 = new byte[32];

            buf1[8]=0x02;
            buf1[9]=0xAA;
            buf1[15] = 0x53;
            buf1[16] = 0x25;
            buf1[17] = 0x15;

            Block testBlock = new Block(buf1.ToList<byte>(), 0);
            
            testBlock.removeBits(9*8+5);

            int mask = ((1 << 6) - 1);
            Assert.AreEqual(0xAA & mask, testBlock.Buffer[0] & mask);
            Assert.AreEqual(buf1[16], testBlock.Buffer[16 - 9]);
            Assert.AreEqual(5, testBlock.Offset);
        }
    }
}
