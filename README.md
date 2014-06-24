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
    // args contains the device information
}
```
