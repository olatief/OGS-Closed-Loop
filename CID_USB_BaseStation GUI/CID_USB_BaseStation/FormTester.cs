using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace CID_USB_BaseStation
{
    public partial class frmMain : Form
    {

        private void cmdTestStim_Click(object sender, EventArgs e)
        {
            
            if (tmrStim.Enabled)
            {
                tmrStim.Enabled = false;
            }
            else
            {
                tmrStim.Enabled = true;
            }
        }

        private void cmdDraw_Click(object sender, EventArgs e)
        {
            int[] adcVals = new int[1000];

            int i = 0;
            // generate sine wave data
            for (i = 0; i < adcVals.Length; ++i)
            {
                adcVals[i] = Convert.ToInt32(1000 * Math.Sin(2 * Math.PI * (i) / 50));
            }

            scope.AddRawADCtoQueue(adcVals);
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            // string s = tRaw.Text;
            // string[] lines = s.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            // UInt16[] bits = lines.Select(x => UInt16.Parse(x)).ToArray();

            // int[] vals = bitsToInt(ref bits);

            //  tConverted.Text = "";
        }
    }
}
