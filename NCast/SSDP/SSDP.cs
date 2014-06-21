using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NCast.Discovery
{
    public class SSDP
    {
        public async Task<SSDPDeviceInformation> GetDeviceInformation(string url)
        {
            var information = new SSDPDeviceInformation();

            try
            {
                var client = new HttpClient();
                var response = await client.GetAsync(new Uri(url));
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var xDocument = XDocument.Parse(await response.Content.ReadAsStringAsync());
                    if (xDocument.Root != null)
                    {
                        XNamespace rootNamespace = xDocument.Root.Name.Namespace;
                        XElement device = xDocument.Root.Element(rootNamespace + "device");
                        if (device != null)
                        {
                            XElement model = device.Element(rootNamespace + "modelName");
                            XElement manufacturer = device.Element(rootNamespace + "manufacturer");
                            XElement friendlyName = device.Element(rootNamespace + "friendlyName");
                            XElement udn = device.Element(rootNamespace + "UDN");
                            XElement deviceType = device.Element(rootNamespace + "deviceType");

                            if (model != null && !String.IsNullOrEmpty(model.Value)) information.Model = model.Value;
                            if (manufacturer != null && !String.IsNullOrEmpty(manufacturer.Value)) information.Manufacturer = manufacturer.Value;
                            if (friendlyName != null && !String.IsNullOrEmpty(friendlyName.Value)) information.Name = friendlyName.Value;
                            if (udn != null && !String.IsNullOrEmpty(udn.Value)) information.UDN = udn.Value;
                            if (deviceType != null && !String.IsNullOrEmpty(deviceType.Value)) information.Type = deviceType.Value;
                        }
                    }
                  
                }

            }
            catch (Exception)
            {
            }

            return information;
        }
    }
}
