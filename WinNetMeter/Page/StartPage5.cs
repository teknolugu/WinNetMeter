using System;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using WinNetMeter.Helper;

namespace WinNetMeter.Page
{
    public partial class StartPage5 : UserControl
    {
        private string batchFileLocation = AppDomain.CurrentDomain.BaseDirectory + @"temp\toolbarInstaller.bat";
        private Integration integration = new Integration();
        public StartPage5()
        {
            InitializeComponent();
        }

        private void StartPage5_Load(object sender, EventArgs e)
        {

        }

        private void ToggleInstaller_CheckedChanged(object sender, EventArgs e)
        {

            switch (ToggleInstaller.Checked)
            {
                case true:
                    integration.InstallToolbar();
                    break;
                case false:
                    integration.UninstallToolbar();
                    break;
            }
        }
    }
}