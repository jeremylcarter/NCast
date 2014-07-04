using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

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


        public string ToJson()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.NullValueHandling = NullValueHandling.Ignore;
            return JsonConvert.SerializeObject(this, GetType(), settings);
        }
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
        [DataMember(Name = "sessionId")]
        public string SessionId { get; set; }
    }

    [DataContract]
    public class GetStatusRequest : RequestWithId
    {
        public GetStatusRequest() : base("GET_STATUS")
        { }
    }

    [DataContract]
    public class PingRequest : Request
    {
        public PingRequest() : base("PING")
        { }
    }

    [DataContract]
    public class ConnectRequest : Request
    {
        public ConnectRequest() : base("CONNECT")
        { }
    }

    [DataContract]
    public class CloseRequest : Request
    {
        public CloseRequest() : base("CLOSE")
        { }
    }

    [DataContract]
    public class GetAppAvailabilityRequest : RequestWithId
    {
        public GetAppAvailabilityRequest(string[] appIds) : base("GET_APP_AVAILABILITY")
        {

        }

        [DataMember(Name = "appId")]
        public string[] ApplicationId { get; set; }
    }

    [DataContract]
    public class Media
    {
        public Media(string url, string contentType)
        {
            this.Url = url;
            this.ContentType = contentType;
            StreamType = "BUFFERED";
        }

        [DataMember(Name = "contentId")]
        public string Url { get; set; }

        [DataMember(Name = "contentType")]
        public string ContentType { get; set; }

        [DataMember(Name = "streamType")]
        public string StreamType { get; set; }

        [DataMember(Name = "duration")]
        public double Duration { get; set; }
    }

    [DataContract]
    public class LoadRequest : RequestWithId
    {
        public LoadRequest(string sessionId, Media media, bool autoPlay, double currentTime, Dictionary<string, string> customData) : base("LOAD")
        {
            this.SessionId = sessionId;
            this.Media = media;
            this.AutoPlay = autoPlay;
            this.CurrentTime = currentTime;
            this.Customdata = customData;
        }

        [DataMember(Name ="sessionId")]
        public string SessionId { get; private set; }

        [DataMember(Name = "media")]
        public Media Media { get; private set; }

        [DataMember(Name = "autoplay")]
        public bool AutoPlay { get; private set; }

        [DataMember(Name = "currentTime")]
        public double CurrentTime { get; private set; }

        [DataMember(Name = "customData")]
        public Dictionary<string, string> Customdata { get; private set; }
    }

    public static class TempSerializer
    {
        public static string ConvertToJson<T>(this Request request)
        {
            JsonSerializerSettings x = new JsonSerializerSettings();

            return JsonConvert.SerializeObject(request, typeof(T), x);
        }
    }


}
