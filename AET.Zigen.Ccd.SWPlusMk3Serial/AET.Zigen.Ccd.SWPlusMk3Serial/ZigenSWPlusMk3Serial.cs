using System;
using Crestron.RAD.Common.Interfaces;
using Crestron.RAD.Common.Transports;
using Crestron.RAD.DeviceTypes.AudioVideoSwitcher;
using Crestron.RAD.ProTransports;

namespace AET.Zigen.Ccd.SWPlusMk3Serial {
  public class ZigenSWPlusMkIIISerial : AAudioVideoSwitcher, ISerialComport, ISimpl {

    private void Initialize() {
      ConnectionTransport.EnableLogging = InternalEnableLogging;
      ConnectionTransport.EnableTxDebug = InternalEnableTxDebug;
      ConnectionTransport.EnableRxDebug = InternalEnableRxDebug;
      ConnectionTransport.CustomLogger = InternalCustomLogger;

      AudioVideoSwitcherProtocol = new ZigenSWPlusMkIIISerialProtocol(ConnectionTransport, Id) {
        EnableLogging = InternalEnableLogging,
        CustomLogger = InternalCustomLogger
      };
      AudioVideoSwitcherProtocol.RxOut += SendRxOut;
      AudioVideoSwitcherProtocol.Initialize(AudioVideoSwitcherData);

      Connected = true;
    }

    public void Initialize(IComPort comPort) {
      ConnectionTransport = new CommonSerialComport(comPort);
      Initialize();
      Connected = true;
    }

    public SimplTransport Initialize(Action<string, object[]> send) {
      ConnectionTransport = new SimplTransport();
      Initialize();
      ConnectionTransport.Send = send;
      return (SimplTransport)ConnectionTransport;
    }

  }
}