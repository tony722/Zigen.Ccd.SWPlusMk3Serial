using System;
using Crestron.RAD.Common.BasicDriver;
using Crestron.RAD.Common.Enums;
using Crestron.RAD.Common.Transports;
using Crestron.RAD.DeviceTypes.AudioVideoSwitcher;
using Crestron.SimplSharp;

namespace AET.Zigen.Ccd.SWPlusMkIIISerial {
  public class ZigenSWPlusMkIIISerialProtocol : AAudioVideoSwitcherProtocol {

    public ZigenSWPlusMkIIISerialProtocol(ISerialTransport transport, byte id)
      : base(transport, id) {
    }

    protected override bool PrepareStringThenSend(CommandSet commandSet) {
      if (EnableLogging) base.Log("Zigen SWPlus TX$: '" + commandSet.Command + "'");
      commandSet.Command += "\n";
      return base.PrepareStringThenSend(commandSet);
    }

  }
}
