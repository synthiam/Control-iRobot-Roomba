using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Create2OI.Chassis;
using EZ_B;
using ARC;
using ARC.Config.Sub;
using iRobot_Roomba_Movement_Panel.Config;

namespace iRobot_Roomba_Movement_Panel {

  public partial class FormMain : ARC.UCForms.FormPluginMaster {

    Create2OI.Chassis.Create _robotController;

    enum RoombaCmdEnum {
      Init,
      EnableSensorStream,
      DisableSensorStream,
      PowerOff,
      SpotClean,
      Clean,
      MaxClean,
      StopAllBrushes,
      MainBrushOn,
      MainBrushOff,
      SideBrushOn,
      SideBrushOff,
      VacuumOn,
      VacuumOff,
      SeekDockingStation
    }

    public FormMain() {

      InitializeComponent();

      tbSpeedRight.Minimum = tbSpeedLeft.Minimum = MovementManager.MIN_SPEED;
      tbSpeedRight.Maximum = tbSpeedLeft.Maximum = MovementManager.MAX_SPEED;
      tbSpeedRight.TickFrequency = tbSpeedLeft.TickFrequency = 10;

      tbSpeedLeft.Value = EZBManager.MovementManager.GetSpeedLeft();
      tbSpeedRight.Value = EZBManager.MovementManager.GetSpeedRight();

      ARC.FormMain.MovementPanel = this;
      EZBManager.MovementManager.LocomotionStyle = MovementManager.LocomotionStyleEnum.Wheeled_Tracked;

      EZBManager.PrimaryEZB.OnConnectionChange2 += PrimaryEZB_OnConnectionChange2;
      EZBManager.MovementManager.OnMovement2 += Movement_OnMovement2;
      EZBManager.MovementManager.OnSpeedChanged += MovementManager_OnSpeedChanged;
    }

    private void FormRoombaMovementPanel_FormClosing(object sender, FormClosingEventArgs e) {

      if (_robotController != null) {

        _robotController.Dispose();

        _robotController = null;
      }

      ARC.FormMain.MovementPanel = null;

      EZBManager.PrimaryEZB.OnConnectionChange2 -= PrimaryEZB_OnConnectionChange2;
      EZBManager.MovementManager.OnMovement2 -= Movement_OnMovement2;
      EZBManager.MovementManager.OnSpeedChanged -= MovementManager_OnSpeedChanged;

      if (ARC.Scripting.ScriptManager.DoesExecutorExist(Text)) {

        var s = ARC.Scripting.ScriptManager.GetExecutor(Text);
        s.OnDone -= S_OnDone;
        s.OnError -= S_OnError;
        s.OnResult -= S_OnResult;
        s.OnStart -= S_OnStart;
        ARC.Scripting.ScriptManager.RemoveExecutor(Text);
      }
    }

    private void MovementManager_OnSpeedChanged(int speedLeft, int speedRight) {

      Invokers.SetValue(tbSpeedLeft, speedLeft);
      Invokers.SetValue(tbSpeedRight, speedRight);
    }

    private void PrimaryEZB_OnConnectionChange2(EZB sender, bool isConnected) {

      var portType = (Config.ConfigTitles.PortTypeEnum)_cf.STORAGE[Config.ConfigTitles.CONNECTION_TYPE];

      if (portType == ConfigTitles.PortTypeEnum.PC_COM)
        return;

      try {

        if (isConnected) {

          init();
        } else {

          if (_robotController != null) {

            _robotController.Dispose();

            _robotController = null;
          }

          Invokers.SetAppendText(tbLog, true, "Disconnected");
        }
      } catch (Exception ex) {

        Invokers.SetAppendText(tbLog, true, "Connection change: {0}", ex);
      }
    }

    public override void SetConfiguration(PluginV1 cf) {

      if (!ARC.Scripting.ScriptManager.DoesExecutorExist(Text)) {

        var s = ARC.Scripting.ScriptManager.GetExecutor(Text);
        s.OnDone += S_OnDone;
        s.OnError += S_OnError;
        s.OnResult += S_OnResult;
        s.OnStart += S_OnStart;       
      }

      cf.SCRIPTS.AddIfNotExist(Config.ConfigTitles.SCRIPT_BUTTON_PRESSED, new ARC.Config.Sub.Reusable.ScriptDefinition());

      cf.STORAGE.AddIfNotExist(Config.ConfigTitles.BAUD_RATE_SERIAL, EZ_B.Uart.BAUD_RATE_ENUM.Baud_115200);
      cf.STORAGE.AddIfNotExist(Config.ConfigTitles.BAUD_RATE_UART, 115200);
      cf.STORAGE.AddIfNotExist(Config.ConfigTitles.BAUD_RATE_PC, 115200);
      cf.STORAGE.AddIfNotExist(Config.ConfigTitles.EZB_SERIAL_PORT, EZ_B.Digital.DigitalPortEnum.D0);
      cf.STORAGE.AddIfNotExist(Config.ConfigTitles.EZB_UART_PORT, 0);
      cf.STORAGE.AddIfNotExist(Config.ConfigTitles.PC_COM_PORT, string.Empty);
      cf.STORAGE.AddIfNotExist(Config.ConfigTitles.CONNECTION_TYPE, Config.ConfigTitles.PortTypeEnum.HW_UART);
      cf.STORAGE.AddIfNotExist(Config.ConfigTitles.SENSOR_POLL_TIME_MS, 500);
      cf.STORAGE.AddIfNotExist(Config.ConfigTitles.NMS_POSITION_DATA, true);

      if (EZBManager.PrimaryEZB.IsConnected)
        try {

          init();
        } catch (Exception ex) {

          tbLog.AppendText(ex.Message);
          tbLog.AppendText(Environment.NewLine);
        }

      base.SetConfiguration(cf);
    }

    private void S_OnStart(string compilerName) {

      Invokers.SetAppendText(tbLog, true, "Pressed");
    }

    private void S_OnResult(string compilerName, string resultTxt) {

      Invokers.SetAppendText(tbLog, true, $"> {resultTxt}");
    }

    private void S_OnError(string compilerName, string errorMessage) {

      Invokers.SetAppendText(tbLog, true, $"> {errorMessage}");
    }

    private void S_OnDone(string compilerName, TimeSpan timeTook) {

      Invokers.SetAppendText(tbLog, true, $"Done {timeTook}");
    }

    RoombaCmdEnum GetRoombaCommand(object obj) {

      string text = obj.ToString();

      RoombaCmdEnum item;

      if (Enum.TryParse<RoombaCmdEnum>(text, true, out item))
        return item;

      throw new Exception("Unknown Roomba Command: " + text);
    }

    public override object[] GetSupportedControlCommands() {

      List<object> list = new List<object>();

      foreach (RoombaCmdEnum cmd in Enum.GetValues(typeof(RoombaCmdEnum)))
        list.Add(Common.Quote(cmd));

      return list.ToArray();
    }

    public override void SendCommand(string windowCommand, params string[] values) {

      var cmd = GetRoombaCommand(windowCommand);

      if (cmd == RoombaCmdEnum.Init) {

        init();

      } else if (cmd == RoombaCmdEnum.DisableSensorStream) {

        Invokers.SetChecked(cbSensorStream, false);

        cbSensorStream_CheckedChanged(null, null);
      } else if (cmd == RoombaCmdEnum.EnableSensorStream) {

        Invokers.SetChecked(cbSensorStream, true);

        cbSensorStream_CheckedChanged(null, null);
      } else if (cmd == RoombaCmdEnum.PowerOff) {

        _robotController.SetMode(Create2OI.Types.OperatingMode.OFF);
      } else if (cmd == RoombaCmdEnum.SeekDockingStation) {

        _robotController.Execute(Create2OI.Types.OpCode.FORCE_SEEKING_DOCK);
      } else if (cmd == RoombaCmdEnum.Clean) {

        _robotController.Execute(Create2OI.Types.OpCode.CLEAN);
      } else if (cmd == RoombaCmdEnum.MaxClean) {

        _robotController.Execute(Create2OI.Types.OpCode.MAX_CLEAN);
      } else if (cmd == RoombaCmdEnum.SpotClean) {

        _robotController.Execute(Create2OI.Types.OpCode.SPOT);
      } else {

        base.SendCommand(windowCommand, values);
      }

      //else if (cmd == RoombaCmdEnum.DisableAllBrushes)
      //  _roomba.DisableAllBrushes();
      //else if (cmd == RoombaCmdEnum.MainBrushOff)
      //  _roomba.SetMainBrush(false);
      //else if (cmd == RoombaCmdEnum.MainBrushOn)
      //  _roomba.SetMainBrush(true);
      //else if (cmd == RoombaCmdEnum.SideBrushOff)
      //  _roomba.SetSideBrush(false);
      //else if (cmd == RoombaCmdEnum.SideBrushOn)
      //  _roomba.SetSideBrush(true);
      //else if (cmd == RoombaCmdEnum.VacuumOff)
      //  _roomba.SetVacuum(false);
      //else if (cmd == RoombaCmdEnum.VacuumOn)
      //  _roomba.SetVacuum(true);
    }

    private void stop(object sender, EventArgs e) {

      EZBManager.MovementManager.GoStop();
    }

    private void forward(object sender, EventArgs e) {

      EZBManager.MovementManager.GoForward((byte)tbSpeedLeft.Value);
    }

    private void left(object sender, EventArgs e) {

      EZBManager.MovementManager.GoLeft((byte)tbSpeedLeft.Value);
    }

    private void reverse(object sender, EventArgs e) {

      EZBManager.MovementManager.GoReverse((byte)tbSpeedLeft.Value);
    }

    private void right(object sender, EventArgs e) {

      EZBManager.MovementManager.GoRight((byte)tbSpeedLeft.Value);
    }

    private void init() {

      if (InvokeRequired) {

        Invoke(new Action(() => init()));

        return;
      }

      tbLog.Clear();

      if (_robotController != null) {

        _robotController.Dispose();

        _robotController = null;
      }

      var portType = (Config.ConfigTitles.PortTypeEnum)_cf.STORAGE[Config.ConfigTitles.CONNECTION_TYPE];

      IOCommunicator comm;

      if (portType == Config.ConfigTitles.PortTypeEnum.Software_Serial) {

        if (!EZBManager.PrimaryEZB.IsConnected)
          throw new Exception("Not connected to EZB Index #0");

        var digitalPort = (Digital.DigitalPortEnum)_cf.STORAGE[Config.ConfigTitles.EZB_SERIAL_PORT];
        var baudrate = (Uart.BAUD_RATE_ENUM)_cf.STORAGE[Config.ConfigTitles.BAUD_RATE_SERIAL];

        tbLog.AppendText(string.Format("Connecting software serial port {0} at {1} baud...", digitalPort, baudrate));

        comm = new EZBDigitalIOCommunicator(digitalPort, baudrate);
      } else if (portType == Config.ConfigTitles.PortTypeEnum.HW_UART) {

        if (!EZBManager.PrimaryEZB.IsConnected)
          throw new Exception("Not connected to EZB Index #0");

        var uartPort = Convert.ToInt16(_cf.STORAGE[Config.ConfigTitles.EZB_UART_PORT]);
        var baudRate = Convert.ToInt32(_cf.STORAGE[Config.ConfigTitles.BAUD_RATE_UART]);

        tbLog.AppendText(string.Format("Connecting HW UART {0} at {1} baud...", uartPort, baudRate));

        comm = new EZBUARTIOCommunicator(uartPort, baudRate);
      } else {

        var comPort = _cf.STORAGE[Config.ConfigTitles.PC_COM_PORT].ToString();
        var baudRate = Convert.ToInt32(_cf.STORAGE[Config.ConfigTitles.BAUD_RATE_PC]);

        tbLog.AppendText(string.Format("Connecting {0} at {1} baud...", comPort, baudRate));

        comm = new SerialPortIOCommunicator(comPort, baudRate);
      }

      _robotController = new Create(
        comm, 
        Convert.ToInt32(_cf.STORAGE[Config.ConfigTitles.SENSOR_POLL_TIME_MS]),
        Convert.ToBoolean(_cf.STORAGE[Config.ConfigTitles.NMS_POSITION_DATA]));

      _robotController.OnError += _robotController_OnError;
      _robotController.OnButtonPressed += _robotController_OnButtonPressed;
      _robotController.SetMode(Create2OI.Types.OperatingMode.FULL);

      cbSensorStream_CheckedChanged(null, null);

      doMotors();

      tbLog.AppendText("Connected");

      tbLog.AppendText(Environment.NewLine);
    }

    private void _robotController_OnButtonPressed(object sender, bool e) {

      ARC.Scripting.ScriptManager.GetExecutor(Text).StartScriptASync(_cf.SCRIPTS[ConfigTitles.SCRIPT_BUTTON_PRESSED]);
    }

    private void _robotController_OnError(object sender, Exception txt) {

      if (IsClosing)
        return;

      Invokers.SetChecked(cbSensorStream, false);

      Invokers.SetAppendText(tbLog, true, txt.ToString());
    }

    private void Movement_OnMovement2(MovementManager.MovementDirectionEnum direction, byte speedLeft, byte speedRight) {

      if (_robotController == null)
        return;

      var speedLeftScaled = (short)Functions.RemapScalar(speedLeft, 0, 255, 0, 500);
      var speedRightScaled = (short)Functions.RemapScalar(speedRight, 0, 255, 0, 500);

      if (direction == MovementManager.MovementDirectionEnum.Stop) {

        _robotController.DriveDirect(0, 0);

        Invokers.SetBackColor(btnForward, btnForward.Parent.BackColor);
        Invokers.SetBackColor(btnRight, btnForward.Parent.BackColor);
        Invokers.SetBackColor(btnLeft, btnForward.Parent.BackColor);
        Invokers.SetBackColor(btnReverse, btnForward.Parent.BackColor);
        Invokers.SetBackColor(btnStop, Common.ChangeColorBrightness(btnForward.Parent.BackColor, -0.3f));
      } else if (direction == MovementManager.MovementDirectionEnum.Forward) {

        _robotController.DriveDirect(speedLeftScaled, speedRightScaled);

        Invokers.SetBackColor(btnForward, Common.ChangeColorBrightness(btnForward.Parent.BackColor, -0.3f));
        Invokers.SetBackColor(btnRight, btnForward.Parent.BackColor);
        Invokers.SetBackColor(btnLeft, btnForward.Parent.BackColor);
        Invokers.SetBackColor(btnReverse, btnForward.Parent.BackColor);
        Invokers.SetBackColor(btnStop, btnForward.Parent.BackColor);
      } else if (direction == MovementManager.MovementDirectionEnum.Right) {

        _robotController.DriveDirect(speedLeftScaled, -speedRightScaled);

        Invokers.SetBackColor(btnForward, btnForward.Parent.BackColor);
        Invokers.SetBackColor(btnRight, Common.ChangeColorBrightness(btnForward.Parent.BackColor, -0.3f));
        Invokers.SetBackColor(btnLeft, btnForward.Parent.BackColor);
        Invokers.SetBackColor(btnReverse, btnForward.Parent.BackColor);
        Invokers.SetBackColor(btnStop, btnForward.Parent.BackColor);
      } else if (direction == MovementManager.MovementDirectionEnum.Reverse) {

        _robotController.DriveDirect(-speedLeftScaled, -speedRightScaled);

        Invokers.SetBackColor(btnForward, btnForward.Parent.BackColor);
        Invokers.SetBackColor(btnRight, btnForward.Parent.BackColor);
        Invokers.SetBackColor(btnLeft, btnForward.Parent.BackColor);
        Invokers.SetBackColor(btnReverse, Common.ChangeColorBrightness(btnForward.Parent.BackColor, -0.3f));
        Invokers.SetBackColor(btnStop, btnForward.Parent.BackColor);
      } else if (direction == MovementManager.MovementDirectionEnum.Left) {

        _robotController.DriveDirect(-speedLeftScaled, speedRightScaled);

        Invokers.SetBackColor(btnForward, btnForward.Parent.BackColor);
        Invokers.SetBackColor(btnRight, btnForward.Parent.BackColor);
        Invokers.SetBackColor(btnLeft, Common.ChangeColorBrightness(btnForward.Parent.BackColor, -0.3f));
        Invokers.SetBackColor(btnReverse, btnForward.Parent.BackColor);
        Invokers.SetBackColor(btnStop, btnForward.Parent.BackColor);
      }
    }

    private void textBox1_KeyUp(object sender, KeyEventArgs e) {

      stop(this, new EventArgs());
    }

    private void textBox1_KeyDown(object sender, KeyEventArgs e) {

      if (EZBManager.MovementManager.GetCurrentDirection != MovementManager.MovementDirectionEnum.Stop)
        return;

      if (e.KeyCode == Keys.Up)
        forward(this, new EventArgs());
      else if (e.KeyCode == Keys.Right)
        right(this, new EventArgs());
      else if (e.KeyCode == Keys.Down)
        reverse(this, new EventArgs());
      else if (e.KeyCode == Keys.Left)
        left(this, new EventArgs());
      else
        stop(this, new EventArgs());
    }

    private void button7_Click(object sender, EventArgs e) {

      _robotController.Execute(Create2OI.Types.OpCode.CLEAN);
    }

    private void button8_Click(object sender, EventArgs e) {

      _robotController.Execute(Create2OI.Types.OpCode.MAX_CLEAN);
    }

    private void button9_Click(object sender, EventArgs e) {

      _robotController.Execute(Create2OI.Types.OpCode.FORCE_SEEKING_DOCK);
    }

    private void button10_Click(object sender, EventArgs e) {

      _robotController.Execute(Create2OI.Types.OpCode.SPOT);
    }

    private void checkBox1_CheckedChanged(object sender, EventArgs e) {

      doMotors();
    }

    private void checkBox2_CheckedChanged(object sender, EventArgs e) {

      doMotors();
    }

    private void checkBox3_CheckedChanged(object sender, EventArgs e) {

      doMotors();
    }

    void doMotors() {

      if (_robotController == null)
        return;

      int b = 0;

      b += checkBox3.Checked ? 1 : 0; // side brush
      b += checkBox2.Checked ? 2 : 0; // vacuum
      b += checkBox1.Checked ? 4 : 0; // main

      _robotController.Execute(Create2OI.Types.OpCode.MOTORS, (byte)b);
    }

    private void button12_Click(object sender, EventArgs e) {

      try {

        init();
      } catch (Exception ex) {

        tbLog.AppendText(ex.Message);
        tbLog.AppendText(Environment.NewLine);
      }
    }

    private void cbSensorStream_CheckedChanged(object sender, EventArgs e) {

      try {

        if (_robotController == null)
          return;

        if (cbSensorStream.Checked)
          _robotController.StartStreaming();
        else
          _robotController.StopStreaming();
      } catch (Exception ex) {

        Invokers.SetAppendText(tbLog, true, ex.Message);
      }
    }

    private void button1_Click(object sender, EventArgs e) {

      _robotController.SetMode(Create2OI.Types.OperatingMode.SAFE);
    }

    public override void ConfigPressed() {

      using (var f = new FormConfig()) {

        f.SetConfiguration(_cf);

        if (f.ShowDialog() == DialogResult.OK)
          SetConfiguration(f.GetConfiguration);
      }
    }
  }
}
