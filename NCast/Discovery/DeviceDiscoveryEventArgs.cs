using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCast.Discovery
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>
    ///     Passed as event argument for devices discovered via <c>DeviceDiscovery</c> instance.
    /// </summary>
    ///-------------------------------------------------------------------------------------------------
    public class DeviceDiscoveryEventArgs : EventArgs
    {
        public DeviceDiscoveryEventArgs(ChromecastDeviceDiscoveryReportItem report)
        {
            this.Report = report;
        }

        public ChromecastDeviceDiscoveryReportItem Report { get; private set; }
    }
}
