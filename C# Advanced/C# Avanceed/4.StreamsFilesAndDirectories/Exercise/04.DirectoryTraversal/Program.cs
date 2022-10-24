namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            SortedDictionary<string, List<FileInfo>> extensionsFiles = new SortedDictionary<string, List<FileInfo>>(); 

            string[] files = Directory.GetFiles(inputFolderPath);

            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                string fileExtension = fileInfo.Extension;

                if (!extensionsFiles.ContainsKey(fileExtension))
                {
                    extensionsFiles.Add(fileExtension, new List<FileInfo>());
                }

                extensionsFiles[fileExtension].Add(fileInfo);
            }

            var orderedFiles = extensionsFiles.OrderByDescending(f => f.Value.Count);

            StringBuilder sb = new StringBuilder();

            foreach (var pair in orderedFiles)
            {
                sb.AppendLine(pair.Key);

                foreach (var kvpitem in pair.Value.OrderByDescending(f => f.Length))
                {
                    sb.AppendLine($"--{kvpitem.Name} - {(double)kvpitem.Length / 1024:F2}kb");
                }
            }

            return sb.ToString();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + reportFileName;
            File.WriteAllText(filePath, textContent);
        }
    }
}
