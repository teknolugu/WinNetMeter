using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using CSDeskBand;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinNetMeter.Shell
{
    [ComVisible(true)]
    [Guid("0F0283BE-FADD-4EAA-9984-9C1822AE469A")]
    [CSDeskBandRegistration(Name = "WinNetMeter", ShowDeskBand = true)]
    public class Deskband : CSDeskBandWin
    {
        private static Control _control;

        public Deskband()
        {
            Options.MinHorizontalSize = new Size(100, 30);
            Options.
            _control = new UserControl1(this);
        }

        protected override Control Control => _control;
    }
}
