using System;
using System.Diagnostics;
using System.IO;

namespace WinNetMeter.Core.Helper
{
    public class Integration
    {
        private string baseLocalAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        private string batchFileLocation = "";
        private string uninstallerBatchFileLocation = "";
        private string FrameworkLocation;
        private StreamWriter writer;

        public Integration(){
            batchFileLocation = baseLocalAppData + @"\temp\toolbarInstaller.bat";
            uninstallerBatchFileLocation = baseLocalAppData + @"\temp\toolbarUninstaller.bat";
        }
        enum FileType
        {
            Installer, 
            Uninstaller
        }

        private void WriteBatFile(string value, bool NewLine, FileType fileType)
        {
            switch (fileType)
            {
                case FileType.Installer:
                    writer = new StreamWriter(batchFileLocation, true);
                    if (NewLine) writer.Write(Environment.NewLine);

                    //Write the .bat script
                    writer.Write(value);

                    //Close the tread
                    writer.Close();
                    break;
                case FileType.Uninstaller:
                    writer = new StreamWriter(uninstallerBatchFileLocation, true);
                    if (NewLine) writer.Write(Environment.NewLine);

                    //Write the .bat script
                    writer.Write(value);

                    //Close the tread
                    writer.Close();
                    break;
            }
           
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
                    WriteBatFile("cd " + FrameworkLocation, false, FileType.Installer);
                    WriteBatFile("regasm /codebase " + "\"" + AppDomain.CurrentDomain.BaseDirectory + @"WinNetMeter.Shell.dll" + "\"", true, FileType.Installer);
                }
            }
            else
            {
                FrameworkLocation = Environment.GetEnvironmentVariable("windir") + @"\Microsoft.NET\Framework\v4.0.30319";
                if (Directory.Exists(FrameworkLocation))
                {
                    WriteBatFile("cd " + FrameworkLocation, false, FileType.Installer);
                    WriteBatFile("regasm /codebase " + "\"" + AppDomain.CurrentDomain.BaseDirectory + @"WinNetMeter.Shell.dll" + "\"", true, FileType.Installer);
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
                WriteBatFile("cd " + FrameworkLocation, false, FileType.Uninstaller);
                WriteBatFile("regasm /unregister " + "\"" + AppDomain.CurrentDomain.BaseDirectory + @"WinNetMeter.Shell.dll" + "\"", true, FileType.Uninstaller);
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
                WriteBatFile("cd " + FrameworkLocation, false, FileType.Installer);

                // Unregister .dll
                WriteBatFile("regasm /unregister " + "\"" + AppDomain.CurrentDomain.BaseDirectory + @"WinNetMeter.Shell.dll" + "\"", true, FileType.Installer);

                // Register .dll
                WriteBatFile("regasm /codebase " + "\"" + AppDomain.CurrentDomain.BaseDirectory + @"WinNetMeter.Shell.dll" + "\"", true, FileType.Installer);
            }

            //Executing the .bat file
            runBat();
        }
        public void MakeUninstaller()
        {
            //Create .bat file for toolbar installation
            if (!Directory.Exists(Path.GetDirectoryName(batchFileLocation)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(batchFileLocation));
            }
            if (!File.Exists(uninstallerBatchFileLocation))
            {
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
                    WriteBatFile("cd " + FrameworkLocation, false, FileType.Uninstaller);
                    WriteBatFile("regasm /unregister " + "\"" + AppDomain.CurrentDomain.BaseDirectory + @"WinNetMeter.Shell.dll" + "\"", true, FileType.Uninstaller);
                    WriteBatFile("taskkill /im explorer.exe /f", true, FileType.Uninstaller);
                    WriteBatFile("start explorer.exe", true, FileType.Uninstaller);
                    WriteBatFile("exit", true, FileType.Uninstaller);
                }
            }

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