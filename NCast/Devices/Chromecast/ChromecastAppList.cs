using System;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using NCast.Common;
using NCast.Devices.Chromecast.Entities.Response;

namespace NCast.Devices
{
    public class ChromecastAppList
    {
        public static async Task<AppListRoot> Get()
        {
            var jsonStream = await WebHelper.GetHttpStream(new Uri(DiscoveryConstants.NewAppList));
            jsonStream.Position += 4;       // Munch ")]}'\n" See https://github.com/jloutsenhizer/CR-Cast/wiki/Chromecast-Implementation-Documentation-WIP

            var applist = (AppListRoot)new DataContractJsonSerializer(typeof(AppListRoot)).ReadObject(jsonStream);

            return applist;
        }
    }
}
