using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using Serilog;
using WinNetMeter.Core.Helper;
using WinNetMeter.Core.Model;

namespace WinNetMeter.Shell.Helper
{
    public class IntegrationHelper
    {
        private string baseLocalAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        private string batchFileLocation = "";
        private string uninstallerBatchFileLocation = "";
        private string FrameworkLocation;
        private StreamWriter writer;

        private readonly string forRunAs =
            "@setlocal enableextensions enabledelayedexpansion\r\n@echo off\r\nif not \"!params!\"==\"\" set \"params=%params:\"=\"\"%\"\r\npushd \"%cd%\" && cd /d \"%~dp0\" && ( if exist \"%temp%\\getadmin.vbs\" del \"%temp%\\getadmin.vbs\" ) && fsutil dirty query %systemdrive% >nul || if %errorlevel%==0 (  echo Set UAC = CreateObject^(\"Shell.Application\"^) : UAC.ShellExecute \"cmd.exe\", \"/k cd \"\"%~sdp0\"\" && %~s0 %params%\", \"\", \"runas\", 1 >> \"%temp%\\getadmin.vbs\" && \"%temp%\\getadmin.vbs\" && exit /B )";

        public IntegrationHelper()
        {
            batchFileLocation = baseLocalAppData + @"\temp\toolbarInstaller.bat";
            uninstallerBatchFileLocation = baseLocalAppData + @"\temp\toolbarUninstaller.bat";
        }

        private enum FileType
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
            FileHelper.SafeDelete(batchFileLocation);
            FileHelper.EnsureDirectory(Path.GetDirectoryName(batchFileLocation));

            File.Create(batchFileLocation).Close();

            WriteBatFile(forRunAs, true, FileType.Installer);

            //Get .NET Framework path Information
            if (Environment.Is64BitOperatingSystem)
            {
                FrameworkLocation = Environment.GetEnvironmentVariable("windir") + @"\Microsoft.NET\Framework64\v4.0.30319";
            }
            else
            {
                FrameworkLocation = Environment.GetEnvironmentVariable("windir") + @"\Microsoft.NET\Framework\v4.0.30319";
            }

            WriteBatFile("cd " + FrameworkLocation, true, FileType.Installer);
            WriteBatFile("regasm /codebase " + "\"" + AppDomain.CurrentDomain.BaseDirectory + @"WinNetMeter.Shell.dll" + "\"", true, FileType.Installer);

            //Executing the .bat file
            runBat("toolbarInstaller.bat");
        }

        public void UninstallToolbar()
        {
            FileHelper.SafeDelete(uninstallerBatchFileLocation);
            FileHelper.EnsureDirectory(Path.GetDirectoryName(uninstallerBatchFileLocation));

            File.Create(uninstallerBatchFileLocation).Close();

            WriteBatFile(forRunAs, false, FileType.Uninstaller);

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
                WriteBatFile("cd " + FrameworkLocation, true, FileType.Uninstaller);
                WriteBatFile("regasm /unregister " + "\"" + AppDomain.CurrentDomain.BaseDirectory + @"WinNetMeter.Shell.dll" + "\"", true,
                    FileType.Uninstaller);
                WriteBatFile("taskkill /F /IM explorer.exe", true, FileType.Uninstaller);
                WriteBatFile("exit", true, FileType.Uninstaller);
            }

            //Executing the .bat file
            runBat("toolbarUninstaller.bat");

            Core.Helper.EnvironmentHelper.RestartExplorer();
        }

        public void ReinstallToolbar()
        {
            FileHelper.SafeDelete(batchFileLocation);
            FileHelper.EnsureDirectory(Path.GetDirectoryName(batchFileLocation));
            File.Create(batchFileLocation).Close();

            WriteBatFile(forRunAs, false, FileType.Installer);

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
                WriteBatFile("cd " + FrameworkLocation, true, FileType.Installer);

                // Unregister .dll
                WriteBatFile("regasm /unregister " + "\"" + AppDomain.CurrentDomain.BaseDirectory + @"WinNetMeter.Shell.dll" + "\"", true, FileType.Installer);

                // Register .dll
                WriteBatFile("regasm /codebase " + "\"" + AppDomain.CurrentDomain.BaseDirectory + @"WinNetMeter.Shell.dll" + "\"", true, FileType.Installer);
            }

            WriteBatFile("exit", true, FileType.Installer);

            //Executing the .bat file
            runBat("toolbarInstaller.bat");
        }

        public void MakeUninstaller()
        {
            FileHelper.SafeDelete(uninstallerBatchFileLocation);
            FileHelper.EnsureDirectory(Path.GetDirectoryName(uninstallerBatchFileLocation));
            WriteBatFile(forRunAs, true, FileType.Uninstaller);

            File.Create(uninstallerBatchFileLocation).Close();

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
                WriteBatFile("regasm /unregister " + "\"" + AppDomain.CurrentDomain.BaseDirectory + @"WinNetMeter.Shell.dll" + "\"", true,
                    FileType.Uninstaller);
                WriteBatFile("taskkill /im explorer.exe /f", true, FileType.Uninstaller);
                WriteBatFile("start explorer.exe", true, FileType.Uninstaller);
                WriteBatFile("exit", true, FileType.Uninstaller);
            }

            //runBat("toolbarUninstaller.bat");
        }

        private void runBat(string fileName)
        {
            //Executing the .bat file
            ProcessStartInfo process = new ProcessStartInfo();
            process.WorkingDirectory = Path.GetDirectoryName(batchFileLocation);
            process.FileName = fileName;
            process.Verb = "runas";
            process.WindowStyle = ProcessWindowStyle.Hidden;
            try
            {
                Process.Start(process);
            }
            catch
            {
            }
        }

        public static void InstallShell()
        {
            var runtimePath = RuntimeEnvironment.GetRuntimeDirectory();
            var currentDir = Settings.AppDirectory;

            if (Environment.Is64BitOperatingSystem) runtimePath = runtimePath.Replace("Framework", "Framework64");
            var cmdUninst = $@"/c {runtimePath}RegAsm.exe /unregister {currentDir}\WinNetMeter.Shell.dll";
            var cmdRegist = $@"/c {runtimePath}RegAsm.exe /codebase {currentDir}\WinNetMeter.Shell.dll";

            Log.Information($"InstallCmd: {cmdUninst}");
            var procUninst = Process.Start("cmd.exe", cmdUninst);
            procUninst.WaitForExit();

            Log.Information($"Uninst: {procUninst.ExitCode}");

            Log.Information($"InstallCmd: {cmdRegist}");
            var procRegist = Process.Start("cmd.exe", cmdRegist);
            procRegist.WaitForExit();

            Log.Information($"Regist: {procRegist.ExitCode}");
        }

        public static void UninstallShell()
        {
            var runtimePath = RuntimeEnvironment.GetRuntimeDirectory();
            var currentDir = Settings.AppDirectory;

            if (Environment.Is64BitOperatingSystem) runtimePath = runtimePath.Replace("Framework", "Framework64");
            var cmdUninst = $@"/c {runtimePath}RegAsm.exe /unregister {currentDir}\WinNetMeter.Shell.dll";

            Log.Information($"InstallCmd: {cmdUninst}");
            var procUninst = Process.Start("cmd.exe", cmdUninst);
            procUninst.WaitForExit();

            ProcessHelper.RestartExplorer();

            Log.Information($"Uninst: {procUninst.ExitCode}");
        }
    }
}