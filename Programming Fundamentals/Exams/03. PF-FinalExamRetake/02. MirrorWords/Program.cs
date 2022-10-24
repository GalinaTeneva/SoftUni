using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace _02._MirrorWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([#|@])(?<firstWord>[A-Za-z]{3,})\1\1(?<secondWord>[A-Za-z]{3,})\1";
            string input = Console.ReadLine();

            MatchCollection hiddenPairs = Regex.Matches(input, pattern);

            if (hiddenPairs.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
                Console.WriteLine("No mirror words!");
            }
            else
            {
                Console.WriteLine($"{hiddenPairs.Count} word pairs found!");

                List<string> validPairs = new List<string>();
                foreach (Match pair in hiddenPairs)
                {
                    string firstWord = pair.Groups["firstWord"].Value;
                    string secondWord = pair.Groups["secondWord"].Value;

                    char[] secondWordCharsBackwords = secondWord.Reverse().ToArray();
                    string secondWordBackwords = string.Join("", secondWordCharsBackwords);

                    if (secondWordBackwords == firstWord)
                    {
                        string currValidPair = $"{firstWord} <=> {secondWord}";
                        validPairs.Add(currValidPair);
                    }
                }

                if (validPairs.Count == 0)
                {
                    Console.WriteLine("No mirror words!");
                }
                else
                {
                    Console.WriteLine("The mirror words are:");
                    Console.WriteLine(string.Join(", ", validPairs));
                }
            }
        }
    }
}
