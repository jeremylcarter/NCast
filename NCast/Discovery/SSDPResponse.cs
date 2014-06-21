using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NCast.Discovery
{

    public class SSDPResponse
    {
        public SSDPResponse()
        {
            Name = "Unknown";
        }
        public IPAddress Interface { get; set; }
        public string Response { get; set; }
        public IPAddress Address { get; set; }
        public IPEndPoint EndPoint { get; set; }
        public string USN { get; set; }
        public string Hash { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public DeviceType DeviceType { get; set; }
        public SSDPDeviceInformation Information { get; set; }
        public void Parse(string response)
        {

            if (response.StartsWith("HTTP/1.1 200 OK"))
            {
                this.Response = response;

                var reader = new StringReader(response);
                var lines = new List<string>();
                for (; ; )
                {
                    var line = reader.ReadLine();
                    if (line == null) break;
                    if (line != "") lines.Add(line);
                }
                string location = lines.Where(lin => lin.StartsWith("LOCATION:")).FirstOrDefault();
                if (!String.IsNullOrEmpty(location))
                {
                    var uri = new Uri(location.Replace("LOCATION:", ""));
                    this.Url = uri.ToString();
                    this.Address = IPAddress.Parse(uri.Host);
                    this.EndPoint = new IPEndPoint(this.Address, uri.Port);

                    var hash = String.Format("{0}{1}{2}", this.Address.ToString(), this.EndPoint.ToString(), this.Interface.ToString());
                    this.Hash = hash.MD5Hash();
                }
                string usn = lines.Where(lin => lin.StartsWith("USN:")).FirstOrDefault();
                if (!String.IsNullOrEmpty(usn))
                {
                    this.USN = usn.Replace("USN:", "");
                }

            }

        }

    }
}
