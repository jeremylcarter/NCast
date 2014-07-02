using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCast.Discovery
{
    public class ChromecastV1DeviceDiscoveryReportItem : ChromecastDeviceDiscoveryReportItem
    {
        public ChromecastV1DeviceDiscoveryReportItem() : base()
        {
            Manufacturer = "Generic";
            Model = "Generic";
            Version = 1;
        }
    }
}
