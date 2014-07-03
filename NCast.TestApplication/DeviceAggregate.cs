using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCast.Devices;
using NCast.Discovery;
using NCast.Protocols.CASTV2;

namespace NCast.TestApplication
{
    public class DeviceAggregate
    {
        public DeviceAggregate(DeviceDiscoveryReportItem report)
        {
            this.Report = report;
        }
        public bool IsReady { get { return Device != null && ConnectionChannel != null && HeartbeatChannel != null && ReceiverChannel != null; } }
        public DeviceDiscoveryReportItem Report { get; private set; }
        public ChromecastDevice Device  { get; set; }
        public ChromecastChannel ConnectionChannel { get; set; }
        public ChromecastChannel HeartbeatChannel { get; set; }
        public ChromecastChannel ReceiverChannel { get; set; }
        public ChromecastClient Client { get; internal set; }

        public override string ToString()
        {
            return Report.ToString();
        }
    }
}
