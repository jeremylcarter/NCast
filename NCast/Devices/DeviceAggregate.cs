using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCast.Devices;
using NCast.Discovery;
using NCast.Protocols.CASTV2;

namespace NCast
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
        public ChromecastClient Client { get; set; }
        public ChromecastChannel MediaChannel { get; private set; }

        public virtual async Task StartDevice()
        {
            var chromeCastReport = Report as ChromecastDeviceDiscoveryReportItem;
            Device = new ChromecastDevice(chromeCastReport );
            Client = new ChromecastClient(chromeCastReport.EndPoint.Address, 8009);   // <-- dat port number :(

            ConnectionChannel = Client.CreateChannel(DialConstants.DialConnectionUrn);
            HeartbeatChannel = Client.CreateChannel(DialConstants.DialHeartbeatUrn);
            ReceiverChannel = Client.CreateChannel(DialConstants.DialReceiverUrn);
            MediaChannel = Client.CreateChannel(DialConstants.DialMediaUrn);

            await Client.Connect();
            Client.Listen();

            // Send the connect message
            Client.Write(MessageFactory.Connect());

            Client.StartHeartbeat();
        }

        public override string ToString()
        {
            return Report.ToString();
        }
    }
}
