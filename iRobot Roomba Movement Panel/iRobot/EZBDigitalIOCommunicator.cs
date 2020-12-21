namespace Create2OI.Chassis {

  public class EZBDigitalIOCommunicator : IOCommunicator {

    EZ_B.Digital.DigitalPortEnum _port;
    EZ_B.Uart.BAUD_RATE_ENUM _baudRate;

    public EZBDigitalIOCommunicator(EZ_B.Digital.DigitalPortEnum digitalPort, EZ_B.Uart.BAUD_RATE_ENUM baudRate) {

      _port = digitalPort;
      _baudRate = baudRate;
    }

    public bool SupportsStreaming {
      get {
        return false;
      }
    }

    public int BytesToRead {
      get {
        return 0;
      }
    }

    public byte[] ReadBytes(int count) {

      return new byte[] { };
    }

    public bool IsConnected {
      get {
        return ARC.EZBManager.PrimaryEZB.IsConnected;
      }
    }

    public int ReadByte() {

      return -1;
    }

    public void Write(byte[] bytes) {

      ARC.EZBManager.PrimaryEZB.Uart.SendSerial(_port, _baudRate, bytes);
    }

    public void Dispose() {

    }
  }
}