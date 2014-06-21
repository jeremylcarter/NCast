using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NCast.Devices
{
    public class Chromecast : IDevice
    {
        public IPAddress Address { get; set; }
        public IPAddress Interface { get; set; }
        public string Name { get; set; }
        public DeviceType Type { get; set; }

    }
}
