NCast
=====

NCast C# SSDP discovery and content casting. Currently supports renderers such as LG TV's and Google Chromecast.

```c#
public SSDPDiscovery Discovery = new SSDPDiscovery();
// Setup the event when a device is discovered
Discovery.OnDeviceDiscovered += OnDeviceDiscovered;
// Start discovering
Discovery.Start();
```
```c#
private void OnDeviceDiscovered(object sender, SSDPDiscoveredDeviceEventArgs args)
{
    // args.Response contains the device information
    var device = args.Response; // type is SSDPResponse
    
    if (device.DeviceType == DeviceType.Chromecast) {
        
        // Turn the generic SSDP device of known manufacturer into a Chromecast specific device
        var chromeCast = new ChromecastDevice(device);
        // Get the name and details from the Chromecast
        var info = await chromeCast.GetDetail();
    }
}
```
