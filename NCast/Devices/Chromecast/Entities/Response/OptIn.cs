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
        public bool? Stats { get; set; }

        [DataMember(IsRequired = false, Name = "crash")]
        public bool? Crash { get; set; }

        [DataMember(IsRequired = false, Name = "device_id")]
        public bool? DeviceId { get; set; }
    }
}
