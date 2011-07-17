using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;
using CID_USB_BaseStation;

namespace BaseStationTests
{
    [TestFixture]
    class PacketTests
    {
        [Test]
        public void ReverseBitsTest()
        {
            Packet testPacket = new Packet();

            byte res1 = testPacket.reverseBits(0xFF); // easy
            byte res2 = testPacket.reverseBits(0x0A);
            byte res3 = testPacket.reverseBits(0x5F);

            Assert.AreEqual(0xFF,res1);
            Assert.AreEqual(0x50,res2);
            Assert.AreEqual(0xFA, res3);

        }
    }
}
