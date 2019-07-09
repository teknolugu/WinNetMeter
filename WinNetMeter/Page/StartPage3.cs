using System;
using System.Threading;
using System.Windows.Forms;
using WinNetMeter.Helper;

namespace WinNetMeter.Page
{
    public partial class StartPage3 : UserControl
    {
        private static bool isLoadCompleted;

        private static string selectedAdapter;

        public static string SelectedAdapter { get => selectedAdapter; set => selectedAdapter = value; }

        public static bool IsLoadCompleted
        {
            get
            {
                return isLoadCompleted;
            }
            set
            {
                isLoadCompleted = value;
            }
        }

        public StartPage3()
        {
            InitializeComponent();
        }

        private void StartPage3_Load(object sender, EventArgs e)
        {
            Thread getAdapter = new Thread(delegate ()
            {
                NetworkIntefaceModule netModule = new NetworkIntefaceModule();
                var adapters = netModule.GetNetworkInterface();
                this.BeginInvoke(new MethodInvoker(delegate ()
                {
                    foreach (String adapter in adapters)
                    {
                        listAdapter.Items.Add(adapter);
                    }
                    IsLoadCompleted = true;
                    listAdapter.Enabled = true;
                    lblDetecting.Visible = false;
                }));
            });

            getAdapter.Start();
        }

        private void ListAdapter_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SelectedAdapter = listAdapter.SelectedItem.ToString();
            }
            catch
            {
                MessageBox.Show("List adapter sedang dimuat, silakan tunggu.", "WinNetMeter Setup",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}