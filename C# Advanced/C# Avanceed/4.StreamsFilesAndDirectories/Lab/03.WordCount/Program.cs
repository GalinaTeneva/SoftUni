using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordCount
{
    public class WordCount
    {
        static void Main(string[] args)
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);

        }

        public static void CalculateWordCounts(string wordPath, string textPath, string outputPath)
        {
            Dictionary<string, int> wordsByCounts = new Dictionary<string, int>();

            StreamReader wordsReader = new StreamReader(wordPath);
            using (wordsReader)
            {
                string[] words = wordsReader.ReadToEnd().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                foreach (string word in words)
                {
                    wordsByCounts.Add(word, 0);
                }

                using (StreamReader textReader = new StreamReader(textPath))
                {
                    while (!textReader.EndOfStream)
                    {
                        string[] lineWords = textReader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);


                        foreach (string lineWord in lineWords)
                        {
                            string wordToCheck = lineWord.ToLower().Trim(new char[] { '-', '?', '!', '.', ',', ':' });

                            if (wordsByCounts.ContainsKey(wordToCheck))
                            {
                                wordsByCounts[wordToCheck]++;
                            }
                        }
                    }
                }
            }

            using (StreamWriter writer = new StreamWriter(outputPath))
            {
                foreach (var pair in wordsByCounts.OrderByDescending(w => w.Value))
                {
                    Console.WriteLine($"{pair.Key} - {pair.Value}");
                }
            }
        }
    }
}
