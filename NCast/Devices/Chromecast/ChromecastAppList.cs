using System;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using NCast.Common;
using NCast.Devices.Chromecast.Entities.Response;
using Newtonsoft.Json;

namespace NCast.Devices
{
    public class ChromecastAppList
    {
        public static async Task<AppListRoot> GetAsync()
        {
            var jsonStream = await WebHelper.GetHttpStreamAsync(new Uri(DiscoveryConstants.NewAppList));
            jsonStream.Position += 4;       // Munch ")]}'\n" See https://github.com/jloutsenhizer/CR-Cast/wiki/Chromecast-Implementation-Documentation-WIP
            return jsonStream.DeSerializeJson<AppListRoot>(); 
        }
    }
}
