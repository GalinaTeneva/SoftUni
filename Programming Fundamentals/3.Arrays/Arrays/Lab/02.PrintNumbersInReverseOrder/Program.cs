using System;

namespace _02.PrintNumbersInReverseOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbersNum = int.Parse(Console.ReadLine());

            int[] numbers = new int[numbersNum];

            for (int i = 0; i < numbersNum; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            for (int i = numbersNum - 1; i >= 0; i--)
            {
                Console.Write(numbers[i] + " ");
            }
        }
    }
}
