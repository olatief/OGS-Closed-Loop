using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Signal_Project;

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
            double[] filterVal = new double[1001];


            int i = 0;
            // generate sine wave data
            oScope.Show();
            filterVal[0] = pktHandler.bpFilter.runFilter(1);
           // oScope.AddData(filterVal[0], 0, 0);
            for (i = 0; i < adcVals.Length; ++i)
            {
                
                adcVals[i] = Convert.ToInt32(1000 * Math.Sin(2 * Math.PI * (i) / 50));
                oScope.AddData(pktHandler.bpFilter.Response((double)i/(double)adcVals.Length), 0, 0);
                oScope.AddExternalData(adcVals[i]);
            }

            

            

            //scope.AddRawADCtoQueue(adcVals);

          
        }

        

        
    }
}
