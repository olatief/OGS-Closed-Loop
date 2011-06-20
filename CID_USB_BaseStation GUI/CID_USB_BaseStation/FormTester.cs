using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
            Int16[] adcVals = new Int16[50];
            int i = 0;
            // gereate sine wave data
            for (i = 0; i < adcVals.Length; ++i)
            {
                adcVals[i] = Convert.ToInt16(100 * Math.Sin(2 * Math.PI * (i) / 5));
            }

            DrawData(adcVals);
        }

    }
}
