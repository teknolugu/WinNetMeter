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

            // Configure update directory
            string exeUpdateFile = AppDomain.CurrentDomain.BaseDirectory + @"update/WinNetMeter.exe";
            string shellUpdateFile = AppDomain.CurrentDomain.BaseDirectory + @"update/WinNetMeter.Shell.dll";

            
            if (File.Exists(exeUpdateFile) && File.Exists(shellUpdateFile))
            {

                // Kill explorer.exe process
                foreach (Process process in Process.GetProcessesByName("explorer"))
                {
                    process.Kill();
                }

                Console.WriteLine("Updating app..");

                // Start the explorer.exe again
                Process.Start("explorer.exe");

                FileHelper.SafeDelete($"{baseExe}");

                Console.WriteLine("Installing dashboard..");
                FileHelper.SaveMove(exeUpdateFile, $"{baseExe}");

                Console.WriteLine("Installing shell..");

                // nstalling new shell
                Integration integration = new Integration();

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