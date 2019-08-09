using System.IO;

namespace WinNetMeterUI.Interfaces
{
    public interface IOService
    {
        string OpenFileDialog(string defaultPath);

        //Other similar untestable IO operations
        Stream OpenFile(string path);
    }
}