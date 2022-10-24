using System;
using System.IO;

namespace FolderSize
{
    public class FolderSize
    {
        static void Main(string[] args)
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputPath)
        {
            double sum = 0;

            DirectoryInfo dir = new DirectoryInfo(folderPath);
            FileInfo[] infos = dir.GetFiles("*", SearchOption.AllDirectories);

            foreach (var item in infos)
            {
                sum += item.Length;
            }

            sum = sum / 1024 / 1024;

            File.WriteAllText(outputPath, sum.ToString());
        }
    }
}
