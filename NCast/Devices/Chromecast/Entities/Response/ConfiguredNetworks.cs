using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NCast.Devices.Chromecast.Entities.Response
{
    [DataContract]
    public class ConfiguredNetworks
    {
        [DataMember(IsRequired = true, Name = "ssid")]
        public string Ssid { get; set; }

        [DataMember(IsRequired = true, Name = "wpa_id")]
        public int WpaId { get; set; }
    }
}
