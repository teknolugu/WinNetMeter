using System;
using System.Collections.Generic;
using System.IO;

namespace WinNetMeter.Core.Helper
{
    public static class FileHelper
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

        public static void WriteToFile(string path, string value, bool append = true, bool newLine = true)
        {
            if (!append) SafeDelete(path);

            var writer = new StreamWriter(path, true);

            //Write the .bat script
            writer.Write(value);
            if (newLine) writer.Write(Environment.NewLine);

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

        public static string EnsureDirectory(this string dirPath)
        {
            var path = Path.GetDirectoryName(dirPath);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return dirPath;
        }

        public static bool IsDirectoryEmpty(this string path)
        {
            IEnumerable<string> items = Directory.EnumerateFileSystemEntries(path);
            using (IEnumerator<string> en = items.GetEnumerator())
            {
                return !en.MoveNext();
            }
        }

        public static void DeleteAllIn(this string path, string wilcard)
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