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

// Creating a client
```c#
ChromecastClient = new ChromecastClient(item.Address, 8009);
```

// Launching an application
```c#
var connection = ChromecastClient.CreateChannel("urn:x-cast:com.google.cast.tp.connection");
var heartbeat = ChromecastClient.CreateChannel("urn:x-cast:com.google.cast.tp.heartbeat");
var receiver = ChromecastClient.CreateChannel("urn:x-cast:com.google.cast.receiver");

await ChromecastClient.Connect();
ChromecastClient.Listen();

connection.OnMessageReceived += OnData;
receiver.OnMessageReceived += OnData;
heartbeat.OnMessageReceived += OnData;

// Send the connect message
ChromecastClient.Write(MessageFactory.Connect());

// Launch the YouTube application
ChromecastClient.Write(MessageFactory.Launch("YouTube"));

// Start a 5 second heartbeat
ChromecastClient.StartHeartbeat();
```


![alt tag](http://i.imgur.com/XalK9X9.png)
