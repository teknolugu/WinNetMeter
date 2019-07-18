using System;
using System.Diagnostics;
using System.IO;
using WinNetMeter.Helper;

namespace WinNetMeter.Core
{
    internal class Integration
    {
        private string batchFileLocation = AppDomain.CurrentDomain.BaseDirectory + @"temp\toolbarInstaller.bat";
        private string FrameworkLocation;
        private StreamWriter writer;

        public Integration()
        {
        }

        private void WriteBatFile(string value, bool NewLine)
        {
            writer = new StreamWriter(batchFileLocation, true);
            if (NewLine) writer.Write(Environment.NewLine);

            //Write the .bat script
            writer.Write(value);

            //Close the tread
            writer.Close();
        }

        public void InstallToolbar()
        {
            //Create .bat file for toolbar installation
            if (!Directory.Exists(Path.GetDirectoryName(batchFileLocation)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(batchFileLocation));
            }

            File.Create(batchFileLocation).Close();

            //Get .NET Framework path Information
            if (Environment.Is64BitOperatingSystem)
            {
                FrameworkLocation = Environment.GetEnvironmentVariable("windir") + @"\Microsoft.NET\Framework64\v4.0.30319";
                if (Directory.Exists(FrameworkLocation))
                {
                    WriteBatFile("cd " + FrameworkLocation, false);
                    WriteBatFile("regasm /codebase " + "\"" + AppDomain.CurrentDomain.BaseDirectory + @"WinNetMeter.Shell.dll" + "\"", true);
                }
            }
            else
            {
                FrameworkLocation = Environment.GetEnvironmentVariable("windir") + @"\Microsoft.NET\Framework\v4.0.30319";
                if (Directory.Exists(FrameworkLocation))
                {
                    WriteBatFile("cd " + FrameworkLocation, false);
                    WriteBatFile("regasm /codebase " + "\"" + AppDomain.CurrentDomain.BaseDirectory + @"WinNetMeter.Shell.dll" + "\"", true);
                }
            }

            //Executing the .bat file
            runBat();
        }

        public void UninstallToolbar()
        {
            //Create .bat file for toolbar installation
            if (!Directory.Exists(Path.GetDirectoryName(batchFileLocation)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(batchFileLocation));
            }
            File.Create(batchFileLocation).Close();

            //Get .NET Framework path Information
            if (Environment.Is64BitOperatingSystem)
            {
                FrameworkLocation = Environment.GetEnvironmentVariable("windir") + @"\Microsoft.NET\Framework64\v4.0.30319";
            }
            else
            {
                FrameworkLocation = Environment.GetEnvironmentVariable("windir") + @"\Microsoft.NET\Framework\v4.0.30319";
            }

            if (Directory.Exists(FrameworkLocation))
            {
                WriteBatFile("cd " + FrameworkLocation, false);
                WriteBatFile("regasm /unregister " + "\"" + AppDomain.CurrentDomain.BaseDirectory + @"WinNetMeter.Shell.dll" + "\"", true);
            }

            //Executing the .bat file
            runBat();
        }

        public void ReinstallToolbar()
        {
            //Create .bat file for toolbar installation
            if (!Directory.Exists(Path.GetDirectoryName(batchFileLocation)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(batchFileLocation));
            }
            File.Create(batchFileLocation).Close();

            //Get .NET Framework path Information
            if (Environment.Is64BitOperatingSystem)
            {
                FrameworkLocation = Environment.GetEnvironmentVariable("windir") + @"\Microsoft.NET\Framework64\v4.0.30319";
            }
            else
            {
                FrameworkLocation = Environment.GetEnvironmentVariable("windir") + @"\Microsoft.NET\Framework\v4.0.30319";
            }

            if (Directory.Exists(FrameworkLocation))
            {
                WriteBatFile("cd " + FrameworkLocation, false);

                // Unregister .dll
                WriteBatFile("regasm /unregister " + "\"" + AppDomain.CurrentDomain.BaseDirectory + @"WinNetMeter.Shell.dll" + "\"", true);

                // Register .dll
                WriteBatFile("regasm /codebase " + "\"" + AppDomain.CurrentDomain.BaseDirectory + @"WinNetMeter.Shell.dll" + "\"", true);
            }

            //Executing the .bat file
            runBat();
        }

        private void runBat()
        {
            //Executing the .bat file
            ProcessStartInfo process = new ProcessStartInfo();
            process.WorkingDirectory = Path.GetDirectoryName(batchFileLocation);
            process.FileName = "toolbarInstaller.bat";
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