using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCast.Protocols.CASTV2
{
    public class ChromecastSSLClientDataReceivedArgs : EventArgs
    {
        public ChromecastSSLClientDataReceivedArgs(byte[] array, CastMessage message)
        {
            Data = array;
            Message = message;
        }
        public byte[] Data { get; set; }
        public CastMessage Message { get; set; }
    }

}
