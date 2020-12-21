using System;

namespace Create2OI.Chassis {

  public interface IOCommunicator : IDisposable {

    bool SupportsStreaming {
      get;
    }

    bool IsConnected {
      get;
    }

    void Write(byte[] bytes);

    byte[] ReadBytes(int count);

    int BytesToRead {
      get;
    }
  }
}
