namespace WinNetMeter.UI.Helpers
{
    public class Env
    {
        public static bool IsProd()
        {
#if DEBUG
            return false;
#else
            return true;
#endif
        }
    }
}