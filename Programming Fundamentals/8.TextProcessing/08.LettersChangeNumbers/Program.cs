using System;

namespace _08.LettersChangeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] strings = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            double sum = 0;
            foreach (string str in strings)
            {
                char firstLetter = str[0];
                char lastLetter = str[str.Length - 1];
                double number = int.Parse(str.Substring(1, str.Length - 2));


                double currStrResult = 0;
                if (firstLetter >= 65 && firstLetter <= 90)
                {
                    int firstLetterAlphabetPosition = firstLetter - 64;
                    currStrResult = number / firstLetterAlphabetPosition;
                }
                else if (true)
                {
                    int firstLetterAlphabetPosition = firstLetter - 96;
                    currStrResult = number * firstLetterAlphabetPosition;
                }

                if (lastLetter >= 65 && lastLetter <= 90)
                {
                    int lastLetterAlphabetPosition = lastLetter - 64;
                    sum += currStrResult - lastLetterAlphabetPosition;
                }
                else
                {
                    int lastLetterAlphabetPosition = lastLetter - 96;
                    sum += currStrResult + lastLetterAlphabetPosition;
                }
            }

            Console.WriteLine($"{sum:F2}");
        }
    }
}
