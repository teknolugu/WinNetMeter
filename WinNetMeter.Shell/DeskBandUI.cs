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

        #endregion Declaration Variable

        public DeskBandUI(CSDeskBand.CSDeskBandWin w)
        {
            InitializeComponent();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            MessageBox.Show(Registry.CurrentUser + @"\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize");
            MessageBox.Show(registryManager.ReadFromRegistry(Registry.CurrentUser + @"\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", "SystemUsesLightTheme").ToString());
            registryManager.SaveHwnd(this.Handle.ToString());

            // Let's Initialize Configuration
            BackgroundWorker ConfigurationLoader = new BackgroundWorker();
            ConfigurationLoader.DoWork += OnGettingConfiguration;
            ConfigurationLoader.RunWorkerCompleted += OnConfigurationLoaded;
            ConfigurationLoader.RunWorkerAsync();
        }

        private void OnGettingConfiguration(object sender, DoWorkEventArgs e)
        {
            BeginInvoke(new MethodInvoker(delegate ()
            {
                configuration = registryManager.GetGeneralConfiguration();
                Style = registryManager.GetStyleConfiguration();
            }));
        }

        private void OnConfigurationLoaded(object sender, RunWorkerCompletedEventArgs e)
        {
            ApplyConfig();

            if (Style.Adaptive)
            {
                MessageBox.Show("yes is adaptive");
                themeMonitor = new ThemeMonitor();
                themeMonitor.OnThemeChanged += OnThemeChanged;

                themeMonitor.Start();
            }

            ApplyStyle();
        }

        private void OnThemeChanged(object sender, EventArgs e)
        {
            MessageBox.Show("theme changed");
            this.theme = themeMonitor.GetTheme();
            switch (theme)
            {
                case WindowsTheme.Dark:
                    MessageBox.Show("theme is dark");
                    break;
                case WindowsTheme.Light:
                    MessageBox.Show("theme is light");
                    break;
            }
        }

        private bool IsTaskBarDark()
        {
            var taskBar = new TaskBarHelper();
            Color taskBarColor = taskBar.GetColourAt(taskBar.GetTaskbarPosition().Location);
            return taskBar.IsDarkColor((int)taskBarColor.R, (int)taskBarColor.G, (int)taskBarColor.B);
        }

        private void ApplyTheme(WindowsTheme theme)
        {

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
            this.Controls.Clear();
            InitializeComponent();

            killTimer();
            ApplyConfig();

            ApplyStyle();
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

        private void ApplyStyle()
        {
            Thread styleThread = new Thread(delegate ()
            {
                this.BeginInvoke(new MethodInvoker(delegate ()
                {
                    this.BackColor = ColorTranslator.FromHtml("#000");

                    LblUpload.ForeColor = ColorTranslator.FromHtml(Style.TextColor);
                    LblDownload.ForeColor = LblUpload.ForeColor;

                    LblUpload.Font = new Font(Style.FontFamily, LblUpload.Font.Size);
                    LblDownload.Font = LblUpload.Font;

                    bool IsDark = this.IsTaskBarDark();

                    if (Style.Icon == IconStyle.Arrow && IsDark)
                    {
                        pictUpload.Image = Properties.Resources.up_white_16px;
                        pictDownload.Image = Properties.Resources.down_white_16px;
                    }
                    else if (Style.Icon == IconStyle.Arrow && IsDark == false)
                    {
                        pictUpload.Image = Properties.Resources.up_black_16px;
                        pictDownload.Image = Properties.Resources.down_black_16px;
                    }
                    else if (Style.Icon == IconStyle.Outline_Arrow && IsDark)
                    {
                        pictUpload.Image = Properties.Resources.outline_arrow_up_white_16px;
                        pictDownload.Image = Properties.Resources.outline_arrow_down_white_16px;
                    }
                    else if (Style.Icon == IconStyle.Outline_Arrow && IsDark == false)
                    {
                        pictUpload.Image = Properties.Resources.outline_arrow_up_black_16px;
                        pictDownload.Image = Properties.Resources.outline_arrow_down_black_16px;
                    }
                    else if (Style.Icon == IconStyle.TriangleArrow && IsDark)
                    {
                        pictUpload.Image = Properties.Resources.Triangle_up_arrow_16px;
                        pictDownload.Image = Properties.Resources.Triangle_down_arrow_16px;
                    }
                    else if (Style.Icon == IconStyle.TriangleArrow && IsDark == false)
                    {
                        pictUpload.Image = Properties.Resources.Triangle_up_arrow_black_16px;
                        pictDownload.Image = Properties.Resources.Triangle_down_arrow_black_16px;
                    }
                }));
            });

            styleThread.Start();
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