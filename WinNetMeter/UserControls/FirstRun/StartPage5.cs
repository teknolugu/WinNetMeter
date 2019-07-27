using System;
using System.Windows.Forms;
using WinNetMeter.Core;
using WinNetMeter.Helper;

namespace WinNetMeter.UserControls.FirstRun
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
            RegistryManager registryManager = new RegistryManager();
            registryManager.SaveExecutableLocation();
        }

        private void ToggleInstaller_CheckedChanged(object sender, EventArgs e)
        {
            switch (ToggleInstaller.Checked)
            {
                case true:
                    integration.InstallToolbar();

                    // Show the deskband
                    ShellController shellController = new ShellController();
                    shellController.callDeskband();
                    break;

                case false:
                    integration.UninstallToolbar();
                    break;
            }
        }
    }
}