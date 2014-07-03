using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using NCast.Devices;
using NCast.Devices.Chromecast.Entities.Response;
using NCast.Discovery;
using NCast.Protocols.CASTV2;

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
                // Launch any app from the combo box
                CurrentAggregate.Client.Write(MessageFactory.Launch((AppComboBox.SelectedItem as ChromecastApp).app_id));

            }
        }

        bool connectionAlreadySetup = false;    // temp

        private void OnData(object sender, ChromecastSSLClientDataReceivedArgs e)
        {
            lstDeviceList.InvokeIfRequired(() =>
            {
                // Added just to see how it works out to get the "type" out JSON dynamically. Will be removed.
                Trace.WriteLine(string.Format("Responsetype: {0}",e.Message.GetJsonType()));
                lstLog.Items.Add(e.Message.payload_utf8);
                
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}