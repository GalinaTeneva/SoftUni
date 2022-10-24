using System;

namespace _02.SumDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputNum = int.Parse(Console.ReadLine());

            int sumOfDigits = 0;
            while (inputNum != 0)
            {
                int currentDigit = inputNum % 10;
                sumOfDigits += currentDigit;
                inputNum /= 10;
            }

            Console.WriteLine(sumOfDigits);
        }
    }
}
