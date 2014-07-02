using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCast.Devices
{
    public class DialConstants
    {
        public const string DialMultiScreenUrn = "urn:dial-multiscreen-org:service:dial:1";
        public const string GenericMulticastAddress = "239.255.255.250";
        public const string DialConnectionUrn = "urn:x-cast:com.google.cast.tp.connection";
        public const string DialHeartbeatUrn = "urn:x-cast:com.google.cast.tp.heartbeat";
        public const string DialReceiverUrn = "urn:x-cast:com.google.cast.receiver";
    }

    public class ChromecastConstants
    {
        public const string ChromecastEurekaPath = "/setup/eureka_info";
    }
}
