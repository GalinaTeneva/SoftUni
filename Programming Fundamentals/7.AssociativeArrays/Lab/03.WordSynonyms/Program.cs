using System;
using System.Collections.Generic;

namespace _03.WordSynonyms
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> words = new Dictionary<string, List<string>>();

            int wordsPairsCount = int.Parse(Console.ReadLine());

            for (int currWordPair = 1; currWordPair <= wordsPairsCount; currWordPair++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();

                if (!words.ContainsKey(word))
                {
                    //words.Add(word, new List<string>();
                    words[word] = new List<string>();
                }

                words[word].Add(synonym);
            }

            foreach (KeyValuePair<string, List<string>> synonymPair in words)
            {
                Console.WriteLine($"{synonymPair.Key} - {string.Join(", ", synonymPair.Value)}");
            }
        }
    }
}
