namespace iRobot_Roomba_Movement_Panel {
  partial class FormConfig {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConfig));
      ARC.Config.Sub.Reusable.ScriptDefinition scriptDefinition2 = new ARC.Config.Sub.Reusable.ScriptDefinition();
      this.label1 = new System.Windows.Forms.Label();
      this.tbUartBaud = new System.Windows.Forms.TextBox();
      this.ucHelpHover1 = new ARC.UCForms.UC.UCHelpHover();
      this.ucHelpHover2 = new ARC.UCForms.UC.UCHelpHover();
      this.label2 = new System.Windows.Forms.Label();
      this.cbSoftwareBaudrate = new System.Windows.Forms.ComboBox();
      this.ucHelpHover3 = new ARC.UCForms.UC.UCHelpHover();
      this.tbSensorPollTime = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.cbConnectionType = new System.Windows.Forms.ComboBox();
      this.ucHelpHover4 = new ARC.UCForms.UC.UCHelpHover();
      this.label4 = new System.Windows.Forms.Label();
      this.cbPCPort = new System.Windows.Forms.ComboBox();
      this.ucHelpHover5 = new ARC.UCForms.UC.UCHelpHover();
      this.label5 = new System.Windows.Forms.Label();
      this.ucHelpHover6 = new ARC.UCForms.UC.UCHelpHover();
      this.label6 = new System.Windows.Forms.Label();
      this.cbHardwareUARTPort = new System.Windows.Forms.ComboBox();
      this.ucHelpHover7 = new ARC.UCForms.UC.UCHelpHover();
      this.label7 = new System.Windows.Forms.Label();
      this.btnSave = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.ucPBSoftwareSerialPort = new ARC.UCForms.UC.UCPortButton();
      this.gbUART = new System.Windows.Forms.GroupBox();
      this.gbSoftware = new System.Windows.Forms.GroupBox();
      this.gbPC = new System.Windows.Forms.GroupBox();
      this.tbPCBaud = new System.Windows.Forms.TextBox();
      this.label8 = new System.Windows.Forms.Label();
      this.ucHelpHover8 = new ARC.UCForms.UC.UCHelpHover();
      this.groupBox4 = new System.Windows.Forms.GroupBox();
      this.panel1 = new System.Windows.Forms.Panel();
      this.ucTabControl1 = new ARC.UCForms.UCTabControl();
      this.tabPage1 = new System.Windows.Forms.TabPage();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.ucHelpHover10 = new ARC.UCForms.UC.UCHelpHover();
      this.cbUseNMS = new System.Windows.Forms.CheckBox();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.ucHelpHover9 = new ARC.UCForms.UC.UCHelpHover();
      this.label9 = new System.Windows.Forms.Label();
      this.scriptButtonPressed = new ARC.UCForms.UC.UCScriptEditInput();
      this.gbUART.SuspendLayout();
      this.gbSoftware.SuspendLayout();
      this.gbPC.SuspendLayout();
      this.groupBox4.SuspendLayout();
      this.panel1.SuspendLayout();
      this.ucTabControl1.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.tabPage2.SuspendLayout();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(55, 18);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(100, 23);
      this.label1.TabIndex = 0;
      this.label1.Text = "Baudrate:";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // tbUartBaud
      // 
      this.tbUartBaud.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tbUartBaud.Location = new System.Drawing.Point(161, 19);
      this.tbUartBaud.Name = "tbUartBaud";
      this.tbUartBaud.Size = new System.Drawing.Size(222, 22);
      this.tbUartBaud.TabIndex = 1;
      // 
      // ucHelpHover1
      // 
      this.ucHelpHover1.BackColor = System.Drawing.Color.Transparent;
      this.ucHelpHover1.Location = new System.Drawing.Point(396, 21);
      this.ucHelpHover1.Margin = new System.Windows.Forms.Padding(0);
      this.ucHelpHover1.Name = "ucHelpHover1";
      this.ucHelpHover1.SetHelpText = "When Connection Type is HW UART or PC COM, this is the baud rate for that connect" +
    "ion.\r\n\r\n";
      this.ucHelpHover1.Size = new System.Drawing.Size(20, 20);
      this.ucHelpHover1.TabIndex = 2;
      // 
      // ucHelpHover2
      // 
      this.ucHelpHover2.BackColor = System.Drawing.Color.Transparent;
      this.ucHelpHover2.Location = new System.Drawing.Point(396, 49);
      this.ucHelpHover2.Margin = new System.Windows.Forms.Padding(0);
      this.ucHelpHover2.Name = "ucHelpHover2";
      this.ucHelpHover2.SetHelpText = "When Connection Type Sotware Serial is set, use this baud rate for the connection" +
    "";
      this.ucHelpHover2.Size = new System.Drawing.Size(20, 20);
      this.ucHelpHover2.TabIndex = 5;
      // 
      // label2
      // 
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.Location = new System.Drawing.Point(70, 46);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(85, 23);
      this.label2.TabIndex = 3;
      this.label2.Text = "Baudrate:";
      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // cbSoftwareBaudrate
      // 
      this.cbSoftwareBaudrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbSoftwareBaudrate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.cbSoftwareBaudrate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.cbSoftwareBaudrate.FormattingEnabled = true;
      this.cbSoftwareBaudrate.Location = new System.Drawing.Point(161, 49);
      this.cbSoftwareBaudrate.Name = "cbSoftwareBaudrate";
      this.cbSoftwareBaudrate.Size = new System.Drawing.Size(222, 24);
      this.cbSoftwareBaudrate.TabIndex = 6;
      // 
      // ucHelpHover3
      // 
      this.ucHelpHover3.BackColor = System.Drawing.Color.Transparent;
      this.ucHelpHover3.Location = new System.Drawing.Point(396, 35);
      this.ucHelpHover3.Margin = new System.Windows.Forms.Padding(0);
      this.ucHelpHover3.Name = "ucHelpHover3";
      this.ucHelpHover3.SetHelpText = resources.GetString("ucHelpHover3.SetHelpText");
      this.ucHelpHover3.Size = new System.Drawing.Size(20, 20);
      this.ucHelpHover3.TabIndex = 9;
      // 
      // tbSensorPollTime
      // 
      this.tbSensorPollTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tbSensorPollTime.Location = new System.Drawing.Point(161, 33);
      this.tbSensorPollTime.Name = "tbSensorPollTime";
      this.tbSensorPollTime.Size = new System.Drawing.Size(222, 22);
      this.tbSensorPollTime.TabIndex = 8;
      // 
      // label3
      // 
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.Location = new System.Drawing.Point(-25, 32);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(180, 23);
      this.label3.TabIndex = 7;
      this.label3.Text = "Sensor Poll Time (ms):";
      this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // cbConnectionType
      // 
      this.cbConnectionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbConnectionType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.cbConnectionType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.cbConnectionType.FormattingEnabled = true;
      this.cbConnectionType.Location = new System.Drawing.Point(161, 63);
      this.cbConnectionType.Name = "cbConnectionType";
      this.cbConnectionType.Size = new System.Drawing.Size(222, 24);
      this.cbConnectionType.TabIndex = 12;
      this.cbConnectionType.SelectedIndexChanged += new System.EventHandler(this.cbConnectionType_SelectedIndexChanged);
      // 
      // ucHelpHover4
      // 
      this.ucHelpHover4.BackColor = System.Drawing.Color.Transparent;
      this.ucHelpHover4.Location = new System.Drawing.Point(396, 63);
      this.ucHelpHover4.Margin = new System.Windows.Forms.Padding(0);
      this.ucHelpHover4.Name = "ucHelpHover4";
      this.ucHelpHover4.SetHelpText = resources.GetString("ucHelpHover4.SetHelpText");
      this.ucHelpHover4.Size = new System.Drawing.Size(20, 20);
      this.ucHelpHover4.TabIndex = 11;
      // 
      // label4
      // 
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.Location = new System.Drawing.Point(-25, 60);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(180, 23);
      this.label4.TabIndex = 10;
      this.label4.Text = "Connection Type:";
      this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // cbPCPort
      // 
      this.cbPCPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbPCPort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.cbPCPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.cbPCPort.FormattingEnabled = true;
      this.cbPCPort.Location = new System.Drawing.Point(161, 23);
      this.cbPCPort.Name = "cbPCPort";
      this.cbPCPort.Size = new System.Drawing.Size(222, 24);
      this.cbPCPort.TabIndex = 15;
      // 
      // ucHelpHover5
      // 
      this.ucHelpHover5.BackColor = System.Drawing.Color.Transparent;
      this.ucHelpHover5.Location = new System.Drawing.Point(396, 23);
      this.ucHelpHover5.Margin = new System.Windows.Forms.Padding(0);
      this.ucHelpHover5.Name = "ucHelpHover5";
      this.ucHelpHover5.SetHelpText = "If PC COM port connection type is specified, this is the COM port that will be us" +
    "ed for the USB Serial TTL adapter";
      this.ucHelpHover5.Size = new System.Drawing.Size(20, 20);
      this.ucHelpHover5.TabIndex = 14;
      // 
      // label5
      // 
      this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label5.Location = new System.Drawing.Point(97, 20);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(58, 23);
      this.label5.TabIndex = 13;
      this.label5.Text = "Port:";
      this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // ucHelpHover6
      // 
      this.ucHelpHover6.BackColor = System.Drawing.Color.Transparent;
      this.ucHelpHover6.Location = new System.Drawing.Point(396, 20);
      this.ucHelpHover6.Margin = new System.Windows.Forms.Padding(0);
      this.ucHelpHover6.Name = "ucHelpHover6";
      this.ucHelpHover6.SetHelpText = "If Connection Type Software SErial is connected, this is the digital port that wi" +
    "ll be used.";
      this.ucHelpHover6.Size = new System.Drawing.Size(20, 20);
      this.ucHelpHover6.TabIndex = 17;
      // 
      // label6
      // 
      this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label6.Location = new System.Drawing.Point(70, 20);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(85, 23);
      this.label6.TabIndex = 16;
      this.label6.Text = "Port:";
      this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // cbHardwareUARTPort
      // 
      this.cbHardwareUARTPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbHardwareUARTPort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.cbHardwareUARTPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.cbHardwareUARTPort.FormattingEnabled = true;
      this.cbHardwareUARTPort.Location = new System.Drawing.Point(161, 47);
      this.cbHardwareUARTPort.Name = "cbHardwareUARTPort";
      this.cbHardwareUARTPort.Size = new System.Drawing.Size(222, 24);
      this.cbHardwareUARTPort.TabIndex = 21;
      // 
      // ucHelpHover7
      // 
      this.ucHelpHover7.BackColor = System.Drawing.Color.Transparent;
      this.ucHelpHover7.Location = new System.Drawing.Point(396, 47);
      this.ucHelpHover7.Margin = new System.Windows.Forms.Padding(0);
      this.ucHelpHover7.Name = "ucHelpHover7";
      this.ucHelpHover7.SetHelpText = "If the Connection Type HW UART is selected, this is the UART index that will be u" +
    "sed. Consult the manual for the robot controller to know what pins the UARTs are" +
    ".";
      this.ucHelpHover7.Size = new System.Drawing.Size(20, 20);
      this.ucHelpHover7.TabIndex = 20;
      // 
      // label7
      // 
      this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label7.Location = new System.Drawing.Point(58, 44);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(97, 23);
      this.label7.TabIndex = 19;
      this.label7.Text = "UART Port:";
      this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // btnSave
      // 
      this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnSave.Location = new System.Drawing.Point(12, 13);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new System.Drawing.Size(99, 38);
      this.btnSave.TabIndex = 22;
      this.btnSave.Text = "&Save";
      this.btnSave.UseVisualStyleBackColor = true;
      this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
      // 
      // btnCancel
      // 
      this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnCancel.Location = new System.Drawing.Point(143, 13);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(99, 38);
      this.btnCancel.TabIndex = 23;
      this.btnCancel.Text = "&Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // ucPBSoftwareSerialPort
      // 
      this.ucPBSoftwareSerialPort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.ucPBSoftwareSerialPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ucPBSoftwareSerialPort.Location = new System.Drawing.Point(161, 20);
      this.ucPBSoftwareSerialPort.Name = "ucPBSoftwareSerialPort";
      this.ucPBSoftwareSerialPort.Size = new System.Drawing.Size(91, 23);
      this.ucPBSoftwareSerialPort.TabIndex = 24;
      this.ucPBSoftwareSerialPort.Text = "Select";
      this.ucPBSoftwareSerialPort.UseVisualStyleBackColor = true;
      // 
      // gbUART
      // 
      this.gbUART.Controls.Add(this.tbUartBaud);
      this.gbUART.Controls.Add(this.label1);
      this.gbUART.Controls.Add(this.ucHelpHover1);
      this.gbUART.Controls.Add(this.cbHardwareUARTPort);
      this.gbUART.Controls.Add(this.label7);
      this.gbUART.Controls.Add(this.ucHelpHover7);
      this.gbUART.Dock = System.Windows.Forms.DockStyle.Top;
      this.gbUART.Location = new System.Drawing.Point(3, 299);
      this.gbUART.Name = "gbUART";
      this.gbUART.Size = new System.Drawing.Size(581, 88);
      this.gbUART.TabIndex = 25;
      this.gbUART.TabStop = false;
      this.gbUART.Text = "H/W UART";
      // 
      // gbSoftware
      // 
      this.gbSoftware.Controls.Add(this.ucPBSoftwareSerialPort);
      this.gbSoftware.Controls.Add(this.label6);
      this.gbSoftware.Controls.Add(this.ucHelpHover6);
      this.gbSoftware.Controls.Add(this.cbSoftwareBaudrate);
      this.gbSoftware.Controls.Add(this.label2);
      this.gbSoftware.Controls.Add(this.ucHelpHover2);
      this.gbSoftware.Dock = System.Windows.Forms.DockStyle.Top;
      this.gbSoftware.Location = new System.Drawing.Point(3, 111);
      this.gbSoftware.Name = "gbSoftware";
      this.gbSoftware.Size = new System.Drawing.Size(581, 98);
      this.gbSoftware.TabIndex = 26;
      this.gbSoftware.TabStop = false;
      this.gbSoftware.Text = "Software Serial";
      // 
      // gbPC
      // 
      this.gbPC.Controls.Add(this.tbPCBaud);
      this.gbPC.Controls.Add(this.label8);
      this.gbPC.Controls.Add(this.ucHelpHover8);
      this.gbPC.Controls.Add(this.cbPCPort);
      this.gbPC.Controls.Add(this.label5);
      this.gbPC.Controls.Add(this.ucHelpHover5);
      this.gbPC.Dock = System.Windows.Forms.DockStyle.Top;
      this.gbPC.Location = new System.Drawing.Point(3, 209);
      this.gbPC.Name = "gbPC";
      this.gbPC.Size = new System.Drawing.Size(581, 90);
      this.gbPC.TabIndex = 27;
      this.gbPC.TabStop = false;
      this.gbPC.Text = "PC COM Port";
      // 
      // tbPCBaud
      // 
      this.tbPCBaud.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tbPCBaud.Location = new System.Drawing.Point(161, 53);
      this.tbPCBaud.Name = "tbPCBaud";
      this.tbPCBaud.Size = new System.Drawing.Size(222, 22);
      this.tbPCBaud.TabIndex = 17;
      // 
      // label8
      // 
      this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label8.Location = new System.Drawing.Point(76, 52);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(79, 23);
      this.label8.TabIndex = 16;
      this.label8.Text = "Baudrate:";
      this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // ucHelpHover8
      // 
      this.ucHelpHover8.BackColor = System.Drawing.Color.Transparent;
      this.ucHelpHover8.Location = new System.Drawing.Point(396, 55);
      this.ucHelpHover8.Margin = new System.Windows.Forms.Padding(0);
      this.ucHelpHover8.Name = "ucHelpHover8";
      this.ucHelpHover8.SetHelpText = "When Connection Type is HW UART or PC COM, this is the baud rate for that connect" +
    "ion.\r\n\r\n";
      this.ucHelpHover8.Size = new System.Drawing.Size(20, 20);
      this.ucHelpHover8.TabIndex = 18;
      // 
      // groupBox4
      // 
      this.groupBox4.Controls.Add(this.label3);
      this.groupBox4.Controls.Add(this.tbSensorPollTime);
      this.groupBox4.Controls.Add(this.ucHelpHover3);
      this.groupBox4.Controls.Add(this.label4);
      this.groupBox4.Controls.Add(this.ucHelpHover4);
      this.groupBox4.Controls.Add(this.cbConnectionType);
      this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
      this.groupBox4.Location = new System.Drawing.Point(3, 3);
      this.groupBox4.Name = "groupBox4";
      this.groupBox4.Size = new System.Drawing.Size(581, 108);
      this.groupBox4.TabIndex = 28;
      this.groupBox4.TabStop = false;
      this.groupBox4.Text = "General";
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.btnSave);
      this.panel1.Controls.Add(this.btnCancel);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel1.Location = new System.Drawing.Point(0, 549);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(595, 63);
      this.panel1.TabIndex = 29;
      // 
      // ucTabControl1
      // 
      this.ucTabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
      this.ucTabControl1.BackColor = System.Drawing.Color.White;
      this.ucTabControl1.ButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(170)))), ((int)(((byte)(234)))));
      this.ucTabControl1.ButtonSelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(146)))), ((int)(((byte)(66)))));
      this.ucTabControl1.ButtonTextColor = System.Drawing.Color.White;
      this.ucTabControl1.Controls.Add(this.tabPage1);
      this.ucTabControl1.Controls.Add(this.tabPage2);
      this.ucTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ucTabControl1.ItemSize = new System.Drawing.Size(60, 50);
      this.ucTabControl1.Location = new System.Drawing.Point(0, 0);
      this.ucTabControl1.Margin = new System.Windows.Forms.Padding(0);
      this.ucTabControl1.MarginLeft = 0;
      this.ucTabControl1.MarginTop = 0;
      this.ucTabControl1.Multiline = true;
      this.ucTabControl1.Name = "ucTabControl1";
      this.ucTabControl1.Padding = new System.Drawing.Point(0, 0);
      this.ucTabControl1.SelectedIndex = 0;
      this.ucTabControl1.Size = new System.Drawing.Size(595, 549);
      this.ucTabControl1.TabIndex = 30;
      // 
      // tabPage1
      // 
      this.tabPage1.Controls.Add(this.groupBox1);
      this.tabPage1.Controls.Add(this.gbUART);
      this.tabPage1.Controls.Add(this.gbPC);
      this.tabPage1.Controls.Add(this.gbSoftware);
      this.tabPage1.Controls.Add(this.groupBox4);
      this.tabPage1.Location = new System.Drawing.Point(4, 54);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage1.Size = new System.Drawing.Size(587, 491);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "Connection";
      this.tabPage1.UseVisualStyleBackColor = true;
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.ucHelpHover10);
      this.groupBox1.Controls.Add(this.cbUseNMS);
      this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
      this.groupBox1.Location = new System.Drawing.Point(3, 387);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(581, 62);
      this.groupBox1.TabIndex = 29;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "NMS (Navigation Messaging System)";
      // 
      // ucHelpHover10
      // 
      this.ucHelpHover10.BackColor = System.Drawing.Color.Transparent;
      this.ucHelpHover10.Location = new System.Drawing.Point(56, 26);
      this.ucHelpHover10.Margin = new System.Windows.Forms.Padding(0);
      this.ucHelpHover10.Name = "ucHelpHover10";
      this.ucHelpHover10.SetHelpText = "Send the Group #2 positioning data from the wheel encoders to the NMS (Navigation" +
    " Messaging System) to be used for localization and SLAM, etc.";
      this.ucHelpHover10.Size = new System.Drawing.Size(20, 20);
      this.ucHelpHover10.TabIndex = 21;
      // 
      // cbUseNMS
      // 
      this.cbUseNMS.AutoSize = true;
      this.cbUseNMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.cbUseNMS.Location = new System.Drawing.Point(79, 26);
      this.cbUseNMS.Name = "cbUseNMS";
      this.cbUseNMS.Size = new System.Drawing.Size(266, 20);
      this.cbUseNMS.TabIndex = 0;
      this.cbUseNMS.Text = "Send Position To NMS (in development)";
      this.cbUseNMS.UseVisualStyleBackColor = true;
      // 
      // tabPage2
      // 
      this.tabPage2.Controls.Add(this.ucHelpHover9);
      this.tabPage2.Controls.Add(this.label9);
      this.tabPage2.Controls.Add(this.scriptButtonPressed);
      this.tabPage2.Location = new System.Drawing.Point(4, 54);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage2.Size = new System.Drawing.Size(587, 491);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "Scripts";
      this.tabPage2.UseVisualStyleBackColor = true;
      // 
      // ucHelpHover9
      // 
      this.ucHelpHover9.BackColor = System.Drawing.Color.Transparent;
      this.ucHelpHover9.Location = new System.Drawing.Point(433, 23);
      this.ucHelpHover9.Margin = new System.Windows.Forms.Padding(0);
      this.ucHelpHover9.Name = "ucHelpHover9";
      this.ucHelpHover9.SetHelpText = "When a button on the roomba is pressed (i.e. clean, day, dock, etc)";
      this.ucHelpHover9.Size = new System.Drawing.Size(20, 20);
      this.ucHelpHover9.TabIndex = 10;
      // 
      // label9
      // 
      this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label9.Location = new System.Drawing.Point(8, 22);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(180, 23);
      this.label9.TabIndex = 8;
      this.label9.Text = "Button Pressed:";
      this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // scriptButtonPressed
      // 
      this.scriptButtonPressed.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.scriptButtonPressed.Location = new System.Drawing.Point(191, 23);
      this.scriptButtonPressed.Margin = new System.Windows.Forms.Padding(0);
      this.scriptButtonPressed.Name = "scriptButtonPressed";
      this.scriptButtonPressed.ScriptDefinition = scriptDefinition2;
      this.scriptButtonPressed.Size = new System.Drawing.Size(231, 20);
      this.scriptButtonPressed.TabIndex = 0;
      // 
      // FormConfig
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(595, 612);
      this.Controls.Add(this.ucTabControl1);
      this.Controls.Add(this.panel1);
      this.Name = "FormConfig";
      this.ShowIcon = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Configuration";
      this.gbUART.ResumeLayout(false);
      this.gbUART.PerformLayout();
      this.gbSoftware.ResumeLayout(false);
      this.gbPC.ResumeLayout(false);
      this.gbPC.PerformLayout();
      this.groupBox4.ResumeLayout(false);
      this.groupBox4.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.ucTabControl1.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.tabPage2.ResumeLayout(false);
      this.ResumeLayout(false);

    }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbUartBaud;
        private ARC.UCForms.UC.UCHelpHover ucHelpHover1;
        private ARC.UCForms.UC.UCHelpHover ucHelpHover2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbSoftwareBaudrate;
        private ARC.UCForms.UC.UCHelpHover ucHelpHover3;
        private System.Windows.Forms.TextBox tbSensorPollTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbConnectionType;
        private ARC.UCForms.UC.UCHelpHover ucHelpHover4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbPCPort;
        private ARC.UCForms.UC.UCHelpHover ucHelpHover5;
        private System.Windows.Forms.Label label5;
        private ARC.UCForms.UC.UCHelpHover ucHelpHover6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbHardwareUARTPort;
        private ARC.UCForms.UC.UCHelpHover ucHelpHover7;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private ARC.UCForms.UC.UCPortButton ucPBSoftwareSerialPort;
        private System.Windows.Forms.GroupBox gbUART;
        private System.Windows.Forms.GroupBox gbSoftware;
        private System.Windows.Forms.GroupBox gbPC;
        private System.Windows.Forms.TextBox tbPCBaud;
        private System.Windows.Forms.Label label8;
        private ARC.UCForms.UC.UCHelpHover ucHelpHover8;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Panel panel1;
        private ARC.UCForms.UCTabControl ucTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private ARC.UCForms.UC.UCHelpHover ucHelpHover9;
        private System.Windows.Forms.Label label9;
        private ARC.UCForms.UC.UCScriptEditInput scriptButtonPressed;
    private System.Windows.Forms.GroupBox groupBox1;
    private ARC.UCForms.UC.UCHelpHover ucHelpHover10;
    private System.Windows.Forms.CheckBox cbUseNMS;
  }
}