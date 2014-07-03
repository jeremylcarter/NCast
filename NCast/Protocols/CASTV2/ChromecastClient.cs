using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using NCast.Devices;

namespace NCast.Protocols.CASTV2
{
    public class ChromecastClient
    {
        private TcpClient _client;
        private SslStream _stream;
        private bool _running;
        private bool _hearbeatRunning;

        public List<ChromecastChannel> Channels { get; set; }
        public IPAddress IPAddress { get; set; }
        public int Port { get; set; }

        public event EventHandler<ChromecastSSLClientDataReceivedArgs> MessageReceived;

        public ChromecastClient(IPEndPoint endPoint)
        {
            IPAddress = endPoint.Address;
            Port = endPoint.Port;
            Channels = new List<ChromecastChannel>();
        }
        public ChromecastClient(IPAddress ip, int port)
        {
            IPAddress = ip;
            Port = port;
            Channels = new List<ChromecastChannel>();
        }

        public ChromecastChannel CreateChannel(string @namespace)
        {
            var channel = new ChromecastChannel(this, @namespace);
            this.Channels.Add(channel);
            return channel;
        }

        public void StopHeartbeat()
        {
            _hearbeatRunning = false;
        }
        public void StartHeartbeat()
        {

            ChromecastChannel channel;
            if (!Channels.Any(ie => ie.Namespace == DialConstants.DialHeartbeatUrn))
            {
                channel = CreateChannel(DialConstants.DialHeartbeatUrn);
            }
            else
            {
                channel = Channels.FirstOrDefault(i => i.Namespace == DialConstants.DialHeartbeatUrn);
            }
            if (channel != null && _hearbeatRunning == false)
            {

                _hearbeatRunning = true;

                Task.Run(async () =>
                {

                    while (_hearbeatRunning)
                    {
                        await Task.Delay(TimeSpan.FromSeconds(5));
                        channel.Write(MessageFactory.Ping());
                    }

                });

            }

        }

        public async Task<bool> Connect(string name = "client")
        {
            if (_client == null) _client = new TcpClient();
            _client.ReceiveBufferSize = 2048;
            _client.SendBufferSize = 2048;
            await _client.ConnectAsync(IPAddress, Port);
            _stream = new SslStream(_client.GetStream(), true, ValidateServerCertificate, null);
            _stream.AuthenticateAsClient(name);
            _running = true;
            return true;
        }

        private void ReadPacket()
        {

            try
            {
                List<byte> header = new List<byte>();
                List<byte> data = new List<byte>();

                byte[] buffer = new byte[2048];

                var escape = true;

                while (escape)
                {
                    // tricky byte order for messages
                    var bytesRead = _stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 1)
                    {
                        // Incoming series of header /data
                        header.Add(buffer[0]);

                        bytesRead = _stream.Read(buffer, 0, buffer.Length);
                        if (bytesRead == 3)
                        {

                            header.Add(buffer[0]);
                            header.Add(buffer[1]);
                            header.Add(buffer[2]);

                            bytesRead = _stream.Read(buffer, 0, buffer.Length);
                            if (bytesRead == 1)
                            {
                                header.Add(buffer[0]);
                                bytesRead = _stream.Read(buffer, 0, buffer.Length);
                                data.AddRange(buffer.Take(bytesRead));
                                escape = false;
                            }
                            else
                            {
                                escape = false;
                            }
                        }
                        else
                        {
                            escape = false;
                        }

                    }
                    else
                    {
                        escape = false;
                    }
                }

                var entireMessage = new List<byte>();
                entireMessage.AddRange(header);
                entireMessage.AddRange(data);

                header = null;
                data = null;

                try
                {
                    var entireMessageArray = entireMessage.ToArray();
                    var castMessage = CastHelper.ToCastMessage(entireMessageArray);
                    if (castMessage != null)
                    {

                            OnMessageReceived(new ChromecastSSLClientDataReceivedArgs(entireMessageArray, castMessage));

                        // Check if a channel exists that this message needs to go to
                        if (!String.IsNullOrEmpty(castMessage.@namespace))
                        {
                            foreach (var channel in this.Channels.Where(i => i.Namespace == castMessage.@namespace))
                            {
                                channel.OnMessageReceived(new ChromecastSSLClientDataReceivedArgs(entireMessageArray, castMessage));
                            }

                        }

                    }
                }
                catch (Exception ex)
                {
                    // Log these bytes?
                    Console.WriteLine(ex);
                }
            }
            catch (Exception ex)
            {
                // Log these bytes?
                Console.WriteLine(ex);
            }

        }

        public async void Listen()
        {
            await Task.Run(() =>
            {
                while (_running)
                {
                    ReadPacket();
                }
            });
        }
        protected void OnMessageReceived(ChromecastSSLClientDataReceivedArgs e)
        {
            if (MessageReceived != null)
                MessageReceived(this, e);
        }

        public async Task Write(CastMessage message)
        {
            var bytes = CastHelper.ToProto(message);
            await Write(bytes);
        }
        public async Task Write(byte[] bytes)
        {
            await _stream.WriteAsync(bytes, 0, bytes.Length);
        }

        public bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }
}
