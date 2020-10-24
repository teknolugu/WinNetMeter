using Serilog;
using System.Diagnostics;

namespace WinNetMeter.Shell.Helper
{
    internal static class ProcessHelper
    {
        public static Process RunShellCommand(string command)
        {
            var process = new Process();
            var startInfo = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = "cmd.exe",
                Arguments = $"/c {command}",
                Verb = "runas"
            };

            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();

            return process;
        }

        public static void RestartProcess(string processName)
        {
            KillProcess(processName);
            RunShellCommand(processName);
        }

        public static void KillProcess(string processName)
        {
            foreach (Process exe in Process.GetProcesses())
            {
                if (exe.ProcessName == processName.Replace(".exe", ""))
                    exe.Kill();
            }
        }

        public static void RestartExplorer()
        {
            if (EnvironmentHelper.IsWindows10())
            {
                Log.Information("IsWin10: True");
                Log.Information("Restarting SiHost.exe");
                RestartProcess("sihost.exe");

                Log.Information("Process restarted.");
            }
        }
    }
}