using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using NCast.Devices;

namespace NCast.Discovery
{
    public class SSDPDiscovery
    {
        private SSDP _SSDP = new SSDP();
        public SSDPDiscovery()
        {
            HashCache = new List<string>();
        }
        public EventHandler<SSDPDiscoveredDeviceEventArgs> OnDeviceDiscovered { get; set; }
        List<string> HashCache { get; set; }
        public async void Start()
        {

            foreach (System.Net.NetworkInformation.NetworkInterface ni in System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces())
            {
                if ((ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet) && ni.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
                    {
                        try
                        {
                            var found = await Find(ip.Address);
                            foreach (var element in found)
                            {
                                if (HashCache.Count(i => i == element.Hash) == 0)
                                {
                                    HashCache.Add(element.Hash);
                                    // Attempt to ask the device about itself
                                    try
                                    {
                                        var info = await _SSDP.GetDeviceInformation(element.Url);
                                        if (info != null)
                                        {
                                            element.Name = info.Name;
                                            element.Information = info;
                                        }
                                    }
                                    catch (Exception)
                                    {
                                    }

                                    element.DeviceType = DeviceTypeDeterminer.Determine(element);

                                    if (OnDeviceDiscovered != null)
                                    {
                                        OnDeviceDiscovered(this, new SSDPDiscoveredDeviceEventArgs(element));
                                    }
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                        }
                    }

                }

            }

        }

        public async Task<List<SSDPResponse>> Find(IPAddress address)
        {
            var list = new List<SSDPResponse>();

            try
            {
                IPEndPoint localEndPoint = new IPEndPoint(address, 1901);
                IPEndPoint multicastEndPoint = new IPEndPoint(IPAddress.Parse("239.255.255.250"), 1900);

                Socket udpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                udpSocket.ReceiveTimeout = 1000;
                udpSocket.SendTimeout = 1000;
                udpSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);
                udpSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 1000);
                udpSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveBuffer, (int)ushort.MaxValue);

                udpSocket.Bind(localEndPoint);

                var ssdpAddress = "239.255.255.250";
                var ssdpPort = 1900;
                var ssdpMx = 2;
                var ssdpSt = "urn:dial-multiscreen-org:service:dial:1";

                var ssdpRequest = "M-SEARCH * HTTP/1.1\r\n" +
                            String.Format("HOST: {0}:{1}\r\n", ssdpAddress, ssdpPort) +
                            "MAN: \"ssdp:discover\"\r\n" +
                            String.Format("MX: {0}\r\n", ssdpMx) +
                            String.Format("ST: {0}\r\n", ssdpSt) + "\r\n";
                var bytes = Encoding.UTF8.GetBytes(ssdpRequest);
                byte[] bytesReceived = new byte[(int)ushort.MaxValue];

                var endPoint = (EndPoint)localEndPoint;

                for (int index = 0; index < 3; ++index)
                {
                    int totalbytes;
                    if ((totalbytes = udpSocket.SendTo(bytes, (EndPoint)multicastEndPoint)) == 0)
                    {

                    }
                    else
                    {

                        while (totalbytes > 0)
                        {
                            try
                            {
                                totalbytes = udpSocket.ReceiveFrom(bytesReceived, ref endPoint);
                                if (totalbytes > 0)
                                {

                                    var response = Encoding.UTF8.GetString(bytesReceived, 0, totalbytes);

                                    var ssdpResponse = new SSDPResponse();
                                    ssdpResponse.Interface = localEndPoint.Address;

                                    ssdpResponse.Parse(response);

                                    list.Add(ssdpResponse);
                                }
                            }
                            catch (Exception ex)
                            {
                                break;
                            }

                        }

                    }

                }

                if (udpSocket != null)
                    udpSocket.Close();
            }
            catch (Exception)
            {
            }

            return list;
        }
    }

    public class SSDPDiscoveredDeviceEventArgs : EventArgs
    {
        public SSDPResponse Response { get; set; }
        public SSDPDiscoveredDeviceEventArgs(SSDPResponse response)
        {
            Response = response;
        }
    }
}
