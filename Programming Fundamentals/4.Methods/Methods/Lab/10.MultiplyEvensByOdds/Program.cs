using System;

namespace _10.MultiplyEvensByOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = Math.Abs(int.Parse(Console.ReadLine()));

            int evenNumsSum = GetSumOfEvenDigits(input);
            int oddNumsSum = GetSumOfOddDigits(input);

            Console.WriteLine(GetMultipleOfEvenAndOdds(evenNumsSum, oddNumsSum));
        }

        static int GetSumOfEvenDigits(int num)
        {
            int sum = 0;
            while (num > 0)
            {
                int currentDigit = num % 10;

                if (currentDigit % 2 == 0)
                {
                    sum += currentDigit;
                }

                num /= 10;
            }

            return sum;
        }

        static int GetSumOfOddDigits(int num)
        {
            int sum = 0;
            while (num > 0)
            {
                int currentDigit = num % 10;

                if (currentDigit % 2 != 0)
                {
                    sum += currentDigit;
                }
                num /= 10;

            }

            return sum;
        }

        static int GetMultipleOfEvenAndOdds(int evenSum, int oddSum)
        {
            return evenSum * oddSum;
        }
    }
}
