using System;
using System.Runtime.InteropServices;

namespace WinNetMeter.Core
{
    internal class ShellController
    {
        private int hr;
        private Guid deskbandGuid = new Guid("0F0283BE-FADD-4EAA-9984-9C1822AE469A");

        [ComImport, Guid("6D67E846-5B9C-4db8-9CBC-DDE12F4254F1"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
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

        public void callDeskband()
        {
            ITrayDeskband obj = null;
            Type trayDeskbandType = System.Type.GetTypeFromCLSID(new Guid("E6442437-6C68-4f52-94DD-2CFED267EFB9"));
            try
            {
                obj = (ITrayDeskband)Activator.CreateInstance(trayDeskbandType);
                obj.DeskBandRegistrationChanged();
                hr = obj.ShowDeskBand(ref deskbandGuid);
                if (hr != 0)
                    throw new Exception("Error while trying to show deskband: " + hr);
                obj.DeskBandRegistrationChanged();
            }
            catch (Exception e)
            {
                
            }
            finally
            {
                if (obj != null && Marshal.IsComObject(obj))
                    Marshal.ReleaseComObject(obj);
            }
        }

        public void hideDeskband()
        {
            ITrayDeskband obj = null;
            Type trayDeskbandType = System.Type.GetTypeFromCLSID(new Guid("E6442437-6C68-4f52-94DD-2CFED267EFB9"));
            try
            {
                obj = (ITrayDeskband)Activator.CreateInstance(trayDeskbandType);
                obj.DeskBandRegistrationChanged();
                hr = obj.HideDeskBand(ref deskbandGuid);
                if (hr != 0)
                    throw new Exception("Error while trying to show deskband: " + hr);
                obj.DeskBandRegistrationChanged();
            }
            catch (Exception e)
            {
                
            }
            finally
            {
                if (obj != null && Marshal.IsComObject(obj))
                    Marshal.ReleaseComObject(obj);
            }
        }

        public int IsShellShown()
        {
            ITrayDeskband obj = null;
            Type trayDeskbandType = System.Type.GetTypeFromCLSID(new Guid("E6442437-6C68-4f52-94DD-2CFED267EFB9"));

            obj = (ITrayDeskband)Activator.CreateInstance(trayDeskbandType);
            obj.DeskBandRegistrationChanged();
            return obj.IsDeskBandShown(ref deskbandGuid);
        }
    }
}