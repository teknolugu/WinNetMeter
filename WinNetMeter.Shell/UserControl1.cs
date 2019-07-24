using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using WinNetMeter.Shell.Controller;
using WinNetMeter.Shell.Helper;
using WinNetMeter.Shell.Model;

namespace WinNetMeter.Shell
{
    public partial class UserControl1 : UserControl
    {
        private AdapterController adapterController;
        private NetworkMonitor monitor;
        private string Format;
        private RegistryManager registryManager = new RegistryManager();
        private StyleConfiguration styleConfiguration;
        private DbManager dataManager = new DbManager();
        private Configuration configuration;

        public UserControl1(CSDeskBand.CSDeskBandWin w)
        {
            InitializeComponent();
            ConfigureStyle();
        }

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
            Load_Config();
            ConfigureStyle();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            registryManager.SaveHwnd(this.Handle.ToString());

            Load_Config();
            ConfigureStyle();
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

        private void Load_Config()
        {
            configuration = registryManager.GetGeneralConfiguration();

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
                LblDownload.Text = "......";
                LblUpload.Text = "......";
            }
        }

        private void ConfigureStyle()
        {
            this.BackColor = ColorTranslator.FromHtml("#000");

            styleConfiguration = registryManager.GetStyleConfiguration();

            LblDownload.ForeColor = ColorTranslator.FromHtml(styleConfiguration.TextColor);
            LblUpload.ForeColor = ColorTranslator.FromHtml(styleConfiguration.TextColor);

            LblDownload.Font = new Font(styleConfiguration.FontFamily, LblDownload.Font.Size);
            LblUpload.Font = new Font(styleConfiguration.FontFamily, LblUpload.Font.Size);
            bool IsDark = false;

            try
            {
                var taskBar = new TaskBarHelper();
                Color taskBarColor = taskBar.GetColourAt(taskBar.GetTaskbarPosition().Location);
                IsDark = taskBar.IsDarkColor((int)taskBarColor.R, (int)taskBarColor.G, (int)taskBarColor.B);
            }
            catch
            {
                goto setIcon;
            }

        setIcon:

            if (styleConfiguration.Icon == IconStyle.Arrow && IsDark == false)
            {
                pictDownload.Image = Properties.Resources.down_black_16px;
                pictUpload.Image = Properties.Resources.up_black_16px;

                pictDownload.Location = new Point(10, 19);
            }
            else if (styleConfiguration.Icon == IconStyle.Arrow && IsDark)
            {
                pictDownload.Image = Properties.Resources.down_white_16px;
                pictUpload.Image = Properties.Resources.up_white_16px;

                pictDownload.Location = new Point(10, 19);
            }
            else if (styleConfiguration.Icon == IconStyle.TriangleArrow && IsDark == false)
            {
                pictDownload.Image = Properties.Resources.Triangle_down_arrow_black_16px;
                pictUpload.Image = Properties.Resources.Triangle_up_arrow_black_16px;
            }
            else if (styleConfiguration.Icon == IconStyle.TriangleArrow && IsDark)
            {
                pictDownload.Image = Properties.Resources.Triangle_down_arrow_16px;
                pictUpload.Image = Properties.Resources.Triangle_up_arrow_16px;
            }
            else if (styleConfiguration.Icon == IconStyle.Outline_Arrow && IsDark == false)
            {
                pictDownload.Image = Properties.Resources.outline_arrow_down_black_16px;
                pictUpload.Image = Properties.Resources.outline_arrow_up_black_16px;
            }
            else if (styleConfiguration.Icon == IconStyle.Outline_Arrow && IsDark)
            {
                pictDownload.Image = Properties.Resources.outline_arrow_down_white_16px;
                pictUpload.Image = Properties.Resources.outline_arrow_up_white_16px;
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            LblUpload.Text = adapterController.UploadSpeedAutoFormatting;
            LblDownload.Text = adapterController.DownloadSpeedAutoFormatting;
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
            Process.Start(registryManager.GetExecutableLocation());
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
    }

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
}