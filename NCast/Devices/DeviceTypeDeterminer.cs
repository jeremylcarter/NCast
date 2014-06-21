using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCast.Discovery;

namespace NCast.Devices
{
    public static class DeviceTypeDeterminer
    {
        public static DeviceType Determine(SSDPResponse response)
        {
            try
            {
                if (response != null && response.Information != null)
                {
                    if (response.Information.Manufacturer.ToLower().Contains("google"))
                    {
                        return DeviceType.Chromecast;
                    }
                    if (response.Information.Model.ToLower().Contains("eureka "))
                    {
                        return DeviceType.Chromecast;
                    }
                    if (response.Information.Manufacturer.ToLower().Contains("tv"))
                    {
                        return DeviceType.Television;
                    }
                    if (response.Information.Model.ToLower().Contains("tv"))
                    {
                        return DeviceType.Television;
                    }
                }
            }
            catch (Exception)
            {
                return DeviceType.Generic;
            }
            return DeviceType.Generic;
        }
    }
}
