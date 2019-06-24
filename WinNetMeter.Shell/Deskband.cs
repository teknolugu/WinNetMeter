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
    [CSDeskBand.CSDeskBandRegistration(Name = "WinNetMeter", ShowDeskBand = false)]
    public class Deskband : CSDeskBand.CSDeskBandWin
    {
        private static Control _control;

        public Deskband()
        {
            Options.MinHorizontalSize = new Size(100, 30);
            _control = new UserControl1(this);
        }

        protected override Control Control => _control;
    }
}
