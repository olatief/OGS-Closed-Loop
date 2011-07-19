using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using Signal_Project;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace CID_USB_BaseStation
{
    public class ProcessingDoneEventArgs : EventArgs
    {
        public ProcessingDoneEventArgs(int[] results, bool isStimulating)
        {
            this.results = results;
            this.isStimulating = isStimulating;
        }

        public int[] results;
        public bool isStimulating;

    }	//end of class HandlerDoneEventArgs

    public class PacketHandler : IDisposable
    {
        public delegate void processingDoneHandler(object sender, ProcessingDoneEventArgs e);

        private static DataLogger logger = DataLogger.Instance;
        private Packet lastPacket = null;
        private int missedPackets;
        private int currentChannel = 1;

        public int CurrentChannel { get { return currentChannel; } set { currentChannel = value; } }

        public BlockingCollection<byte[]> bcWorkQueue = new BlockingCollection<byte[]>(new ConcurrentQueue<byte[]>());
        public static DataLogger Logger { get { return PacketHandler.logger; } }
        public Packet LastPacket { get { return lastPacket; } }
        public event processingDoneHandler processingDone;
        public Butterworth bpFilter = new Butterworth(0.1,.5,2);
        public Notch notchFilter = new Notch(60, 16000, 10);
        public bool bpFilterEnabled = false;
        public bool notchFilterEnabled = false;
        private Parser SixteenChanParser = new Parser();

        public PacketHandler()
        {
            WirelessStats.Instance.Reset();
            Task.Factory.StartNew(processQueue);

            
        }
       
        public void processQueue()
        {
            while (!bcWorkQueue.IsCompleted || disposed == true)
            {
                byte[] buffer = null;

                try
                {
                    buffer = bcWorkQueue.Take();
                }
                catch (InvalidOperationException) { }

                if (buffer != null)
                {
                    Packet rxPacket = new Packet(buffer);
                    
                    ParseNewPacket(rxPacket);
                }
            }
        }

        public void ParseNewPacket(Packet receivedPacket)
        {
            List<int> parsedValues;

            if (lastPacket != null)
            {

                UpdateWirelessStats(receivedPacket);

                parsedValues = parseSixteenChan(receivedPacket);
                
                
               // Scope.CurrentScope.AddRawADCtoQueue(parsedValues);
            }
            else
            {
                parsedValues = new List<int>();
            }
            
            lastPacket = receivedPacket;

            if (processingDone != null)
            {
                processingDone(this, new ProcessingDoneEventArgs(parsedValues.ToArray(), lastPacket.IsStimulating));
            }
        }

        private void UpdateWirelessStats(Packet receivedPacket)
        {
            // missedPackets = receivedPacket.calculateMissedPacketsBetween(lastPacket);
            missedPackets = receivedPacket.Count - lastPacket.Count - 1;
            if (receivedPacket.Count <= lastPacket.Count) // check for overflow since count only goes to 128;
            {
                if (missedPackets == 0)
                {
                    // throw new InvalidOperationException();
                }
                missedPackets += 128;
            }

            if (missedPackets == 0)
            {
                ++WirelessStats.Instance.NumSuccessRxPackets;
            }
            else
            {
                WirelessStats.Instance.NumDroppedPackets += missedPackets;
                ++WirelessStats.Instance.NumSuccessRxPackets; // we still need to count the last packet we received as a successful packet
            }
        }

        public List<int> parseSixteenChan(Packet receivedPacket)
        {
            List<int> parsedValues = new List<int>();
            List<Block> validBlocks = SixteenChanParser.ParseNewPacket(receivedPacket);

            foreach (Block block in validBlocks)
            {
                parsedValues.Add(block.Parse()[currentChannel]);
            }
            return parsedValues;
        }


        public int[] parseSingleChan(Packet receivedPacket)
        {
            List<int> parsedValues = new List<int>();

            for (int i = 0; i < parsedValues.Length; i++)
            {
                tempValue = pkt.DataBuffer[2*i+1] + (pkt.DataBuffer[2*i] << 8);
              /*  if (tempValue >= 512)
                {
                    tempValue = -tempValue;
                }
               * */
                parsedValues[i] = 2048-tempValue; // This is because a value of 2048 is 0 in differential recording mode
                
                logger.LogLine(parsedValues[i]);
            }

            return parsedValues;
        }

        private Int32[] bitsToInt(ref UInt16[] arr)
        {
            Int32[] val = new Int32[16];
            Int32 tmpVal = 0;

            for (short i = 0; i < val.Length; ++i)
            {
                tmpVal = 0;

                for (short j = 2; j < 11; ++j)
                {
                    tmpVal += ((arr[12 * i + j]) << (10 - j));
                }

                if (1 == arr[12 * i + 1]) // negative # (2's complement)
                {
                    tmpVal = -1 * tmpVal;
                }

                val[i] = tmpVal;
            }
            return val;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    // so it doesnt keep on running when we shut down. TODO: see if this is necessary so we can get rid of Dispose pattern
                    this.bcWorkQueue.CompleteAdding();
                }

                disposed = true;
            }
        }
        ~PacketHandler()
        {
            Dispose(false);
        }
    }
}
