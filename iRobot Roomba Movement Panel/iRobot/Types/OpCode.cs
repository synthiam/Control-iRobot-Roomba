namespace Create2OI.Types {

  /// <summary>
  /// The following is a list of all of Roomba’s Open Interface commands. Each command starts with a
  /// onebyte opcode. Some of the commands must be followed by data bytes. All of Roomba’s OI commands
  /// including their required data bytes are described below.
  /// NOTE: Always send the required number of data bytes for the command, otherwise, the processor
  /// will enter and remain in a “waiting” state until all of the required data bytes are received.
  /// </summary>
  public enum OpCode {

    /// <summary>
    /// This command resets the robot, as if you had removed and reinserted the battery.
    /// Serial sequence: [7]
    /// Available in modes: Always available.
    /// Changes mode to: Off. You will have to send [128] again to re-enter Open Interface mode.
    /// OpCode = 7
    /// Data Bytes: 0
    /// </summary>
    RESET = 7,

    /// <summary>
    /// This command starts the OI. You must always send the Start command before sending any other
    /// commands to the OI.
    /// Serial sequence: [128]
    /// Available in modes: Passive, Safe, or Full
    /// Changes mode to: Passive. Roomba beeps once to acknowledge it is starting from “off” mode.
    /// OpCode = 128
    /// Data Bytes: 0
    /// </summary>
    START = 128,

    /// <summary>
    /// This command sets the baud rate in bits per second (bps) at which OI commands and data are sent
    /// according to the baud code sent in the data byte. The default baud rate at power up is 115200 bps, but
    /// the starting baud rate can be changed to 19200 by following the method outlined on page 4. Once the
    /// baud rate is changed, it persists until Roomba is power cycled by pressing the power button or removing
    /// the battery, or when the battery voltage falls below the minimum required for processor operation. You
    /// must wait 100ms after sending this command before sending additional commands at the new baud rate.
    /// Serial sequence: [129][Baud Code]
    /// Available in modes: Passive, Safe, or Full
    /// Changes mode to: No Change
    /// Data Bytes: 1 Baud Code(0 - 11)
    /// OpCode = 129
    /// </summary>
    BAUD = 129,

    /// <summary>
    /// The effect and usage of the Control command (130) are identical to the Safe command (131).
    /// Data Bytes: 0
    /// OpCode = 130
    /// </summary>
    ENABLE_USER_CONTROL = 130,

    /// <summary>
    /// This command puts the OI into Safe mode, enabling user control of Roomba. It turns off all LEDs. The OI
    /// can be in Passive, Safe, or Full mode to accept this command. If a safety condition occurs (see above)
    /// Roomba reverts automatically to Passive mode.
    /// Serial sequence: [131]
    /// Available in modes: Passive, Safe, or Full
    /// Changes mode to: Safe
    /// Data Bytes: 0
    /// OpCode = 131
    /// </summary>
    SAFE_MODE = 131,

    /// <summary>
    /// This command gives you complete control over Roomba by putting the OI into Full mode, and turning off
    /// the cliff, wheel-drop and internal charger safety features. That is, in Full mode, Roomba executes any
    /// command that you send it, even if the internal charger is plugged in, or command triggers a cliff or wheel
    /// drop condition.
    /// Serial sequence: [132]
    /// Available in modes: Passive, Safe, or Full
    /// Changes mode to: Full
    /// Data Bytes: 0
    /// OpCode = 132
    /// </summary>
    FULL_MODE = 132,

    /// <summary>
    /// This command powers down Roomba. The OI can be in Passive, Safe, or Full mode to accept this
    /// command.
    /// Serial sequence: [133]
    /// Available in modes: Passive, Safe, or Full
    /// Changes mode to: Passive
    /// Data Bytes: 0
    /// OpCode = 133
    /// </summary>
    POWER = 133,

    /// <summary>
    /// This command starts the Spot cleaning mode. This is the same as pressing Roomba’s Spot button,
    /// and will pause a cleaning cycle if one is already in progress.
    /// Available in modes: Passive, Safe, or Full
    /// Changes mode to: Passive
    /// Data Bytes: 0
    /// OpCode = 134
    /// </summary>
    SPOT = 134,

    /// <summary>
    /// This command starts the default cleaning mode. This is the same as pressing Roomba’s Clean button,
    /// and will pause a cleaning cycle if one is already in progress.
    /// Available in modes: Passive, Safe, or Full
    /// Changes mode to: Passive
    /// OpCode = 135
    /// </summary>
    CLEAN = 135,

    /// <summary>
    /// This command starts the Max cleaning mode, which will clean until the battery is dead. This command
    /// will pause a cleaning cycle if one is already in progress.
    /// Available in modes: Passive, Safe, or Full
    /// Changes mode to: Passive
    /// OpCode = 136
    /// </summary>
    MAX_CLEAN = 136,

    /// <summary>
    /// Controls Roomba's drive wheels. This command takes 4 data bytes.
    /// These data bytes are interpreted as two 16 bit values using twos-compliment.
    /// The first two bytes specify the average velocity of the drive wheels in millimeters per second (mm/s).
    /// The next 2 bytes specify the radius, in millimeters, in which Roomba should turn.
    /// The longer radii make Roomba drive straighter, shorter radii make Roomba turn more.
    /// A drive command with a positive velocity and a positive radius will make Roomba drive forward
    /// while turning toward the left.  A negative radius will make Roomba turn toward the right.
    /// Special cases for the radius make Roomba turn in place or drive straight.
    /// 
    /// Note: The robot system and its environment impose restrictions that may prevent the robot 
    /// from accurately carrying out some drive commands. For example, it may not be possible to drive
    /// in a large arc with a large radius of curvature.
    /// 
    /// Data Bytes: 4
    /// Data Bytes 1 and 2: Velocity (-500 - 500 mm/s)
    /// Data Bytes 3 and 4: Radius (-2000 - 2000 mm)
    /// Special cases:
    ///	Straight = 32768 or 32767 = 0x8000 or 0x7FFF
    ///	Turn in place clockwise = -1 = 0xFFFF
    ///	Turn in place counter-clockwise = 1 = 0x0001
    /// 
    /// C# usage example:
    /// To drive in reverse at a velocity of -200mm/s while turning at a radius of 500mm:
    /// myCreateObj.Drive(-200, 500),
    /// 
    /// This command does not change Roomba's mode
    /// Roomba must be in safe or full mode to accept this command
    /// OpCode = 137
    /// </summary>
    DRIVE = 137,

    /// <summary>
    /// This command lets you control the forward and backward motion of Roomba’s main brush, side brush,
    /// and vacuum independently. Motor velocity cannot be controlled with this command, all motors will run at
    /// maximum speed when enabled. The main brush and side brush can be run in either direction. The
    /// vacuum only runs forward.
    /// Serial sequence: [138] [Motors]
    ///	Available in modes: Safe or Full
    ///	Changes mode to: No Change
    ///	Bits 0-2: 0 = off, 1 = on at 100% pwm duty cycle
    ///	Bits 3 & 4: 0 = motor’s default direction, 1 = motor’s opposite direction. Default direction for the side
    /// brush is counterclockwise. Default direction for the main brush/flapper is inward.
    /// Bit		7 6 5			4							3							2				1			0
    /// Value	Reserved		MainBrushDirection	SideBrushClockwise?	MainBrush	Vacuum	SideBrush
    /// Example:
    /// To turn on the main brush inward and the side brush clockwise, send: [138] [13]
    /// </summary>
    MOTORS = 138,

    /// <summary>
    /// Controls Roomba's LEDs.  This Opcode is used in conjunction with Creates_2 LED class
    /// This command does not change Roomba's mode
    /// Roomba must be in safe or full mode to accept this command
    /// OpCode = 139
    /// </summary>
    LEDS = 139,

    /// <summary>
    /// This command lets you specify up to four songs to the OI that you can play at a later time. Each song is
    /// associated with a song number. The Play command uses the song number to identify your song selection.
    /// Each song can contain up to sixteen notes. Each note is associated with a note number that uses MIDI
    /// note definitions and a duration that is specified in fractions of a second. The number of data bytes varies,
    /// depending on the length of the song specified. A one note song is specified by four data bytes. For each
    /// additional note within a song, add two data bytes.
    /// Serial sequence: [140] [Song Number] [Song Length] [Note Number 1] [Note Duration 1] [Note Number 2] [Note Duration 2], etc.
    /// Available in modes: Passive, Safe, or Full
    /// Changes mode to: No Change
    /// Song Number (0 – 4)
    /// The song number associated with the specific song. If you send a second Song command, using the
    /// same song number, the old song is overwritten.
    /// Song Length (1 – 16)
    /// The length of the song, according to the number of musical notes within the song.
    /// Song data bytes 3, 5, 7, etc.: Note Number (31 – 127)
    /// The pitch of the musical note Roomba will play, according to the MIDI note numbering scheme. The
    /// lowest musical note that Roomba will play is Note #31. Roomba considers all musical notes outside
    /// the range of 31 – 127 as rest notes, and will make no sound during the duration of those notes.
    /// Song data bytes 4, 6, 8, etc.: Note Duration (0 – 255)
    /// The duration of a musical note, in increments of 1/64th of a second. Example: a half-second long
    /// musical note has a duration value of 32.
    /// OpCode = 140
    /// Data Bytes: 2N+2,where N is the number of notes in the song.
    /// </summary>
    SONG = 140,

    /// <summary>
    /// This command lets you select a song to play from the songs added to Roomba using the Song command.
    /// You must add one or more songs to Roomba using the Song command in order for the Play command to
    /// work.
    /// Serial sequence: [141] [Song Number]
    /// Available in modes: Safe or Full
    /// Changes mode to: No Change
    /// Song Number (0 – 4)
    /// The number of the song Roomba is to play.
    /// Opcode: 141 
    /// Data Bytes: 1
    /// </summary>
    PLAY = 141,

    /// <summary>
    /// This command requests the OI to send a packet of sensor data bytes. 
    /// There are 58 different sensor data packets:
    ///	Group Packet ID	Packet Size	 Contains Packets
    ///				0				      26				  7 - 26
    ///				1				      10				  7 - 16
    ///				2				      6	   			 17 - 20
    ///				3			      	10				 21 - 26
		///				4				      14				 27 - 34
    ///				5				      12				 35 - 42
    ///				6				      52				  7 - 42
    ///			 100				    80				  7 - 58 <-- ALL SENSOR DATA
    ///			 101				    28				 43 - 58
    ///			 106				    12				 46 - 51
    ///			 107				    9			     54 - 58
    /// This Command is used in conjunction with the Sensors class
    /// This command does not change Roomba's mode
    /// Roomba must be in passive, safe or full mode to accept this command.
    /// Serial sequence: [142] [Packet ID]
    /// OpCode = 142
    /// </summary>
    QUERY_PACKET = 142,

    /// <summary>
    /// Turns on Roomba's force-seeking dock mode, which causes the robot to immediately attempt to dock
    /// during its cleaning cycle. If it encounters the docking beams from its home base. (note, however, that
    /// if the robot was not active in a clean, spot, or max cycle it will not attempt to execute the docking.)
    /// Normally, the robot attempts to dock only if the cleaning cycle has completed or the battery
    /// is nearing depletion. The command cam be sent anytime, but the mode will be cancelled if the robot turns 
    /// off, begins charging, or is commanded to safe or full mode.
    /// OpCode = 143
    /// </summary>
    FORCE_SEEKING_DOCK = 143,

    /// <summary>
    /// This command lets you control the speed of Roomba’s main brush, side brush, and vacuum independently.
    /// With each data byte, you specify the duty cycle for the low side driver (max 128). For example,
    /// if you want to control a motor with 25% of battery voltage, choose a duty cycle of 128 * 25% = 32.
    /// The main brush and side brush can be run in either direction. The vacuum only runs forward.
    /// Positive speeds turn the motor in its default (cleaning) direction. Default direction for the side brush
    /// is counterclockwise. Default direction for the main brush/flapper is inward.
    /// Serial sequence: [144] [Main Brush PWM] [Side Brush PWM] [Vacuum PWM]
    /// Available in modes: Safe or Full
    /// Changes mode to: No Change
    /// Main Brush and Side Brush duty cycle (-127 – 127)
    /// Vacuum duty cycle (0 – 127)
    /// Data Bytes: 3
    /// OpCode = 144
    /// </summary>
    PWM_MOTORS = 144,

    /// <summary>
    /// This command lets you control the forward and backward motion of Roomba’s drive wheels independently.
    /// It takes four data bytes, which are interpreted as two 16-bit signed values using two’s complement. 
    /// The first two bytes specify the velocity of the right wheel in millimeters per second (mm/s), with
    /// the high byte sent frst. The next two bytes specify the velocity of the left wheel, in the same format.
    /// A positive velocity makes that wheel drive forward, while a negative velocity makes it drive backward.
    /// OpCode = 145
    /// </summary>
    DRIVE_DIRECT = 145,

    /// <summary>
    /// This command lets you control the raw forward and backward motion of Roomba’s drive wheels
    /// independently. It takes four data bytes, which are interpreted as two 16-bit signed values using two’s
    /// complement. The first two bytes specify the PWM of the right wheel, with the high byte sent first. The
    /// next two bytes specify the PWM of the left wheel, in the same format. A positive PWM makes that wheel
    /// drive forward, while a negative PWM makes it drive backward.
    /// Serial sequence: [146] [Right PWM high byte] [Right PWM low byte] [Left PWM high byte] [Left PWM
    /// low byte]
    /// Available in modes: Safe or Full
    /// Changes mode to: No Change
    /// Right wheel PWM (-255 – 255)
    /// Left wheel PWM (-255 – 255)
    /// Data Bytes: 4
    /// OpCode = 146
    /// </summary>
    DRIVE_PWM = 146,

    /// <summary>
    /// This command starts a continuous stream of data packets.  The list of packets requested is sent every 15 ms, which is 
    /// the rate iRobot Roomba uses to update data. This is the best method of requesting sensor data if you 
    /// are controlling Roomba over a wireless network (which has poor real-time characteristics) with software running on a desktop computer)
    /// </summary>
    STREAM = 148,

    /// <summary>
    /// This command lets you ask for a list of sensor packets. The result is returned once, as in the Sensors
    /// command. The robot returns the packets in the order you specify.
    /// Serial sequence: [149][Number of Packets][Packet ID 1][Packet ID 2]...[Packet ID N]
    /// Available in modes: Passive, Safe, or Full
    /// Changes modes to: No Change
    /// Example: To get the state of the bumpers and the virtual wall sensor, send the following sequence: [149] [2] [7] [13]
    /// Data Bytes: N + 1 (where N is the number of packets requested.)
    /// Opcode: 149
    /// </summary>
    QUERY_LIST = 149,

    /// <summary>
    /// This command lets you stop and restart the steam without clearing the list of requested packets.
    /// </summary>
    PAUSE_RESUME_STREAM = 150,

    /// <summary>
    /// This command controls the state of the scheduling LEDs present on the Roomba 560 and 570.
    /// Serial sequence: [162] [Weekday LED Bits][Scheduling LED Bits]
    /// Available in modes: Safe or Full
    /// Changes mode to: No Change
    /// Weekday LED Bits (0 – 255)
    /// Scheduling LED Bits (0 – 255)
    /// All use red LEDs: 0 = off, 1 = on
    /// Weekday LED Bits
    ///	Bit	   7			6	 5	  4	  3	  2	  1	  0
    ///	Value	Reserved  Sat  Fri	Thu	Wed	Tue	Mon	Sun
    /// Scheduling LED Bits
    ///	Bit		7  6	5 4		  3	  2  1  0
    ///	Value	Reserved Schedule Clock AM PM Colon (:)
    /// Opcode: 162 Data Bytes: 2
    /// </summary>
    SCHEDULING_LEDS = 162,

    /// <summary>
    /// Opcode: 163 Data Bytes: 4
    /// This command controls the four 7 segment	displays on the Roomba.
    /// Serial sequence: [163] [Digit 3 Bits] [Digit 2
    /// Bits] [Digit 1 Bits] [Digit 0 Bits]
    /// Available in modes: Safe or Full
    /// Changes mode to: No Change
    /// Digit N Bits (0 – 255)
    /// All use red LEDs: 0 = off, 1 = on. Digits are
    /// ordered from left to right on the robot 3,2,1,0.
    /// Digit N Bits
    ///	Bit	7		  6 5 4 3 2 1 0
    ///	Value Reserved G F E D C B A
    /// </summary>
    DIGIT_LEDS_RAW = 163,

    /// <summary>
    /// Opcode: 164 Data Bytes: 4
    /// This command controls the four 7 segment displays on the Roomba 560 and 570 using ASCII character
    /// codes. Because a 7 segment display is not sufficient to display alphabetic characters properly, all
    /// characters are an approximation, and not all ASCII codes are implemented.
    /// Serial sequence: [164] [Digit 3 ASCII] [Digit 2 ASCII] [Digit 1 ASCII] [Digit 0 ASCII]
    /// Available in modes: Safe or Full
    /// Changes mode to: No Change
    /// Digit N ASCII (32 – 126)
    /// All use red LEDs. Digits are ordered from left to right on the robot 3,2,1,0.
    /// Example:
    /// To write ABCD to the display, send the serial byte sequence: [164] [65] [66] [67] [68]
    /// See spec gor a table of ASCII codes.
    /// </summary>
    DIGIT_LEDS_ASCII = 164,

    /// <summary>
    /// This command lets you push Roomba’s buttons. The buttons will automatically release after 1/6th of a
    /// second.
    /// Serial sequence: [165] [Buttons]
    /// Available in modes: Passive, Safe, or Full
    /// Changes mode to: No Change
    /// Buttons (0-255) 1 = Push Button, 0 = Release Button
    /// Buttons
    /// Bit	7	  6		  5	 4	 3		2	  1	  0
    /// Value Clock Schedule Day  Hour Minute Dock  Spot  Clean
    /// Opcode: 165 Data Bytes: 1
    /// </summary>
    BUTTONS = 165,

    /// <summary>
    /// This command sends Roomba a new schedule. To disable scheduled cleaning, send all 0s.
    /// Serial sequence: [167] [Days] [Sun Hour] [Sun Minute] [Mon Hour] [Mon Minute] [Tue Hour] [Tue
    /// Minute] [Wed Hour] [Wed Minute] [Thu Hour] [Thu Minute] [Fri Hour] [Fri Minute] [Sat Hour] [Sat
    /// Minute]
    /// Available in modes: Passive, Safe, or Full.
    /// If Roomba’s schedule or clock button is pressed, this command will be ignored.
    /// Changes mode to: No change
    /// Times are sent in 24 hour format. Hour (0-23) Minute (0-59) Days
    /// Bit 7 6 5 4 3 2 1 0
    /// Value Reserved Sat Fri Thu Wed Tue Mon Sun
    /// Example:
    /// To schedule the robot to clean at 3:00 PM on Wednesdays and 10:36 AM on Fridays, send: [167] [40] [0]
    /// [0] [0] [0] [0] [0] [15] [0] [0] [0] [10] [36] [0] [0]
    /// To disable scheduled cleaning, send: [167] [0] [0] [0] [0] [0] [0] [0] [0] [0] [0] [0] [0] [0] [0] [0]
    /// Opcode: 167 Data Bytes: 15
    /// </summary>
    SCHEDULE = 167,

    /// <summary>
    /// This command sets Roomba’s clock.
    /// Serial sequence: [168] [Day] [Hour] [Minute]
    /// Available in modes: Passive, Safe, or Full.
    /// If Roomba’s schedule or clock button is pressed, this command will be ignored.
    /// Changes mode to: No change
    /// Time is sent in 24 hour format. Hour (0-23) Minute (0-59)
    ///	Code  Day
    ///	0	  Sunday
    ///	1	  Monday
    ///	2	  Tuesday
    ///	3	  Wednesday
    ///	4	  Thursday
    ///	5	  Friday
    ///	6	  Saturday
    /// Opcode: 168 Data Bytes: 3
    /// </summary>
    SET_DAY_TIME = 168,

    /// <summary>
    /// This command stops the OI. All streams will stop and the robot will no longer respond to commands.
    /// Use this command when you are finished working with the robot.
    /// Serial sequence: [173].
    /// Available in modes: Passive, Safe, or Full
    /// Changes mode to: Off. Roomba plays a song to acknowledge it is exiting the OI.
    /// Opcode: 173 Data Bytes: 0
    /// </summary>
    STOP = 173
  }
}
