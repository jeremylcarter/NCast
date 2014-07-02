using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCast.Discovery
{

    public class ChromecastV2DeviceDiscoveryReportItem : ChromecastDeviceDiscoveryReportItem
    {
        public ChromecastV2DeviceDiscoveryReportItem() : base()
        {
            Manufacturer = "Generic";
            Model = "Generic";
            Version = 2;
        }
    }
}
