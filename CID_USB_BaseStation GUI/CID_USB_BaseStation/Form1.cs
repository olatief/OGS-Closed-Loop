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
using System.Drawing;

namespace CID_USB_BaseStation
{
    public partial class frmMain : Form
    {
        private const double OVERSAMPLE = 1;
        Stopwatch sw = new Stopwatch();
        long count = 0;
        private const byte endpoint = 0x02;
        private UInt16 [] dataIn = new UInt16 [15];
        private UsbDevice mUsbDevice;
        private UsbEndpointReader mEpReader;
        private UsbEndpointWriter mEpWriter;
        private UsbRegDeviceList mRegDevices;

        private ArrayList data = new ArrayList();
        private UInt32 [] pktStart = new UInt32[10000];
        private Int32[] pktLoc = new Int32[10000];
        private UInt16 pktStart_ind = 0;

        private UInt16[] bitValues = new UInt16[1000];
        private UInt16 bv_ind = 0;

        progAll pAll = new progAll();
        progStim pStim = new progStim();
        progAlgo pAlgo = new progAlgo();

        /// <summary>
        /// Converts bytes into a hexidecimal string
        /// </summary>
        /// <param name="data">Bytes to converted to a a hex string.</param>
        private static StringBuilder GetHexString(byte[] data, int offset, int length)
        {
            StringBuilder sb = new StringBuilder(length * 3);
            for (int i = offset; i < (offset + length); i++)
            {
                sb.Append(data[i].ToString("X2") + " ");
            }
            return sb;
        }


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

        string[] ledvals = { "0", "20.0", "17.0", "14.0", "12.0","10.0", "8.6", "7.0", "6.0", "5.0", "4.2","3.6","3.0","2.4","1.8" };

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
        private Int32[] bitsToInt(ref UInt16[] arr)
        {
            Int32[] val = new Int32[16];
            Int32 tmpVal = 0;

            for(short i =0; i < val.Length; ++i)
            {
                tmpVal = 0;

                for (short j = 2; j < 11; ++j)
                {
                    tmpVal += ((arr[12 * i + j]) << (10-j));
                }

                if (1 == arr[12 * i + 1]) // negative # (2's complement)
                {
                    tmpVal = -1*tmpVal;
                }

                val[i] = tmpVal;
            }
            return val;
        }

        #region Nested Types

        private delegate void OnDataReceivedDelegate(object sender, EndpointDataEventArgs e);

        private delegate void UsbErrorEventDelegate(object sender, UsbError e);

        #endregion
        UInt32 tmr_cnt = 0;
        private void cmdOpen_Click(object sender, EventArgs e)
        {
            string raw = "";
            string allData = "";
            
            if (cmdOpen.Text == "Open")
            {
                if (cboDevices.SelectedIndex >= 0)
                {
                    if (openDevice(cboDevices.SelectedIndex))
                    {
                        if (!dataLogger.LoggingActivated)
                        {
                            MessageBox.Show("Data will not be saved for this session because no file was selected.");
                        }
                        cmdOpen.Enabled = false;
                        sw.Restart();

                        btnFile.Enabled = false;
                        
                        mEpReader.DataReceivedEnabled = true;
                        cmdOpen.Text = "Close";
                        pktStart_ind = 0;
                        tmr_cnt = 0;
                        data.Clear();
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
                tRecv.Text = Convert.ToString(sw.ElapsedMilliseconds) + " " + Convert.ToString(tmr_cnt) ;

                
                /*
                for (int i = 0; i < pktStart_ind; ++i)
                {
                    raw = raw + Convert.ToString(pktStart[i]) + "\t" + Convert.ToString(pktLoc[i]) + Environment.NewLine;
                }
                tRaw.Text = raw;

                foreach (Int32 d in data)
                {
                    allData = allData + Convert.ToString(d) + Environment.NewLine;
                }
                */
                tConverted.Text = allData;
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

        Int16 odr_cnt = 0;
        double odr_div = 0;
        Int16 odr_result = 0;
        Int16 odr_preamble = 0;
        bool odr_prevValue = false;
        bool odr_currValue = false;
        enum PKTTYPE { VALID = 0, ACQUIRING, INVALID };
        UInt16[] validPkt = new UInt16[204];

        private void parseSingleChan(EndpointDataEventArgs e)
        {
            int[] parsedValues = new int[15];

            for (int i = 0; i < parsedValues.Length; i++)
            {
                int tempValue = e.Buffer[2*i+1] + (e.Buffer[2*i] << 8);
              /*  if (tempValue >= 512)
                {
                    tempValue = -tempValue;
                }
               * */
                parsedValues[i] = tempValue;
                dataLogger.LogLine(tempValue);
            }

            tslStatus.Text = String.Format("Values Written: {0}", dataLogger.NumValuesWritten);

            if ((e.Buffer[30] & 128) != 0) // means its Stimulating
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

        private void parse16chan(EndpointDataEventArgs e)
        {
            string dataRx = "";
            string dataRaw = "";
            uint bConvert = 0;
            PKTTYPE pkt = PKTTYPE.ACQUIRING;

            BitArray bitArray = new BitArray(e.Buffer);

            bitArray.Length = 240; // truncate bitArray;



            for (int i = 0; i < bitArray.Length; ++i)
            {
                ++tmr_cnt;

                odr_currValue = bitArray.Get(i);

                dataLogger.LogLine(odr_currValue ? "1" : "0");

                bitValues[bv_ind & (0x1FF)] = (odr_currValue ? (ushort)1 : (ushort)0);
                ++bv_ind;
                if (odr_prevValue == odr_currValue)
                {
                    ++odr_cnt;
                }
                else
                {
                    odr_div = odr_cnt / OVERSAMPLE;
                    odr_div = Math.Round(odr_div);
                    odr_result = Convert.ToInt16(odr_div);
                    //  dataRx = dataRx + Convert.ToString(odr_result) + Environment.NewLine;

                    if (1 == odr_cnt) // checks to see if it's toggled
                    {
                        ++odr_preamble;
                        if (odr_preamble == 11)   // TODO: might be 11
                        {
                            if (bv_ind == 204)
                            {
                                pkt = PKTTYPE.VALID;
                                Array.Copy(bitValues, validPkt, 204);
                                parsePacket(ref validPkt);
                            }
                            else
                            {
                                pkt = PKTTYPE.INVALID;
                            }

                            bv_ind = 0;
                            //  pktLoc[pktStart_ind] = i;
                            // pktStart[pktStart_ind] = tmr_cnt;
                            ++pktStart_ind;
                        }
                    }
                    else
                    {
                        odr_preamble = 0;
                    }
                    odr_cnt = 1;

                }

                odr_prevValue = odr_currValue;


                //   dataRaw = dataRaw + Convert.ToString( (odr_currValue ? 1 : 0) ) + Environment.NewLine;
            }
            /* for (uint i = 0; i < (e.Count-1)/2; ++i)
            {
                dataIn[i] = (UInt16)( (e.Buffer[2 * i + 1]<<8) + (UInt16)(e.Buffer[2 * i]));
                dataRx = dataRx + Convert.ToString(dataIn[i]) + Environment.NewLine;
            }
            */
            //tConverted.AppendText(dataRx);
            //tRaw.AppendText(dataRaw);
            //showBytes(e.Buffer, e.Count);
        }
        private void OnDataReceived(object sender, EndpointDataEventArgs e)
        {
            parseSingleChan(e);
            // parse16chan(e);
        }

        private void parsePacket(ref ushort[] validPkt)
        {
            string pkt = "";
            Int32[] res = bitsToInt(ref validPkt);


         //   data.AddRange(res);
          /*  for(int i = 0; i< validPkt.Length; i++)
            {
                pkt = pkt + validPkt[i] + Environment.NewLine;
            }
            */
           
           tConverted.Text = pkt;
        }

        private void showBytes(byte[] readBuffer, int uiTransmitted)
        {
                // Convert the data to a hex string before displaying
                tRecv.AppendText(GetHexString(readBuffer, 0, uiTransmitted).ToString());
           
        }
        
        private void txtDC_TextChanged(object sender, EventArgs e)
        {
          /*  Int32 DC = cToInt16(tvalDC.Text) ;
            if (DC > 100)
            {
                tvalDC.Text = "100";
            }
            else if (DC < 0)
            {
                tvalDC.Text = "0";
            }
            */
        }

        private void tAmplitude_TextChanged(object sender, EventArgs e)
        {
            /*
            Int32 Amplitude = cToInt16(tvalAmplitude.Text);
            if (Amplitude > 100)
            {
                tvalAmplitude.Text = "100";
            }
            else if (Amplitude < 0)
            {
                tvalAmplitude.Text = "0";
            }
            */
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void chkLockHigh_CheckedChanged(object sender, EventArgs e)
        {
            /*
            if (chkLockHigh.Checked)
            {
                tvalHighThresh.Enabled = false;
                lblHigh.Enabled = false;
                tvalHighThresh.Text = ( cToInt16(tvalLowThresh.Text) + 100).ToString();
            }
            else
            {
                tvalHighThresh.Enabled = true;
                lblHigh.Enabled = true;
            }
             * */
        }

        private void tLowThresh_TextChanged(object sender, EventArgs e)
        {
            /*
            if (chkLockHigh.Checked)
            {
                tvalHighThresh.Text = (cToInt16(tvalLowThresh.Text) + 100).ToString();
            }
             * */
        }

        private Int16 cToInt16(string value)
        {
            Int16 result;
            if (Int16.TryParse(value, out result))
            {
                return result;
            }
            else
            {
                return 0;
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

            int[] vals = bitsToInt(ref bits);

            tConverted.Text = "";

            foreach (int val in vals)
            {
                tConverted.AppendText(val.ToString() + Environment.NewLine);
            }
        }

        private void cboDevices_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        DataLogger dataLogger = DataLogger.Instance;

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

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

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

        private void cmdDraw_Click(object sender, EventArgs e)
        {
            Int16 [] adcVals = new Int16[50];
            int i = 0;
            // gereate sine wave data
            for (i = 0; i < adcVals.Length; ++i)
            {
                adcVals[i] = Convert.ToInt16(100*Math.Sin(2 * Math.PI * (i) /5));
            }

            DrawData(adcVals);
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
    }
}
