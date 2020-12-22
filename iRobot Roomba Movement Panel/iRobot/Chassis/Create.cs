using System;
using System.Collections.Generic;
using System.Linq;
using Create2OI.Interfaces;
using Create2OI.Types;

namespace Create2OI.Chassis {

  public class Create : IDisposable {

    public enum ButtonTypeEnum {
      Clean,
      Spot,
      Dock,
      Day,
      Hour,
      Minute,
      Schedule,
      Clock
    }

    public event EventHandler<int> OnStreamPacketCnt;

    public event EventHandler<string> OnLog;

    public event EventHandler<bool> OnButtonPressed;

    public delegate void OnErrorEventHandler(object sender, Exception txt);
    public event OnErrorEventHandler OnError;

    System.Timers.Timer _timer;
    bool                _isRunning = false;
    List<byte>          _buffer = new List<byte>();
    bool                _sendNMS = false;
    bool                _lastButtonState = false;
    int                 _streamPacketCnt = 0;

    public IOCommunicator IO {
      private set;
      get;
    }

    public Create(IOCommunicator io, int pollTimeMS, bool sendNMSPosition) {

      _sendNMS = sendNMSPosition;

      IO = io;

      GC.Collect();

      SetMode(OperatingMode.PASSIVE);

      _timer = new System.Timers.Timer();
      _timer.Elapsed += _timer_Elapsed;
      _timer.Interval = pollTimeMS;

      ARC.Scripting.VariableManager.SetVariable("$RoombaSensorStreaming", false);

      OnLog?.Invoke(this, "iRobot communicate initialized");
    }

    public void Dispose() {

      _timer.Stop();
      _timer.Dispose();
      _timer = null;

      IO.Dispose();
    }

    public void StartStreaming() {

      if (!IO.SupportsStreaming)
        throw new Exception("Connection type does not support sensor streaming");

      if (_timer.Enabled)
        throw new Exception("Sensor stream already running");

      ARC.Scripting.VariableManager.SetVariable("$RoombaSensorStreaming", true);

      _lastButtonState = false;

      _buffer.Clear();

      _streamPacketCnt = 0;

      // Let the input buffer clear if the roomba was in mid send of sensor data
      System.Threading.Thread.Sleep(500);

      var tmp = IO.ReadBytes(IO.BytesToRead);

      if (tmp.Length > 0)
        OnLog?.Invoke(this, $"Cleared {tmp.Length} bytes from input buffer");

      _timer.Start();

      OnLog?.Invoke(this, "Sensor stream started");
    }

    public void StopStreaming() {

      if (_timer != null)
        _timer.Stop();

      ARC.Scripting.VariableManager.SetVariable("$RoombaSensorStreaming", false);

      OnLog?.Invoke(this, "Sensor stream stopped");
    }

    private void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e) {

      if (_isRunning)
        return;

      _isRunning = true;

      try {

        Execute(OpCode.QUERY_PACKET, 100);

        _buffer.AddRange(IO.ReadBytes(IO.BytesToRead));

        while (_buffer.Count >= 80 && _timer != null) {

          var data = _buffer.Take(80).ToArray();

          _buffer.RemoveRange(0, 80);

          var sensorData = new SensorData(data);

          ARC.Scripting.VariableManager.SetVariable("$RoombaAngle", sensorData.Angle);
          ARC.Scripting.VariableManager.SetVariable("$RoombaBatteryCapacity", sensorData.BatteryCapacity);
          ARC.Scripting.VariableManager.SetVariable("$RoombaBatteryCharge", sensorData.BatteryCharge);
          ARC.Scripting.VariableManager.SetVariable("$RoombaBumpLeft", sensorData.BumpLeft);
          ARC.Scripting.VariableManager.SetVariable("$RoombaBumpRight", sensorData.BumpRight);

          ARC.Scripting.VariableManager.SetVariable("$RoombaButtonClean", sensorData.ButtonClean);
          ARC.Scripting.VariableManager.SetVariable("$RoombaButtonClock", sensorData.ButtonClock);
          ARC.Scripting.VariableManager.SetVariable("$RoombaButtonDay", sensorData.ButtonDay);
          ARC.Scripting.VariableManager.SetVariable("$RoombaButtonDock", sensorData.ButtonDock);
          ARC.Scripting.VariableManager.SetVariable("$RoombaButtonHour", sensorData.ButtonHour);
          ARC.Scripting.VariableManager.SetVariable("$RoombaButtonMinute", sensorData.ButtonMinute);
          ARC.Scripting.VariableManager.SetVariable("$RoombaButtonSchedule", sensorData.ButtonSchedule);
          ARC.Scripting.VariableManager.SetVariable("$RoombaButtonSpot", sensorData.ButtonSpot);

          bool btnState = sensorData.ButtonState > 0;

          if (btnState && !_lastButtonState)
            OnButtonPressed?.Invoke(this, btnState);

          _lastButtonState = btnState;

          ARC.Scripting.VariableManager.SetVariable("$RoombaChargingSourceHomeBase", sensorData.ChargingSourceHomeBase);
          ARC.Scripting.VariableManager.SetVariable("$RoombaChargingSourceCharger", sensorData.ChargingSourceInternalCharger);
          ARC.Scripting.VariableManager.SetVariable("$RoombaChargingState", sensorData.ChargingState);
          ARC.Scripting.VariableManager.SetVariable("$RoombaCliffFrontLeft", sensorData.CliffFrontLeft);
          ARC.Scripting.VariableManager.SetVariable("$RoombaCliffFrontLeftSignal", sensorData.CliffFrontLeftSignal);
          ARC.Scripting.VariableManager.SetVariable("$RoombaCliffFrontRight", sensorData.CliffFrontRight);
          ARC.Scripting.VariableManager.SetVariable("$RoombaCliffFrontRightSignal", sensorData.CliffFrontRightSignal);
          ARC.Scripting.VariableManager.SetVariable("$RoombaCliffLeft", sensorData.CliffLeft);
          ARC.Scripting.VariableManager.SetVariable("$RoombaCliffLeftSignal", sensorData.CliffLeftSignal);
          ARC.Scripting.VariableManager.SetVariable("$RoombaCliffRight", sensorData.CliffRight);
          ARC.Scripting.VariableManager.SetVariable("$RoombaCliffRightSignal", sensorData.CliffRightSignal);
          ARC.Scripting.VariableManager.SetVariable("$RoombaCurrent", sensorData.Current);
          ARC.Scripting.VariableManager.SetVariable("$RoombaDirtDetect", sensorData.DirtDetect);
          ARC.Scripting.VariableManager.SetVariable("$RoombaDistance", sensorData.Distance);
          ARC.Scripting.VariableManager.SetVariable("$RoombaInfraredCharacterLeft", sensorData.InfraredCharacterLeft);
          ARC.Scripting.VariableManager.SetVariable("$RoombaInfraredCharacterOmni", sensorData.InfraredCharacterOmni);
          ARC.Scripting.VariableManager.SetVariable("$RoombaInfraredCharacterRight", sensorData.InfraredCharacterRight);
          ARC.Scripting.VariableManager.SetVariable("$RoombaLeftEncoderCounts", sensorData.LeftEncoderCounts);
          ARC.Scripting.VariableManager.SetVariable("$RoombaLeftMotorCurrent", sensorData.LeftMotorCurrent);
          ARC.Scripting.VariableManager.SetVariable("$RoombaLightBumperCenterLeft", sensorData.LightBumperCenterLeft);
          ARC.Scripting.VariableManager.SetVariable("$RoombaLightBumperCenterLeftSignal", sensorData.LightBumperCenterLeftSignal);
          ARC.Scripting.VariableManager.SetVariable("$RoombaLightBumperCenterRight", sensorData.LightBumperCenterRight);
          ARC.Scripting.VariableManager.SetVariable("$RoombaLightBumperCenterRightSignal", sensorData.LightBumperCenterRightSignal);
          ARC.Scripting.VariableManager.SetVariable("$RoombaLightBumperFrontLeft", sensorData.LightBumperFrontLeft);
          ARC.Scripting.VariableManager.SetVariable("$RoombaLightBumperFrontLeftSignal", sensorData.LightBumperFrontLeftSignal);
          ARC.Scripting.VariableManager.SetVariable("$RoombaLightBumperFrontRight", sensorData.LightBumperFrontRight);
          ARC.Scripting.VariableManager.SetVariable("$RoombaLightBumperFrontRightSignal", sensorData.LightBumperFrontRightSignal);
          ARC.Scripting.VariableManager.SetVariable("$RoombaLightBumperLeft", sensorData.LightBumperLeft);
          ARC.Scripting.VariableManager.SetVariable("$RoombaLightBumperLeftSignal", sensorData.LightBumperLeftSignal);
          ARC.Scripting.VariableManager.SetVariable("$RoombaLightBumperRight", sensorData.LightBumperRight);
          ARC.Scripting.VariableManager.SetVariable("$RoombaLightBumperRightSignal", sensorData.LightBumperRightSignal);
          ARC.Scripting.VariableManager.SetVariable("$RoombaMainBrushMotorCurrent", sensorData.MainBrushMotorCurrent);
          ARC.Scripting.VariableManager.SetVariable("$RoombaNumberOfStreamPackets", sensorData.NumberOfStreamPackets);
          ARC.Scripting.VariableManager.SetVariable("$RoombaOIMode", sensorData.OIMode);
          ARC.Scripting.VariableManager.SetVariable("$RoombaOverCurrentLeftWheel", sensorData.OverCurrentLeftWheel);
          ARC.Scripting.VariableManager.SetVariable("$RoombaOverCurrentMainBrush", sensorData.OverCurrentMainBrush);
          ARC.Scripting.VariableManager.SetVariable("$RoombaOverCurrentRightWheel", sensorData.OverCurrentRightWheel);
          ARC.Scripting.VariableManager.SetVariable("$RoombaOverCurrentSideBrush", sensorData.OverCurrentSideBrush);
          ARC.Scripting.VariableManager.SetVariable("$RoombaRequestedLeftVelocity", sensorData.RequestedLeftVelocity);
          ARC.Scripting.VariableManager.SetVariable("$RoombaRequestedRadius", sensorData.RequestedRadius);
          ARC.Scripting.VariableManager.SetVariable("$RoombaRequestedRightVelocity", sensorData.RequestedRightVelocity);
          ARC.Scripting.VariableManager.SetVariable("$RoombaRequestedVelocity", sensorData.RequestedVelocity);
          ARC.Scripting.VariableManager.SetVariable("$RoombaRightEncoderCounts", sensorData.RightEncoderCounts);
          ARC.Scripting.VariableManager.SetVariable("$RoombaRightMotorCurrent", sensorData.RightMotorCurrent);
          ARC.Scripting.VariableManager.SetVariable("$RoombaSideBrushMotorCurrent", sensorData.SideBrushMotorCurrent);
          ARC.Scripting.VariableManager.SetVariable("$RoombaSongNumber", sensorData.SongNumber);
          ARC.Scripting.VariableManager.SetVariable("$RoombaSongPlaying", sensorData.SongPlaying);
          ARC.Scripting.VariableManager.SetVariable("$RoombaStatis", sensorData.Statis);
          ARC.Scripting.VariableManager.SetVariable("$RoombaTemperature", sensorData.Temperature);
          ARC.Scripting.VariableManager.SetVariable("$RoombaVirtualWall", sensorData.VirtualWall);
          ARC.Scripting.VariableManager.SetVariable("$RoombaVoltage", Math.Round((decimal)sensorData.Voltage / 1000, 2));
          ARC.Scripting.VariableManager.SetVariable("$RoombaWall", sensorData.Wall);
          ARC.Scripting.VariableManager.SetVariable("$RoombaWallSignal", sensorData.WallSignal);
          ARC.Scripting.VariableManager.SetVariable("$RoombaWheelDropLeft", sensorData.WheelDropLeft);
          ARC.Scripting.VariableManager.SetVariable("$RoombaWheelDropRight", sensorData.WheelDropRight);

          //if (_sendNMS) {

          //  var distance = ((sensorData.RightEncoderCounts + sensorData.LeftEncoderCounts) / 2d) / 25.8d;

          //  ARC.MessagingService.Navigation2DV1.Messenger.UpdateLocation(
          //      (int)EZ_B.Functions.DegX2(distance, sensorData.Angle),
          //      (int)EZ_B.Functions.DegY2(distance, sensorData.Angle),
          //      255,
          //      (int)delta);
          //}

          _streamPacketCnt++;

          OnStreamPacketCnt?.Invoke(this, _streamPacketCnt);

          sensorData = null;
        }
      } catch (Exception ex) {

        OnError?.Invoke(this, ex);

        StopStreaming();
      } finally {

        _isRunning = false;
      }
    }

    public bool SetMode(OperatingMode byOpenInterfaceMode) {

      bool success = false;

      switch (byOpenInterfaceMode) {
        case OperatingMode.OFF:
          success = Execute(OpCode.POWER);
          break;

        case OperatingMode.PASSIVE:
          success = Execute(OpCode.START);
          break;

        case OperatingMode.SAFE:
          success = Execute(OpCode.SAFE_MODE);
          break;

        case OperatingMode.FULL:
          success = Execute(OpCode.FULL_MODE);
          break;
      }

      return success;
    }

    // There is more that needs to be done here.
    public void Song(byte songPosition, List<INote> notesToPlay) {

      List<byte> notes = new List<byte>();

      // Take this out. This is hardcoded only for testing!
      notes.Add(songPosition); // Roomba a new Song in Position 3
      notes.Add((byte)notes.Count);

      foreach (INote currentNote in notesToPlay) {

        notes.Add(currentNote.Number);
        notes.Add(currentNote.Duration);
      }

      Execute(OpCode.SONG, notes);
    }

    public bool DriveDirect(Velocity lSpeed, Velocity rSpeed) {

      int num = lSpeed.ToInt;
      byte byLeftHi = (byte)(num >> 8);
      byte byLeftLo = (byte)(num & 255);

      num = rSpeed.ToInt;
      byte byRightHi = (byte)(num >> 8);
      byte byRightLo = (byte)(num & 255);

      bool bSuccess;

      var send = new byte[] {
        (byte)OpCode.DRIVE_DIRECT,
        byRightHi,
        byRightLo,
        byLeftHi,
        byLeftLo
      };

      IO.Write(send);

      bSuccess = true;

      return bSuccess;
    }

    public bool SetLed(byte bSetting) {

      bool success = false;

      byte[] b = new byte[4];
      b[0] = (byte)OpCode.LEDS;
      b[1] = bSetting;
      b[2] = 0;
      b[3] = 0;

      IO.Write(b);

      success = true;

      return success;
    }

    public bool SetLeds(byte bLedBits, byte bPwrColor, byte bPwrIntensity) {

      bool success = false;
      List<byte> b = new List<byte>();

      b.Add((byte)OpCode.LEDS);
      b.Add(bLedBits);
      b.Add(bPwrColor);
      b.Add(bPwrIntensity);

      IO.Write(b.ToArray());

      success = true;

      return success;
    }

    /// <summary>
    /// Power off
    /// </summary>
    public void PowerOff() {

      Execute(OpCode.POWER);

      OnLog?.Invoke(this, "Powered off");
    }


    /// <summary>
    /// Tell the robot to reset itself and also powers down
    /// </summary>
    public void Reset() {

      Execute(OpCode.RESET);

      OnLog?.Invoke(this, "Reset & power off (verify beep)");
    }

    /// <summary>
    /// This command stops the OI. All streams will stop and the robot will no longer respond to commands.
    /// Use this command when you are finished working with the robot.
    /// Serial sequence: [173].
    /// Available in modes: Passive, Safe, or Full
    /// Changes mode to: Off. Roomba plays a song to acknowledge it is exiting the OI.
    /// Opcode: 173 Data Bytes: 0
    /// </summary>
    public void StopCommunication() {

      Execute(OpCode.STOP);
    }

    /// <summary>
    /// Sends any command that is not in this framework.
    /// </summary>
    public bool Execute(List<byte> sendBytes) {

      bool success = false;

      byte[] b = sendBytes.ToArray();

      IO.Write(b);

      success = true;

      return success;
    }

    public bool Execute(OpCode opCode, List<byte> sendBytes) {

      bool success = false;
      byte[] b = new byte[sendBytes.Count + 1];
      b[0] = (byte)opCode;

      IO.Write(b);

      success = true; //Command sent without error

      return success;
    }

    /// <summary>
    /// Sends a command to Roomba that requires a single OpCode and a single data byte.
    /// </summary>
    public bool Execute(OpCode opCode, byte sendByte) {

      bool success = false;
      byte[] b = new byte[2];
      b[0] = (byte)opCode;
      b[1] = sendByte;

      IO.Write(b);

      success = true; //Command sent without error

      return success;
    }

    /// <summary>
    /// Sends a command to Roomba that requires a single OpCode and no data bytes.
    /// </summary>
    public bool Execute(OpCode opCode) {

      bool success = false;
      byte[] b = new byte[1];
      b[0] = (byte)opCode;

      IO.Write(b);

      success = true;

      return success;
    }
  }
}
