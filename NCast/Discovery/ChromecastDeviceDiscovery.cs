using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NCast.MDNS;

namespace NCast.Discovery
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>
    ///     Chromecast device discovery class.
    /// </summary>
    ///
    /// <remarks>
    ///     Instantiate, Subscribe to event and call start to receive
    ///     <c>IDeviceDiscoveryReportItem</c> objects.
    /// </remarks>
    ///-------------------------------------------------------------------------------------------------
    public class ChromecastDeviceDiscovery : DeviceDiscovery
    {
        private SSDPDiscovery ssdpDiscovery = new SSDPDiscovery();
        private ServiceBrowser mDnsDiscovery = new ServiceBrowser();

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Starts discovery of Chromecast dongles in local subnet. Subscribe to <c>DeviceDiscovered</c> to
        ///     receive device information.
        /// </summary>
        ///-------------------------------------------------------------------------------------------------
        public override async void Start()
        {
            // TODO: This stuff still needs to go shoot off into thread space and we need CancellationTokens
            mDnsDiscovery.ServiceAdded += MDnsDiscovery_ServiceAdded;
            mDnsDiscovery.StartBrowse();

            ssdpDiscovery.DeviceDiscovered += SsdpDiscovery_DeviceDiscovered;
            ssdpDiscovery.Start();
        }

        private void SsdpDiscovery_DeviceDiscovered(object sender, SSDPDiscoveredDeviceEventArgs e)
        {
            var response = e.Response;
            var uri = new Uri(response.Url);

            var report = new ChromecastV1DeviceDiscoveryReportItem()
            {
                Endpoint = response.EndPoint,
                Interface = response.Interface,
                Name = response.Name,
                Id = response.Hash,
                BaseUri = new Uri(String.Format("{0}://{1}", uri.Scheme, uri.Authority)),
                DeviceType = response.DeviceType
            };
            if (response.Information != null)
            {
                report.Manufacturer = response.Information.Manufacturer;
                report.Model = response.Information.Model;
            }

            OnDeviceDiscovered(new DeviceDiscoveryEventArgs(report));
        }

        private void MDnsDiscovery_ServiceAdded(object sender, ServiceAnnouncementEventArgs e)
        {

            IPAddress localInterface = IPAddress.Any;

            // Retrieve local interface address
            // TODO: This will need some IPv6 love at some point
            if (e.Announcement.NetworkInterface.Information.OperationalStatus == System.Net.NetworkInformation.OperationalStatus.Up)
            {
                var ipv4Addresses = e.Announcement.NetworkInterface.Information.GetIPProperties().UnicastAddresses.Where((ad) => ad.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);
                localInterface = ipv4Addresses.FirstOrDefault().Address;
            }

            // Retrieve version string
            var versionTempString = e.Announcement.Txt.Where((kvp) => kvp.Contains("ve=")).FirstOrDefault();
            int versionNumber = 2;
            if (string.IsNullOrEmpty(versionTempString) == false)
            {
                versionNumber = int.Parse(versionTempString.Split('=')[1]);
            }

            // Retrieve device ID
            var idTempString = e.Announcement.Txt.Where((kvp) => kvp.Contains("id=")).FirstOrDefault();
            string Id = "";
            if (string.IsNullOrEmpty(idTempString) == false)
            {
                Id = idTempString.Split('=')[1];
            }
            else
            {
                // Log.Error(string.Format("Unable to get ID of device {0}", e.Announcement.Hostname));
                return;
            }

            // Optional: Verify that it's a Chromecast device
            var tempDeviceType = e.Announcement.Txt.Where((kvp) => kvp.Contains("md=")).FirstOrDefault();
            var deviceType = DeviceType.Generic;
            if (string.IsNullOrEmpty(tempDeviceType) == false && tempDeviceType.Split('=')[1] == "Chromecast")
            {
                deviceType = DeviceType.Chromecast;
            }
            else
            {
                deviceType = DeviceType.Generic;
            }


            // Build baseUrl
            // This might not be right as there URI scheme could be something else.
            var scheme = "http";
            var address = e.Announcement.Addresses.First();
            var port = e.Announcement.Port;
            var uri = new Uri(string.Format("{0}://{1}:{2}", scheme, address, port));

            var report = new ChromecastV2DeviceDiscoveryReportItem()
            {
                DeviceType = deviceType,
                Version = versionNumber,
                Id = Id,
                Name = e.Announcement.Hostname,
                Endpoint = new IPEndPoint(e.Announcement.Addresses.First(), e.Announcement.Port),
                Interface = localInterface,
                BaseUri = uri,
            };

            Trace.WriteLine(report);
            OnDeviceDiscovered(new DeviceDiscoveryEventArgs(report));
        }
    }
}
