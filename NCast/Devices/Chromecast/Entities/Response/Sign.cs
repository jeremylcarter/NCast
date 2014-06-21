using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NCast.Devices.Chromecast.Entities.Response
{

    [DataContract]
    public class Sign
    {
        [DataMember(IsRequired = true, Name = "certificate")]
        public string certificate { get; set; }

        [DataMember(IsRequired = true, Name = "nonce")]
        public string nonce { get; set; }

        [DataMember(IsRequired = true, Name = "signed_data")]
        public string signed_data { get; set; }
    }
}
