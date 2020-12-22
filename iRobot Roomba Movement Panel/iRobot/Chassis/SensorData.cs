using System;

namespace Create2OI.Chassis {

  internal class SensorData {

    byte [] _data;
    int pos;

    public SensorData(byte[] data) {

      if (data.Length != 80)
        throw new Exception("Missing data. Expecting 80 bytes");

      _data = data;
      pos = 0;

      byte tmpByte;

      // 7
      tmpByte = getByte();
      WheelDropLeft = EZ_B.Functions.IsBitSet(tmpByte, 3);
      WheelDropRight = EZ_B.Functions.IsBitSet(tmpByte, 2);
      BumpLeft = EZ_B.Functions.IsBitSet(tmpByte, 1);
      BumpRight = EZ_B.Functions.IsBitSet(tmpByte, 0);

      // 8
      Wall = getBool();

      // 9
      CliffLeft = getBool();

      // 10
      CliffFrontLeft = getBool();

      // 11
      CliffFrontRight = getBool();

      // 12
      CliffRight = getBool();

      // 13
      VirtualWall = getBool();

      // 14
      tmpByte = getByte();
      OverCurrentLeftWheel = EZ_B.Functions.IsBitSet(tmpByte, 4);
      OverCurrentRightWheel = EZ_B.Functions.IsBitSet(tmpByte, 3);
      OverCurrentMainBrush = EZ_B.Functions.IsBitSet(tmpByte, 2);
      OverCurrentSideBrush = EZ_B.Functions.IsBitSet(tmpByte, 0);

      // 15
      DirtDetect = getByte();

      // 16 (1 byte)
      pos++;

      // 17
      InfraredCharacterOmni = getByte();

      // 18
      tmpByte = getByte();
      ButtonState = tmpByte;
      ButtonClock = EZ_B.Functions.IsBitSet(tmpByte, 7);
      ButtonSchedule = EZ_B.Functions.IsBitSet(tmpByte, 6);
      ButtonDay = EZ_B.Functions.IsBitSet(tmpByte, 5);
      ButtonHour = EZ_B.Functions.IsBitSet(tmpByte, 4);
      ButtonMinute = EZ_B.Functions.IsBitSet(tmpByte, 3);
      ButtonDock = EZ_B.Functions.IsBitSet(tmpByte, 2);
      ButtonSpot = EZ_B.Functions.IsBitSet(tmpByte, 1);
      ButtonClean = EZ_B.Functions.IsBitSet(tmpByte, 0);

      // 19
      Distance = getInt16();

      // 20
      Angle = getInt16();

      // 21
      ChargingState = getByte();

      // 22
      Voltage = getUInt16();

      // 23
      Current = getInt16();

      // 24
      Temperature = getSByte();

      // 25
      BatteryCharge = getUInt16();

      // 26
      BatteryCapacity = getUInt16();

      // 27
      WallSignal = getUInt16();

      // 28
      CliffLeftSignal = getUInt16();

      // 29
      CliffFrontLeftSignal = getUInt16();

      // 30
      CliffFrontRightSignal = getUInt16();

      // 31
      CliffRightSignal = getUInt16();

      // 32 (1 byte)
      // 33 (2 bytes)
      pos += 3;

      // 34
      tmpByte = getByte();
      ChargingSourceHomeBase = EZ_B.Functions.IsBitSet(tmpByte, 1);
      ChargingSourceInternalCharger = EZ_B.Functions.IsBitSet(tmpByte, 0);

      // 35
      OIMode = getByte();

      // 36
      SongNumber = getByte();

      // 37
      SongPlaying = getByte();

      // 38
      NumberOfStreamPackets = getByte();

      // 39
      RequestedVelocity = getInt16();

      // 40
      RequestedRadius = getInt16();

      // 41
      RequestedRightVelocity = getInt16();

      // 42
      RequestedLeftVelocity = getInt16();

      // 43
      RightEncoderCounts = getUInt16();

      // 44
      LeftEncoderCounts = getUInt16();

      // 45
      tmpByte = getByte();
      LightBumperRight = EZ_B.Functions.IsBitSet(tmpByte, 5);
      LightBumperFrontRight = EZ_B.Functions.IsBitSet(tmpByte, 4);
      LightBumperCenterRight = EZ_B.Functions.IsBitSet(tmpByte, 3);
      LightBumperCenterLeft = EZ_B.Functions.IsBitSet(tmpByte, 2);
      LightBumperFrontLeft = EZ_B.Functions.IsBitSet(tmpByte, 1);
      LightBumperLeft = EZ_B.Functions.IsBitSet(tmpByte, 0);

      // 46
      LightBumperLeftSignal = getUInt16();

      // 47
      LightBumperFrontLeftSignal = getUInt16();

      // 48
      LightBumperCenterLeftSignal = getUInt16();

      // 49
      LightBumperCenterRightSignal = getUInt16();

      // 50
      LightBumperFrontRightSignal = getUInt16();

      // 51
      LightBumperRightSignal = getUInt16();

      // 52
      InfraredCharacterLeft = getByte();

      // 53
      InfraredCharacterRight = getByte();

      // 54
      LeftMotorCurrent = getInt16();

      // 55
      RightMotorCurrent = getInt16();

      // 56
      MainBrushMotorCurrent = getInt16();

      // 57
      SideBrushMotorCurrent = getInt16();

      // 58
      Statis = getBool();
    }

    bool getBool() {

      var v = _data[pos] == 1;

      pos++;

      return v;
    }

    sbyte getSByte() {

      var v = Convert.ToSByte(127 - _data[pos]);

      pos++;

      return v;
    }

    byte getByte() {

      var v = _data[pos];

      pos++;

      return v;
    }

    ushort getUInt16() {

      var b1 = _data[pos];

      pos++;

      var b2 = _data[pos];

      pos++;

      return (ushort)(b2 + (b1 << 8));
    }

    short getInt16() {

      var b1 = _data[pos];

      pos++;

      var b2 = _data[pos];

      pos++;

      return (short)(b2 + (b1 << 8));
    }

    public bool WheelDropLeft;
    public bool WheelDropRight;
    public bool BumpLeft;
    public bool BumpRight;

    public bool Wall;

    public bool CliffLeft;
    public bool CliffFrontLeft;

    public bool CliffRight;
    public bool CliffFrontRight;

    public bool VirtualWall;

    public bool OverCurrentLeftWheel;
    public bool OverCurrentRightWheel;
    public bool OverCurrentMainBrush;
    public bool OverCurrentSideBrush;

    public byte DirtDetect;

    public byte InfraredCharacterOmni;

    public byte InfraredCharacterLeft;
    public byte InfraredCharacterRight;

    public bool ButtonClock;
    public bool ButtonSchedule;
    public bool ButtonDay;
    public bool ButtonHour;
    public bool ButtonMinute;
    public bool ButtonDock;
    public bool ButtonSpot;
    public bool ButtonClean;
    public byte ButtonState;

    public Int16 Distance;

    public Int16 Angle;

    public byte ChargingState;

    public UInt16 Voltage;

    public Int16 Current;

    public sbyte Temperature;

    public UInt16 BatteryCharge;

    public UInt16 BatteryCapacity;

    public UInt16 WallSignal;

    public UInt16 CliffLeftSignal;

    public UInt16 CliffFrontLeftSignal;

    public UInt16 CliffFrontRightSignal;

    public UInt16 CliffRightSignal;

    public bool ChargingSourceHomeBase;
    public bool ChargingSourceInternalCharger;

    public byte OIMode;

    public byte SongNumber;

    public byte SongPlaying;

    public byte NumberOfStreamPackets;

    public Int16 RequestedVelocity;

    public Int16 RequestedRadius;

    public Int16 RequestedRightVelocity;
    public Int16 RequestedLeftVelocity;

    public UInt16 RightEncoderCounts;
    public UInt16 LeftEncoderCounts;

    public bool LightBumperRight;
    public bool LightBumperFrontRight;
    public bool LightBumperCenterRight;
    public bool LightBumperCenterLeft;
    public bool LightBumperFrontLeft;
    public bool LightBumperLeft;

    public UInt16 LightBumperLeftSignal;
    public UInt16 LightBumperFrontLeftSignal;
    public UInt16 LightBumperCenterLeftSignal;
    public UInt16 LightBumperCenterRightSignal;
    public UInt16 LightBumperFrontRightSignal;
    public UInt16 LightBumperRightSignal;

    public Int16 LeftMotorCurrent;
    public Int16 RightMotorCurrent;

    public Int16 MainBrushMotorCurrent;

    public Int16 SideBrushMotorCurrent;

    public bool Statis;
  }
}
