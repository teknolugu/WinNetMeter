using System;
using System.Collections.Generic;
using System.IO;

namespace WinNetMeter.Core.Helper
{
    public class FileHelper
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

        public static void CreateDirectory(string dirPath)
        {
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
        }

        public static bool IsDirectoryEmpty(string path)
        {
            IEnumerable<string> items = Directory.EnumerateFileSystemEntries(path);
            using (IEnumerator<string> en = items.GetEnumerator())
            {
                return !en.MoveNext();
            }
        }

        public static void DeleteAllIn(string path, string wilcard)
        {
            string[] fileList = System.IO.Directory.GetFiles(path, wilcard);
            foreach (string file in fileList)
            {
                FileHelper.SafeDelete(file);
            }
        }

        public static void DeleteFolderInside(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
        }
    }
}