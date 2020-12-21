using System;

namespace Create2OI.Chassis {

  public class EZBUARTIOCommunicator : IOCommunicator {

    int _uartPortIndex;

    int _baudRate;

    public EZBUARTIOCommunicator(int uartPortIndex, int baudRate) {

      _uartPortIndex = uartPortIndex;
      _baudRate = baudRate;

      ARC.EZBManager.PrimaryEZB.OnConnectionChange2 += PrimaryEZB_OnConnectionChange2;

      if (ARC.EZBManager.PrimaryEZB.IsConnected)
        init();
    }

    public bool SupportsStreaming {
      get {
        return true;
      }
    }

    void init() {

      try {

        ARC.EZBManager.PrimaryEZB.Uart.UARTExpansionInit(_uartPortIndex, (uint)_baudRate);
      } catch {

        throw;
      }
    }

    private void PrimaryEZB_OnConnectionChange2(EZ_B.EZB sender, bool isConnected) {

      try {

        if (isConnected)
          init();
      } catch {

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

      ARC.EZBManager.PrimaryEZB.OnConnectionChange2 -= PrimaryEZB_OnConnectionChange2;
    }
  }
}