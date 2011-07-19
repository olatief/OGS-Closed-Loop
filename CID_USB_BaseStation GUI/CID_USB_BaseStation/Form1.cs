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
using System.Threading;

using System.Runtime.InteropServices;
using Signal_Project;
using System.Threading.Tasks;
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
        private Oscilloscope oScope;

        progAll pAll = new progAll();
        progStim pStim = new progStim();
        progAlgo pAlgo = new progAlgo();

        DataLogger dataLogger = DataLogger.Instance;
        PacketHandler pktHandler=new PacketHandler();

        private void UsbGlobals_UsbErrorEvent(object sender, UsbError e) { Invoke(new UsbErrorEventDelegate(UsbGlobalErrorEvent), new object[] { sender, e }); }
        private void UsbGlobalErrorEvent(object sender, UsbError e) { /* tRecv.AppendText(e + "\r\n");*/ }

        private QueuedBackgroundWorker bw_ProcessUSBpacket = new QueuedBackgroundWorker();

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
            tvalPulseOff.Tag = validate(0, 250, delegate(Int32 val) { pStim.PulseOff = (byte)val; ComputeTimes(); });
            tvalCycles.Tag = validate(0, 250, delegate(Int32 val) { pStim.Cycles = (byte)val; ComputeTimes(); });
            tvalDelay.Tag = validate(0, 40 * 250, delegate(Int32 val) { pAlgo.delay = (byte)(val / 40); tvalDelay.Text = Convert.ToString(pAlgo.delay * 40); });
            
            oScope = Oscilloscope.Create();
            if (oScope == null)
            {
                MessageBox.Show("Cant load Osc_DLL.dll. Make sure this file is in the same folder as the executable");
                Environment.Exit(0);
                return;
                
            }
            oScope.Show();
        
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
        
        
        private void OnValidationTest(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Int32 userVal;
            Validator val;
            TextBox txtSender = (TextBox)sender;

            val = (Validator)(txtSender.Tag);
            if (Int32.TryParse(txtSender.Text, out userVal))
            {
                if (userVal > val.max || userVal < val.min)
                {
                    e.Cancel = true;
                    this.errorProvider1.SetError(txtSender, String.Format("Value is out of range: {0} to {1}", val.min, val.max));
                }
                else
                {
                    this.errorProvider1.SetError(txtSender, String.Empty);
                }
            }
            else
            {
                e.Cancel = true;
                this.errorProvider1.SetError(txtSender, "Value is not an integer");
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

        private delegate void OnDataReceivedDelegate(object sender, EndpointDataEventArgs e, bool isStimulating);

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
                        pktHandler.processingDone += new PacketHandler.processingDoneHandler(ProcessUSBpacket_Done);
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
                }
            }
        }

        private bool openDevice(int index)
        {
            bool bRtn = false;

            closeDevice();

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
                    mEpReader.ReadBufferSize = 64;
                    mEpReader.ReadThreadPriority = ThreadPriority.AboveNormal;
                    mEpReader.Flush();
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

            byte[] buffer = (byte[])e.Buffer.Clone(); // so we dont process duplicates

            if (this.IsDisposed) // stop everything
            {
                // This prevents the process from waiting for the processing thread to get done
                pktHandler.bcWorkQueue.CompleteAdding();
            }
            else
            {
                // So we can keep on receiveing USB Packets as fast as possible without being blocked by UI thread
                pktHandler.bcWorkQueue.Add(buffer);
            }
        }

        void ProcessUSBpacket_Done(object sender, ProcessingDoneEventArgs e)
        {
            double tmpVal;
            foreach (int val in e.results)
            {
                tmpVal = val;
                if (pktHandler.bpFilterEnabled)
                {
                    tmpVal = pktHandler.bpFilter.runFilter(tmpVal);
                }
                if (pktHandler.notchFilterEnabled)
                {
                    tmpVal = pktHandler.notchFilter.runFilter(tmpVal);
                }
                oScope.AddData(tmpVal,0,0);
            }

            // oScope.AddData(sum/15, 0, 0);
            return;
        }

        void bw_ProcessUSBpacket_RunWorkerCompleted(bool isStimulating)
        {
            tslStatus.Text = String.Format("Values Written: {0}", dataLogger.NumValuesWritten);

            if (isStimulating) // means it was Stimulating
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

            int uiTransmitted = 2;
            if (mEpWriter != null)
            {
                //wError = mEpWriter.SubmitAsyncTransfer(bytesToWrite, 0, bytesToWrite.Length, 100, out usbWriteTransfer);
               // wError = usbWriteTransfer.Wait(out uiTransmitted);

                 wError = mEpWriter.Write(bytesToWrite, 100, out uiTransmitted);
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

        private bool firstTime = true;

        private void frmMain_Activated(object sender, EventArgs e)
        {
            if (firstTime) // This is because sometimes the form gets Activated more than once
            {
                firstTime = false;
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
                tmrStats.Enabled = true;
            }
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

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            oScope.Dispose();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDroppedStat.Text = Convert.ToString(WirelessStats.Instance.NumDroppedPackets);
            lblSuccessStat.Text = Convert.ToString(WirelessStats.Instance.NumSuccessRxPackets);

            if (null != pktHandler)
            {
                if (null != pktHandler.LastPacket)
                {
                    bw_ProcessUSBpacket_RunWorkerCompleted(pktHandler.LastPacket.IsStimulating);
                }
            }
        }

        private void btnUpdateFilter_Click(object sender, EventArgs e)
        {
            double samplingFreq = Convert.ToDouble(txtSamplingFreq.Text);
            double LowFreq = Convert.ToDouble(txtFilterLowFreq.Text);
            double HiFreq = Convert.ToDouble(txtFilterHiFreq.Text);
            int filterOrder = Convert.ToInt32(txtFilterOrder.Text);

            double notchFrequency = Convert.ToDouble(txtFilterNotchFreq.Text);
            int numHarmonics = Convert.ToInt32(txtFilterNumHarmonics.Text);
            double bandwidth = Convert.ToDouble(txtFilterBandwidth.Text);

            pktHandler.notchFilter.updateFilter(pktHandler.notchFilter.notchesPrototype(notchFrequency,samplingFreq,bandwidth,1,numHarmonics));

            pktHandler.bpFilter = new Butterworth(LowFreq / samplingFreq, HiFreq / samplingFreq, filterOrder);
        }

        
        private void chkFilterEnabled_CheckedChanged(object sender, EventArgs e)
        {
            pktHandler.bpFilterEnabled = chkFilterEnabled.Checked;
        }

        private void chkNotchFilterEnabled_CheckedChanged(object sender, EventArgs e)
        {
            pktHandler.notchFilterEnabled = chkNotchFilterEnabled.Checked;
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void rdoSingle_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoSingle.Checked)
            {
                pnlChannelSelect.Enabled = false;
            }
        }

        private void rdoSixteen_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoSixteen.Checked)
            {
                pnlChannelSelect.Enabled = true;
            }
        }

        private void cboChannelDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            pktHandler.CurrentChannel = cboChannelDisplay.SelectedIndex+1;
        }
    }
}
