using System;
using System.Linq;

namespace _01.RecursionAndBacktracking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ")
                .Select(n => int.Parse(n))
                .ToArray();

            Console.WriteLine(CalcSum(numbers, 0));
        }

        private static int CalcSum(int[] numbers, int index)
        {
            if (index >= numbers.Length)
            {
                return 0;
            }

            return numbers[index] + CalcSum(numbers, index + 1);
        }
    }
}