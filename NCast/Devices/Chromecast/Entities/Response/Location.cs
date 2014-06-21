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
        public string CountryCode { get; set; }

        [DataMember(IsRequired = false, Name = "latitude")]
        public double Latitude { get; set; }

        [DataMember(IsRequired = false, Name = "longitude")]
        public double Longitude { get; set; }
    }
}
