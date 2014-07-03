using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using NCast.Common;
using NCast.Devices.Chromecast.Entities.Response;

namespace NCast.Devices
{
    public class ChromecastAppList
    {
        public static async Task<AppListRoot> Get()
        {
            //WebClient x = new WebClient();
            //var result = x.DownloadString(DiscoveryConstants.NewAppList);
            var task = await WebHelper.GetHttpStream(new Uri(DiscoveryConstants.NewAppList));
            //task.Wait();
            //var text = task.Result;
            var jsonStream = task;
            jsonStream.Position += 4;       // Munch ")]}'\n" See https://github.com/jloutsenhizer/CR-Cast/wiki/Chromecast-Implementation-Documentation-WIP
            var applist = (AppListRoot)new DataContractJsonSerializer(typeof(AppListRoot)).ReadObject(jsonStream);

            return applist;
        }
    }
}
