using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NCast.Discovery;

namespace NCast
{
    public interface IDevice
    {
        bool Parse(DeviceDiscoveryReportItem report);
        IPEndPoint EndPoint { get; set; }
        IPAddress Interface { get; set; }
        string Name { get; set; }
        string Manufacturer { get; set; }
        string Model { get; set; }
        string BaseUrl { get; set; }
        DeviceType Type { get; set; }
    }
}
