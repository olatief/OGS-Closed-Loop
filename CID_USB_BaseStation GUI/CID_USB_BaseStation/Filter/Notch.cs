using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace CID_USB_BaseStation
{
    class Notch : Filter
    {
        private double notchFrequency;
        private double samplingFrequency;
        private double bandwidth;
        private int numHarmonics;
        private double aPass;

        public double SamplingFrequency
        {
            get { return samplingFrequency; }
            set
            {
                if (samplingFrequency != value)
                {
                    samplingFrequency = value;
                    updateFilter();
                }
            }
        }

        public double NotchFrequency
        {
            get { return notchFrequency; }
            set
            {
                if (notchFrequency != value)
                {
                    notchFrequency = value;
                    updateFilter();
                }
            }
        }
        public double Bandwidth
        {
            get { return bandwidth; }
            set
            {
                if (bandwidth != value)
                {
                    bandwidth = value;
                    updateFilter();
                }
            }
        }
        public int NumHarmonics
        {
            get { return numHarmonics; }
            set
            {
                if (numHarmonics != value)
                {
                    numHarmonics = value;
                    updateFilter();
                }
            }
        }
        public double APass
        {
            get { return aPass; }
            set
            {
                if (aPass != value)
                {
                    aPass = value;
                    updateFilter();
                }
            }
        }
        public Notch(double notchFreq, double samplingFrequency, double bandwidth) : this(notchFreq, samplingFrequency, bandwidth, 1.0f) { }
        public Notch(double notchFreq, double samplingFrequency, double bandwidth, int numHarmonics) : this( notchFreq,  samplingFrequency,  bandwidth,  1,  numHarmonics) { }
        public Notch(double notchFreq, double samplingFrequency, double bandwidth, double aPass) : this( notchFreq,  samplingFrequency,  bandwidth,  aPass,  1) { }

        public Notch(double notchFreq, double samplingFrequency, double bandwidth, double aPass, int numHarmonics)
        {
            this.notchFrequency = notchFreq;
            this.samplingFrequency = samplingFrequency;
            this.bandwidth = bandwidth;
            this.aPass = aPass;
            this.numHarmonics = numHarmonics;

            bpFilter = notchesPrototype();
        }

        private void updateFilter()
        {
            updateFilter(notchesPrototype());
        }

        public LTISystem[] notchesPrototype(double notchFreq, double samplingFrequency, double bandwidth, double aPass, int numHarmonics)
        {
            this.notchFrequency = notchFreq;
            this.samplingFrequency = samplingFrequency;
            this.bandwidth = bandwidth;
            this.aPass = aPass;
            this.numHarmonics = numHarmonics;

            return notchesPrototype();
        }
        private LTISystem[] notchesPrototype()
        {
            LTISystem[] notchFilt = new LTISystem[numHarmonics];

            for (int i = 0; i < numHarmonics; ++i)
            {
                notchFilt[i] = notchPrototype(i);
            }

            return notchFilt;
        }

        private LTISystem notchPrototype(int harmonic)
        {
            LTISystem notch = new LTISystem(2, 2);

            double BW = 2 * Math.PI * bandwidth / samplingFrequency;
            double Wo = 2 * Math.PI * harmonic * notchFrequency / samplingFrequency;

            double Gb = Math.Pow(10,-aPass / 20);
            double beta = Math.Tan(BW/2)*Math.Sqrt(1 - Gb * Gb)/Gb;
            double gain = 1 / (1 + beta);

            notch.a[0] = gain;
            notch.a[1] = -2 * gain*Math.Cos(Wo);
            notch.a[2] = gain;

            notch.b[1] = notch.a[1];
            notch.b[2] = 2 * gain - 1;

            return notch;
        }
    }
}
