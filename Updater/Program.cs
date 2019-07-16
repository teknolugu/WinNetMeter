using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Updater.Helper;

namespace Updater
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string baseExe = "WinNetMeter.exe";
            string baseShell = "WinNetMeter.Shell.dll";
            string updateDirectory = AppDomain.CurrentDomain.BaseDirectory + @"update";
            string exeUpdateFile = updateDirectory + @"\" + baseExe;
            string shellUpdateFile = updateDirectory + @"\" + baseShell;

            if (File.Exists(exeUpdateFile) && File.Exists(shellUpdateFile))
            {
                Console.WriteLine("Updating app..");

                FileHelper.SafeDelete($"{baseExe}");

                Console.WriteLine("Installing dashboard..");
                FileHelper.SaveMove(exeUpdateFile, $"{baseExe}");

                Console.WriteLine("Installing shell..");

                // Uninstalling and installing new shell
                // Uninstall Toolbar first
                Integration integration = new Integration();
                integration.UninstallToolbar();

                // Kill explorer.exe process
                foreach (Process process in Process.GetProcessesByName("explorer"))
                {
                    process.Kill();
                }


                // Start the explorer.exe again
                Process.Start("explorer.exe");

                // Delete shell old file
                FileHelper.SafeDelete($"{baseShell}");
                FileHelper.SaveMove(shellUpdateFile, $"{baseShell}");

                integration.InstallToolbar();


                Console.WriteLine("Finished..");
                Thread.Sleep(1000);

                Process.Start($"{baseExe}");
                Environment.Exit(0);
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}