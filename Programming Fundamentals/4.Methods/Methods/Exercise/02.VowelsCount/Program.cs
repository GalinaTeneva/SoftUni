using System;

namespace _02.VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToLower();

            PrintVowelsNum(input);

            
        }

        static void PrintVowelsNum(string text)
        {
            int vowelsCount = 0;

            foreach (char letter in text)
            {
                if ("aouei".Contains(letter))
                {
                    vowelsCount++;
                }
            }

            Console.WriteLine(vowelsCount);
        }
    }
}
