using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileManagementChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourceFolder = @"D:\workspace\Visual Studio\weekly\FileManagementChallenge\testfolder1";
            string destFolder = @"D:\workspace\Visual Studio\weekly\FileManagementChallenge\testfolder2";

            StartCopy(sourceFolder, destFolder, false);
        }

        public static void StartCopy(string sourceFolder, string destFolder, bool allInOne)
        {
            if (!Directory.Exists(destFolder))
            {
                Directory.CreateDirectory(destFolder);
            }

            string[] files = Directory.GetFiles(sourceFolder);
            string[] folders = Directory.GetDirectories(sourceFolder);

            foreach (string file in files)
            {
                string name = Path.GetFileName(file);
                string dest = Path.Combine(destFolder, name);
                if (!File.Exists(dest))
                {
                    File.Copy(file, dest, false);
                }
            }

            switch (allInOne)
            {
                case true:
                    foreach (string folder in folders)
                    {
                        AllInOne(folder, destFolder);
                    }
                    break;
                case false:
                    foreach (string folder in folders)
                    {
                        string name = Path.GetFileName(folder);
                        string dest = Path.Combine(destFolder, name);
                        CopyFolder(folder, dest);
                    }
                    break;
                default:
                    break;
            }
        }

        public static void CopyFolder(string sourceFolder, string destFolder)
        {
            if (!Directory.Exists(destFolder))
            {
                Directory.CreateDirectory(destFolder);
            }

            string[] files = Directory.GetFiles(sourceFolder);
            string[] folders = Directory.GetDirectories(sourceFolder);
            
            foreach (string file in files)
            {
                string name = Path.GetFileName(file);
                string dest = Path.Combine(destFolder, name);
                if (!File.Exists(dest))
                {
                    File.Copy(file, dest, false);
                }
            }
            foreach (string folder in folders)
            {
                string name = Path.GetFileName(folder);
                string dest = Path.Combine(destFolder, name);
                if (!File.Exists(dest))
                {
                    CopyFolder(folder, dest);
                }
            }
        }

        public static void AllInOne(string sourceFolder, string destFolder)
        {
            string[] files = Directory.GetFiles(sourceFolder);
            string[] folders = Directory.GetDirectories(sourceFolder);

            foreach (string file in files)
            {
                string name = Path.GetFileName(file);
                string folderName = Path.GetFileName(sourceFolder);
                string dest = Path.Combine(destFolder, $"{ folderName }_{ name }");

                if (!File.Exists(dest))
                {
                    File.Copy(file, dest, false);
                }
            }
            foreach (string folder in folders)
            {
                AllInOne(folder, destFolder);
            }
        }
    }
}
