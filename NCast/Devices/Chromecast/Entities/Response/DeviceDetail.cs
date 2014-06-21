using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NCast.Devices.Chromecast.Entities.Response
{
    [DataContract]
    public class DeviceInfo
    {
        [DataMember(IsRequired = false, Name = "version")]
        public int Version { get; set; }

        [DataMember(IsRequired = true, Name = "name")]
        public string Name { get; set; }

        [DataMember(IsRequired = true, Name = "build_version")]
        public string SystemVersion { get; set; }

        [DataMember(IsRequired = true, Name = "has_update")]
        public bool HasUpdate { get; set; }

        [DataMember(IsRequired = true, Name = "ssdp_udn")]
        public Guid SsdpUdn { get; set; }

        [DataMember(IsRequired = true, Name = "mac_address")]
        public string MacAddress { get; set; }

        [DataMember(IsRequired = false, Name = "hotspot_bssid")]
        public string HotspotBssid { get; set; }

        [DataMember(IsRequired = false, Name = "ip_address")]
        public string IpAddress { get; set; }

        [DataMember(IsRequired = true, Name = "connected")]
        public bool Connected { get; set; }

        [DataMember(IsRequired = true, Name = "ssid")]
        public string Ssid { get; set; }

        [DataMember(IsRequired = true, Name = "wpa_state")]
        public WpaState WpaState { get; set; }

        [DataMember(IsRequired = true, Name = "setup_state")]
        public SetupState SetupState { get; set; }

        [DataMember(IsRequired = true, Name = "wpa_configured")]
        public bool WpaConfigured { get; set; }

        [DataMember(IsRequired = false, Name = "wpa_id")]
        public int WpaId { get; set; }

        [DataMember(IsRequired = false, Name = "signal_level")]
        public int SignalLevel { get; set; }

        [DataMember(IsRequired = false, Name = "public_key")]
        public string PublicKey { get; set; }

        [DataMember(IsRequired = false, Name = "timezone")]
        public string Timezone { get; set; }

        [DataMember(IsRequired = false, Name = "locale")]
        public string Locale { get; set; }

        [DataMember(IsRequired = false, Name = "location")]
        public Location Location { get; set; }

        [DataMember(IsRequired = false, Name = "opt_in")]
        public OptIn OptIn { get; set; }

        [DataMember(IsRequired = false, Name = "uptime")]
        public float Uptime { get; set; }

        [DataMember(IsRequired = false, Name = "sign")]
        public Sign Sign { get; set; }

        [DataMember(IsRequired = false, Name = "time_format")]
        public int TimeFormat { get; set; }
    }
}
