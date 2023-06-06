using System;

namespace _04.RecursiveFactorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            long result = CalcFactorial(number);
            Console.WriteLine(result);
        }

        private static long CalcFactorial(int number)
        {
            if (number <= 0)
            {
                return 1;
            }

            return number * CalcFactorial(number - 1);
        }
    }
}