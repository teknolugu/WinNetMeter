using System.ComponentModel;
using System.Windows.Forms;

namespace WinNetMeter.Components
{
    [Description("The ButtonEx is extended from Button base"), Category("Common Control")]
    internal class ButtonEx : Button
    {
        public override void NotifyDefault(bool value)
        {
            base.NotifyDefault(false);
        }
    }
}