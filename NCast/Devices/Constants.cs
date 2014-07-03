using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCast.Devices
{
    public static class DiscoveryConstants
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        ///     The delay used for SSDP discovery when no mDNS devices where found.
        /// </summary>
        ///-------------------------------------------------------------------------------------------------
        public static TimeSpan SsdpInvocationDelay = TimeSpan.FromSeconds(5);
        public const string OldAppList = "https://clients3.google.com/cast/chromecast/device/config";
        public const string NewAppList = "https://clients3.google.com/cast/chromecast/device/baseconfig";
    }
    public static class DialConstants
    {
        public const string GenericMulticastAddress = "239.255.255.250";
        public const string DialMultiScreenUrn = "urn:dial-multiscreen-org:service:dial:1";
        public const string DialConnectionUrn = "urn:x-cast:com.google.cast.tp.connection";
        public const string DialHeartbeatUrn = "urn:x-cast:com.google.cast.tp.heartbeat";
        public const string DialReceiverUrn = "urn:x-cast:com.google.cast.receiver";
        public const string DialMediaUrn = "urn:x-cast:com.google.cast.media";
    }

    public static class ChromecastConstants
    {
        public const string ChromecastEurekaPath = "/setup/eureka_info";
    }
}
