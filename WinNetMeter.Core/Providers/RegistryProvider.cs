using Microsoft.Win32;
using Serilog;

namespace WinNetMeter.Core.Providers
{
    public static class RegistryProvider
    {
        private static readonly RegistryKey registryBase = Registry.CurrentUser.OpenSubKey(@"Software", true);
        private static RegistryKey _registryRoot;
        private static string rootPath = @"WinTenDev\NetMeter";

        public static void Init()
        {
            registryBase.CreateSubKey(rootPath);
            _registryRoot = registryBase.OpenSubKey(rootPath, true);

            if (_registryRoot != null)
            {
                _registryRoot.CreateSubKey("General");
                _registryRoot.CreateSubKey("Database");
                _registryRoot.CreateSubKey("Style");
            }
            else
            {
                Log.Error("You must execute RegistryProvider.Init() on startup.");
            }
        }

        public static void Reset()
        {
            if (_registryRoot == null)
            {
                return;
            }

            foreach (string subKey in _registryRoot.GetSubKeyNames())
            {
                try
                {
                    _registryRoot.DeleteSubKeyTree(subKey);
                }
                catch
                {
                }
            }

            Init();
        }

        public static bool IsKeyExist(string regPath)
        {
            var regKey = _registryRoot.OpenSubKey(regPath);
            return regKey != null;
        }

        public static void WriteToRegistry(string path, string keyReg, string valReg)
        {
            var exeKey = _registryRoot.OpenSubKey(@path, true);
            exeKey?.SetValue(keyReg, valReg, RegistryValueKind.String);
        }

        public static object ReadFromRegistry(string path, string keyReg)
        {
            var regKey = _registryRoot.OpenSubKey(path, true);
            return regKey?.GetValue(keyReg);
        }
    }
}