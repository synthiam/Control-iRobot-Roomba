namespace iRobot_Roomba_Movement_Panel.Config {

  internal class ConfigTitles {

    public enum PortTypeEnum {
      HW_UART,
      Software_Serial,
      PC_COM
    }

    /// <summary>
    /// Script runs when a button is pressed
    /// </summary>
    public readonly static string SCRIPT_BUTTON_PRESSED = "script to run when button pressed";

    /// <summary>
    /// The baud rate from ez_b.uart.baudrates thats used for the serial output
    /// </summary>
    public readonly static string BAUD_RATE_SERIAL = "baud rate serial";

    /// <summary>
    /// INT milliseconds how fast to poll the sensor data
    /// </summary>
    public readonly static string SENSOR_POLL_TIME_MS = "sensor poll time ms";

    /// <summary>
    /// The baud rate for the uart ports. integer
    /// </summary>
    public readonly static string BAUD_RATE_UART = "baud rate for uart";

    /// <summary>
    /// The baud rate for the pc com ports. integer
    /// </summary>
    public readonly static string BAUD_RATE_PC = "baud rate for pc";

    /// <summary>
    /// The PortTypeEnum
    /// </summary>
    public readonly static string CONNECTION_TYPE = "Connection Type";

    /// <summary>
    /// The STRING for the com port name (i.e. com1)
    /// </summary>
    public readonly static string PC_COM_PORT = "pc com port";

    /// <summary>
    /// The INT index for the uart port on the ezb 
    /// </summary>
    public readonly static string EZB_UART_PORT = "ezb uart port";

    /// <summary>
    /// The EZ_B.Digital.DigitalPortEnum of the Serial digital port output pin
    /// </summary>
    public readonly static string EZB_SERIAL_PORT = "ezb serial port";

    /// <summary>
    /// Send the distance and degrees to the NMS
    /// </summary>
    public readonly static string NMS_POSITION_DATA = "Send NMS position data";
  }
}
