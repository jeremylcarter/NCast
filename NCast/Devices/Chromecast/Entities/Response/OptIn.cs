using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NCast.Devices.Chromecast.Entities.Response
{
    [DataContract]
    public class OptIn
    {
        [DataMember(IsRequired = false, Name = "stats")]
        public bool? stats { get; set; }

        [DataMember(IsRequired = false, Name = "crash")]
        public bool? crash { get; set; }

        [DataMember(IsRequired = false, Name = "device_id")]
        public bool? device_id { get; set; }
    }
}
