using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.FoodFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            string pear = "pear";
            string flour = "flour";
            string pork = "pork";
            string olive = "olive";

            List<string> words = new List<string> { pear, flour, pork, olive };

            char[] vowels = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
            char[] consonants = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

            Queue<char> vowelsQueue = new Queue<char>(vowels);
            Stack<char> consonantsStack = new Stack<char>(consonants);

            List<string> foundWords = new List<string>();

            while (consonantsStack.Count != 0)
            {
                char currVowel = vowelsQueue.Dequeue();
                char currConsonant = consonantsStack.Pop();

                if (pear.Contains(currVowel) || pear.Contains(currConsonant))
                {
                    pear = pear.Replace(currVowel, ' ');
                    pear = pear.Replace(currConsonant, ' ');

                    if (pear.Trim() == string.Empty)
                    {
                        foundWords.Add("pear");
                    }
                }
                if (flour.Contains(currVowel) || flour.Contains(currConsonant))
                {
                    flour = flour.Replace(currVowel, ' ');
                    flour = flour.Replace(currConsonant, ' ');

                    if (flour.Trim() == string.Empty)
                    {
                        foundWords.Add("flour");
                    }
                }
                if (pork.Contains(currVowel) || pork.Contains(currConsonant))
                {
                    pork = pork.Replace(currVowel, ' ');
                    pork = pork.Replace(currConsonant, ' ');

                    if (pork.Trim() == string.Empty)
                    {
                        foundWords.Add("pork");
                    }
                }
                if (olive.Contains(currVowel) || olive.Contains(currConsonant))
                {
                    olive = olive.Replace(currVowel, ' ');
                    olive = olive.Replace(currConsonant, ' ');

                    if (olive.Trim() == string.Empty)
                    {
                        foundWords.Add("olive");
                    }
                }

                vowelsQueue.Enqueue(currVowel);
            }

            Console.WriteLine($"Words found: {foundWords.Count}");
            foreach (string word in words)
            {
                foreach (string item in foundWords)
                {
                    if (item == word)
                    {
                        Console.WriteLine(word);
                    }
                }
            }
        }
    }
}
