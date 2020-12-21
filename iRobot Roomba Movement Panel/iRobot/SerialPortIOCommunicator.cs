using System;
using System.IO.Ports;

namespace Create2OI.Chassis {

  public class SerialPortIOCommunicator : IOCommunicator {

    private SerialPort _serialPort;

    public SerialPortIOCommunicator(string portName, int baudRate) {

      var serialPort = new SerialPort {
        PortName = portName,
        BaudRate = baudRate,  //Pretty much the only supported baud rate, page 5 of "Documents/Create Open Interface.pdf"
        DataBits = 8,
        DtrEnable = false,
        StopBits = StopBits.One,
        Handshake = Handshake.None,
        Parity = Parity.None,
        RtsEnable = false
      };

      Init(serialPort);
    }

    public bool SupportsStreaming {
      get {
        return true;
      }
    }

    private void Init(SerialPort serialPort) {

      _serialPort = serialPort;
      _serialPort.Open();
    }

    public bool IsConnected {
      get {
        return _serialPort.IsOpen;
      }
    }

    public byte[] ReadBytes(int count) {

      byte [] buf = new byte[count];

      _serialPort.Read(buf, 0, count);

      return buf;
    }

    public void Write(byte[] bytes) {

      _serialPort.Write(bytes, 0, bytes.Length);
    }

    public int BytesToRead {
      get {
        return _serialPort.BytesToRead;
      }
    }

    public void Dispose() {

      if (_serialPort == null)
        return;

      if (_serialPort.IsOpen)
        _serialPort.Close();

      _serialPort.Dispose();
    }
  }
}