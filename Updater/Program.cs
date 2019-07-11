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
            string baseExe = "WinNetMeter";
            string baseShell = "WinNetMeter.Shell";

            if (File.Exists($"{baseExe}.aim") && File.Exists($"{baseExe}.aim"))
            {
                Console.WriteLine("Updating app..");

                //FileHelper.SafeDelete($"{baseExe}.exe");
                //FileHelper.SafeDelete($"{baseShell}.dll");

                Console.WriteLine("Preparing..");
                FileHelper.SafeDelete($"{baseExe}.exe.old");
                FileHelper.SafeDelete($"{baseShell}.dll.old");

                Console.WriteLine("Backing up..");
                FileHelper.SaveMove($"{baseExe}.exe", $"{baseExe}.exe.old");
                FileHelper.SaveMove($"{baseShell}.dll", $"{baseShell}.dll.old");

                Console.WriteLine("Installing..");
                FileHelper.SaveMove($"{baseExe}.aim", $"{baseExe}.exe");
                FileHelper.SaveMove($"{baseShell}.aim", $"{baseShell}.dll");

                Console.WriteLine("Finished..");
                Thread.Sleep(1000);

                Process.Start($"{baseExe}.exe");
                Environment.Exit(0);
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}