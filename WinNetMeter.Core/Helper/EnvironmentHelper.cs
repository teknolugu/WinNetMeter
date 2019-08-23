using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinNetMeter.Core.Helper
{
    public class EnvironmentHelper
    {
        public static bool IsUwpApp()
        {
            var helpers = new DesktopBridge.Helpers();
            return helpers.IsRunningAsUwp();
        }
    }
}