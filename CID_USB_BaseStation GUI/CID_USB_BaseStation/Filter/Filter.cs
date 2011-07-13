using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace CID_USB_BaseStation
{
    public class Filter
    {
        protected object filtLock = new object();

        protected LTISystem[] bpFilter;

        public double Response(double freq)
        {
            Complex result = 1;

            foreach (LTISystem lti in bpFilter)
            {
                result *= lti.response(freq);
            }

            return result.Magnitude;
        }
        
        public void updateFilter(LTISystem [] newFilter)
        {
            // prevent updating coefficients while we're in the middle of a filter operation. Prevents index out of bound exceptions
            lock (filtLock)
            {
                bpFilter = newFilter;
            }
        }

        public double runFilter(double val)
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
    }
}
