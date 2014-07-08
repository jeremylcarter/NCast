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
                ProtocolVersion = 0,
                PayloadType = 0,
                PayloadBinary = null,
                DestinationId = "receiver-0",
                SourceId = "sender-0"
            };
        }

        public static CastMessage Close()
        {
            var msg = MessageFactory.Generic();
            msg.Namespace = DialConstants.DialConnectionUrn;
            msg.PayloadUtf8 = new CloseRequest().ToJson();
            return msg;
        }
        public static CastMessage Connect()
        {
            var msg = MessageFactory.Generic();
            msg.Namespace = DialConstants.DialConnectionUrn;
            msg.PayloadUtf8 = new ConnectRequest().ToJson();
            return msg;
        }

        public static CastMessage Connect(string destinationId)
        {
            var msg = MessageFactory.Generic();
            msg.DestinationId = destinationId;
            msg.Namespace = DialConstants.DialConnectionUrn;
            msg.PayloadUtf8 = new ConnectRequest().ToJson();
            return msg;
        }
        public static CastMessage Ping()
        {
            var msg = MessageFactory.Generic();
            msg.Namespace = DialConstants.DialHeartbeatUrn;
            msg.PayloadUtf8 = new PingRequest().ToJson();
            return msg;
        }
        public static CastMessage Status()
        {
            var msg = new CastMessage();
            msg.Namespace = DialConstants.DialReceiverUrn;
            msg.PayloadUtf8 = new GetStatusRequest().ToJson();
            return msg;
        }
        public static CastMessage Launch(string appId)
        {
            var msg = MessageFactory.Generic();
            msg.Namespace = DialConstants.DialReceiverUrn;
            msg.PayloadUtf8 = new LaunchRequest(appId).ToJson();
            return msg;
        }

        public static CastMessage Load(string destinationId, string payload)
        {
            var msg = MessageFactory.Generic();
            msg.DestinationId = destinationId;
            msg.Namespace = DialConstants.DialMediaUrn;
            msg.PayloadUtf8 = payload;
            return msg;
        }

    }


}
