using System;
using System.Collections.Generic;

namespace _01.CountCharsInAString
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] text = Console.ReadLine().ToCharArray();
            Dictionary<char, int> occurances = new Dictionary<char, int>();

            foreach (char symbol in text)
            {
                if (symbol != ' ')
                {
                    if (!occurances.ContainsKey(symbol))
                    {
                        occurances.Add(symbol, 0);
                    }

                    occurances[symbol]++;
                }
            }

            foreach (var occurance in occurances)
            {
                Console.WriteLine($"{occurance.Key} -> {occurance.Value}");
            }
        }
    }
}
