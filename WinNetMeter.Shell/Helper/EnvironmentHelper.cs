using System;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;

namespace WinNetMeter.Shell.Helper
{
    public class EnvironmentHelper
    {
        public static bool IsUwpApp()
        {
            var helpers = new DesktopBridge.Helpers();
            return helpers.IsRunningAsUwp();
        }

        public static void RestartExplorer()
        {
            Process.Start(Path.Combine(Environment.GetEnvironmentVariable("windir"), "explorer.exe"));
        }

        public static bool IsWindows10()
        {
            var reg = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion");

            string productName = (string)reg.GetValue("ProductName");

            return productName.StartsWith("Windows 10");
        }
    }
}