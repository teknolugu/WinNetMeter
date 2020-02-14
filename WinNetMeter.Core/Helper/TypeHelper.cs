using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinNetMeter.Core.Helpers
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
    }
}
