using System;
using System.IO;

namespace Updater.Helper
{
    internal class FileHelper
    {
        public static void WriteBatFile(string path, string value, bool NewLine)
        {
            var writer = new StreamWriter(path, true);
            if (NewLine) writer.Write(Environment.NewLine);

            //Write the .bat script
            writer.Write(value);

            //Close the tread
            writer.Close();
        }

        public static void SafeDelete(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public static void SaveMove(string path, string newPath)
        {
            if (File.Exists(path))
            {
                File.Move(path, newPath);
            }
        }

        public static void SaveCopy(string path, string newPath)
        {
            if (File.Exists(path))
            {
                File.Copy(path, newPath, true);
            }
        }
    }
}