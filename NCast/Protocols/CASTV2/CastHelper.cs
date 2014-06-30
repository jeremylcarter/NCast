using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace NCast.Protocols.CASTV2
{
    public static class CastHelper
    {
        public static byte[] AddHeader(byte[] array)
        {
            var header = BitConverter.GetBytes((UInt32)array.Length);
            var dataToSend = header.Reverse().ToList();
            dataToSend.AddRange(array.ToList());
            return dataToSend.ToArray();
        }
        public static CastMessage ToCastMessage(byte[] array, bool includeHeader = true)
        {

            try
            {
                Stream bufStream = new MemoryStream();
                bufStream.Write(array, 0, array.Length);
                bufStream.Position = 0;
                var msg = Serializer.DeserializeWithLengthPrefix<CastMessage>(bufStream, PrefixStyle.Fixed32BigEndian);
                return msg;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public static byte[] ToProto(object obj, bool includeHeader = true)
        {

            var bufStream = new MemoryStream();
            ProtoBuf.Serializer.Serialize(bufStream, obj);

            if (includeHeader)
            {
                var buffer = AddHeader(bufStream.ToArray());
                return buffer;
            }
            else
            {
                return bufStream.ToArray();
            }

        }

    }
}
