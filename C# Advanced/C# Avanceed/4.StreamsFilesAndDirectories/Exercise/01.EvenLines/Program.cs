namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class EvenLines
    {
        static void Main(string[] args)
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            StringBuilder sb = new StringBuilder();

            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                int lineCount = 0;
                string line = string.Empty;
                while (line != null)
                {
                    line = reader.ReadLine();

                    if (lineCount % 2 == 0)
                    {
                        string replacedSymbols = ReplaceSymbols(line);
                        string reverseWords = ReverseWords(replacedSymbols);

                        sb.AppendLine(reverseWords);
                    }

                    lineCount++;
                }
            }

            return sb.ToString().TrimEnd();
        }

        private static string ReverseWords(string line)
        {
            string[] reversedWords = line
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Reverse()
                .ToArray();

            return string.Join(' ', reversedWords);
        }

        private static string ReplaceSymbols(string line)
        {
            char[] symbolsToReplace = new char[] { '-', ',', '.', '!', '?' };
            foreach (char symbol in symbolsToReplace)
            {
                line = line.Replace(symbol, '@');
            }

            return line;
        }
    }
}
