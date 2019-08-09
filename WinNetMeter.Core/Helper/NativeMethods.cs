using System;
using System.Runtime.InteropServices;

namespace WinNetMeter.Core.Helper
{
    public class NativeMethods
    {
        public const int HWND_BROADCAST = 0xffff;
        public static readonly int WM_RESTART = RegisterWindowMessage("WM_RESTART");
        public static readonly int WM_OFFMONITOR = RegisterWindowMessage("WM_OFFMONITOR");

        [DllImport("user32")]
        public static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);

        [DllImport("user32")]
        public static extern int RegisterWindowMessage(string message);
    }
}