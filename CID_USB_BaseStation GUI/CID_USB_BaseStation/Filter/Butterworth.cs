using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace CID_USB_BaseStation
{
    class Butterworth
    {
        private object filtLock = new object();

        private LTISystem[] bpFilter;
        private double lowfreq;
        private double hifreq;
        private int nSection;

        public double LowFreq
        {
            get { return lowfreq; }
            set
            {
                if (lowfreq != value)
                {
                    lowfreq = value;
                    updateFilter();
                }
            }
        }
        public double HiFreq
        {
            get { return hifreq; }
            set
            {
                if (hifreq != value)
                {
                    hifreq = value;
                    updateFilter();
                }
            }
        }
        public int Nsection
        {
            get { return nSection; }
            set
            {
                if (nSection != value)
                {
                    nSection = value;
                    updateFilter();
                }
            }
        }
        private void updateFilter()
        {
            LTISystem[] temp =  BandPass(lowfreq,hifreq,nSection); // no reason why we cant calculate coefficients before we lock
            // prevent updating coefficients while we're in the middle of a filter operation. Prevents index out of bound exceptions;
            lock (filtLock) 
            {
                bpFilter = temp; 
            }
        }

        public Butterworth(double lofreq, double hifreq, int nSection)
        {
            bpFilter = BandPass( lofreq,  hifreq, nSection);
        }

        public double Response(double freq)
        {
            Complex result = 1;
            foreach (LTISystem lti in bpFilter)
            {
                result *= lti.response(freq);
            }

            return result.Magnitude;
        }

        public double Filter(double val)
        {
            double result;

            lock (filtLock)
            {
                result = bpFilter[0].Eval(val);
                for (int i = 1; i < bpFilter.Length; i++)
                {
                    result = bpFilter[i].Eval(result);
                }
            }
            return result;
        }

        public static Complex[] Poles( double freq,
                                        int nSection)
        {
            double tanw = Math.Tan(Math.PI * freq);
            Complex[] poles;

            if (nSection == 1)
            {
                poles = new Complex[1];
                poles[0] = new Complex(-1, 0);
            }
            else
            {
                poles = new Complex[nSection / 2];
                for (int m = nSection/2; m < nSection; m++)
                {
                    double ang = (2 * m + 1) * Math.PI / (2 * nSection);
                    double d = 1 - 2 * tanw * Math.Cos(ang) + tanw * tanw;
                    poles[m - nSection/2] =
                        new Complex((1 - tanw * tanw) / d, 2 * tanw * Math.Sin(ang) / d);
                }
            }
            return poles;
        }

        public static LTISystem[] BandPass(double lofreq, double hifreq, int nSection)
        {
            if ((nSection % 2) == 1) nSection++; // force even # of sections

            Complex[] pol = Poles(hifreq - lofreq, nSection);
            LTISystem[] bpfilt = new LTISystem[nSection];
            // translate the poles to band-pass position
            Complex[] bpol = new Complex[nSection];
            double wlo = 2 * Math.PI * lofreq;
            double whi = 2 * Math.PI * hifreq;
            double ang = Math.Cos((whi + wlo) / 2) / Math.Cos((whi - wlo) / 2);
            for (int i = 0; i < nSection / 2; i++)
            {
                Complex p1 = new Complex(pol[i].Real + 1, pol[i].Imaginary);
                Complex tmp = Complex.Sqrt(p1 * p1 * ang * ang * 0.25 - pol[i]);
                bpol[2 * i] = (p1 * ang * 0.5) + tmp;
                bpol[2 * i + 1] = (p1 * ang * 0.5) - tmp;
            }

            // convert each conjugate pole pair to
            //   difference equation
            for (int i=0;i<nSection;i++) {
              bpfilt[i] = new LTISystem(2,2);
              // put in conjugate pole pair
              bpfilt[i].b[1] = -2.0 * bpol[i].Real;
              bpfilt[i].b[2] = bpol[i].Real * bpol[i].Real +
                            bpol[i].Imaginary * bpol[i].Imaginary;
              // put zeros at (1,0) and (-1,0)
              bpfilt[i].a[0] = 1.0;
              bpfilt[i].a[1] = 0.0;
              bpfilt[i].a[2] = -1.0;
              // normalise to unity gain
              double gain = (bpfilt[i].response((hifreq+lofreq)/2)).Magnitude;
              bpfilt[i].a[0] = bpfilt[i].a[0]/gain;
              // bpfilt[i].a[1] = bpfilt[i].a[1]/gain; // we know this is 0 since its a bandpass
              bpfilt[i].a[2] = bpfilt[i].a[2]/gain;
            }
 
            return bpfilt;
        }
    }
}
