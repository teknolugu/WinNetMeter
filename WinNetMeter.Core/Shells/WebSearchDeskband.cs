using System.Runtime.InteropServices;
using System.Windows.Forms;
using SharpShell.Attributes;
using SharpShell.SharpDeskBand;

namespace WinNetMeter.Core.Shells
{
    [ComVisible(true)]
    [DisplayName("Web Search")]
    public class WebSearchDeskband : SharpDeskBand
    {
        protected override UserControl CreateDeskBand()
        {
            return new WebSearchUI();
        }

        protected override BandOptions GetBandOptions()
        {
            return new BandOptions
            {
                HasVariableHeight = false,
                IsSunken = false,
                ShowTitle = true,
                Title = "Web Search",
                UseBackgroundColour = false,
                AlwaysShowGripper = true
            };
        }
    }
}