using System;

namespace WinNetMeter.Shell.Helper
{
    public static class TypeHelper
    {
        public static bool ToBool(this object obj)
        {
            return Convert.ToBoolean(obj);
        }

        public static int ToInt(this object obj)
        {
            return Convert.ToInt32(obj);
        }

        public static float ToFloat(this object obj)
        {
            return Convert.ToSingle(obj);
        }
    }
}