using System;

namespace WinNetMeter.Core.Model
{
    public class PathInfo
    {

        // Directory
        public static readonly string baseApp = AppDomain.CurrentDomain.BaseDirectory;
        public static readonly string baseLocalData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        public static readonly string companyFolderName = "WinTenDev";
        public static string tempFolderName = "temp";
        public static string updateFolderName = "update";

        // File
        public static readonly string toolBarInstallerFileName = "toolbarInstaller.bat";
        public static string toolBarUninstallerFileName = "toolbarUninstaller.bat";

        public static readonly string tempLocation = $@"{baseLocalData}\{companyFolderName}\{tempFolderName}";
        public static readonly string updateLocation = $@"{baseLocalData}\{companyFolderName}\{updateFolderName}";
        public static readonly string toolBarInstallerLocation = $@"{baseLocalData}\{companyFolderName}\{tempFolderName}\{toolBarInstallerFileName}";
        public static readonly string toolBarUninstallerLocation = $@"{baseLocalData}\{companyFolderName}\{tempFolderName}\{toolBarUninstallerFileName}";
        public static readonly string appLocation = $"{baseApp}WinNetMeter.exe";
        public static readonly string shellLocation = $"{baseApp}WinNetMeter.Shell.dll";
    }
}
