using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using WinNetMeter.Helper;
using WinNetMeter.Core.Views;
using WinNetMeter.Core.Helper;
using WinNetMeter.Core.Model;

namespace WinNetMeter.UserControls.Controls
{
    public partial class AppUpdater : UserControl
    {
        private WebClient _webClient;
        private readonly Stopwatch sw = new Stopwatch();

        // Configure Server update
        private readonly string baseUrl = "https://cdn.winten.space";

        private readonly string zipUpdateURL;

        // Configure local update storage location
        private readonly string baseLocalApp = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        private readonly string extractedUpdateFileDir;
        private readonly string updateFile;

        private List<string> changelog;
        private RegistryManager registryManager = new RegistryManager();
        private Configuration configuration;

        public AppUpdater()
        {
            InitializeComponent();

            BtnCancel.Location = BtnCheckUpdates.Location;

            extractedUpdateFileDir = baseLocalApp + @"\WinTenDev\update";
            updateFile = baseLocalApp + @"\WinTenDev\temp\update.zip";

            configuration = registryManager.GetGeneralConfiguration();
            zipUpdateURL = $"{baseUrl}/products/win-netmeter/release/update.zip";
            //zipUpdateURL = $"{baseUrl}/products/win-netmeter/release/simulate/update.zip";
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

                onCancelUpdate();
                FileHelper.SafeDelete(updateFile);
            }
            else
            {
                Title.Text = "Extracting..";

                //Extract .zip file
                if (IsDirectoryEmpty(extractedUpdateFileDir) == false)
                {
                    foreach (string file in Directory.GetFiles(extractedUpdateFileDir))
                    {
                        FileHelper.SafeDelete(file);
                    }
                }
                ZipFile.ExtractToDirectory(updateFile, extractedUpdateFileDir);

                Title.Text = "Restarting App..";
                BtnCheckUpdates.Enabled = true;
                BtnCancel.Enabled = false;

                // Install updates
                UpdateHandler updateHandler = new UpdateHandler();
                updateHandler.InstallUpdate();
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
                BtnCheckUpdates.Visible = false;
                BtnCancel.Visible = false;
                CheckForUpdates();
            }
            else if (BtnCheckUpdates.Text.Contains("Download"))
            {
                BtnCancel.Visible = true;
                BtnCheckUpdates.Visible = false;
                // Create temp directory
                FileHelper.CreateDirectory(Path.GetDirectoryName(updateFile));

                // Create update directory
                FileHelper.CreateDirectory(extractedUpdateFileDir);

                //Download update file
                DownloadFile(zipUpdateURL, updateFile);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (_webClient != null)
            {
                _webClient.CancelAsync();
                BtnCheckUpdates.Visible = true;
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
            Title.Text = "Checking for updates..";

            Thread updateThread = new Thread(delegate ()
            {
                this.BeginInvoke(new MethodInvoker(delegate ()
                {
                    Description.Text = "";

                    Updater updater = new Updater();
                    if (updater.IsUpdateAvailable() == true)
                    {
                        Title.Text = "New Update available..!!";
                        Description.Text = $"v{updater.getDashboardVersion()}";
                        changelog = updater.getChangelog();

                        Changelog.Visible = true;
                    }
                    else
                    {
                        Title.Text = "Check for Updates";
                        Description.Text = "No updates found";
                        BtnCheckUpdates.Visible = true;
                    }

                    onFinishCheckForUpdates();
                }));
            });

            updateThread.Start();
        }

        #region Fire An Event..!!

        private void onCancelUpdate()
        {
            Title.Text = "Check for Updates";
            Description.ResetText();
            BtnCheckUpdates.Text = "Check for Updates";
            BtnCancel.Visible = false;
            Changelog.Visible = false;
        }

        private void onFinishCheckForUpdates()
        {
            BtnCheckUpdates.Visible = true;
            BtnCancel.Visible = false;

            if (Title.Text.Contains("available"))
            {
                BtnCheckUpdates.Text = "Download updates";
            }
        }

        #endregion Fire An Event..!!

        private void Changelog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormUpdater formUpdater = new FormUpdater();
            formUpdater.Show();
        }
    }
}