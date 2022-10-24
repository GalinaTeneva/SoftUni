using System;

namespace _02.CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string firstString = input[0];
            string secondString = input[1];

            int sum = 0;

            string shorterString = string.Empty;
            string longerString = string.Empty;

            if (firstString.Length > secondString.Length)
            {
                shorterString = secondString;
                longerString = firstString;
            }
            else
            {
                shorterString = firstString;
                longerString = secondString;
            }

            for (int i = 0; i < shorterString.Length; i++)
            {
                int sumOfCurrChars = firstString[i] * secondString[i];
                sum += sumOfCurrChars;
            }

            for (int i = shorterString.Length; i < longerString.Length; i++)
            {
                sum += longerString[i];
            }

            Console.WriteLine(sum);
        }
    }
}
