using System.Drawing;
using WinNetMeter.Core.Model;

namespace WinNetMeter.Shell.Controller
{
    class InterfaceController
    {
        public void darkTheme(StyleConfiguration style)
        {
            DeskBandUI.DownloadLabel.ForeColor = Color.White;
            DeskBandUI.UploadLabel.ForeColor = Color.White;

            if (style.Icon == IconStyle.Arrow)
            {
                DeskBandUI.UploadIcon.Image = Properties.Resources.up_white_16px;
                DeskBandUI.DownloadIcon.Image = Properties.Resources.down_white_16px;
            }
            else if (style.Icon == IconStyle.Outline_Arrow)
            {
                DeskBandUI.UploadIcon.Image = Properties.Resources.outline_arrow_up_white_16px;
                DeskBandUI.DownloadIcon.Image = Properties.Resources.outline_arrow_down_white_16px;
            }
            else if (style.Icon == IconStyle.TriangleArrow)
            {
                DeskBandUI.UploadIcon.Image = Properties.Resources.Triangle_up_arrow_16px;
                DeskBandUI.DownloadIcon.Image = Properties.Resources.Triangle_down_arrow_16px;
            }
        }

        public void lightTheme(StyleConfiguration style)
        {
            DeskBandUI.DownloadLabel.ForeColor = Color.Black;
            DeskBandUI.UploadLabel.ForeColor = Color.Black;

            if (style.Icon == IconStyle.Arrow)
            {
                DeskBandUI.UploadIcon.Image = Properties.Resources.up_black_16px;
                DeskBandUI.DownloadIcon.Image = Properties.Resources.down_black_16px;
            }
            else if (style.Icon == IconStyle.Outline_Arrow)
            {
                DeskBandUI.UploadIcon.Image = Properties.Resources.outline_arrow_up_black_16px;
                DeskBandUI.DownloadIcon.Image = Properties.Resources.outline_arrow_down_black_16px;
            }
            else if (style.Icon == IconStyle.TriangleArrow)
            {
                DeskBandUI.UploadIcon.Image = Properties.Resources.Triangle_up_arrow_black_16px;
                DeskBandUI.DownloadIcon.Image = Properties.Resources.Triangle_down_arrow_black_16px;
            }
        }
    }
}
