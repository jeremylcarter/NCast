using System;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using NCast.Devices;
using NCast.Devices.Chromecast.Entities.Request;
using NCast.Devices.Chromecast.Entities.Response;
using NCast.Discovery;
using NCast.Protocols.CASTV2;
using System.Collections.Generic;

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
            CurrentAggregate = (DeviceAggregate)lstDeviceList.SelectedItem;
            if (CurrentAggregate != null && CurrentAggregate.Report.DeviceType == DeviceType.Chromecast)
            {
                var chromecastReport = CurrentAggregate.Report as ChromecastDeviceDiscoveryReportItem;
                CurrentAggregate.StartDevice();

                lblAddress.Text = chromecastReport.EndPoint.ToString();
                lblName.Text = chromecastReport.Name;

                groupChromecast.Enabled = true;
                CurrentAggregate.ConnectionChannel.MessageReceived += OnData;
                CurrentAggregate.ReceiverChannel.MessageReceived += OnData;
                CurrentAggregate.HeartbeatChannel.MessageReceived += OnData;
                CurrentAggregate.MediaChannel.MessageReceived += OnData;

                btnLaunchYoutube.Enabled = true;
            }
        }

        private async void btnLaunchYoutube_Click(object sender, EventArgs e)
        {
            if (CurrentAggregate != null && CurrentAggregate.IsReady)
            {
                this.CurrentApp = (AppComboBox.SelectedItem as ChromecastApp);
                // Launch any app from the combo box
                CurrentAggregate.Client.Write(MessageFactory.Launch(CurrentApp.app_id));

            }
        }

        bool connectionAlreadySetup = false;    // temp
        private ReceiverStatusResponse CurrentStatus;
        private ChromecastApp CurrentApp;

        private void OnData(object sender, ChromecastSSLClientDataReceivedArgs e)
        {
            lstDeviceList.InvokeIfRequired(() =>
            {
                // Added just to see how it works out to get the "type" out JSON dynamically. Will be removed.
                Trace.WriteLine(string.Format("Responsetype: {0}", e.Message.GetJsonType()));

                if (e.Message.GetJsonType() == "RECEIVER_STATUS")
                {
                    ReceiverStatusResponse response = e.Message.payload_utf8.DeserializeJson<ReceiverStatusResponse>();
                    this.CurrentStatus = response;
                    Trace.WriteLine("current status set");
                }
                lstLog.Items.Add(e.Message.payload_utf8);

            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4";
            // set destinationId == transportid

            var currentAppStatus = from p in this.CurrentStatus.status.applications where (p.appId == CurrentApp.app_id) select p;
            var curre = this.CurrentStatus.status.applications.FirstOrDefault((t) => t.appId == CurrentApp.app_id);

            var customData = new Dictionary<string, string>();
            customData.Add("title:", "BigBuckbunny");
            customData.Add("thumb", null);
            
            var req = new LoadRequest(curre.sessionId, new Media(url, "video/mp4"), true, 0.0, customData);
            Trace.WriteLine(req.ToJson());
            CurrentAggregate.Client.Write(MessageFactory.Load(curre.transportId, req.ToJson()));

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var currentAppStatus = from p in this.CurrentStatus.status.applications where (p.appId == CurrentApp.app_id) select p;
            var curre = this.CurrentStatus.status.applications.FirstOrDefault((t) => t.appId == CurrentApp.app_id);

            CurrentAggregate.Client.Write(MessageFactory.Connect(curre.transportId));

        }
    }
}