using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCast.Protocols.CASTV2
{

    public class ChromecastChannel
    {
        private ChromecastClient _client { get; set; }
        public string Namespace { get; set; }

        public event EventHandler<ChromecastSSLClientDataReceivedArgs> MessageReceived;

        public ChromecastChannel(ChromecastClient client, string @ns)
        {
            Namespace = ns;
            _client = client;
        }

        public async Task Write(CastMessage message)
        {
            message.@namespace = this.Namespace;

            var bytes = CastHelper.ToProto(message);
            await _client.Write(bytes);
        }
        public async Task Write(byte[] bytes)
        {
            await _client.Write(bytes);
        }

        public void OnMessageReceived(ChromecastSSLClientDataReceivedArgs e)
        {
            if (MessageReceived != null)
                MessageReceived(this, e);
        }
    }

}
