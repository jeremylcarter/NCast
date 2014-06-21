using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NCast
{
    public interface IDevice
    {
        IPAddress Address { get; set; }
        IPAddress Interface { get; set; }
        string Name { get; set; }
        DeviceType Type { get; set; }
    }
}
