using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace NCast.Protocols.CASTV2
{

    [Serializable, ProtoContract]
    public class CastMessage
    {
        [ProtoMember(1, IsRequired = true)]
        public int protocol_version = 0;
        [ProtoMember(2, IsRequired = true)]
        public string source_id;
        [ProtoMember(3, IsRequired = true)]
        public string destination_id;
        [ProtoMember(4, IsRequired = true)]
        public string @namespace;
        [ProtoMember(5, IsRequired = true)]
        public int payload_type = 0;
        [ProtoMember(6, IsRequired = false)]
        public string payload_utf8;
        [ProtoMember(7, IsRequired = false)]
        public byte[] payload_binary;
    }
}
