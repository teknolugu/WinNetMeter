using System.IO;

namespace WinNetMeter.UI.Interfaces
{
    public interface IOService
    {
        string OpenFileDialog(string defaultPath);

        //Other similar untestable IO operations
        Stream OpenFile(string path);
    }
}