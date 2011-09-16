namespace CID_USB_BaseStation
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                closeDevice(); // closes USB
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cboDevices = new System.Windows.Forms.ComboBox();
            this.cmdOpen = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslStimulating = new System.Windows.Forms.ToolStripStatusLabel();
            this.tRecv = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabProgram = new System.Windows.Forms.TabControl();
            this.tabSingle = new System.Windows.Forms.TabPage();
            this.pnlProg = new System.Windows.Forms.Panel();
            this.btnProgAll = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tvalDelay = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.chkLockHigh = new System.Windows.Forms.CheckBox();
            this.btnProgAlgo = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tvalIEI = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tvalNstage = new System.Windows.Forms.TextBox();
            this.lblHigh = new System.Windows.Forms.Label();
            this.tvalHighThresh = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tvalLowThresh = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.testTotalTime = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.testTimeOff = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.testTimeOn = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tEstLedCurrent = new System.Windows.Forms.TextBox();
            this.lblCycles = new System.Windows.Forms.Label();
            this.tvalCycles = new System.Windows.Forms.TextBox();
            this.lblPulseOff = new System.Windows.Forms.Label();
            this.tvalPulseOff = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tvalPulseOn = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tvalFreq = new System.Windows.Forms.TextBox();
            this.btnProgStim = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tvalAmplitude = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tvalDC = new System.Windows.Forms.TextBox();
            this.tabElecStim = new System.Windows.Forms.TabPage();
            this.btnProgSingleChan = new System.Windows.Forms.Button();
            this.label28 = new System.Windows.Forms.Label();
            this.txtSingleAmplitude = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.txtSingleNegPulse = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.txtSinglePosPulse = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.txtSinglePeriod = new System.Windows.Forms.TextBox();
            this.btnConvert = new System.Windows.Forms.Button();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnFile = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tmrStats = new System.Windows.Forms.Timer(this.components);
            this.cmdDraw = new System.Windows.Forms.Button();
            this.tmrStim = new System.Windows.Forms.Timer(this.components);
            this.cmdTestStim = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lblSuccessStat = new System.Windows.Forms.Label();
            this.lblDroppedStat = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtFilterBandwidth = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtFilterNumHarmonics = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtFilterNotchFreq = new System.Windows.Forms.TextBox();
            this.chkNotchFilterEnabled = new System.Windows.Forms.CheckBox();
            this.btnUpdateFilter = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.txtFilterOrder = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtFilterHiFreq = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtFilterLowFreq = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtSamplingFreq = new System.Windows.Forms.TextBox();
            this.chkFilterEnabled = new System.Windows.Forms.CheckBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.pnlChannelSelect = new System.Windows.Forms.Panel();
            this.cboChannelDisplay = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdoElecStim = new System.Windows.Forms.RadioButton();
            this.rdoSixteen = new System.Windows.Forms.RadioButton();
            this.rdoSingle = new System.Windows.Forms.RadioButton();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabProgram.SuspendLayout();
            this.tabSingle.SuspendLayout();
            this.pnlProg.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabElecStim.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.pnlChannelSelect.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboDevices
            // 
            this.cboDevices.FormattingEnabled = true;
            this.cboDevices.Location = new System.Drawing.Point(7, 19);
            this.cboDevices.Name = "cboDevices";
            this.cboDevices.Size = new System.Drawing.Size(389, 21);
            this.cboDevices.TabIndex = 0;
            this.cboDevices.DropDown += new System.EventHandler(this.cboDevices_DropDown);
            // 
            // cmdOpen
            // 
            this.cmdOpen.Location = new System.Drawing.Point(402, 18);
            this.cmdOpen.Name = "cmdOpen";
            this.cmdOpen.Size = new System.Drawing.Size(69, 21);
            this.cmdOpen.TabIndex = 1;
            this.cmdOpen.Text = "Open";
            this.cmdOpen.UseVisualStyleBackColor = true;
            this.cmdOpen.Click += new System.EventHandler(this.cmdOpen_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsStatus,
            this.tslStatus,
            this.tslStimulating});
            this.statusStrip1.Location = new System.Drawing.Point(0, 662);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1187, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsStatus
            // 
            this.tsStatus.Name = "tsStatus";
            this.tsStatus.Size = new System.Drawing.Size(84, 17);
            this.tsStatus.Text = "Devices Found";
            // 
            // tslStatus
            // 
            this.tslStatus.Name = "tslStatus";
            this.tslStatus.Size = new System.Drawing.Size(95, 17);
            this.tslStatus.Text = "Values Written: 0";
            // 
            // tslStimulating
            // 
            this.tslStimulating.ForeColor = System.Drawing.Color.Red;
            this.tslStimulating.Name = "tslStimulating";
            this.tslStimulating.Size = new System.Drawing.Size(46, 17);
            this.tslStimulating.Text = "             ";
            // 
            // tRecv
            // 
            this.tRecv.Location = new System.Drawing.Point(549, 29);
            this.tRecv.Name = "tRecv";
            this.tRecv.Size = new System.Drawing.Size(157, 20);
            this.tRecv.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmdOpen);
            this.groupBox1.Controls.Add(this.cboDevices);
            this.groupBox1.Location = new System.Drawing.Point(26, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(487, 48);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "USB Devices";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tabProgram);
            this.groupBox2.Location = new System.Drawing.Point(26, 106);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(417, 534);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Programming Controls";
            // 
            // tabProgram
            // 
            this.tabProgram.Controls.Add(this.tabSingle);
            this.tabProgram.Controls.Add(this.tabElecStim);
            this.tabProgram.Location = new System.Drawing.Point(7, 19);
            this.tabProgram.Name = "tabProgram";
            this.tabProgram.SelectedIndex = 0;
            this.tabProgram.Size = new System.Drawing.Size(404, 509);
            this.tabProgram.TabIndex = 3;
            this.tabProgram.TabStop = false;
            // 
            // tabSingle
            // 
            this.tabSingle.Controls.Add(this.pnlProg);
            this.tabSingle.Location = new System.Drawing.Point(4, 22);
            this.tabSingle.Name = "tabSingle";
            this.tabSingle.Padding = new System.Windows.Forms.Padding(3);
            this.tabSingle.Size = new System.Drawing.Size(396, 483);
            this.tabSingle.TabIndex = 0;
            this.tabSingle.Text = "Single Channel";
            this.tabSingle.UseVisualStyleBackColor = true;
            // 
            // pnlProg
            // 
            this.pnlProg.Controls.Add(this.btnProgAll);
            this.pnlProg.Controls.Add(this.groupBox4);
            this.pnlProg.Controls.Add(this.groupBox3);
            this.pnlProg.Location = new System.Drawing.Point(6, 6);
            this.pnlProg.Name = "pnlProg";
            this.pnlProg.Size = new System.Drawing.Size(397, 474);
            this.pnlProg.TabIndex = 0;
            // 
            // btnProgAll
            // 
            this.btnProgAll.Location = new System.Drawing.Point(264, 263);
            this.btnProgAll.Name = "btnProgAll";
            this.btnProgAll.Size = new System.Drawing.Size(105, 32);
            this.btnProgAll.TabIndex = 3;
            this.btnProgAll.Text = "Program All";
            this.btnProgAll.UseVisualStyleBackColor = true;
            this.btnProgAll.Click += new System.EventHandler(this.btnProgAll_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tvalDelay);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.chkLockHigh);
            this.groupBox4.Controls.Add(this.btnProgAlgo);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.tvalIEI);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.tvalNstage);
            this.groupBox4.Controls.Add(this.lblHigh);
            this.groupBox4.Controls.Add(this.tvalHighThresh);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.tvalLowThresh);
            this.groupBox4.Location = new System.Drawing.Point(12, 236);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(231, 230);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Seizure Detection Algorithm";
            // 
            // tvalDelay
            // 
            this.tvalDelay.Location = new System.Drawing.Point(162, 133);
            this.tvalDelay.Name = "tvalDelay";
            this.tvalDelay.Size = new System.Drawing.Size(52, 20);
            this.tvalDelay.TabIndex = 13;
            this.tvalDelay.Text = "40";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 136);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(153, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Stim Delay After Detection (ms)";
            // 
            // chkLockHigh
            // 
            this.chkLockHigh.AutoSize = true;
            this.chkLockHigh.Location = new System.Drawing.Point(22, 207);
            this.chkLockHigh.Name = "chkLockHigh";
            this.chkLockHigh.Size = new System.Drawing.Size(134, 17);
            this.chkLockHigh.TabIndex = 9;
            this.chkLockHigh.Text = "Lock High Threshold? ";
            this.chkLockHigh.UseVisualStyleBackColor = true;
            // 
            // btnProgAlgo
            // 
            this.btnProgAlgo.Location = new System.Drawing.Point(21, 180);
            this.btnProgAlgo.Name = "btnProgAlgo";
            this.btnProgAlgo.Size = new System.Drawing.Size(115, 21);
            this.btnProgAlgo.TabIndex = 4;
            this.btnProgAlgo.Text = "Program Algo";
            this.btnProgAlgo.UseVisualStyleBackColor = true;
            this.btnProgAlgo.Click += new System.EventHandler(this.btnProgAlgo_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "IEI";
            // 
            // tvalIEI
            // 
            this.tvalIEI.Location = new System.Drawing.Point(93, 78);
            this.tvalIEI.Name = "tvalIEI";
            this.tvalIEI.Size = new System.Drawing.Size(101, 20);
            this.tvalIEI.TabIndex = 7;
            this.tvalIEI.Text = "400";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "nStage";
            // 
            // tvalNstage
            // 
            this.tvalNstage.Location = new System.Drawing.Point(93, 104);
            this.tvalNstage.Name = "tvalNstage";
            this.tvalNstage.Size = new System.Drawing.Size(101, 20);
            this.tvalNstage.TabIndex = 5;
            this.tvalNstage.Text = "5";
            // 
            // lblHigh
            // 
            this.lblHigh.AutoSize = true;
            this.lblHigh.Location = new System.Drawing.Point(6, 27);
            this.lblHigh.Name = "lblHigh";
            this.lblHigh.Size = new System.Drawing.Size(79, 13);
            this.lblHigh.TabIndex = 3;
            this.lblHigh.Text = "High Threshold";
            // 
            // tvalHighThresh
            // 
            this.tvalHighThresh.Location = new System.Drawing.Point(93, 24);
            this.tvalHighThresh.Name = "tvalHighThresh";
            this.tvalHighThresh.Size = new System.Drawing.Size(101, 20);
            this.tvalHighThresh.TabIndex = 2;
            this.tvalHighThresh.Text = "1100";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Low Threshold";
            // 
            // tvalLowThresh
            // 
            this.tvalLowThresh.Location = new System.Drawing.Point(93, 50);
            this.tvalLowThresh.Name = "tvalLowThresh";
            this.tvalLowThresh.Size = new System.Drawing.Size(101, 20);
            this.tvalLowThresh.TabIndex = 0;
            this.tvalLowThresh.Text = "1000";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.testTotalTime);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.testTimeOff);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.testTimeOn);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.tEstLedCurrent);
            this.groupBox3.Controls.Add(this.lblCycles);
            this.groupBox3.Controls.Add(this.tvalCycles);
            this.groupBox3.Controls.Add(this.lblPulseOff);
            this.groupBox3.Controls.Add(this.tvalPulseOff);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.tvalPulseOn);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.tvalFreq);
            this.groupBox3.Controls.Add(this.btnProgStim);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.tvalAmplitude);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.tvalDC);
            this.groupBox3.Location = new System.Drawing.Point(12, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(372, 215);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Stimulation Control";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(181, 170);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(102, 13);
            this.label13.TabIndex = 20;
            this.label13.Text = "Total Stim Time (ms)";
            // 
            // testTotalTime
            // 
            this.testTotalTime.Location = new System.Drawing.Point(289, 167);
            this.testTotalTime.Name = "testTotalTime";
            this.testTotalTime.ReadOnly = true;
            this.testTotalTime.Size = new System.Drawing.Size(49, 20);
            this.testTotalTime.TabIndex = 19;
            this.testTotalTime.Text = "20";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(208, 144);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "Time Off (ms)";
            // 
            // testTimeOff
            // 
            this.testTimeOff.Location = new System.Drawing.Point(289, 141);
            this.testTimeOff.Name = "testTimeOff";
            this.testTimeOff.ReadOnly = true;
            this.testTimeOff.Size = new System.Drawing.Size(49, 20);
            this.testTimeOff.TabIndex = 17;
            this.testTimeOff.Text = "20";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(208, 120);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "Time On (ms)";
            // 
            // testTimeOn
            // 
            this.testTimeOn.Location = new System.Drawing.Point(289, 117);
            this.testTimeOn.Name = "testTimeOn";
            this.testTimeOn.ReadOnly = true;
            this.testTimeOn.Size = new System.Drawing.Size(49, 20);
            this.testTimeOn.TabIndex = 15;
            this.testTimeOn.Text = "20";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 120);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "LED Current (mA)";
            // 
            // tEstLedCurrent
            // 
            this.tEstLedCurrent.Location = new System.Drawing.Point(107, 117);
            this.tEstLedCurrent.Name = "tEstLedCurrent";
            this.tEstLedCurrent.ReadOnly = true;
            this.tEstLedCurrent.Size = new System.Drawing.Size(49, 20);
            this.tEstLedCurrent.TabIndex = 13;
            this.tEstLedCurrent.Text = "20";
            // 
            // lblCycles
            // 
            this.lblCycles.AutoSize = true;
            this.lblCycles.Location = new System.Drawing.Point(239, 79);
            this.lblCycles.Name = "lblCycles";
            this.lblCycles.Size = new System.Drawing.Size(38, 13);
            this.lblCycles.TabIndex = 12;
            this.lblCycles.Text = "Cycles";
            // 
            // tvalCycles
            // 
            this.tvalCycles.Location = new System.Drawing.Point(283, 76);
            this.tvalCycles.Name = "tvalCycles";
            this.tvalCycles.Size = new System.Drawing.Size(46, 20);
            this.tvalCycles.TabIndex = 11;
            this.tvalCycles.Text = "3";
            // 
            // lblPulseOff
            // 
            this.lblPulseOff.AutoSize = true;
            this.lblPulseOff.Location = new System.Drawing.Point(222, 53);
            this.lblPulseOff.Name = "lblPulseOff";
            this.lblPulseOff.Size = new System.Drawing.Size(55, 13);
            this.lblPulseOff.TabIndex = 10;
            this.lblPulseOff.Text = "Pulses Off";
            // 
            // tvalPulseOff
            // 
            this.tvalPulseOff.Location = new System.Drawing.Point(283, 50);
            this.tvalPulseOff.Name = "tvalPulseOff";
            this.tvalPulseOff.Size = new System.Drawing.Size(46, 20);
            this.tvalPulseOff.TabIndex = 9;
            this.tvalPulseOff.Text = "5";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(222, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Pulses On";
            // 
            // tvalPulseOn
            // 
            this.tvalPulseOn.Location = new System.Drawing.Point(283, 24);
            this.tvalPulseOn.Name = "tvalPulseOn";
            this.tvalPulseOn.Size = new System.Drawing.Size(46, 20);
            this.tvalPulseOn.TabIndex = 7;
            this.tvalPulseOn.Text = "5";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Frequency (Hz)";
            // 
            // tvalFreq
            // 
            this.tvalFreq.Location = new System.Drawing.Point(87, 50);
            this.tvalFreq.Name = "tvalFreq";
            this.tvalFreq.Size = new System.Drawing.Size(49, 20);
            this.tvalFreq.TabIndex = 5;
            this.tvalFreq.Text = "10";
            // 
            // btnProgStim
            // 
            this.btnProgStim.Location = new System.Drawing.Point(22, 167);
            this.btnProgStim.Name = "btnProgStim";
            this.btnProgStim.Size = new System.Drawing.Size(115, 21);
            this.btnProgStim.TabIndex = 4;
            this.btnProgStim.Text = "Program Stimulation";
            this.btnProgStim.UseVisualStyleBackColor = true;
            this.btnProgStim.Click += new System.EventHandler(this.btnProgStim_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "LED Level";
            // 
            // tvalAmplitude
            // 
            this.tvalAmplitude.Location = new System.Drawing.Point(87, 24);
            this.tvalAmplitude.Name = "tvalAmplitude";
            this.tvalAmplitude.Size = new System.Drawing.Size(49, 20);
            this.tvalAmplitude.TabIndex = 2;
            this.tvalAmplitude.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Duty Cycle (%)";
            // 
            // tvalDC
            // 
            this.tvalDC.Location = new System.Drawing.Point(87, 76);
            this.tvalDC.Name = "tvalDC";
            this.tvalDC.Size = new System.Drawing.Size(49, 20);
            this.tvalDC.TabIndex = 0;
            this.tvalDC.Text = "50";
            this.tvalDC.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidationTest);
            this.tvalDC.Validated += new System.EventHandler(this.OnValidated);
            // 
            // tabElecStim
            // 
            this.tabElecStim.Controls.Add(this.btnProgSingleChan);
            this.tabElecStim.Controls.Add(this.label28);
            this.tabElecStim.Controls.Add(this.txtSingleAmplitude);
            this.tabElecStim.Controls.Add(this.label27);
            this.tabElecStim.Controls.Add(this.txtSingleNegPulse);
            this.tabElecStim.Controls.Add(this.label26);
            this.tabElecStim.Controls.Add(this.txtSinglePosPulse);
            this.tabElecStim.Controls.Add(this.label24);
            this.tabElecStim.Controls.Add(this.txtSinglePeriod);
            this.tabElecStim.Location = new System.Drawing.Point(4, 22);
            this.tabElecStim.Name = "tabElecStim";
            this.tabElecStim.Padding = new System.Windows.Forms.Padding(3);
            this.tabElecStim.Size = new System.Drawing.Size(396, 483);
            this.tabElecStim.TabIndex = 1;
            this.tabElecStim.Text = "Electrical Stimulation";
            this.tabElecStim.UseVisualStyleBackColor = true;
            // 
            // btnProgSingleChan
            // 
            this.btnProgSingleChan.Location = new System.Drawing.Point(145, 227);
            this.btnProgSingleChan.Name = "btnProgSingleChan";
            this.btnProgSingleChan.Size = new System.Drawing.Size(115, 44);
            this.btnProgSingleChan.TabIndex = 16;
            this.btnProgSingleChan.Text = "Program Stimulation Parameters";
            this.btnProgSingleChan.UseVisualStyleBackColor = true;
            this.btnProgSingleChan.Click += new System.EventHandler(this.btnProgSingleChan_Click);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(6, 35);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(75, 13);
            this.label28.TabIndex = 15;
            this.label28.Text = "Amplitude (μA)";
            // 
            // txtSingleAmplitude
            // 
            this.txtSingleAmplitude.Location = new System.Drawing.Point(87, 32);
            this.txtSingleAmplitude.Name = "txtSingleAmplitude";
            this.txtSingleAmplitude.Size = new System.Drawing.Size(49, 20);
            this.txtSingleAmplitude.TabIndex = 14;
            this.txtSingleAmplitude.Text = "100";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(6, 160);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(163, 13);
            this.label27.TabIndex = 13;
            this.label27.Text = "Negative Phase Pulse Width (μs)";
            // 
            // txtSingleNegPulse
            // 
            this.txtSingleNegPulse.Location = new System.Drawing.Point(175, 156);
            this.txtSingleNegPulse.Name = "txtSingleNegPulse";
            this.txtSingleNegPulse.Size = new System.Drawing.Size(49, 20);
            this.txtSingleNegPulse.TabIndex = 12;
            this.txtSingleNegPulse.Text = "50";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(6, 134);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(157, 13);
            this.label26.TabIndex = 11;
            this.label26.Text = "Positive Phase Pulse Width (μs)";
            // 
            // txtSinglePosPulse
            // 
            this.txtSinglePosPulse.Location = new System.Drawing.Point(175, 127);
            this.txtSinglePosPulse.Name = "txtSinglePosPulse";
            this.txtSinglePosPulse.Size = new System.Drawing.Size(49, 20);
            this.txtSinglePosPulse.TabIndex = 10;
            this.txtSinglePosPulse.Text = "100";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(6, 69);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(59, 13);
            this.label24.TabIndex = 7;
            this.label24.Text = "Period (ms)";
            // 
            // txtSinglePeriod
            // 
            this.txtSinglePeriod.Location = new System.Drawing.Point(71, 66);
            this.txtSinglePeriod.Name = "txtSinglePeriod";
            this.txtSinglePeriod.Size = new System.Drawing.Size(49, 20);
            this.txtSinglePeriod.TabIndex = 6;
            this.txtSinglePeriod.Text = "10";
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(745, 28);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(69, 21);
            this.btnConvert.TabIndex = 8;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            // 
            // txtFilename
            // 
            this.txtFilename.Location = new System.Drawing.Point(93, 68);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.ReadOnly = true;
            this.txtFilename.Size = new System.Drawing.Size(329, 20);
            this.txtFilename.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "File Name:";
            // 
            // btnFile
            // 
            this.btnFile.Location = new System.Drawing.Point(428, 66);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(85, 22);
            this.btnFile.TabIndex = 11;
            this.btnFile.Text = "Choose File";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // tmrStats
            // 
            this.tmrStats.Interval = 500;
            this.tmrStats.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // cmdDraw
            // 
            this.cmdDraw.Location = new System.Drawing.Point(850, 29);
            this.cmdDraw.Name = "cmdDraw";
            this.cmdDraw.Size = new System.Drawing.Size(69, 21);
            this.cmdDraw.TabIndex = 13;
            this.cmdDraw.Text = "Draw";
            this.cmdDraw.UseVisualStyleBackColor = true;
            this.cmdDraw.Click += new System.EventHandler(this.cmdDraw_Click);
            // 
            // tmrStim
            // 
            this.tmrStim.Tick += new System.EventHandler(this.tmrStim_Tick);
            // 
            // cmdTestStim
            // 
            this.cmdTestStim.Location = new System.Drawing.Point(850, 56);
            this.cmdTestStim.Name = "cmdTestStim";
            this.cmdTestStim.Size = new System.Drawing.Size(69, 21);
            this.cmdTestStim.TabIndex = 14;
            this.cmdTestStim.Text = "TestStim";
            this.cmdTestStim.UseVisualStyleBackColor = true;
            this.cmdTestStim.Click += new System.EventHandler(this.cmdTestStim_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lblSuccessStat);
            this.groupBox5.Controls.Add(this.lblDroppedStat);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Location = new System.Drawing.Point(464, 420);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(486, 207);
            this.groupBox5.TabIndex = 15;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Wireless Stats";
            // 
            // lblSuccessStat
            // 
            this.lblSuccessStat.AutoSize = true;
            this.lblSuccessStat.Location = new System.Drawing.Point(145, 61);
            this.lblSuccessStat.Name = "lblSuccessStat";
            this.lblSuccessStat.Size = new System.Drawing.Size(13, 13);
            this.lblSuccessStat.TabIndex = 3;
            this.lblSuccessStat.Text = "0";
            // 
            // lblDroppedStat
            // 
            this.lblDroppedStat.AutoSize = true;
            this.lblDroppedStat.Location = new System.Drawing.Point(145, 35);
            this.lblDroppedStat.Name = "lblDroppedStat";
            this.lblDroppedStat.Size = new System.Drawing.Size(13, 13);
            this.lblDroppedStat.TabIndex = 2;
            this.lblDroppedStat.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(16, 61);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(104, 13);
            this.label15.TabIndex = 1;
            this.label15.Text = "Successful Packets:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(16, 36);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(93, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "Dropped Packets:";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label22);
            this.groupBox6.Controls.Add(this.txtFilterBandwidth);
            this.groupBox6.Controls.Add(this.label21);
            this.groupBox6.Controls.Add(this.txtFilterNumHarmonics);
            this.groupBox6.Controls.Add(this.label20);
            this.groupBox6.Controls.Add(this.txtFilterNotchFreq);
            this.groupBox6.Controls.Add(this.chkNotchFilterEnabled);
            this.groupBox6.Controls.Add(this.btnUpdateFilter);
            this.groupBox6.Controls.Add(this.label19);
            this.groupBox6.Controls.Add(this.txtFilterOrder);
            this.groupBox6.Controls.Add(this.label18);
            this.groupBox6.Controls.Add(this.txtFilterHiFreq);
            this.groupBox6.Controls.Add(this.label17);
            this.groupBox6.Controls.Add(this.txtFilterLowFreq);
            this.groupBox6.Controls.Add(this.label16);
            this.groupBox6.Controls.Add(this.txtSamplingFreq);
            this.groupBox6.Controls.Add(this.chkFilterEnabled);
            this.groupBox6.Location = new System.Drawing.Point(464, 106);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(486, 290);
            this.groupBox6.TabIndex = 16;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Real-time Filtering";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(280, 139);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(104, 13);
            this.label22.TabIndex = 19;
            this.label22.Text = "1 dB Bandwidth (Hz)";
            // 
            // txtFilterBandwidth
            // 
            this.txtFilterBandwidth.Location = new System.Drawing.Point(395, 136);
            this.txtFilterBandwidth.Name = "txtFilterBandwidth";
            this.txtFilterBandwidth.Size = new System.Drawing.Size(49, 20);
            this.txtFilterBandwidth.TabIndex = 18;
            this.txtFilterBandwidth.Text = "10";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(280, 114);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(109, 13);
            this.label21.TabIndex = 17;
            this.label21.Text = "Number of Harmonics";
            this.label21.Click += new System.EventHandler(this.label21_Click);
            // 
            // txtFilterNumHarmonics
            // 
            this.txtFilterNumHarmonics.Location = new System.Drawing.Point(395, 111);
            this.txtFilterNumHarmonics.Name = "txtFilterNumHarmonics";
            this.txtFilterNumHarmonics.Size = new System.Drawing.Size(49, 20);
            this.txtFilterNumHarmonics.TabIndex = 16;
            this.txtFilterNumHarmonics.Text = "20";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(278, 88);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(111, 13);
            this.label20.TabIndex = 15;
            this.label20.Text = "Notch Frequency (Hz)";
            // 
            // txtFilterNotchFreq
            // 
            this.txtFilterNotchFreq.Location = new System.Drawing.Point(395, 85);
            this.txtFilterNotchFreq.Name = "txtFilterNotchFreq";
            this.txtFilterNotchFreq.Size = new System.Drawing.Size(49, 20);
            this.txtFilterNotchFreq.TabIndex = 14;
            this.txtFilterNotchFreq.Text = "60";
            // 
            // chkNotchFilterEnabled
            // 
            this.chkNotchFilterEnabled.AutoSize = true;
            this.chkNotchFilterEnabled.Location = new System.Drawing.Point(281, 41);
            this.chkNotchFilterEnabled.Name = "chkNotchFilterEnabled";
            this.chkNotchFilterEnabled.Size = new System.Drawing.Size(201, 17);
            this.chkNotchFilterEnabled.TabIndex = 13;
            this.chkNotchFilterEnabled.Text = "60Hz Pseudo-Comb Filtering Enabled";
            this.chkNotchFilterEnabled.UseVisualStyleBackColor = true;
            this.chkNotchFilterEnabled.CheckedChanged += new System.EventHandler(this.chkNotchFilterEnabled_CheckedChanged);
            // 
            // btnUpdateFilter
            // 
            this.btnUpdateFilter.Location = new System.Drawing.Point(211, 223);
            this.btnUpdateFilter.Name = "btnUpdateFilter";
            this.btnUpdateFilter.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateFilter.TabIndex = 12;
            this.btnUpdateFilter.Text = "Update Filter";
            this.btnUpdateFilter.UseVisualStyleBackColor = true;
            this.btnUpdateFilter.Click += new System.EventHandler(this.btnUpdateFilter_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(22, 175);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(112, 13);
            this.label19.TabIndex = 11;
            this.label19.Text = "Filter Order (per cutoff)";
            // 
            // txtFilterOrder
            // 
            this.txtFilterOrder.Location = new System.Drawing.Point(153, 175);
            this.txtFilterOrder.Name = "txtFilterOrder";
            this.txtFilterOrder.Size = new System.Drawing.Size(49, 20);
            this.txtFilterOrder.TabIndex = 10;
            this.txtFilterOrder.Text = "10";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(22, 139);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(106, 13);
            this.label18.TabIndex = 9;
            this.label18.Text = "High Freq Cutoff (Hz)";
            // 
            // txtFilterHiFreq
            // 
            this.txtFilterHiFreq.Location = new System.Drawing.Point(153, 132);
            this.txtFilterHiFreq.Name = "txtFilterHiFreq";
            this.txtFilterHiFreq.Size = new System.Drawing.Size(49, 20);
            this.txtFilterHiFreq.TabIndex = 8;
            this.txtFilterHiFreq.Text = "800";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(22, 114);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(104, 13);
            this.label17.TabIndex = 7;
            this.label17.Text = "Low Freq Cutoff (Hz)";
            // 
            // txtFilterLowFreq
            // 
            this.txtFilterLowFreq.Location = new System.Drawing.Point(153, 107);
            this.txtFilterLowFreq.Name = "txtFilterLowFreq";
            this.txtFilterLowFreq.Size = new System.Drawing.Size(49, 20);
            this.txtFilterLowFreq.TabIndex = 6;
            this.txtFilterLowFreq.Text = "10";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(22, 88);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(125, 13);
            this.label16.TabIndex = 5;
            this.label16.Text = "Sampling Frequency (Hz)";
            // 
            // txtSamplingFreq
            // 
            this.txtSamplingFreq.Location = new System.Drawing.Point(153, 84);
            this.txtSamplingFreq.Name = "txtSamplingFreq";
            this.txtSamplingFreq.Size = new System.Drawing.Size(49, 20);
            this.txtSamplingFreq.TabIndex = 4;
            this.txtSamplingFreq.Text = "16000";
            // 
            // chkFilterEnabled
            // 
            this.chkFilterEnabled.AutoSize = true;
            this.chkFilterEnabled.Location = new System.Drawing.Point(25, 41);
            this.chkFilterEnabled.Name = "chkFilterEnabled";
            this.chkFilterEnabled.Size = new System.Drawing.Size(154, 17);
            this.chkFilterEnabled.TabIndex = 0;
            this.chkFilterEnabled.Text = "Bandpass Filtering Enabled";
            this.chkFilterEnabled.UseVisualStyleBackColor = true;
            this.chkFilterEnabled.CheckedChanged += new System.EventHandler(this.chkFilterEnabled_CheckedChanged);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.pnlChannelSelect);
            this.groupBox7.Controls.Add(this.panel1);
            this.groupBox7.Location = new System.Drawing.Point(984, 106);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(189, 521);
            this.groupBox7.TabIndex = 17;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "System Selection";
            // 
            // pnlChannelSelect
            // 
            this.pnlChannelSelect.Controls.Add(this.cboChannelDisplay);
            this.pnlChannelSelect.Controls.Add(this.label23);
            this.pnlChannelSelect.Enabled = false;
            this.pnlChannelSelect.Location = new System.Drawing.Point(9, 115);
            this.pnlChannelSelect.Name = "pnlChannelSelect";
            this.pnlChannelSelect.Size = new System.Drawing.Size(160, 80);
            this.pnlChannelSelect.TabIndex = 2;
            // 
            // cboChannelDisplay
            // 
            this.cboChannelDisplay.FormattingEnabled = true;
            this.cboChannelDisplay.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16"});
            this.cboChannelDisplay.Location = new System.Drawing.Point(23, 43);
            this.cboChannelDisplay.Name = "cboChannelDisplay";
            this.cboChannelDisplay.Size = new System.Drawing.Size(121, 21);
            this.cboChannelDisplay.TabIndex = 2;
            this.cboChannelDisplay.SelectedIndexChanged += new System.EventHandler(this.cboChannelDisplay_SelectedIndexChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(32, 10);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(101, 13);
            this.label23.TabIndex = 1;
            this.label23.Text = "Channel For Display";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdoElecStim);
            this.panel1.Controls.Add(this.rdoSixteen);
            this.panel1.Controls.Add(this.rdoSingle);
            this.panel1.Location = new System.Drawing.Point(6, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(136, 73);
            this.panel1.TabIndex = 0;
            // 
            // rdoElecStim
            // 
            this.rdoElecStim.AutoSize = true;
            this.rdoElecStim.Location = new System.Drawing.Point(3, 50);
            this.rdoElecStim.Name = "rdoElecStim";
            this.rdoElecStim.Size = new System.Drawing.Size(122, 17);
            this.rdoElecStim.TabIndex = 2;
            this.rdoElecStim.Text = "Electrical Stimulation";
            this.rdoElecStim.UseVisualStyleBackColor = true;
            this.rdoElecStim.CheckedChanged += new System.EventHandler(this.rdoElecStim_CheckedChanged);
            // 
            // rdoSixteen
            // 
            this.rdoSixteen.AutoSize = true;
            this.rdoSixteen.Location = new System.Drawing.Point(3, 27);
            this.rdoSixteen.Name = "rdoSixteen";
            this.rdoSixteen.Size = new System.Drawing.Size(106, 17);
            this.rdoSixteen.TabIndex = 1;
            this.rdoSixteen.Text = "16 Channel ASIC";
            this.rdoSixteen.UseVisualStyleBackColor = true;
            this.rdoSixteen.CheckedChanged += new System.EventHandler(this.rdoSixteen_CheckedChanged);
            // 
            // rdoSingle
            // 
            this.rdoSingle.AutoSize = true;
            this.rdoSingle.Checked = true;
            this.rdoSingle.Location = new System.Drawing.Point(3, 3);
            this.rdoSingle.Name = "rdoSingle";
            this.rdoSingle.Size = new System.Drawing.Size(123, 17);
            this.rdoSingle.TabIndex = 0;
            this.rdoSingle.TabStop = true;
            this.rdoSingle.Text = "Single Channel ASIC";
            this.rdoSingle.UseVisualStyleBackColor = true;
            this.rdoSingle.CheckedChanged += new System.EventHandler(this.rdoSingle_CheckedChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1187, 684);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.cmdTestStim);
            this.Controls.Add(this.cmdDraw);
            this.Controls.Add(this.btnFile);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtFilename);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tRecv);
            this.Controls.Add(this.statusStrip1);
            this.DoubleBuffered = true;
            this.Name = "frmMain";
            this.Text = "CID USB Base Station";
            this.Activated += new System.EventHandler(this.frmMain_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tabProgram.ResumeLayout(false);
            this.tabSingle.ResumeLayout(false);
            this.pnlProg.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabElecStim.ResumeLayout(false);
            this.tabElecStim.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.pnlChannelSelect.ResumeLayout(false);
            this.pnlChannelSelect.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboDevices;
        private System.Windows.Forms.Button cmdOpen;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsStatus;
        private System.Windows.Forms.TextBox tRecv;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.ToolStripStatusLabel tslStatus;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Timer tmrStats;
        private System.Windows.Forms.Button cmdDraw;
        private System.Windows.Forms.ToolStripStatusLabel tslStimulating;
        private System.Windows.Forms.Timer tmrStim;
        private System.Windows.Forms.Button cmdTestStim;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblSuccessStat;
        private System.Windows.Forms.Label lblDroppedStat;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckBox chkFilterEnabled;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtSamplingFreq;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtFilterLowFreq;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtFilterOrder;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtFilterHiFreq;
        private System.Windows.Forms.Button btnUpdateFilter;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtFilterNotchFreq;
        private System.Windows.Forms.CheckBox chkNotchFilterEnabled;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtFilterNumHarmonics;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtFilterBandwidth;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdoSixteen;
        private System.Windows.Forms.RadioButton rdoSingle;
        private System.Windows.Forms.Panel pnlChannelSelect;
        private System.Windows.Forms.ComboBox cboChannelDisplay;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.RadioButton rdoElecStim;
        private System.Windows.Forms.TabControl tabProgram;
        private System.Windows.Forms.TabPage tabSingle;
        private System.Windows.Forms.Panel pnlProg;
        private System.Windows.Forms.Button btnProgAll;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox tvalDelay;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkLockHigh;
        private System.Windows.Forms.Button btnProgAlgo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tvalIEI;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tvalNstage;
        private System.Windows.Forms.Label lblHigh;
        private System.Windows.Forms.TextBox tvalHighThresh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tvalLowThresh;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox testTotalTime;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox testTimeOff;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox testTimeOn;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tEstLedCurrent;
        private System.Windows.Forms.Label lblCycles;
        private System.Windows.Forms.TextBox tvalCycles;
        private System.Windows.Forms.Label lblPulseOff;
        private System.Windows.Forms.TextBox tvalPulseOff;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tvalPulseOn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tvalFreq;
        private System.Windows.Forms.Button btnProgStim;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tvalAmplitude;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tvalDC;
        private System.Windows.Forms.TabPage tabElecStim;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtSinglePosPulse;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtSinglePeriod;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox txtSingleAmplitude;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtSingleNegPulse;
        private System.Windows.Forms.Button btnProgSingleChan;
    }
}

