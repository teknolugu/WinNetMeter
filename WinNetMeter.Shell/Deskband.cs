using System;
using System.Drawing;
using System.Runtime.InteropServices;
using CSDeskBand;
using System.Windows.Forms;

namespace WinNetMeter.Shell
{
    [ComVisible(true)]
    [Guid("0F0283BE-FADD-4EAA-9984-9C1822AE469A")]
    [CSDeskBandRegistration(Name = "WinNetMeter", ShowDeskBand = false)]
    public class Deskband : CSDeskBandWin
    {
        private static Control _control;

        public Deskband()
        {
            Options.MinHorizontalSize = new Size(111, 30);
            _control = new DeskBandUI(this);
        }

        protected override Control Control => _control;
    }
}
