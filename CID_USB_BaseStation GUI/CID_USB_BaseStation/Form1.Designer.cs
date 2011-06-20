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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.cboDevices = new System.Windows.Forms.ComboBox();
            this.cmdOpen = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslStimulating = new System.Windows.Forms.ToolStripStatusLabel();
            this.tRecv = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tConverted = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pnlProg = new System.Windows.Forms.Panel();
            this.btnProgAll = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tvalDelay = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.chkLockHigh = new System.Windows.Forms.CheckBox();
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
            this.btnProgAlgo = new System.Windows.Forms.Button();
            this.tRaw = new System.Windows.Forms.TextBox();
            this.btnConvert = new System.Windows.Forms.Button();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnFile = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.picPlot = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cmdDraw = new System.Windows.Forms.Button();
            this.tmrStim = new System.Windows.Forms.Timer(this.components);
            this.cmdTestStim = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.pnlProg.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlot)).BeginInit();
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 639);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(710, 22);
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
            this.tRecv.Location = new System.Drawing.Point(534, 30);
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
            // tConverted
            // 
            this.tConverted.Location = new System.Drawing.Point(815, 162);
            this.tConverted.Multiline = true;
            this.tConverted.Name = "tConverted";
            this.tConverted.Size = new System.Drawing.Size(188, 320);
            this.tConverted.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pnlProg);
            this.groupBox2.Location = new System.Drawing.Point(26, 106);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(460, 521);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Programming Controls";
            // 
            // pnlProg
            // 
            this.pnlProg.Controls.Add(this.btnProgAll);
            this.pnlProg.Controls.Add(this.groupBox4);
            this.pnlProg.Controls.Add(this.groupBox3);
            this.pnlProg.Location = new System.Drawing.Point(14, 28);
            this.pnlProg.Name = "pnlProg";
            this.pnlProg.Size = new System.Drawing.Size(440, 487);
            this.pnlProg.TabIndex = 0;
            // 
            // btnProgAll
            // 
            this.btnProgAll.Location = new System.Drawing.Point(268, 249);
            this.btnProgAll.Name = "btnProgAll";
            this.btnProgAll.Size = new System.Drawing.Size(105, 45);
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
            // tRaw
            // 
            this.tRaw.Location = new System.Drawing.Point(1009, 159);
            this.tRaw.Multiline = true;
            this.tRaw.Name = "tRaw";
            this.tRaw.Size = new System.Drawing.Size(188, 358);
            this.tRaw.TabIndex = 7;
            this.tRaw.Text = resources.GetString("tRaw.Text");
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(827, 86);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(69, 21);
            this.btnConvert.TabIndex = 8;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
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
            // picPlot
            // 
            this.picPlot.Enabled = false;
            this.picPlot.Location = new System.Drawing.Point(527, 170);
            this.picPlot.Name = "picPlot";
            this.picPlot.Size = new System.Drawing.Size(264, 250);
            this.picPlot.TabIndex = 12;
            this.picPlot.TabStop = false;
            this.picPlot.Visible = false;
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
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 661);
            this.Controls.Add(this.cmdTestStim);
            this.Controls.Add(this.cmdDraw);
            this.Controls.Add(this.btnFile);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtFilename);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.tRaw);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tConverted);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tRecv);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.picPlot);
            this.Name = "frmMain";
            this.Text = "CID USB Base Station";
            this.Activated += new System.EventHandler(this.frmMain_Activated);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.pnlProg.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlot)).EndInit();
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
        private System.Windows.Forms.TextBox tConverted;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel pnlProg;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnProgStim;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tvalAmplitude;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tvalDC;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnProgAlgo;
        private System.Windows.Forms.Label lblHigh;
        private System.Windows.Forms.TextBox tvalHighThresh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tvalLowThresh;
        private System.Windows.Forms.CheckBox chkLockHigh;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tvalIEI;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tvalNstage;
        private System.Windows.Forms.Button btnProgAll;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tvalFreq;
        private System.Windows.Forms.TextBox tRaw;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.ToolStripStatusLabel tslStatus;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lblPulseOff;
        private System.Windows.Forms.TextBox tvalPulseOff;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tvalPulseOn;
        private System.Windows.Forms.Label lblCycles;
        private System.Windows.Forms.TextBox tvalCycles;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tvalDelay;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tEstLedCurrent;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox testTotalTime;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox testTimeOff;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox testTimeOn;
        private System.Windows.Forms.PictureBox picPlot;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button cmdDraw;
        private System.Windows.Forms.ToolStripStatusLabel tslStimulating;
        private System.Windows.Forms.Timer tmrStim;
        private System.Windows.Forms.Button cmdTestStim;
    }
}

