using System;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using NCast.Devices.Chromecast.Entities.Response;
using NCast.Discovery;

namespace NCast.Devices
{
    public class ChromecastDevice : IDevice
    {
        public ChromecastDevice(SSDPResponse response)
        {
            Parse(response);
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Parses the v1 response from a chromecast device
        /// </summary>
        ///
        /// <param name="response">
        ///     The response.
        /// </param>
        ///-------------------------------------------------------------------------------------------------
        public void Parse(SSDPResponse response)
        {
            if (response != null)
            {
                this.EndPoint = response.EndPoint;
                this.Interface = response.Interface;
                this.Name = response.Name;

                var uri = new Uri(response.Url);
                this.BaseUrl = String.Format("{0}://{1}", uri.Scheme, uri.Authority);
                this.Type = response.DeviceType;
                if (response.Information != null)
                {
                    this.Manufacturer = response.Information.Manufacturer;
                    this.Model = response.Information.Model;
                }
            }
        }


        public IPEndPoint EndPoint { get; set; }
        public IPAddress Interface { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string BaseUrl { get; set; }
        public DeviceType Type { get; set; }

        public async Task<DeviceInfo> GetDetail()
        {
            try
            {
                var detail = new DeviceInfo();

                var httpClient = new HttpClient();
                var uri = new Uri(String.Format("{0}{1}", this.BaseUrl, ChromecastConstants.ChromecastEurekaPath));

                var response = await httpClient.GetAsync(uri);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var stream = await response.Content.ReadAsStreamAsync();
                    detail = (DeviceInfo)new DataContractJsonSerializer(typeof(DeviceInfo)).ReadObject(stream);
                }

                return detail;
            }
            catch (Exception)
            {
                return null;
            }

        }
    }
}
