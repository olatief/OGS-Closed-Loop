using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;

namespace CID_USB_BaseStation
{
    class Scope
    {
        private static Scope currentScope;
        public static Scope CurrentScope { get { return currentScope; } }
        private static Int32 refreshRate = 100;
        private static float maxYrange = 4096;
        private static float minYrange = 100;

        private static float maxXrange = 1000; // in ms
        private static float minXrange = 10;   // in ms
        private static float Fs = 4000; // Hz
        private Point location;
        private Size size;
        private float xScalingFactor;
        private float yScalingFactor;
        private float xRange;
        private float yRange;

        private Queue<int> rawADCQueue = new Queue<int>(100);
        private int [] lastPlottedValues;
        private int triggerLine = 0; 
        private bool triggerLineDisplayed = false;
        public bool TriggerLineDisplayed { set; get; }

        public int TriggerLine { get { return triggerLine; } }
        public float YScrollLocation 
        { 
            set 
            { 
                yRange = value*(maxYrange-minYrange)/1000+minYrange;
                yScalingFactor = (yRange) / PlottingExtents.Height;
                DrawRawADC(lastPlottedValues);
            } 
        }

        public float XScrollLocation 
        { 
            set 
            { 
                xRange = value*(maxXrange-minXrange)/1000+minXrange;
                xScalingFactor = (xRange * Fs / 1000) / PlottingExtents.Width; // Basically what factor we should downsample by to display on the screen
                DrawRawADC(lastPlottedValues);
            } 
        }

        private Rectangle ScopeExtents;
        private Rectangle PlottingExtents;

        private Pen mDataPen = new Pen(Color.Navy, 2);
        private Form scopeForm;
        private System.Timers.Timer tmrUpdate = new System.Timers.Timer(refreshRate);
        

        public Scope(Point location, Size size, Form scopeForm)
        {
            this.location = location;
            this.size = size;
            this.scopeForm = scopeForm;
            currentScope = this;
            ScopeExtents = new Rectangle(location, size);
            PlottingExtents = ScopeExtents; // TODO: change this to make plotting area smaller for axis info
            lastPlottedValues = new int[PlottingExtents.Width];
            minYrange = size.Height;
            minXrange = 1000*size.Width/Fs;
            YScrollLocation = 500;
            XScrollLocation = 500;
          //  tmrUpdate.Elapsed += new ElapsedEventHandler(Timer_Tick);
           // tmrUpdate.Enabled = true;
        }

        public void AddRawADCtoQueue(int[] newVals)
        {
            int countThreshold = Convert.ToInt32(PlottingExtents.Width*xScalingFactor); // This is the number of values that we can display on our Scope
            int[] adcValuestoPlot = new int[countThreshold];
           
            for (int i = 0; i < newVals.Length; ++i)
            {
                rawADCQueue.Enqueue(newVals[i]);
            }

            // dont dequeue values until we have enough points we can plot on the screen
            if (rawADCQueue.Count > countThreshold)
            {
                for (int i = 0; i < countThreshold; i++)
                {
                    adcValuestoPlot[i] = rawADCQueue.Dequeue();
                }

                DrawRawADC(adcValuestoPlot);
            }
        }

        private void DrawRawADC(int[] adcVals)
        {
            int[] convertedToPixels = new int[PlottingExtents.Width];
            float sum;
            lastPlottedValues = adcVals;

            for(int i = 0; i < Math.Min(convertedToPixels.Length, (int)(adcVals.Length/xScalingFactor)); i++)
            {
                // Naive Downsample. TODO: use a more DSP way to downsample.
                // Average
                sum = 0;
                for (int j = 0; j < (int)xScalingFactor; j++)
                {
                    sum += adcVals[i * (int)xScalingFactor + j];
                }

                
               //  convertedToPixels[i] = Convert.ToInt32(sum / xScalingFactor);
                convertedToPixels[i] = Convert.ToInt32(adcVals[i * (int)xScalingFactor]/yScalingFactor);
               // Check for Overflows
                if (convertedToPixels[i] > PlottingExtents.Height/2)
                {
                    convertedToPixels[i] = PlottingExtents.Height/2;
                }
                if (convertedToPixels[i] < -PlottingExtents.Height / 2)
                {
                    convertedToPixels[i] = -PlottingExtents.Height / 2;
                }
            }

            DrawData(convertedToPixels);

        }

        private void DrawData(int[] adcVals)
        {

            DrawData(adcVals, 0, Math.Min(adcVals.Length, PlottingExtents.Width));
        }

        private void DrawData(int[] pxVals, int StartIndex, int StopIndex)
        {
            //   populateArray2();
            Point[] pts = new Point[StopIndex-StartIndex];
           // lastPlottedValues = pxVals;
           // float XScalingFactor = 5.0f;
            // float YScalingFactor = 1.0f;
            int BottomOffset = location.Y + size.Height / 2;// +picPlot.Size.Height;
            int LeftOffset = location.X;// +picPlot.Size.Width;

            for (int i = StartIndex; i < StopIndex; i++)
            {
                pts[i].X = LeftOffset + i;
                pts[i].Y = (BottomOffset + pxVals[i]);
            }

            Graphics myGraphic = scopeForm.CreateGraphics();
            myGraphic.Clear(System.Drawing.SystemColors.Control);

            myGraphic.FillRectangle(
              Brushes.Gray, ScopeExtents);

            // pMaxValue = myRectangle.Height-(BottomOffset + pMax);
            // myGraphic.DrawLine(Pens.Black,10,pMaxValue,180,pMaxValue);
            myGraphic.DrawCurve(mDataPen, pts);

            if (triggerLineDisplayed)
            {
            }

        }
 
        private void Timer_Tick(object sender, ElapsedEventArgs e)
        {
        }
    }
}
