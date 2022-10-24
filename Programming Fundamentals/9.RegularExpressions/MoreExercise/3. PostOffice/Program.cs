using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace _3._PostOffice
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputParts = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);

            string inputFirstPart = inputParts[0];
            string firstLettersPattern = @"([#|$|%|*|&])(?<letters>[A-Z]+)\1";

            var firstLetters = Regex.Match(inputFirstPart, firstLettersPattern).Groups["letters"].Value.ToCharArray();

            Dictionary<char, int> validLetterLengthPairs = new Dictionary<char, int>();
            foreach (char symbol in firstLetters)
            {
                int symbolCode = symbol;

                string inputSecondPart = inputParts[1];
                string wordsLengthPattern = $@"{symbolCode}:(?<length>[0-9][0-9])";
                Match validMatche = Regex.Match(inputSecondPart, wordsLengthPattern);

                int length = int.Parse(validMatche.Groups["length"].Value);


                validLetterLengthPairs.Add(symbol, length);
            }
            
            string inputThirdPart = inputParts[2];
            string[] thirdPartWords = inputThirdPart.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (var pair in validLetterLengthPairs)
            {
                foreach (var word in thirdPartWords)
                {
                    int currWordLenght = word.Length;
                    char currWordFirstLetter = word[0];

                    if (pair.Key == currWordFirstLetter && pair.Value + 1 == currWordLenght)
                    {
                        Console.WriteLine(word);
                        break;
                    }
                }
            }
        }
    }
}
