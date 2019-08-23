using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Threading;
using System.Windows.Forms;
using WinNetMeter.Core.Helper;
using WinNetMeter.Core.Model;
using WinNetMeter.Core.Services;
using WinNetMeter.Shell.Controller;
using WinNetMeter.Core.Views;
using WinNetMeter.Shell.Helper;

namespace WinNetMeter.Shell
{
    public partial class DeskBandUI : UserControl
    {
        #region DeclarationVariables

        private AdapterController adapterController;
        private NetworkMonitor monitor;
        private string Format;
        private RegistryManager dataServices = new RegistryManager();
        private StyleConfiguration Style;
        private DbManager dataManager = new DbManager();
        private Configuration configuration;
        private static DeskBandUI thisUI;
        private BackgroundWorker ConfigurationLoader;
        private Theme windowsTheme;
        private bool IsDark = false;
        private FrmFlyOut flyOut;

        public Theme WindowsTheme {
            get
            {
                return windowsTheme;
            }
            set
            {
                windowsTheme = value;
            }
        }

        #endregion DeclarationVariables

        #region Constructor

        public DeskBandUI(CSDeskBand.CSDeskBandWin w)
        {
            InitializeComponent();
            thisUI = this;

            configuration = dataServices.GetGeneralConfiguration();
            ApplyConfig();
        }

        #endregion Constructor

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

        #region Configuration Loader

        private void ApplyConfig()
        {
            try
            {
                if (configuration.Monitoring == true)
                {
                    Format = configuration.Format;

                    adapterController = new AdapterController(configuration.MonitoredAdapter);
                    monitor = new NetworkMonitor(adapterController);
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
                }
                else
                {
                    LblUpload.Text = "N/A";
                    LblDownload.Text = "N/A";
                }
            }
            catch (Exception ex)
            {
                LblUpload.Text = "N/A";
                LblDownload.Text = "N/A";
            }
        }

        #endregion Configuration Loader

        #region ThemeHandler

        private void ThemeChangedHandler(object sender, EventArgs e)
        {
            Thread ThemeChanger = new Thread(delegate ()
            {
                this.BeginInvoke(new MethodInvoker(delegate ()
                {

                    IsDark = GetTaskBarColor();
                    WindowsTheme = dataServices.GetTheme();
                    switch (WindowsTheme)
                    {

                        case Theme.Light:
                            SetLabelColor(Theme.Light);

                            break;

                        case Theme.Dark:
                            IsDark = GetTaskBarColor();

                            switch (IsDark)
                            {
                                case true:
                                    SetLabelColor(Theme.Dark);

                                    break;
                                case false:
                                    SetLabelColor(Theme.Light);

                                    break;
                            }

                            break;
                    }
                    ConfigureIcon();

                }));
            });

            ThemeChanger.Start();
        }


        private void ThemeLoad()
        {
            if (Style.Adaptive)
            {
                switch (WindowsTheme)
                {
                    case Theme.Light:
                        SetLabelColor(Theme.Light);
                        
                        break;

                    case Theme.Dark:

                        switch (IsDark)
                        {
                            case true:
                                SetLabelColor(Theme.Dark);

                                break;
                            case false:
                                SetLabelColor(Theme.Light);

                                break;
                        }

                        break;
                }

            }
        }

        private void SetLabelColor(Theme TaskBarTheme)
        {
            switch (TaskBarTheme)
            {
                case Theme.Dark:
                    LblUpload.ForeColor = Color.White;
                    LblDownload.ForeColor = Color.White;

                    break;
                case Theme.Light:
                    LblUpload.ForeColor = Color.Black;
                    LblDownload.ForeColor = Color.Black;

                    break;
            }
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            dataServices.SaveHwnd(this.Handle.ToString());

            // Get Network and style configuration
            ConfigurationLoader = new BackgroundWorker();
            ConfigurationLoader.RunWorkerCompleted += OnConfigurationLoaded;
            ConfigurationLoader.DoWork += (obj, ev) =>
            {
                this.BeginInvoke(new MethodInvoker(delegate ()
                  {
                      Style = dataServices.GetStyleConfiguration();
                      WindowsTheme = dataServices.GetTheme();

                  }));
            };

            ConfigurationLoader.RunWorkerAsync();
        }

        private void OnConfigurationLoaded(object sender, RunWorkerCompletedEventArgs e)
        {
            ApplyStyle();
        }

        private void ApplyStyle()
        {
           
            if (Style.Adaptive)
            {
                ThemeMonitor themeMonitorService = new ThemeMonitor();
                themeMonitorService.OnThemeChanged += ThemeChangedHandler;
                themeMonitorService.Start();
            }

            Thread StyleManager = new Thread(delegate ()
            {
                this.BeginInvoke(new MethodInvoker(delegate ()
                {
                    IsDark = GetTaskBarColor();

                    LblUpload.Font = new Font(Style.FontFamily, LblUpload.Font.Size);
                    LblDownload.Font = new Font(Style.FontFamily, LblDownload.Font.Size);

                    if (Style.Adaptive)
                    {
                        ThemeLoad();
                        ConfigureIcon();
                    }
                    else
                    {
                        ApplyStyleByConfig();
                        ConfigureIcon();
                    }

                }));
            });

            StyleManager.Start();
        }

        private void ApplyStyleByConfig()
        {
            LblUpload.ForeColor = ColorTranslator.FromHtml(Style.TextColor);
            LblDownload.ForeColor = LblUpload.ForeColor;

        }

        private void ConfigureIcon()
        {

            if (Style.Icon == IconStyle.Arrow && IsDark == false)
            {
                pictUpload.Image = Properties.Resources.up_black_16px;
                pictDownload.Image = Properties.Resources.down_black_16px;

                pictDownload.Location = new Point(11, 17);
            }
            else if (Style.Icon == IconStyle.Arrow && IsDark)
            {
                pictUpload.Image = Properties.Resources.up_white_16px;
                pictDownload.Image = Properties.Resources.down_white_16px;

                pictDownload.Location = new Point(11, 17);
            }
            else if (Style.Icon == IconStyle.TriangleArrow && IsDark == false)
            {
                pictUpload.Image = Properties.Resources.Triangle_up_arrow_black_16px;
                pictDownload.Image = Properties.Resources.Triangle_down_arrow_black_16px;
            }
            else if (Style.Icon == IconStyle.TriangleArrow && IsDark)
            {
                pictUpload.Image = Properties.Resources.Triangle_up_arrow_16px;
                pictDownload.Image = Properties.Resources.Triangle_down_arrow_16px;
            }
            else if (Style.Icon == IconStyle.Outline_Arrow && IsDark == false)
            {
                pictUpload.Image = Properties.Resources.outline_arrow_up_black_16px;
                pictDownload.Image = Properties.Resources.outline_arrow_down_black_16px;
            }
            else if (Style.Icon == IconStyle.Outline_Arrow && IsDark)
            {
                pictUpload.Image = Properties.Resources.outline_arrow_up_white_16px;
                pictDownload.Image = Properties.Resources.outline_arrow_down_white_16px;
            }
        }

        private bool GetTaskBarColor()
        {
            var taskBar = new TaskBarHelper();
            Color taskBarColor = taskBar.GetColourAt(taskBar.GetTaskbarPosition().Location);
            return taskBar.IsDarkColor((int)taskBarColor.R, (int)taskBarColor.G, (int)taskBarColor.B);
        }

        #endregion ThemeHandler

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

        private void ConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(dataServices.GetExecutableLocation());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataServices.Save("Monitoring", "True", ConfigurationType.GeneralConfiguration);
            RestartDesk();
        }

        private void OffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataServices.Save("Monitoring", "False", ConfigurationType.GeneralConfiguration);
            timerAuto.Stop();
            RestartDesk();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = dataServices.GetExecutableLocation();
            startInfo.Arguments = "-about";
            Process.Start(startInfo);
        }

        private void TimerTrafficLog_Tick(object sender, EventArgs e)
        {
            //SaveTrafficLog();
        }

        private void SaveTrafficLog()
        {
            var data = new Dictionary<string, string>()
            {
                {"date", DateTime.Now.ToString("yyyy-MM-dd") },
                {"time", DateTime.Now.ToString("HH:mm:ss") },
                {"download", adapterController.DownloadSpeed.ToString() },
                {"upload", adapterController.UploadSpeed.ToString() }
            };

            TrafficLogs.Save(data);
        }

        private void UserControl1_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void DeskBandUI_MouseHover(object sender, EventArgs e)
        {
            try
            {
                flyOut = new FrmFlyOut();
                flyOut.Show();
            }
            catch { }
            
        }

        private void DeskBandUI_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                if(flyOut != null)
                {
                    flyOut.Close();
                }
            }
            catch { }
        }
    }

    #region CustomComponent

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

    #endregion CustomComponent
}