using System;
using System.Diagnostics;
using System.Windows.Forms;
using WinNetMeter.Core;
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
                FileHelper.SaveMove(AppDomain.CurrentDomain.BaseDirectory + @"update/Updater.exe", "Updater.exe");

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
