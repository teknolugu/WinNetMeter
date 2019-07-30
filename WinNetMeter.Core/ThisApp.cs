using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using WinNetMeter.Helper;

namespace WinNetMeter.Core
{
    internal class ThisApp
    {
        public static void InstallUpdates()
        {
            string batUpdates = "install.bat";
            string baseExe = "WinNetMeter";
            string baseShell = "WinNetMeter.Shell";

            var FrameworkLocation = Environment.GetEnvironmentVariable("windir") + @"\Microsoft.NET\Framework64\v4.0.30319";
            var installToolbar = "";
            if (Directory.Exists(FrameworkLocation))
            {
                installToolbar = $"cd {FrameworkLocation}" +
                    $"\nregasm /codebase " + "\"" + AppDomain.CurrentDomain.BaseDirectory + @"WinNetMeter.Shell.dll" + "\"";
            }
            else
            {
                MessageBox.Show("May problem with Windows 32 Bit", "Updater");
            }

            string forBat =
               $"taskkill /f /im {baseExe}.exe" +
               $"\nmove {baseExe}.exe {baseExe}.exe.old" + // Backup old .exe
               $"\ncopy {baseShell}.dll {baseShell}.exe.old" + // backup old .dll
               $"\nmove {baseExe}.aim {baseExe}.exe" + // Move to new .exe
               $"\nmove {baseShell}.aim {baseShell}.dll" +
               $"\n{installToolbar}" +
               $"\ndel {baseExe}.aim" +
               $"\ndel {baseShell}.aim" +
               $"\ndel {batUpdates}" +
               $"\n{baseExe}.exe"; // Move to new .dll

            Integration integration = new Integration();
            integration.UninstallToolbar();

            FileHelper.SafeDelete(batUpdates);
            FileHelper.WriteBatFile(batUpdates, forBat, false);

            runBat(batUpdates);
            //Application.Exit();
        }

        public static bool IsUwpApp()
        {
            var helpers = new DesktopBridge.Helpers();
            return helpers.IsRunningAsUwp();
        }

        private static void runBat(string path)
        {
            //Executing the .bat file
            ProcessStartInfo process = new ProcessStartInfo();
            process.WorkingDirectory = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory + @path);
            process.FileName = "install.bat";
            process.Verb = "runas";
            process.WindowStyle = ProcessWindowStyle.Hidden;
            try
            {
                Process.Start(process);
            }
            catch { }
        }
    }
}