using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using CID_USB_BaseStation;
 
namespace BaseStationTests
{
    [TestFixture]
    public class PacketHandlerTest
    {
        [Test]
        public void parseSingleChanTest()
        {
            UInt16 testVal = 1000;
            byte[] buf = new byte[Packet.MaxLength];
            for (int i = 0; i < 14; i++)
            {
                buf[2*i+1] = (byte)(testVal & 0xFF);
                buf[2 * i ] = (byte)(testVal >> 8);
            }

            Packet testPacket = new Packet(buf);
            PacketHandler pkthandleTest = new PacketHandler();

            int [] results = pkthandleTest.parseSingleChan(testPacket);

            Assert.AreEqual(2048-testVal, results[3]);

        }

    }
}
