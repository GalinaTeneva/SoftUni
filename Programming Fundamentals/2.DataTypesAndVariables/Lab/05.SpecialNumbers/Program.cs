using System;

namespace _05.SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputNumber = int.Parse(Console.ReadLine());

            for (int currentNum = 1; currentNum <= inputNumber; currentNum++)
            {
                int sumOfDigitsOfCurrentNum = 0;
                int remainingCurrentNum = currentNum;
                while (remainingCurrentNum != 0)
                {
                    int currentDigitOfCurrentNum = remainingCurrentNum % 10;
                    sumOfDigitsOfCurrentNum += currentDigitOfCurrentNum;
                    remainingCurrentNum /= 10;

                }

                bool isSpecial = sumOfDigitsOfCurrentNum == 5 || sumOfDigitsOfCurrentNum == 7 || sumOfDigitsOfCurrentNum == 11;
                Console.WriteLine($"{currentNum} -> {isSpecial}");
            }

        }
    }
}
