using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NCast.Devices.Chromecast.Entities.Response
{
    [DataContract]
    public class SupportedTimezone
    {
        [DataMember(IsRequired = true, Name = "timezone")]
        public string Timezone { get; set; }

        [DataMember(IsRequired = true, Name = "display_string")]
        public string DisplayString { get; set; }

        [DataMember(IsRequired = true, Name = "offset")]
        public int Offset { get; set; }
    }
}
