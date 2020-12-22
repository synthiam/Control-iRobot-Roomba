namespace iRobot_Roomba_Movement_Panel {
    partial class FormMain {
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
      this.btnStop = new System.Windows.Forms.Button();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.button7 = new System.Windows.Forms.Button();
      this.button8 = new System.Windows.Forms.Button();
      this.button9 = new System.Windows.Forms.Button();
      this.button10 = new System.Windows.Forms.Button();
      this.tbSpeedLeft = new System.Windows.Forms.TrackBar();
      this.checkBox1 = new System.Windows.Forms.CheckBox();
      this.checkBox2 = new System.Windows.Forms.CheckBox();
      this.checkBox3 = new System.Windows.Forms.CheckBox();
      this.button12 = new System.Windows.Forms.Button();
      this.panel1 = new System.Windows.Forms.Panel();
      this.lblStreamCnt = new System.Windows.Forms.Label();
      this.cbSensorStream = new System.Windows.Forms.CheckBox();
      this.tbSpeedRight = new System.Windows.Forms.TrackBar();
      this.btnForward = new System.Windows.Forms.Button();
      this.btnLeft = new System.Windows.Forms.Button();
      this.btnReverse = new System.Windows.Forms.Button();
      this.btnRight = new System.Windows.Forms.Button();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.button1 = new System.Windows.Forms.Button();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.tbLog = new System.Windows.Forms.TextBox();
      this.btnReset = new System.Windows.Forms.Button();
      this.btnPowerDown = new System.Windows.Forms.Button();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      ((System.ComponentModel.ISupportInitialize)(this.tbSpeedLeft)).BeginInit();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.tbSpeedRight)).BeginInit();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.SuspendLayout();
      // 
      // btnStop
      // 
      this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnStop.Location = new System.Drawing.Point(40, 143);
      this.btnStop.Name = "btnStop";
      this.btnStop.Size = new System.Drawing.Size(63, 30);
      this.btnStop.TabIndex = 3;
      this.btnStop.Text = "Stop";
      this.btnStop.UseVisualStyleBackColor = true;
      this.btnStop.Click += new System.EventHandler(this.stop);
      // 
      // textBox1
      // 
      this.textBox1.BackColor = System.Drawing.Color.Black;
      this.textBox1.Cursor = System.Windows.Forms.Cursors.Hand;
      this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.textBox1.ForeColor = System.Drawing.Color.White;
      this.textBox1.Location = new System.Drawing.Point(8, 215);
      this.textBox1.Name = "textBox1";
      this.textBox1.ReadOnly = true;
      this.textBox1.Size = new System.Drawing.Size(127, 21);
      this.textBox1.TabIndex = 9;
      this.textBox1.Text = "Click For Arrow Key Control";
      this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
      this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
      // 
      // button7
      // 
      this.button7.Dock = System.Windows.Forms.DockStyle.Top;
      this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.button7.Location = new System.Drawing.Point(3, 128);
      this.button7.Name = "button7";
      this.button7.Size = new System.Drawing.Size(121, 28);
      this.button7.TabIndex = 14;
      this.button7.Text = "Clean";
      this.button7.UseVisualStyleBackColor = true;
      this.button7.Click += new System.EventHandler(this.button7_Click);
      // 
      // button8
      // 
      this.button8.Dock = System.Windows.Forms.DockStyle.Top;
      this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.button8.Location = new System.Drawing.Point(3, 100);
      this.button8.Name = "button8";
      this.button8.Size = new System.Drawing.Size(121, 28);
      this.button8.TabIndex = 15;
      this.button8.Text = "Max Clean";
      this.button8.UseVisualStyleBackColor = true;
      this.button8.Click += new System.EventHandler(this.button8_Click);
      // 
      // button9
      // 
      this.button9.Dock = System.Windows.Forms.DockStyle.Top;
      this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.button9.Location = new System.Drawing.Point(3, 72);
      this.button9.Name = "button9";
      this.button9.Size = new System.Drawing.Size(121, 28);
      this.button9.TabIndex = 16;
      this.button9.Text = "Seek Dock";
      this.button9.UseVisualStyleBackColor = true;
      this.button9.Click += new System.EventHandler(this.button9_Click);
      // 
      // button10
      // 
      this.button10.Dock = System.Windows.Forms.DockStyle.Top;
      this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.button10.Location = new System.Drawing.Point(3, 44);
      this.button10.Name = "button10";
      this.button10.Size = new System.Drawing.Size(121, 28);
      this.button10.TabIndex = 17;
      this.button10.Text = "Spot Clean";
      this.button10.UseVisualStyleBackColor = true;
      this.button10.Click += new System.EventHandler(this.button10_Click);
      // 
      // tbSpeedLeft
      // 
      this.tbSpeedLeft.Dock = System.Windows.Forms.DockStyle.Right;
      this.tbSpeedLeft.Location = new System.Drawing.Point(146, 0);
      this.tbSpeedLeft.Name = "tbSpeedLeft";
      this.tbSpeedLeft.Orientation = System.Windows.Forms.Orientation.Vertical;
      this.tbSpeedLeft.Size = new System.Drawing.Size(45, 248);
      this.tbSpeedLeft.TabIndex = 19;
      // 
      // checkBox1
      // 
      this.checkBox1.AutoSize = true;
      this.checkBox1.Dock = System.Windows.Forms.DockStyle.Top;
      this.checkBox1.Location = new System.Drawing.Point(3, 50);
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.Size = new System.Drawing.Size(205, 17);
      this.checkBox1.TabIndex = 20;
      this.checkBox1.Text = "Main Brush";
      this.checkBox1.UseVisualStyleBackColor = true;
      this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
      // 
      // checkBox2
      // 
      this.checkBox2.AutoSize = true;
      this.checkBox2.Dock = System.Windows.Forms.DockStyle.Top;
      this.checkBox2.Location = new System.Drawing.Point(3, 33);
      this.checkBox2.Name = "checkBox2";
      this.checkBox2.Size = new System.Drawing.Size(205, 17);
      this.checkBox2.TabIndex = 21;
      this.checkBox2.Text = "Vacuum";
      this.checkBox2.UseVisualStyleBackColor = true;
      this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
      // 
      // checkBox3
      // 
      this.checkBox3.AutoSize = true;
      this.checkBox3.Dock = System.Windows.Forms.DockStyle.Top;
      this.checkBox3.Location = new System.Drawing.Point(3, 16);
      this.checkBox3.Name = "checkBox3";
      this.checkBox3.Size = new System.Drawing.Size(205, 17);
      this.checkBox3.TabIndex = 22;
      this.checkBox3.Text = "Side Brush";
      this.checkBox3.UseVisualStyleBackColor = true;
      this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
      // 
      // button12
      // 
      this.button12.Dock = System.Windows.Forms.DockStyle.Top;
      this.button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.button12.Location = new System.Drawing.Point(3, 16);
      this.button12.Name = "button12";
      this.button12.Size = new System.Drawing.Size(121, 28);
      this.button12.TabIndex = 23;
      this.button12.Text = "Send Init";
      this.button12.UseVisualStyleBackColor = true;
      this.button12.Click += new System.EventHandler(this.button12_Click);
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.groupBox3);
      this.panel1.Controls.Add(this.tbSpeedLeft);
      this.panel1.Controls.Add(this.tbSpeedRight);
      this.panel1.Controls.Add(this.btnForward);
      this.panel1.Controls.Add(this.btnStop);
      this.panel1.Controls.Add(this.btnLeft);
      this.panel1.Controls.Add(this.btnReverse);
      this.panel1.Controls.Add(this.btnRight);
      this.panel1.Controls.Add(this.textBox1);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.MinimumSize = new System.Drawing.Size(236, 194);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(236, 248);
      this.panel1.TabIndex = 26;
      // 
      // lblStreamCnt
      // 
      this.lblStreamCnt.Dock = System.Windows.Forms.DockStyle.Top;
      this.lblStreamCnt.Location = new System.Drawing.Point(3, 39);
      this.lblStreamCnt.Name = "lblStreamCnt";
      this.lblStreamCnt.Size = new System.Drawing.Size(140, 21);
      this.lblStreamCnt.TabIndex = 30;
      this.lblStreamCnt.Text = "0 packets";
      // 
      // cbSensorStream
      // 
      this.cbSensorStream.Dock = System.Windows.Forms.DockStyle.Top;
      this.cbSensorStream.Location = new System.Drawing.Point(3, 16);
      this.cbSensorStream.Name = "cbSensorStream";
      this.cbSensorStream.Size = new System.Drawing.Size(140, 23);
      this.cbSensorStream.TabIndex = 29;
      this.cbSensorStream.Text = "Sensor Streaming";
      this.cbSensorStream.UseVisualStyleBackColor = true;
      this.cbSensorStream.CheckedChanged += new System.EventHandler(this.cbSensorStream_CheckedChanged);
      // 
      // tbSpeedRight
      // 
      this.tbSpeedRight.Dock = System.Windows.Forms.DockStyle.Right;
      this.tbSpeedRight.Location = new System.Drawing.Point(191, 0);
      this.tbSpeedRight.Name = "tbSpeedRight";
      this.tbSpeedRight.Orientation = System.Windows.Forms.Orientation.Vertical;
      this.tbSpeedRight.Size = new System.Drawing.Size(45, 248);
      this.tbSpeedRight.TabIndex = 27;
      // 
      // btnForward
      // 
      this.btnForward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnForward.Image = global::iRobot_Roomba_Movement_Panel.Properties.Resources.Actions_go_up_icon1;
      this.btnForward.Location = new System.Drawing.Point(57, 108);
      this.btnForward.Name = "btnForward";
      this.btnForward.Size = new System.Drawing.Size(30, 30);
      this.btnForward.TabIndex = 5;
      this.btnForward.UseVisualStyleBackColor = true;
      this.btnForward.Click += new System.EventHandler(this.forward);
      // 
      // btnLeft
      // 
      this.btnLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnLeft.Image = global::iRobot_Roomba_Movement_Panel.Properties.Resources.Actions_go_previous_icon;
      this.btnLeft.Location = new System.Drawing.Point(4, 143);
      this.btnLeft.Name = "btnLeft";
      this.btnLeft.Size = new System.Drawing.Size(30, 30);
      this.btnLeft.TabIndex = 6;
      this.btnLeft.UseVisualStyleBackColor = true;
      this.btnLeft.Click += new System.EventHandler(this.left);
      // 
      // btnReverse
      // 
      this.btnReverse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnReverse.Image = global::iRobot_Roomba_Movement_Panel.Properties.Resources.Actions_go_down_icon;
      this.btnReverse.Location = new System.Drawing.Point(57, 178);
      this.btnReverse.Name = "btnReverse";
      this.btnReverse.Size = new System.Drawing.Size(30, 30);
      this.btnReverse.TabIndex = 7;
      this.btnReverse.UseVisualStyleBackColor = true;
      this.btnReverse.Click += new System.EventHandler(this.reverse);
      // 
      // btnRight
      // 
      this.btnRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnRight.Image = global::iRobot_Roomba_Movement_Panel.Properties.Resources.Actions_go_next_icon;
      this.btnRight.Location = new System.Drawing.Point(109, 143);
      this.btnRight.Name = "btnRight";
      this.btnRight.Size = new System.Drawing.Size(30, 30);
      this.btnRight.TabIndex = 8;
      this.btnRight.UseVisualStyleBackColor = true;
      this.btnRight.Click += new System.EventHandler(this.right);
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.btnPowerDown);
      this.groupBox1.Controls.Add(this.btnReset);
      this.groupBox1.Controls.Add(this.button1);
      this.groupBox1.Controls.Add(this.button7);
      this.groupBox1.Controls.Add(this.button8);
      this.groupBox1.Controls.Add(this.button9);
      this.groupBox1.Controls.Add(this.button10);
      this.groupBox1.Controls.Add(this.button12);
      this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
      this.groupBox1.Location = new System.Drawing.Point(236, 0);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(127, 248);
      this.groupBox1.TabIndex = 27;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Commands";
      // 
      // button1
      // 
      this.button1.Dock = System.Windows.Forms.DockStyle.Top;
      this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.button1.Location = new System.Drawing.Point(3, 156);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(121, 28);
      this.button1.TabIndex = 24;
      this.button1.Text = "Stop Clean";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.tbLog);
      this.groupBox2.Controls.Add(this.checkBox1);
      this.groupBox2.Controls.Add(this.checkBox2);
      this.groupBox2.Controls.Add(this.checkBox3);
      this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupBox2.Location = new System.Drawing.Point(363, 0);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(211, 248);
      this.groupBox2.TabIndex = 28;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Hardware Commands";
      // 
      // tbLog
      // 
      this.tbLog.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tbLog.Location = new System.Drawing.Point(3, 67);
      this.tbLog.Multiline = true;
      this.tbLog.Name = "tbLog";
      this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.tbLog.Size = new System.Drawing.Size(205, 178);
      this.tbLog.TabIndex = 26;
      // 
      // btnReset
      // 
      this.btnReset.Dock = System.Windows.Forms.DockStyle.Top;
      this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnReset.Location = new System.Drawing.Point(3, 184);
      this.btnReset.Name = "btnReset";
      this.btnReset.Size = new System.Drawing.Size(121, 28);
      this.btnReset.TabIndex = 25;
      this.btnReset.Text = "Reset/Power Off";
      this.btnReset.UseVisualStyleBackColor = true;
      this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
      // 
      // btnPowerDown
      // 
      this.btnPowerDown.Dock = System.Windows.Forms.DockStyle.Top;
      this.btnPowerDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnPowerDown.Location = new System.Drawing.Point(3, 212);
      this.btnPowerDown.Name = "btnPowerDown";
      this.btnPowerDown.Size = new System.Drawing.Size(121, 28);
      this.btnPowerDown.TabIndex = 26;
      this.btnPowerDown.Text = "Power Down";
      this.btnPowerDown.UseVisualStyleBackColor = true;
      this.btnPowerDown.Click += new System.EventHandler(this.btnPowerDown_Click);
      // 
      // groupBox3
      // 
      this.groupBox3.Controls.Add(this.lblStreamCnt);
      this.groupBox3.Controls.Add(this.cbSensorStream);
      this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
      this.groupBox3.Location = new System.Drawing.Point(0, 0);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new System.Drawing.Size(146, 67);
      this.groupBox3.TabIndex = 31;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Sensor Data";
      // 
      // FormMain
      // 
      this.ClientSize = new System.Drawing.Size(574, 248);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.panel1);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "FormMain";
      this.Text = "Roomba";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormRoombaMovementPanel_FormClosing);
      ((System.ComponentModel.ISupportInitialize)(this.tbSpeedLeft)).EndInit();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.tbSpeedRight)).EndInit();
      this.groupBox1.ResumeLayout(false);
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.groupBox3.ResumeLayout(false);
      this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnForward;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnReverse;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.TrackBar tbSpeedLeft;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TrackBar tbSpeedRight;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.CheckBox cbSensorStream;
        private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Label lblStreamCnt;
    private System.Windows.Forms.Button btnReset;
    private System.Windows.Forms.Button btnPowerDown;
    private System.Windows.Forms.GroupBox groupBox3;
  }
}