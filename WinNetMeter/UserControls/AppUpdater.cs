using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Windows.Forms;
using WinNetMeter.Helper;
using WinNetMeter.Model;
using WinNetMeter.Shell.Helper;

namespace WinNetMeter.UserControls
{
    public partial class AppUpdater : UserControl
    {
        private WebClient _webClient;
        private readonly Stopwatch sw = new Stopwatch();

        private readonly string baseUrl = "https://cdn.winten.space";
        private readonly string updateDirectory = AppDomain.CurrentDomain.BaseDirectory + @"update";
        private readonly string urlDashboard = "";
        private readonly string urlShell = "";
        private readonly string urlUpdater = "";
        private bool isDownloadDashboard = false;
        private readonly string zipUpdateFile;
        private readonly string imageInsall = "WinNetMeter.aim";
        private readonly string imageShell = "WinNetMeter.Shell.aim";
        private readonly string updateFile = "update.zip";
        private List<string> changelog;
        private RegistryManager registryManager = new RegistryManager();
        private Configuration configuration;

        public AppUpdater()
        {
            InitializeComponent();

            urlDashboard = $"{baseUrl}/products/win-netmeter/release/WinNetMeter.exe";
            urlShell = $"{baseUrl}/products/win-netmeter/release/WinNetMeter.Shell.dll";
            urlUpdater = $"{baseUrl}/products/win-netmeter/release/Updater.exe";
            configuration = registryManager.GetGeneralConfiguration();
            zipUpdateFile = $"{baseUrl}/products/win-netmeter/release/{updateFile}";
        }

        private void DownloadFile(string urlAddress, string location)
        {
            using (_webClient = new WebClient())
            {
                _webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                _webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);

                // The variable that will be holding the url address (making sure it starts with http://)
                Uri URL = urlAddress.StartsWith("https://", StringComparison.OrdinalIgnoreCase)
                    ? new Uri(urlAddress)
                    : new Uri("https://" + urlAddress);

                if (urlAddress.Contains(".exe"))
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
                Title.Text = "Extracting..";

                //Extract .zip file
                if (IsDirectoryEmpty(updateDirectory) == false)
                {
                    foreach (string file in Directory.GetFiles(updateDirectory))
                    {
                        if (!file.Contains("update.zip"))
                        {
                            FileHelper.SafeDelete(file);
                        }
                    }
                }
                ZipFile.ExtractToDirectory(updateDirectory + ".zip", updateDirectory);

                Title.Text = "Restarting App..";
                BtnCheckUpdates.Enabled = true;
                BtnCancel.Enabled = false;
                //ThisApp.InstallUpdates();

                Process.Start("Updater.exe");
                Application.Exit();
            }
        }

        public bool IsDirectoryEmpty(string path)
        {
            IEnumerable<string> items = Directory.EnumerateFileSystemEntries(path);
            using (IEnumerator<string> en = items.GetEnumerator())
            {
                return !en.MoveNext();
            }
        }

        private void BtnCheckUpdates_Click(object sender, EventArgs e)
        {
            if (BtnCheckUpdates.Text.Contains("Check"))
            {
                Title.Text = "Getting ready..";
                BtnCheckUpdates.Enabled = false;
                BtnCancel.Enabled = true;
                CheckForUpdates();
            }
            else if (BtnCheckUpdates.Text.Contains("Download"))
            {
                FileHelper.CreateDirectory(updateDirectory);
                DownloadFile(zipUpdateFile, updateDirectory + ".zip");
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (_webClient != null)
            {
                _webClient.CancelAsync();
                BtnCheckUpdates.Enabled = true;
            }
        }

        private void AppUpdater_Load(object sender, EventArgs e)
        {
            if (configuration.AutoUpdate == true)
            {
                CheckForUpdates();
            }
        }

        private void CheckForUpdates()
        {
            Description.Text = "";

            Updater updater = new Updater();
            if (updater.IsUpdateAvailable() == true)
            {
                Title.Text = "New Update available..!!";
                Description.Text = updater.getDashboardVersion();
                changelog = updater.getChangelog();

                Changelog.Visible = true;
            }
            else
            {
                Title.Text = "No updates found";
            }

            onFinishCheckForUpdates();
        }

        private void onFinishCheckForUpdates()
        {
            BtnCheckUpdates.Enabled = true;
            BtnCancel.Enabled = false;

            if (Title.Text.Contains("available"))
            {
                BtnCheckUpdates.Text = "Download updates";
            }
        }

        private void Changelog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var currentChangelog = string.Join(Environment.NewLine, changelog);
            MessageBox.Show(currentChangelog);
        }
    }
}