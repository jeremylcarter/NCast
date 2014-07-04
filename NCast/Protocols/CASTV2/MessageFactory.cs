using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCast.Devices;
using NCast.Devices.Chromecast.Entities.Request;

namespace NCast.Protocols.CASTV2
{

    public static class MessageFactory
    {

        public static CastMessage Generic()
        {
            return new CastMessage()
            {
                protocol_version = 0,
                payload_type = 0,
                payload_binary = null,
                destination_id = "receiver-0",
                source_id = "sender-0"
            };
        }

        public static CastMessage Close()
        {
            var msg = MessageFactory.Generic();
            msg.@namespace = DialConstants.DialConnectionUrn;
            msg.payload_utf8 = new CloseRequest().ToJson();
            return msg;
        }
        public static CastMessage Connect()
        {
            var msg = MessageFactory.Generic();
            msg.@namespace = DialConstants.DialConnectionUrn;
            msg.payload_utf8 = new ConnectRequest().ToJson();
            return msg;
        }

        public static CastMessage Connect(string destinationId)
        {
            var msg = MessageFactory.Generic();
            msg.destination_id = destinationId;
            msg.@namespace = DialConstants.DialConnectionUrn;
            msg.payload_utf8 = new ConnectRequest().ToJson();
            return msg;
        }
        public static CastMessage Ping()
        {
            var msg = MessageFactory.Generic();
            msg.@namespace = DialConstants.DialHeartbeatUrn;
            msg.payload_utf8 = new PingRequest().ToJson();
            return msg;
        }
        public static CastMessage Status()
        {
            var msg = new CastMessage();
            msg.@namespace = DialConstants.DialReceiverUrn;
            msg.payload_utf8 = new GetStatusRequest().ToJson();
            return msg;
        }
        public static CastMessage Launch(string appId)
        {
            var msg = MessageFactory.Generic();
            msg.@namespace = DialConstants.DialReceiverUrn;
            msg.payload_utf8 = new LaunchRequest(appId).ToJson();
            return msg;
        }

        public static CastMessage Load(string destinationId, string payload)
        {
            var msg = MessageFactory.Generic();
            msg.destination_id = destinationId;
            msg.@namespace = DialConstants.DialMediaUrn;
            msg.payload_utf8 = payload;
            return msg;
        }

    }


}
