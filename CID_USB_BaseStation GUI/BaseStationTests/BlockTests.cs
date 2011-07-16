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
