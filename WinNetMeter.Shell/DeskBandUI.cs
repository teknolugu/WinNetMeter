using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Threading;
using System.Windows.Forms;
using WinNetMeter.Core.Controllers;
using WinNetMeter.Core.Helper;
using WinNetMeter.Shell.Controller;
using WinNetMeter.Core.Model;

namespace WinNetMeter.Shell
{
    public partial class DeskBandUI : UserControl
    {
        #region Declaration Variable

        private AdapterController adapterController;
        private NetworkMonitor monitor;
        private string Format;
        private RegistryManager registryManager = new RegistryManager();
        private StyleConfiguration Style;
        private DbManager dataManager = new DbManager();
        private Configuration configuration;
        private ThemeMonitor themeMonitor;
        private WindowsTheme theme;
        private InterfaceController interfaceController = new InterfaceController();

        public static PictureBox UploadIcon;
        public static PictureBox DownloadIcon;
        public static Label DownloadLabel;
        public static Label UploadLabel;
        public static UserControl deskUI;
 

        #endregion Declaration Variable

        public DeskBandUI(CSDeskBand.CSDeskBandWin w)
        {
            InitializeComponent();

            DownloadLabel = this.LblDownload;
            UploadLabel = this.LblUpload;
            UploadIcon = this.pictUpload;
            DownloadIcon = this.pictDownload;
            deskUI = this;

        }


        private void OnGettingConfiguration(object sender, DoWorkEventArgs e)
        {
            BeginInvoke(new MethodInvoker(delegate ()
            {
                configuration = registryManager.GetGeneralConfiguration();
            }));

            Style = registryManager.GetStyleConfiguration();
        }

        private void OnConfigurationLoaded(object sender, RunWorkerCompletedEventArgs e)
        {
            ApplyConfig();

            interfaceController.Style = this.Style;
            interfaceController.InitializeStyle();


            if (Style.Adaptive)
            { 
                themeMonitor = new ThemeMonitor();
                themeMonitor.OnThemeChanged += OnThemeChanged;
                CheckTheme();

                themeMonitor.Start();   
            }

        }

        private void OnThemeChanged(object sender, EventArgs e)
        {
            CheckTheme();
        }

        private void CheckTheme()
        {
            this.theme = themeMonitor.GetTheme();
            switch (theme)
            {
                case WindowsTheme.Dark:
                    interfaceController.darkTheme();
                    break;
                case WindowsTheme.Light:
                    interfaceController.lightTheme();
                    break;
            }
        }

        #region Core Controller

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == NativeMethods.WM_RESTART)
            {
                RestartDesk();
            }
            base.WndProc(ref m);
        }

        private void RestartDesk()
        {
            killTimer();
            this.RunConfigurationLoader();
        }

        private void killTimer()
        {
            timerAuto.Stop();
            timerKB.Stop();
            timerMB.Stop();
            try
            {
                monitor.Stop();
                monitor.Dispose();
            }
            catch { }
        }

        private void RunConfigurationLoader()
        {

            BackgroundWorker ConfigurationLoader = new BackgroundWorker();
            ConfigurationLoader.DoWork += OnGettingConfiguration;
            ConfigurationLoader.RunWorkerCompleted += OnConfigurationLoaded;
            ConfigurationLoader.RunWorkerAsync();
        }

        #endregion Core Controller

        #region ApplyConfiguration

        private void ApplyConfig()
        {
            try
            {
                switch (configuration.Monitoring)
                {
                    case true:
                        // Configure format
                        Format = configuration.Format;
                        // Initialize adapter
                        adapterController = new AdapterController(configuration.MonitoredAdapter);
                        monitor = new NetworkMonitor(adapterController);
                        // Start Monitoring
                        monitor.Start();

                        switch (Format)
                        {
                            case "Auto":
                                timerAuto.Start();
                                break;

                            case "KB":
                                timerKB.Start();
                                break;

                            case "MB":
                                timerMB.Start();
                                break;
                        }
                        break;

                    case false:
                        LblUpload.Text = "N/A";
                        LblDownload.Text = "N/A";
                        break;
                }
            }
            catch (Exception ex)
            {
                LblUpload.Text = "N/A";
                LblDownload.Text = "N/A";
            }
        }

      
        #endregion ApplyConfiguration

        #region Timer

        private void Timer1_Tick(object sender, EventArgs e)
        {
            LblUpload.Text = adapterController.UploadSpeedAutoFormatting;
            LblDownload.Text = adapterController.DownloadSpeedAutoFormatting;

            //SaveTrafficLog();
        }

        private void TimerKB_Tick(object sender, EventArgs e)
        {
            LblUpload.Text = string.Format("{0:n} KB/s", adapterController.UploadSpeedKBps);
            LblDownload.Text = string.Format("{0:n} KB/s", adapterController.DownloadSpeedKBps);
        }

        private void TimerMB_Tick(object sender, EventArgs e)
        {
            LblUpload.Text = string.Format("{0:n} MB/s", adapterController.UploadSpeedMBps);
            LblDownload.Text = string.Format("{0:n} MB/s", adapterController.DownloadSpeedMBps);
        }

        #endregion Timer

        private void ConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(registryManager.GetExecutableLocation());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            registryManager.Save("Monitoring", "True", ConfigurationType.GeneralConfiguration);
            RestartDesk();
        }

        private void OffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            registryManager.Save("Monitoring", "False", ConfigurationType.GeneralConfiguration);
            timerAuto.Stop();
            RestartDesk();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = registryManager.GetExecutableLocation();
            startInfo.Arguments = "-about";
            Process.Start(startInfo);
        }

        private void TimerTrafficLog_Tick(object sender, EventArgs e)
        {
            //SaveTrafficLog();
        }

        private void SaveTrafficLog()
        {
            //var data = new Dictionary<string, string>()
            //{
            //    {"date", DateTime.Now.ToString("yyyy-MM-dd") },
            //    {"time", DateTime.Now.ToString("HH:mm:ss") },
            //    {"download", adapterController.DownloadSpeed.ToString() },
            //    {"upload", adapterController.UploadSpeed.ToString() }
            //};

            //TrafficLogs.Save(data);
        }

        private void UserControl1_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void DeskBandUI_Load(object sender, EventArgs e)
        {
            registryManager.SaveHwnd(this.Handle.ToString());

            // Initialize Configuration
            this.RunConfigurationLoader();
        }
    }

    #region Custom Component

    public class MyLabel : Label
    {
        private TextRenderingHint _textRenderingHint = TextRenderingHint.SystemDefault;

        public TextRenderingHint TextRenderingHint
        {
            get { return _textRenderingHint; }
            set { _textRenderingHint = value; }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.TextRenderingHint = _textRenderingHint;
            base.OnPaint(e);
        }
    }

    #endregion Custom Component

}