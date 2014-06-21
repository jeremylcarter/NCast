using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NCast.Devices.Chromecast.Entities.Response
{
    [DataContract]
    public class ChromecastApiVersion
    {
        [DataMember(IsRequired = true, Name = "version")]
        public int Version { get; set; }
    }
}
