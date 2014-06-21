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
        public int version { get; set; }

        [DataMember(IsRequired = true, Name = "name")]
        public string name { get; set; }

        [DataMember(IsRequired = true, Name = "build_version")]
        public string system_version { get; set; }

        [DataMember(IsRequired = true, Name = "has_update")]
        public bool has_update { get; set; }

        [DataMember(IsRequired = true, Name = "ssdp_udn")]
        public Guid ssdp_udn { get; set; }

        [DataMember(IsRequired = true, Name = "mac_address")]
        public string mac_address { get; set; }

        [DataMember(IsRequired = false, Name = "hotspot_bssid")]
        public string hotspot_bssid { get; set; }

        [DataMember(IsRequired = false, Name = "ip_address")]
        public string ip_address { get; set; }

        [DataMember(IsRequired = true, Name = "connected")]
        public bool connected { get; set; }

        [DataMember(IsRequired = true, Name = "ssid")]
        public string ssid { get; set; }

        [DataMember(IsRequired = true, Name = "wpa_state")]
        public WpaState wpa_state { get; set; }

        [DataMember(IsRequired = true, Name = "setup_state")]
        public SetupState setup_state { get; set; }

        [DataMember(IsRequired = true, Name = "wpa_configured")]
        public bool wpa_configured { get; set; }

        [DataMember(IsRequired = false, Name = "wpa_id")]
        public int wpa_id { get; set; }

        [DataMember(IsRequired = false, Name = "signal_level")]
        public int signal_level { get; set; }

        [DataMember(IsRequired = false, Name = "public_key")]
        public string public_key { get; set; }

        [DataMember(IsRequired = false, Name = "timezone")]
        public string timezone { get; set; }

        [DataMember(IsRequired = false, Name = "locale")]
        public string locale { get; set; }

        [DataMember(IsRequired = false, Name = "location")]
        public Location location { get; set; }

        [DataMember(IsRequired = false, Name = "opt_in")]
        public OptIn opt_in { get; set; }

        [DataMember(IsRequired = false, Name = "uptime")]
        public float uptime { get; set; }

        [DataMember(IsRequired = false, Name = "sign")]
        public Sign sign { get; set; }

        [DataMember(IsRequired = false, Name = "time_format")]
        public int time_format { get; set; }
    }
}
