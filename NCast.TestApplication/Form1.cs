using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NCast.Discovery;
using NCast.Devices;
using NCast.Protocols.CASTV2;

namespace NCast.TestApplication
{
    public partial class Form1 : Form
    {
        public SSDPDiscovery Discovery = new SSDPDiscovery();
        public ChromecastClient ChromecastClient;
        public Form1()
        {
            InitializeComponent();
            RefreshDeviceList();
            Discovery.OnDeviceDiscovered += OnDeviceDiscovered;
        }

        private void OnDeviceDiscovered(object sender, SSDPDiscoveredDeviceEventArgs args)
        {
            lstDeviceList.InvokeIfRequired(() =>
            {
                lstDeviceList.Items.Add(args.Response);
            });
        }

        public void RefreshDeviceList()
        {
            var task = Task.Run(() =>
            {
                if (Discovery != null)
                {
                    lstDeviceList.InvokeIfRequired(() => lstDeviceList.Items.Clear());
                    Discovery.Start();
                }
            });
        }

        private void tmrRefreshDeviceList_Tick(object sender, EventArgs e)
        {
            RefreshDeviceList();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void lstDeviceList_DoubleClick(object sender, EventArgs e)
        {
             var item = (SSDPResponse) lstDeviceList.SelectedItem;
            if (item != null && item.DeviceType == DeviceType.Chromecast)
            {
                var chromeCast = new ChromecastDevice(item);
                var info = await chromeCast.GetDetail();

                lblAddress.Text = info.IpAddress;
                lblName.Text = info.Name;

                groupChromecast.Enabled = true;
                ChromecastClient = new ChromecastClient(item.Address, 8009);
                btnLaunchYoutube.Enabled = true;
            }
        }

        private async void btnLaunchYoutube_Click(object sender, EventArgs e)
        {
            if (ChromecastClient != null)
            {
                // Create channels for communication

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
		
            }
        }

        private void OnData(object sender, ChromecastSSLClientDataReceivedArgs e)
        {
            lstDeviceList.InvokeIfRequired(() =>
            {
                lstLog.Items.Add(e.Message.payload_utf8);
            });
        }

    }
}
