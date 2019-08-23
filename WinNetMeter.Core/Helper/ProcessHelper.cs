using System.Diagnostics;

namespace WinNetMeter.Core.Helper
{
    internal class ProcessHelper
    {
        public static void RunShellCommand(string command)
        {
            var process = new Process();
            var startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = command;
            startInfo.Verb = "runas";
            process.StartInfo = startInfo;
            process.Start();
        }
    }
}