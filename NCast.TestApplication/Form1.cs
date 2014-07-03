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
using NCast.MDNS;
using System.Diagnostics;

namespace NCast.TestApplication
{
    public partial class Form1 : Form
    {
        public ChromecastClient ChromecastClient;
        ChromecastDeviceDiscovery Discovery = new ChromecastDeviceDiscovery();
        public Form1()
        {
            InitializeComponent();
            RefreshDeviceList();

            Discovery.DeviceDiscovered += Discovery_DeviceDiscovered;
            Discovery.Start();

            
        }

        private void Discovery_DeviceDiscovered(object sender, DeviceDiscoveryEventArgs e)
        {
            lstDeviceList.InvokeIfRequired(() =>
            {
                lstDeviceList.Items.Add(e.Report);
            });

        }

        private void OnDeviceDiscovered(object sender, SSDPDiscoveredDeviceEventArgs args)
        {
        }

        public void RefreshDeviceList()
        {
            var task = Task.Run(() =>
            {
                if (Discovery != null)
                {
                    lstDeviceList.InvokeIfRequired(() => lstDeviceList.Items.Clear());
                    //Discovery.Start();
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
            var item = (SSDPResponse)lstDeviceList.SelectedItem;
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

                var connection = ChromecastClient.CreateChannel(DialConstants.DialConnectionUrn);
                var heartbeat = ChromecastClient.CreateChannel(DialConstants.DialHeartbeatUrn);
                var receiver = ChromecastClient.CreateChannel(DialConstants.DialReceiverUrn);

                await ChromecastClient.Connect();
                ChromecastClient.Listen();

                connection.MessageReceived += OnData;
                receiver.MessageReceived += OnData;
                heartbeat.MessageReceived += OnData;

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

        ChromecastDeviceDiscovery disc = new ChromecastDeviceDiscovery();
        private void button1_Click_1(object sender, EventArgs e)
        {
            disc.DeviceDiscovered += Disc_DeviceDiscovered;
            disc.Start();
        }

        private void Disc_DeviceDiscovered(object sender, DeviceDiscoveryEventArgs e)
        {
            Debug.WriteLine(string.Format("Report: {0}", e.Report));
        }
    }
}