using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace CID_USB_BaseStation
{
    public sealed class WirelessStats : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private static readonly WirelessStats instance = new WirelessStats();
        private long startTime;
        private long stopTime;
        private long numDroppedPackets;
        private long numSuccessRxPackets;

        public static WirelessStats Instance { get { return instance; } }  // Singleton Pattern
        public long StartTime { set; get; }
        public long StopTime { set; get; }
      

        public long NumDroppedPackets 
            {
                get { return numDroppedPackets; }
                set
                {
                    numDroppedPackets = value;
                    OnPropertyChanged("NumDroppedPackets");
                }
            }
        public long NumSuccessRxPackets { get { return numSuccessRxPackets; }
            set
            {
                numSuccessRxPackets = value;
                OnPropertyChanged("NumSuccessRxPackets");
            }
        }
        
        private WirelessStats() { Reset(); }

        public void Reset()
        {
            StartTime = System.DateTime.Now.Ticks;
            StopTime = -1;

            NumDroppedPackets = 0;
            NumSuccessRxPackets = 0;
        }

        private void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
