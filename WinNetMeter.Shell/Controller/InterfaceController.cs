using System.Drawing;
using System.Windows.Forms;
using WinNetMeter.Core.Helper;
using WinNetMeter.Core.Model;

namespace WinNetMeter.Shell.Controller
{
    class InterfaceController
    {
        private StyleConfiguration style;

        public StyleConfiguration Style { get => style; set => style = value; }

        public void darkTheme()
        {
            DeskBandUI.DownloadLabel.ForeColor = Color.White;
            DeskBandUI.UploadLabel.ForeColor = Color.White;

            if (Style.Icon == IconStyle.Arrow)
            {
                DeskBandUI.UploadIcon.Image = Properties.Resources.up_white_16px;
                DeskBandUI.DownloadIcon.Image = Properties.Resources.down_white_16px;
            }
            else if (Style.Icon == IconStyle.Outline_Arrow)
            {
                DeskBandUI.UploadIcon.Image = Properties.Resources.outline_arrow_up_white_16px;
                DeskBandUI.DownloadIcon.Image = Properties.Resources.outline_arrow_down_white_16px;
            }
            else if (Style.Icon == IconStyle.TriangleArrow)
            {
                DeskBandUI.UploadIcon.Image = Properties.Resources.Triangle_up_arrow_16px;
                DeskBandUI.DownloadIcon.Image = Properties.Resources.Triangle_down_arrow_16px;
            }
        }

        public void lightTheme()
        {
            DeskBandUI.DownloadLabel.ForeColor = Color.Black;
            DeskBandUI.UploadLabel.ForeColor = Color.Black;

            if (Style.Icon == IconStyle.Arrow)
            {
                DeskBandUI.UploadIcon.Image = Properties.Resources.up_black_16px;
                DeskBandUI.DownloadIcon.Image = Properties.Resources.down_black_16px;
            }
            else if (Style.Icon == IconStyle.Outline_Arrow)
            {
                DeskBandUI.UploadIcon.Image = Properties.Resources.outline_arrow_up_black_16px;
                DeskBandUI.DownloadIcon.Image = Properties.Resources.outline_arrow_down_black_16px;
            }
            else if (Style.Icon == IconStyle.TriangleArrow)
            {
                DeskBandUI.UploadIcon.Image = Properties.Resources.Triangle_up_arrow_black_16px;
                DeskBandUI.DownloadIcon.Image = Properties.Resources.Triangle_down_arrow_black_16px;
            }
        }

        public void InitializeStyle()
        {
            DeskBandUI.deskUI.BackColor = ColorTranslator.FromHtml("#000");

            if (Style.Adaptive)
            {
                if (IsTaskBarDark())
                {
                    this.darkTheme();
                }
                else
                {
                    this.lightTheme();
                }
            }
            else
            {
                DeskBandUI.UploadLabel.ForeColor = ColorTranslator.FromHtml(Style.TextColor);
                DeskBandUI.DownloadLabel.ForeColor = DeskBandUI.UploadLabel.ForeColor;

                DeskBandUI.UploadLabel.Font = new Font(Style.FontFamily, DeskBandUI.UploadLabel.Font.Size);
                DeskBandUI.DownloadLabel.Font = DeskBandUI.UploadLabel.Font;

                bool IsDark = this.IsTaskBarDark();

                if (Style.Icon == IconStyle.Arrow && IsDark)
                {
                    DeskBandUI.UploadIcon.Image = Properties.Resources.up_white_16px;
                    DeskBandUI.DownloadIcon.Image = Properties.Resources.down_white_16px;
                }
                else if (Style.Icon == IconStyle.Arrow && IsDark == false)
                {
                    DeskBandUI.UploadIcon.Image = Properties.Resources.up_black_16px;
                    DeskBandUI.DownloadIcon.Image = Properties.Resources.down_black_16px;
                }
                else if (Style.Icon == IconStyle.Outline_Arrow && IsDark)
                {
                    DeskBandUI.UploadIcon.Image = Properties.Resources.outline_arrow_up_white_16px;
                    DeskBandUI.DownloadIcon.Image = Properties.Resources.outline_arrow_down_white_16px;
                }
                else if (Style.Icon == IconStyle.Outline_Arrow && IsDark == false)
                {
                    DeskBandUI.UploadIcon.Image = Properties.Resources.outline_arrow_up_black_16px;
                    DeskBandUI.DownloadIcon.Image = Properties.Resources.outline_arrow_down_black_16px;
                }
                else if (Style.Icon == IconStyle.TriangleArrow && IsDark)
                {
                    DeskBandUI.UploadIcon.Image = Properties.Resources.Triangle_up_arrow_16px;
                    DeskBandUI.DownloadIcon.Image = Properties.Resources.Triangle_down_arrow_16px;
                }
                else if (Style.Icon == IconStyle.TriangleArrow && IsDark == false)
                {
                    DeskBandUI.UploadIcon.Image = Properties.Resources.Triangle_up_arrow_black_16px;
                    DeskBandUI.DownloadIcon.Image = Properties.Resources.Triangle_down_arrow_black_16px;
                }
            }
        }

        public bool IsTaskBarDark()
        {
            var taskBar = new TaskBarHelper();
            Color taskBarColor = taskBar.GetColourAt(taskBar.GetTaskbarPosition().Location);
            return taskBar.IsDarkColor((int)taskBarColor.R, (int)taskBarColor.G, (int)taskBarColor.B);
        }

    }
}
