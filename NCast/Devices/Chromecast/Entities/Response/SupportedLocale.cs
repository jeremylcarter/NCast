using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NCast.Devices.Chromecast.Entities.Response
{
    [DataContract]
    public class SupportedLocale
    {
        [DataMember(IsRequired = true, Name = "locale")]
        public string locale { get; set; }

        [DataMember(IsRequired = true, Name = "display_string")]
        public string display_string { get; set; }
    }

}
