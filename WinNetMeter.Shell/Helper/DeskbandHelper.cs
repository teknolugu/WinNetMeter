using Microsoft.Win32;
using Serilog;
using System;
using System.Runtime.InteropServices;

namespace WinNetMeter.Shell.Helper
{
    public static class DeskbandHelper
    {
        private const string GuidShell = "E6442437-6C68-4f52-94DD-2CFED267EFB9";
        private static Guid deskbandGuid = new Guid("0F0283BE-FADD-4EAA-9984-9C1822AE469A");

        public static void CallDeskband()
        {
            Log.Debug("Starting call Deskband");

            ITrayDeskband obj = null;
            Type trayDeskbandType = Type.GetTypeFromCLSID(new Guid(GuidShell));
            try
            {
                obj = (ITrayDeskband)Activator.CreateInstance(trayDeskbandType);
                obj.DeskBandRegistrationChanged();
                var hr = obj.ShowDeskBand(ref deskbandGuid);
                if (hr != 0)
                {
                    Log.Error("Error while trying to show deskband: {0}", hr);
                    // throw new Exception("Error while trying to show deskband: " + hr);
                }

                obj.DeskBandRegistrationChanged();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error when Call Deskband!");
            }
            finally
            {
                if (obj != null && Marshal.IsComObject(obj))
                    Marshal.ReleaseComObject(obj);

                Log.Debug("Call shell successfully..");
            }
        }

        public static void HideDeskband()
        {
            Log.Debug("Starting hide Deskband");

            ITrayDeskband obj = null;
            Type trayDeskbandType = Type.GetTypeFromCLSID(new Guid(GuidShell));
            try
            {
                obj = (ITrayDeskband)Activator.CreateInstance(trayDeskbandType);
                obj.DeskBandRegistrationChanged();
                var hr = obj.HideDeskBand(ref deskbandGuid);
                if (hr != 0)
                {
                    Log.Error("Error while trying to hide deskband: {0}", hr);
                    // throw new Exception("Error while trying to show deskband: " + hr);
                }

                obj.DeskBandRegistrationChanged();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error when Hide Deskband!");
            }
            finally
            {
                if (obj != null && Marshal.IsComObject(obj))
                    Marshal.ReleaseComObject(obj);

                Log.Debug("Hide shell successfully..");
            }
        }

        public static bool IsDeskbandVisible()
        {
            // ITrayDeskband obj = null;

            var trayDeskbandType = Type.GetTypeFromCLSID(new Guid(GuidShell));
            var obj = (ITrayDeskband)Activator.CreateInstance(trayDeskbandType);

            obj.DeskBandRegistrationChanged();

            var cek = obj.IsDeskBandShown(ref deskbandGuid);
            var isVisible = cek == 0;

            Log.Debug("Is Deskband visible: {0}", isVisible);
            return isVisible;
        }

        public static bool IsDeskbandInstalled()
        {
            var shellClassRoot = Registry.ClassesRoot.OpenSubKey("WinNetMeter.Shell.Deskband");
            var isInstalled = shellClassRoot != null && shellClassRoot.ValueCount == 1;

            Log.Debug("Is Deskband installed: {0}", isInstalled);
            return isInstalled;
        }

        public static void RestartShell()
        {
            Log.Debug("Restarting Deskband..");

            HideDeskband();
            CallDeskband();

            Log.Debug("Deskband restarted successfully..");

            // var hwnd = new IntPtr(Convert.ToInt32(Settings.ShellHwnd));
            // NativeMethods.PostMessage(hwnd, NativeMethods.WM_RESTART, IntPtr.Zero, IntPtr.Zero);
        }
    }

    [ComImport, Guid("6D67E846-5B9C-4db8-9CBC-DDE12F4254F1"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ITrayDeskband
    {
        [PreserveSig]
        int ShowDeskBand([In, MarshalAs(UnmanagedType.Struct)] ref Guid clsid);

        [PreserveSig]
        int HideDeskBand([In, MarshalAs(UnmanagedType.Struct)] ref Guid clsid);

        [PreserveSig]
        int IsDeskBandShown([In, MarshalAs(UnmanagedType.Struct)] ref Guid clsid);

        [PreserveSig]
        int DeskBandRegistrationChanged();
    }
}