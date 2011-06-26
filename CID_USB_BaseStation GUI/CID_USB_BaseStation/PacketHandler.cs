﻿using System;
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

    class PacketHandler : IDisposable
    {
        public delegate void processingDoneHandler(object sender, ProcessingDoneEventArgs e);

        private static DataLogger logger = DataLogger.Instance;
        private Packet lastPacket = null;
        private int missedPackets;

        public BlockingCollection<byte[]> bcWorkQueue = new BlockingCollection<byte[]>(new ConcurrentQueue<byte[]>());
        public static DataLogger Logger { get { return PacketHandler.logger; } }
        public Packet LastPacket { get { return lastPacket; } }
        public event processingDoneHandler processingDone;

       
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
                    ParseNewPacket(new Packet(buffer));
                }
            }
        }

        public void ParseNewPacket(Packet receivedPacket)
        {
            int [] parsedValues;
            if (lastPacket != null)
            {
                missedPackets = receivedPacket.Count - lastPacket.Count - 1;
                
                if (receivedPacket.Count <= lastPacket.Count) // check for overflow since count only goes to 128;
                {
                    if (missedPackets == 0)
                    {
                        throw new InvalidOperationException();
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
                }

                parsedValues = receivedPacket.AdcVals;

               // Scope.CurrentScope.AddRawADCtoQueue(parsedValues);
            }
            else
            {
                parsedValues = new int[0];
            }
            
            lastPacket = receivedPacket;

            if (processingDone != null)
            {
                processingDone(this, new ProcessingDoneEventArgs(parsedValues, lastPacket.IsStimulating));
            }
        }

        private int[] parseSingleChan(Packet pkt)
        {
            int[] parsedValues = new int[15];
            int tempValue;
            for (int i = 0; i < parsedValues.Length; i++)
            {
                tempValue = pkt.Buffer[2*i+1] + (pkt.Buffer[2*i] << 8);
              /*  if (tempValue >= 512)
                {
                    tempValue = -tempValue;
                }
               * */

                parsedValues[i] = 2048-tempValue;
                
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
