using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinNetMeter
{
    static class Program
    {
        static Mutex m;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Properties.Settings.Default.Reset();
            bool first = false;
            m = new Mutex(true, Application.ProductName.ToString(), out first);
            if ((first))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                if (Properties.Settings.Default.FirstLaunch == true)
                {
                    Application.Run(new Setup());
                }
                else
                {
                    Application.Run(new Main());
                }
            }
            else
            {
                MessageBox.Show(Application.ProductName.ToString() + " Already running");
            }

           

        }
    }
}
