using System;
using System.IO;

namespace OddLines
{
    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            StreamReader reader = new StreamReader(inputFilePath);
            using (reader)
            {
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    int lineNum = 0;
                    while (!reader.EndOfStream)
                    {
                        string currLine = reader.ReadLine();
                        if (lineNum % 2 == 1)
                        {
                            writer.WriteLine(currLine);
                        }

                        lineNum++;
                    }
                }
            }
        }
    }
}
