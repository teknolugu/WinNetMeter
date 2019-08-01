using System;
using System.Diagnostics;
using System.Windows.Forms;
using WinNetMeter.Core.Helper;
namespace WinNetMeter.Helper
{
    class UpdateHandler
    {
        public void InstallUpdate()
        {
            try
            {
                // Uninstall shell
                Integration integration = new Integration();
                integration.UninstallToolbar();

                FileHelper.SafeDelete("Updater.exe");
                FileHelper.SaveMove(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\WinTenDev\update\Updater.exe", "Updater.exe");

                // Running updater.exe for processing update files
                Process.Start("Updater.exe");
                Application.Exit();
            }catch(Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message, "Unable to start updater", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         
        }

    }
}
