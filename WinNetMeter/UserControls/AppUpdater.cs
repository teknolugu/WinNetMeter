using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;
using WinNetMeter.Core;
using WinNetMeter.Helper;
using WinNetMeter.Shell.Helper;

namespace WinNetMeter.UserControls
{
    public partial class AppUpdater : UserControl
    {
        private WebClient _webClient;
        private Stopwatch sw = new Stopwatch();
        private string urlDashboard = "https://cdn.azhe.space/products/win-netmeter/release/WinNetMeter.exe";
        private string urlShell = "https://cdn.azhe.space/products/win-netmeter/release/WinNetMeter.Shell.dll";
        private bool isDownloadDashboard = false;
        private string imageInsall = "WinNetMeter.aim";
        private string imageShell = "WinNetMeter.Shell.aim";
        private string moduleName = "Updater";

        public AppUpdater()
        {
            InitializeComponent();
            //DownloadFile(urlDashboard, imageInsall);
        }

        private void DownloadFile(string urlAddress, string location)
        {
            using (WebClient wc = new WebClient())
            {
                wc.DownloadFile(urlShell, imageShell);
            }

            using (_webClient = new WebClient())
            {
                _webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                _webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);

                // The variable that will be holding the url address (making sure it starts with http://)
                Uri URL = urlAddress.StartsWith("https://", StringComparison.OrdinalIgnoreCase)
                    ? new Uri(urlAddress)
                    : new Uri("https://" + urlAddress);

                if (urlAddress.Contains("exe"))
                {
                    isDownloadDashboard = true;
                }

                // Start the stopwatch which we will be using to calculate the download speed
                sw.Start();

                try
                {
                    // Start downloading the file
                    _webClient.DownloadFileAsync(URL, location);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            // Calculate download speed and output it to labelSpeed.
            var speed = (e.BytesReceived / 1024d / sw.Elapsed.TotalSeconds).ToString("0.00");
            //            var speed = NumberHelper.NiceSize(e.BytesReceived / sw.Elapsed.TotalSeconds,"/s");
            //            var elapsedSize = (e.BytesReceived / 1024d / 1024d).ToString("0.00");
            var elapsedSize = Numeric.SizeFormat(e.BytesReceived);
            //            var totalSize = (e.TotalBytesToReceive / 1024d / 1024d).ToString("0.00");
            var totalSize = Numeric.SizeFormat(e.TotalBytesToReceive);

            // Show the percentage on our label.
            Title.Text = $"Updating ({e.ProgressPercentage} %)";
            Description.Text = $"{elapsedSize} / {totalSize}. Speed {speed} kb/s";
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            sw.Reset();

            if (e.Cancelled == true)
            {
                MessageBox.Show("Download has been canceled.");
                Title.ResetText();
                Description.ResetText();

                FileHelper.SafeDelete(imageInsall);
                FileHelper.SafeDelete(imageShell);
            }
            else
            {
                if (isDownloadDashboard)
                {
                    // MessageBox.Show("Download completed!");
                    Title.Text = "Restarting App..";
                    BtnCheckUpdates.Enabled = true;
                    BtnCancel.Enabled = false;
                    ThisApp.InstallUpdates();
                }
            }
        }

        private void BtnCheckUpdates_Click(object sender, EventArgs e)
        {
            Title.Text = "Getting ready..";
            BtnCheckUpdates.Enabled = false;
            BtnCancel.Enabled = true;
            DownloadFile(urlDashboard, imageInsall);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (_webClient != null)
            {
                _webClient.CancelAsync();
                BtnCheckUpdates.Enabled = true;
            }
        }
    }
}