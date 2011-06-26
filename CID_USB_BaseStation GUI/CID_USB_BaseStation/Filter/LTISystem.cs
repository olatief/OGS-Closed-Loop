using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace CID_USB_BaseStation
{
    class LTISystem
    {
        public Double[] a;
        public Double[] b;
        public Double[] s;
        
        public LTISystem(int na, int nb)
        {
            a = new Double[na + 1];
            b = new Double[nb + 1];
            s = new Double[(na > nb) ? na + 1 : nb + 1];

            b[0] = 1.0f;
        }
        public void Clear()
        {
            for(int i = 0; i < s.Length; i++)
                s[i] = 0;
            
        }
        public double Eval(double ival)
        {
            int i;
            double result = 0;

            for (i = s.Length - 1; i > 0; i--)
                s[i] = s[i - 1];
            
            s[0] = ival;
            
            for (i = 1; i < b.Length; i++)
                s[0] -= b[i] * s[i];

            for (i = 0; i < a.Length; i++)
                result += a[i] * s[i];

            return result;
        }

        public Complex response(double freq)
        {
            int i;
            Complex rnum = 0;
            Complex rden = 0;
            Complex[] omega = new Complex[s.Length];
            Complex z = Complex.Exp(new Complex(0, 2 * Math.PI * freq));
            omega[0] = 1.0;
            omega[1] = z;

            for (i = 2; i < s.Length; i++)
                omega[i] = omega[i - 1] * z;
            
            for (i = 0; i < a.Length; i++)
                rnum += a[i] * omega[i];
            
            rden = omega[0];
            for (i = 1; i < b.Length; i++)
                rden += b[i] * omega[i];
            

            if (rden.Magnitude == 0)
            {
                return Double.MaxValue;
            }
            else
            {
                return rnum / rden;
            }
        }
    }
}
