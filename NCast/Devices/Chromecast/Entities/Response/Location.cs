using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NCast.Devices.Chromecast.Entities.Response
{

    [DataContract]
    public class Location
    {
        [DataMember(IsRequired = false, Name = "country_code")]
        public string country_code { get; set; }

        [DataMember(IsRequired = false, Name = "latitude")]
        public double latitude { get; set; }

        [DataMember(IsRequired = false, Name = "longitude")]
        public double longitude { get; set; }
    }
}
