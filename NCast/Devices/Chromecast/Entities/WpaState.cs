using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCast.Devices.Chromecast.Entities
{
    public enum WpaState
    {
        WPA_STATE_UNKNOWN,
        WPA_STATE_DISCONNECTED,
        WPA_STATE_INTERFACE_DISABLED,
        WPA_STATE_INACTIVE,
        WPA_STATE_SCANNING,
        WPA_STATE_AUTHENTICATING,
        WPA_STATE_ASSOCIATING,
        WPA_STATE_ASSOCIATED,
        WPA_STATE_4WAY_HANDSHAKE,
        WPA_STATE_GROUP_HANDSHAKE,
        WPA_STATE_COMPLETED,
    }

}
