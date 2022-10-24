using System;
using System.Collections.Generic;

namespace _05.CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> charsByCount = new SortedDictionary<char, int>();

            string text = Console.ReadLine();

            for (int i = 0; i < text.Length; i++)
            {
                if (!charsByCount.ContainsKey(text[i]))
                {
                    charsByCount[text[i]] = 0;
                }

                charsByCount[text[i]]++;
            }

            foreach (var pair in charsByCount)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value} time/s");
            }
        }
    }
}
