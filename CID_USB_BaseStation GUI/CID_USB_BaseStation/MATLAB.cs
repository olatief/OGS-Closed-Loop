using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CID_USB_BaseStation
{
    class Matlab
    {
        private static MLApp.MLAppClass matlab = new MLApp.MLAppClass();

        private static double[] arrayreal = new double[10];


        public static string tester()
        {
            double[] temp = new double[10];

            matlab.PutWorkspaceData("temp1", "base", temp);
           return matlab.Execute("sqrt(5)");
        }
    }
}
