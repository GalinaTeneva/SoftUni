using System;

namespace _06.MiddleCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            PrintMiddleChars(input);
        }

        private static void PrintMiddleChars(string text)
        {
            if (text.Length % 2 != 0)
            {
                int middleIndex = text.Length / 2;

                Console.WriteLine(text[middleIndex]);
            }
            else
            {
                int firstMiddleIndex = text.Length / 2 - 1;
                int secondMiddleIndex = text.Length / 2;
                Console.WriteLine($"{text[firstMiddleIndex]}{text[secondMiddleIndex]}");
            }
        }
    }
}
