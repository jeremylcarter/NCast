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
using System.IO;
using NCast.Devices.Chromecast.Entities.Response;
namespace NCast.TestApplication
{
    public partial class Form1 : Form
    {
        public DeviceAggregate CurrentAggregate;
        ChromecastDeviceDiscovery Discovery = new ChromecastDeviceDiscovery();
        public Form1()
        {
            InitializeComponent();
            RefreshDeviceList();

            Discovery.DeviceDiscovered += Discovery_DeviceDiscovered;

            ChromecastAppList.Get().ContinueWith((t) =>
                AppComboBox.InvokeIfRequired(() =>
                {
                    AppComboBox.Items.AddRange(t.Result.applications);
                    if (AppComboBox.Items.Count > 0)
                    {
                        AppComboBox.SelectedIndex = 0;
                    }
                }));
        }

        private void Discovery_DeviceDiscovered(object sender, DeviceDiscoveryEventArgs e)
        {
            lstDeviceList.InvokeIfRequired(() =>
            {
                lstDeviceList.Items.Add(new DeviceAggregate(e.Report));
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
            var da = (DeviceAggregate)lstDeviceList.SelectedItem;
            if (da != null && da.Report.DeviceType == DeviceType.Chromecast)
            {
                CurrentAggregate = da;
                var chromeCastReport = da.Report as ChromecastDeviceDiscoveryReportItem;
                da.Device = new ChromecastDevice(chromeCastReport);

                lblAddress.Text = chromeCastReport.EndPoint.ToString();
                lblName.Text = chromeCastReport.Name;

                groupChromecast.Enabled = true;
                da.Client = new ChromecastClient(chromeCastReport.EndPoint.Address, 8009);   // <-- dat port number :(

                da.ConnectionChannel = da.Client.CreateChannel(DialConstants.DialConnectionUrn);
                da.HeartbeatChannel = da.Client.CreateChannel(DialConstants.DialHeartbeatUrn);
                da.ReceiverChannel = da.Client.CreateChannel(DialConstants.DialReceiverUrn);

                await da.Client.Connect();
                da.Client.Listen();

                da.ConnectionChannel.MessageReceived += OnData;
                da.ReceiverChannel.MessageReceived += OnData;
                da.HeartbeatChannel.MessageReceived += OnData;

                // Send the connect message
                da.Client.Write(MessageFactory.Connect());

                da.Client.StartHeartbeat();

                btnLaunchYoutube.Enabled = true;
            }
        }

        private async void btnLaunchYoutube_Click(object sender, EventArgs e)
        {
            if (CurrentAggregate != null && CurrentAggregate.IsReady)
            {
                // Launch any app from the combo box
                var app = AppComboBox.SelectedItem as ChromecastApp;
                CurrentAggregate.Client.Write(MessageFactory.Launch(app.app_id));

            }
        }

        bool connectionAlreadySetup = false;    // temp

        private void OnData(object sender, ChromecastSSLClientDataReceivedArgs e)
        {
            lstDeviceList.InvokeIfRequired(() =>
            {
                lstLog.Items.Add(e.Message.payload_utf8);
            });
        }

    }
}