using System;

namespace _10.TopNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int endValue = int.Parse(Console.ReadLine());

            for (int currentNum = 1; currentNum <= endValue; currentNum++)
            {
                bool isTopNum = DetermTopNumber(currentNum);
                if (isTopNum)
                {
                    Console.WriteLine(currentNum);
                }
            }
        }

        private static bool DetermTopNumber(int number)
        {
            bool isSumOfDigitsDevisibleByEight = DetermIfDevisibleByEight(number);
            bool isThereOddDigit = DetermOddDigit(number);

            if (isSumOfDigitsDevisibleByEight && isThereOddDigit)
            {
                return true;
            }

            return false;
        }

        private static bool DetermOddDigit(int number)
        {
            int copyOfNumber = number;
            for (int i = 1; i <= number.ToString().Length; i++)
            {
                int currentDigit = copyOfNumber % 10;

                if (currentDigit % 2 != 0)
                {
                    return true;
                }
                copyOfNumber /= 10;
            }

            return false;
        }

        private static bool DetermIfDevisibleByEight(int number)
        {
            int copyOfNumber = number;
            int sumOfDigits = 0;
            for (int i = 1; i <= number.ToString().Length; i++)
            {
                int currentDigit = copyOfNumber % 10;
                sumOfDigits += currentDigit;
                copyOfNumber /= 10;
            }

            if (sumOfDigits % 8 == 0)
            {
                return true;
            }

            return false;
        }
    }
}
