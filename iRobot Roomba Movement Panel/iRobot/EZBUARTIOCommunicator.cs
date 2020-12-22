namespace Create2OI.Chassis {

  public class EZBUARTIOCommunicator : IOCommunicator {

    int _uartPortIndex;

    int _baudRate;

    public EZBUARTIOCommunicator(int uartPortIndex, int baudRate) {

      _uartPortIndex = uartPortIndex;
      _baudRate = baudRate;

      ARC.EZBManager.PrimaryEZB.Uart.UARTExpansionInit(_uartPortIndex, (uint)_baudRate);
    }

    public bool SupportsStreaming {
      get {
        return true;
      }
    }

    public int BytesToRead {
      get {
        return ARC.EZBManager.PrimaryEZB.Uart.UARTExpansionAvailableBytes(_uartPortIndex);
      }
    }

    public byte[] ReadBytes(int count) {

      return ARC.EZBManager.PrimaryEZB.Uart.UARTExpansionRead(_uartPortIndex, count);
    }

    public bool IsConnected {
      get {
        return ARC.EZBManager.PrimaryEZB.IsConnected;
      }
    }

    public void Write(byte[] bytes) {

      ARC.EZBManager.PrimaryEZB.Uart.UARTExpansionWrite(_uartPortIndex, bytes);
    }

    public void Dispose() {

    }
  }
}