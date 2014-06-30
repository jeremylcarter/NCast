using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            msg.@namespace = "urn:x-cast:com.google.cast.tp.connection";
            msg.payload_utf8 = "{\"type\":\"CLOSE\"}";
            return msg;
        }
        public static CastMessage Connect()
        {
            var msg = MessageFactory.Generic();
            msg.@namespace = "urn:x-cast:com.google.cast.tp.connection";
            msg.payload_utf8 = "{\"type\":\"CONNECT\"}";
            return msg;
        }
        public static CastMessage Ping()
        {
            var msg = MessageFactory.Generic();
            msg.@namespace = "urn:x-cast:com.google.cast.tp.heartbeat";
            msg.payload_utf8 = "{\"type\":\"PING\"}";
            return msg;
        }
        public static CastMessage Status()
        {
            var msg = new CastMessage();
            msg.@namespace = "urn:x-cast:com.google.cast.receiver";
            msg.payload_utf8 = "{\"type\":\"GET_STATUS\"}";
            return msg;
        }
        public static CastMessage Launch(string appId)
        {
            var msg = MessageFactory.Generic();
            msg.@namespace = "urn:x-cast:com.google.cast.receiver";
            msg.payload_utf8 = String.Format("{{\"type\":\"LAUNCH\",\"appId\":\"{0}\",\"requestId\":1}}", appId);
            return msg;
        }
    }


}
