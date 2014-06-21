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

namespace NCast.TestApplication
{
    public partial class Form1 : Form
    {
        public SSDPDiscovery Discovery = new SSDPDiscovery();

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
                lstDeviceList.Items.Add(args.Response.Name + " ("+ args.Response.DeviceType + ") @ " + args.Response.EndPoint);
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
    }
}
