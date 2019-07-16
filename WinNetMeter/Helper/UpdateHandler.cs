using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinNetMeter.Helper
{
    class UpdateHandler
    {
        public void InstallDashBoard()
        {
            Process.Start("Updater.exe");
            Application.Exit();
        }

    }
}
