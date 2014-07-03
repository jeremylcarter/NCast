using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NCast.Devices.Chromecast.Entities.Request
{
    public static class RequestIdProvider
    {
        public static int GetNext()
        {
            return Interlocked.Add(ref currentId, 1);
        }
        private static /*volatile*/ int currentId = new Random((int)DateTime.Now.Ticks).Next();
    }

    [DataContract]
    public abstract class Request
    {
        public Request(string requestType)
        {
            this.RequestType = requestType;

        }
        [DataMember(Name = "type")]
        public string RequestType { get; set; }
    }

    [DataContract]
    public abstract class RequestWithId : Request
    {
        public RequestWithId(string requestType) : base(requestType)
        {
            RequestId = RequestIdProvider.GetNext();
        }
        [DataMember(Name = "requestId")]
        public int RequestId { get; set; }
    }


    [DataContract]
    public class LaunchRequest : RequestWithId
    {
        public LaunchRequest(string appId) : base("LAUNCH")
        {
            this.ApplicationId = appId;
        }

        [DataMember(Name = "appId")]
        public string ApplicationId { get; set; }
    }

    [DataContract]
    public class StopRequest : RequestWithId
    {
        public StopRequest(string sessionId) : base("STOP")
        {

        }
        [DataMember(Name ="sessionId")]
        public string SessionId { get; set; }
    }

    [DataContract]
    public class GetStatusRequest : RequestWithId
    {
        public GetStatusRequest() : base("GET_STATUS")
        { }
    }

    [DataContract]
    public class GetAppAvailabilityRequest : RequestWithId
    {
        public GetAppAvailabilityRequest(string[] appIds) : base("GET_APP_AVAILABILITY")
        {

        }

        [DataMember(Name = "appId")]
        public string[]  ApplicationId { get; set; }
    }


}
