
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace NCast.Devices.Chromecast.Entities.Response
{
    [DataContract()]
    public partial class ReceiverStatusResponse
    {

        [DataMember(Name = "requestId")]
        public int requestId;

        [DataMember(Name ="status")]
        public Status status;

        [DataMember(Name = "type")]
        public string type;
    }

    [DataContract(Name = "status")]
    public partial class Status
    {
        [DataMember(Name = "applications")]
        public ApplicationStatus[] Applications;

        [DataMember(Name = "isActiveInput")]
        public bool IsActiveInput;

        [DataMember(Name = "volume")]
        public Volume Volume;
    }

    [DataContract(Name = "applications")]
    public partial class ApplicationStatus
    {

        [DataMember(Name ="appId")]
        public string AppId;

        [DataMember(Name = "displayName")]
        public string DisplayName;

        [DataMember(Name = "namespaces")]
        public ApplicationNamespaces[] Namespaces;

        [DataMember(Name = "sessionId")]
        public string SessionId;

        [DataMember(Name = "statusText")]
        public string StatusText;

        [DataMember(Name = "transportId")]
        public string TransportId;
    }

    [DataContract(Name = "namespaces")]
    public partial class ApplicationNamespaces
    {
        [DataMember(Name ="name")]
        public string Name;
    }

    [DataContract(Name = "volume")]
    public partial class Volume
    {

        [DataMember(Name = "level")]
        public float Level;

        [DataMember(Name = "muted")]
        public bool Muted;
    }

}
