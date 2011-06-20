using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using LibUsbDotNet;
using LibUsbDotNet.LibUsb;
using LibUsbDotNet.Main;
using EC = LibUsbDotNet.Main.ErrorCode;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace CID_USB_BaseStation
{
    public partial class frmMain : Form
    {
        Stopwatch sw = new Stopwatch();
        private const byte endpoint = 0x02;
        private UsbDevice mUsbDevice;
        private UsbEndpointReader mEpReader;
        private UsbEndpointWriter mEpWriter;
        private UsbRegDeviceList mRegDevices;

        progAll pAll = new progAll();
        progStim pStim = new progStim();
        progAlgo pAlgo = new progAlgo();

        DataLogger dataLogger = DataLogger.Instance;
        PacketHandler pktHandler;

        private void UsbGlobals_UsbErrorEvent(object sender, UsbError e) { Invoke(new UsbErrorEventDelegate(UsbGlobalErrorEvent), new object[] { sender, e }); }
        private void UsbGlobalErrorEvent(object sender, UsbError e) { /* tRecv.AppendText(e + "\r\n");*/ }

        public frmMain()
        {
            
            InitializeComponent();
            UsbDevice.UsbErrorEvent += UsbGlobals_UsbErrorEvent;
        }

        private void cboDevices_DropDown(object sender, EventArgs e)
        {
            // Get a new device list each time the device dropdown is opened
            cboDevices.Items.Clear();
            mRegDevices = UsbDevice.AllDevices;

            foreach (UsbRegistry regDevice in mRegDevices)
            {
                // add the Vid, Pid, and usb device description to the dropdown display.
                // NOTE: There are many more properties available to provide you with more device information.
                // See the LibUsbDotNet.Main.SPDRP enumeration.
                string sItem = String.Format("Vid:{0} Pid:{1} {2}",
                                             regDevice.Vid.ToString("X4"),
                                             regDevice.Pid.ToString("X4"),
                                             regDevice.FullName);
                cboDevices.Items.Add(sItem);
            }
           // tsNumDevices.Text = cboDevices.Items.Count.ToString();
        }

        

        #region VALIDATIONS
        
        string[] ledvals = { "0", "20.0", "17.0", "14.0", "12.0", "10.0", "8.6", "7.0", "6.0", "5.0", "4.2", "3.6", "3.0", "2.4", "1.8" };

        private void Form1_Load(object sender, EventArgs e)
        {
            tvalDC.Tag = validate(10, 90, delegate(Int32 val) { pStim.DC = (byte)val; });
            tvalAmplitude.Tag = validate(0, 14, delegate(Int32 val) { pStim.Amplitude = (byte)val; tEstLedCurrent.Text = ledvals[val]; });
            tvalFreq.Tag = validate(0, 200, delegate(Int32 val) { pStim.Freq = (byte)val; ComputeTimes(); });
            tvalHighThresh.Tag = validate(100, 3000, delegate(Int32 val) { pAlgo.high = (ushort)val; });
            tvalIEI.Tag = validate(10, 2000, delegate(Int32 val) { pAlgo.IEI = (byte)(val/10); });
            tvalLowThresh.Tag = validate(1, 3000, delegate(Int32 val) { pAlgo.low = (ushort)val; });
            tvalNstage.Tag = validate(1, 10, delegate(Int32 val) { pAlgo.nStage = (byte)val; });

            tvalPulseOn.Tag = validate(1, 250, delegate(Int32 val) { pStim.PulseOn = (byte)val; ComputeTimes(); });
            tvalPulseOff.Tag = validate(1, 250, delegate(Int32 val) { pStim.PulseOff = (byte)val; ComputeTimes(); });
            tvalCycles.Tag = validate(0, 250, delegate(Int32 val) { pStim.Cycles = (byte)val; ComputeTimes(); });
            tvalDelay.Tag = validate(0, 40 * 250, delegate(Int32 val) { pAlgo.delay = (byte)(val / 40); tvalDelay.Text = Convert.ToString(pAlgo.delay * 40); });
        }

        private void ComputeTimes()
        {
            float timeOn = 0;
            float timeOff = 0;
            float timeTotal = 0;

            if (pStim.Freq != 0)
            {
                timeOn = pStim.PulseOn * 1000 / pStim.Freq;

        

                timeOff = pStim.PulseOff * 1000 / pStim.Freq;
                timeTotal = (timeOn + timeOff) * pStim.Cycles;
            }
            testTimeOn.Text = Convert.ToString(timeOn);
            testTimeOff.Text = Convert.ToString(timeOff);
            testTotalTime.Text = (pStim.Cycles == 0) ? "Inf" : Convert.ToString(timeTotal); 
        }

        private void OnValidated(object sender, EventArgs e)
        {

            Int32 val = Int32.Parse(((TextBox)sender).Text);

            ((Validator)((TextBox)sender).Tag).AssignVal(val);
        }
        
        
        public void OnValidationTest(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Int32 userVal;
            Validator val;
            
            val = (Validator)(((TextBox)sender).Tag);
            if (Int32.TryParse(((TextBox)sender).Text, out userVal))
            {
                if (userVal > val.max || userVal < val.min)
                {
                    e.Cancel = true;
                    this.errorProvider1.SetError((TextBox)sender, String.Format("Value is out of range: {0} to {1}", val.min, val.max));
                }
                else
                {
                    this.errorProvider1.SetError((TextBox)sender, String.Empty);
                }
            }
            else
            {
                e.Cancel = true;
                this.errorProvider1.SetError((TextBox)sender, "Value is not an integer");
            }
        }

        private Validator validate(Int32 min, Int32 max, stAssignVal Assign)
        {
            Validator val;
            val.max = max;
            val.min = min;
            val.AssignVal = Assign;

            return val;
        }

        #endregion     

        #region Nested Types

        private delegate void OnDataReceivedDelegate(object sender, EndpointDataEventArgs e);

        private delegate void UsbErrorEventDelegate(object sender, UsbError e);

        #endregion
       
        UInt32 tmr_cnt = 0;
        
        private void cmdOpen_Click(object sender, EventArgs e)
        {   
            if (cmdOpen.Text == "Open")
            {
                if (cboDevices.SelectedIndex >= 0)
                {
                    if (openDevice(cboDevices.SelectedIndex))
                    {
                        pktHandler = new PacketHandler();

                        if (!dataLogger.LoggingActivated)
                        {
                            MessageBox.Show("Data will not be saved for this session because no file was selected.");
                        }
                        cmdOpen.Enabled = false;
                        sw.Restart();

                        btnFile.Enabled = false;
                        
                        mEpReader.DataReceivedEnabled = true;
                        cmdOpen.Text = "Close";
                        tmr_cnt = 0;
                    }
                }
            }
            else
            {
                sw.Stop();
                
                closeDevice();
                cmdOpen.Text = "Open";
                dataLogger.Stop();
                btnFile.Enabled = true;
                tRecv.Text = Convert.ToString(sw.ElapsedMilliseconds) + "/" + Convert.ToString(tmr_cnt) ;
            }
            cmdOpen.Enabled = true;
        }

        private void closeDevice()
        {
            if (mUsbDevice != null)
            {
                if (mUsbDevice.IsOpen)
                {
                    if (mEpReader != null)
                    {
                        mEpReader.DataReceivedEnabled = false;
                        mEpReader.DataReceived -= mEp_DataReceived;
                        mEpReader.Dispose();
                        mEpReader = null;
                    }
                    if (mEpWriter != null)
                    {
                        mEpWriter.Abort();
                        mEpWriter.Dispose();
                        mEpWriter = null;
                    }

                    // If this is a "whole" usb device (libusb-win32, linux libusb)
                    // it will have an IUsbDevice interface. If not (WinUSB) the 
                    // variable will be null indicating this is an interface of a 
                    // device.
                    IUsbDevice wholeUsbDevice = mUsbDevice as IUsbDevice;
                    if (!ReferenceEquals(wholeUsbDevice, null))
                    {
                        // Release interface #0.
                        wholeUsbDevice.ReleaseInterface(0);
                    }

                    mUsbDevice.Close();
                    mUsbDevice = null;
                    tsStatus.Text = "Device Closed";
                    //chkLogToFile.Checked = false;
                }

            }
            // panTransfer.Enabled = false;
        }

        private bool openDevice(int index)
        {
            bool bRtn = false;

            closeDevice();
           /* TODO: Delete
            chkRead.CheckedChanged -= chkRead_CheckedChanged;
            chkRead.Checked = false;
            cmdRead.Enabled = true;
            chkRead.CheckedChanged += chkRead_CheckedChanged;
        */
            if (mRegDevices[index].Open(out mUsbDevice))
            {
                bRtn = true;

                // If this is a "whole" usb device (libusb-win32, linux libusb)
                // it will have an IUsbDevice interface. If not (WinUSB) the 
                // variable will be null indicating this is an interface of a 
                // device.
                IUsbDevice wholeUsbDevice = mUsbDevice as IUsbDevice;
                if (!ReferenceEquals(wholeUsbDevice, null))
                {
                    // This is a "whole" USB device. Before it can be used, 
                    // the desired configuration and interface must be selected.

                    // Select config #1
                    wholeUsbDevice.SetConfiguration(1);

                    // Claim interface #0.
                    wholeUsbDevice.ClaimInterface(0);
                }

                if (bRtn)
                {
                    byte epNum = endpoint;
                    mEpReader = mUsbDevice.OpenEndpointReader((ReadEndpointID)(epNum | 0x80), 64);
                    mEpWriter = mUsbDevice.OpenEndpointWriter((WriteEndpointID)epNum);
                    mEpReader.DataReceived += mEp_DataReceived;
                    mEpReader.Flush();
                //    panTransfer.Enabled = true;
                }
            }
            
            if (bRtn)
            {
                tsStatus.Text = "Device Opened.";
            }
            else
            {
                tsStatus.Text = "Device Failed to Opened!";
                if (!ReferenceEquals(mUsbDevice, null))
                {
                    if (mUsbDevice.IsOpen) mUsbDevice.Close();
                    mUsbDevice = null;
                }
            }

            return bRtn;
        }

        private void mEp_DataReceived(object sender, EndpointDataEventArgs e) { 
            Invoke(new OnDataReceivedDelegate(OnDataReceived), new object[] { sender, e }); 
        }

        private void OnDataReceived(object sender, EndpointDataEventArgs e)
        {
            Packet RxPacket = new Packet(e);
            pktHandler.ParseNewPacket(RxPacket);
            
            tslStatus.Text = String.Format("Values Written: {0}", dataLogger.NumValuesWritten);

            
            if (RxPacket.IsStimulating) // means it was Stimulating
            {
                tmrStim.Enabled = true;
                tslStimulating.Text = "Stimulating!!";
            }
            else
            {
                tmrStim.Enabled = false;
                tslStimulating.Text = "             ";
            }
        }


        private void btnProgAll_Click(object sender, EventArgs e)
        {
            pAll.pType = pktType.All;

            pAll.pStim = pStim;
            pAll.pAlgo = pAlgo;

            sendProg(pAll);
        }

        public static byte[] StructureToByteArray(object obj)
        {
            int Length = Marshal.SizeOf(obj);
            byte[] bytearray = new byte[Length];
            IntPtr ptr = Marshal.AllocHGlobal(Length);
            Marshal.StructureToPtr(obj, ptr, false);
            Marshal.Copy(ptr, bytearray, 0, Length);
            Marshal.FreeHGlobal(ptr);
            return bytearray;
        }



        private void btnProgStim_Click(object sender, EventArgs e)
        {
            pAll.pType = pktType.Stim;
            pAll.pStim = pStim;
            pAll.pAlgo = pAlgo;

            sendProg(pAll);
        }


        private void btnProgAlgo_Click(object sender, EventArgs e)
        {
            pAll.pType = pktType.Algo;
            pAll.pStim = pStim;
            pAll.pAlgo = pAlgo;

            sendProg(pAll);
        }

        private void sendProg(progAll pAll)
        {
            ErrorCode wError;
            byte[] bytesToWrite = StructureToByteArray(pAll);

            int uiTransmitted;
            if (mEpWriter != null)
            {
               
                wError = mEpWriter.Write(bytesToWrite, 1000, out uiTransmitted);
                if (wError == ErrorCode.None)
                {
                    tsStatus.Text = uiTransmitted + " bytes written.";
                }
                else
                {
                    tsStatus.Text = "Write failed!";
                    mEpWriter.Reset();
                }
            }
            else
            {
                tsStatus.Text = "USB device needs to be Opened";
            }

        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            string s = tRaw.Text;
            string[] lines = s.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            UInt16[] bits = lines.Select(x => UInt16.Parse(x)).ToArray();

           // int[] vals = bitsToInt(ref bits);

            tConverted.Text = "";
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "Data File|*.dat";
            saveFileDialog1.Title = "Save a Data File";
            saveFileDialog1.OverwritePrompt = true;
            saveFileDialog1.ShowDialog();


            if (saveFileDialog1.FileName != "")
            {
                dataLogger.Start(saveFileDialog1.FileName);
            }
            else
            {
                dataLogger.Stop();
            }

            txtFilename.Text = dataLogger.FileName;
        }

        private void frmMain_Activated(object sender, EventArgs e)
        {
            List<TextBox> tvals = new List<TextBox>();

            tvals.Add(tvalAmplitude);
            tvals.Add(tvalDC);
            tvals.Add(tvalFreq);
            tvals.Add(tvalHighThresh);
            tvals.Add(tvalIEI);
            tvals.Add(tvalLowThresh);
            tvals.Add(tvalNstage);
            tvals.Add(tvalPulseOff);
            tvals.Add(tvalPulseOn);
            tvals.Add(tvalDelay);
            tvals.Add(tvalCycles);

            foreach (TextBox tval in tvals)
            {
                tval.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidationTest);
                tval.Validated += new System.EventHandler(this.OnValidated);
                tval.Select(); // Validate
            }
            tvals[0].Select();
        }

        private void tmrStim_Tick(object sender, EventArgs e)
        {
            tslStimulating.Text = "Stimulating!!";
            if (tslStimulating.ForeColor == Color.Blue)
            {
                tslStimulating.ForeColor = Color.Red;
            }
            else
            {
                tslStimulating.ForeColor = Color.Blue;
            }

        }

        #region DATAPLOTTING

        Rectangle myRectangle; 
        Pen mDataPen = new Pen(Color.Navy, 2);
        Graphics myGraphic; 

        private void initPlot()
        {
            myRectangle = new Rectangle(picPlot.Location, picPlot.Size);
            myGraphic = this.CreateGraphics();

            timer1.Stop();
            timer1.Enabled = false;
            timer1.Enabled = true;
        }

        private void startDrawing()
        {
            timer1.Stop();
            timer1.Enabled = false;
            timer1.Enabled = true;
        }

        private int LeftOffset = 10;
        private  int BottomOffset = 10; 
        private const float SamplingFreq = 4000; // (Hz)

        private float XScalingFactor = 5.0f;
        private float YScalingFactor = 1.0f;

        private void DrawData(Int16[] adcVals)
        {
         //   populateArray2();
          Point[] pts = new Point[adcVals.Length];
          BottomOffset = picPlot.Location.Y + picPlot.Size.Height/2;// +picPlot.Size.Height;
          LeftOffset = picPlot.Location.X;// +picPlot.Size.Width;
          for (int i=0; i < adcVals.Length; i++){
              pts[i].X = LeftOffset + Convert.ToInt32(XScalingFactor * i);
              pts[i].Y = (BottomOffset +  Convert.ToInt32(YScalingFactor*adcVals[i]));
          }

          myGraphic = this.CreateGraphics();
        //  myGraphic.Clear(System.Drawing.SystemColors.Control);
          myGraphic.DrawRectangle(
           Pens.Black, 
           picPlot.Location.X,
           picPlot.Location.Y,
          picPlot.Size.Width - 1,
            picPlot.Size.Height - 1);

          // pMaxValue = myRectangle.Height-(BottomOffset + pMax);
          // myGraphic.DrawLine(Pens.Black,10,pMaxValue,180,pMaxValue);
          myGraphic.DrawCurve(mDataPen, pts);
 
        }
        #endregion

    }
}
