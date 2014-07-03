using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NCast.Devices;

namespace NCast.Discovery 
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>
    ///     Device discovery report item specific to Chromecast.
    /// </summary>
    ///-------------------------------------------------------------------------------------------------
    public abstract class ChromecastDeviceDiscoveryReportItem : DeviceDiscoveryReportItem
    {
        public ChromecastDeviceDiscoveryReportItem()
        {
            
        }
        public int Version { get; set; }
        public string Id { get; set; }
        public IDevice Device { get; set; }
        public IPEndPoint EndPoint { get; set; }
        public IPAddress Interface { get; set; }
        public string Name { get; set; }
        public Uri BaseUri { get; set; }


        // Additional

        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public override string ToString()
        {
            return string.Format("{0}, {1}, v{2}, {3}, {4}, {5}, {6}", DeviceType, Name, Version, Id, EndPoint, Interface, BaseUri);
        }

        public override IDevice ToDevice()
        {
            return new ChromecastDevice(this);
        }
    }

   


}
