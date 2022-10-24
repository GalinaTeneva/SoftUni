using System;
using System.IO;

namespace LineNumbers
{
    public class LineNumbers
    {
        static void Main()
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            RewriteFileWithLineNumbers(inputPath, outputPath);
        }

        public static void RewriteFileWithLineNumbers(string inputPath, string outputPath)
        {
            using (StreamReader reader = new StreamReader(inputPath))
            {
                int lineNum = 1;
                while (!reader.EndOfStream)
                {
                    Console.WriteLine($"{lineNum++}. {reader.ReadLine()}");
                }
            }
        }
    }
}
