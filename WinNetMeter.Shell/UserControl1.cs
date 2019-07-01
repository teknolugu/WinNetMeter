using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WinNetMeter.Shell.Controller;
using WinNetMeter.Shell.Helper;
using System.IO;
using System.Threading;
using WinNetMeter.Shell.Model;
using System.Drawing.Text;

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

        public UserControl1(CSDeskBand.CSDeskBandWin w)
        {
            InitializeComponent();
            ConfigureStyle();
        }

        protected override void WndProc(ref Message m)
        {
            if(m.Msg == NativeMethods.WM_RESTART)
            {
                RestartDesk();
            }
            base.WndProc(ref m);
        }

        private void RestartDesk()
        {
            this.Controls.Clear();
            InitializeComponent();
            UserControl1_Load(new EventArgs(), new EventArgs());
            ConfigureStyle();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            registryManager.SaveHwnd(this.Handle.ToString());
            
            //get taskbar color

            var taskBar = new TaskBarHelper();
            Color taskBarColor = taskBar.GetColourAt(taskBar.GetTaskbarPosition().Location);

            bool IsDark = taskBar.IsDarkColor((int)taskBarColor.R, (int)taskBarColor.G, (int)taskBarColor.B);

            if (styleConfiguration.Icon == IconStyle.Arrow && IsDark == false)
            {
                pictDownload.Image = Properties.Resources.down_black_16px;
                pictUpload.Image = Properties.Resources.up_black_16px;

                pictDownload.Location = new Point(10, 14);
            }
            else if (styleConfiguration.Icon == IconStyle.Arrow && IsDark)
            {
                pictDownload.Image = Properties.Resources.down_white_16px;
                pictUpload.Image = Properties.Resources.up_white_16px;

                pictDownload.Location = new Point(10, 14);
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

            var config = registryManager.GetGeneralConfiguration();

            if (config.Monitoring == true)
            {
                Format = config.Format;

                adapterController = new AdapterController(config.MonitoredAdapter);
                monitor = new NetworkMonitor(adapterController);
                monitor.Start();
                timer1.Start();
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
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            switch (Format)
            {
                case "Auto":
                    {
                        LblUpload.Text = adapterController.UploadSpeedAutoFormatting;
                        LblDownload.Text = adapterController.DownloadSpeedAutoFormatting;
                        break;
                    }
                case "KB":
                    {
                        LblUpload.Text = string.Format("{0:n} KB/s", adapterController.UploadSpeedKBps);
                        LblDownload.Text = string.Format("{0:n} KB/s", adapterController.DownloadSpeedKBps);
                        break;
                    }
                case "MB":
                    {
                        LblUpload.Text = string.Format("{0:n} MB/s", adapterController.UploadSpeedMBps);
                        LblDownload.Text = string.Format("{0:n} MB/s", adapterController.DownloadSpeedMBps);
                        break;
                    }
            }
        }

        private void LblUpload_Click(object sender, EventArgs e)
        {
            RestartDesk();
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