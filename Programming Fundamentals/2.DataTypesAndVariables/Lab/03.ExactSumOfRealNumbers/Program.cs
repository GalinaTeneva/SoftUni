using System;
using System.Numerics;

namespace _03.ExactSumOfRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalNums = int.Parse(Console.ReadLine());

            decimal sum = 0;
            for (int currentInput= 1; currentInput <= totalNums; currentInput++)
            {
                decimal currentNum = decimal.Parse(Console.ReadLine());
                sum += currentNum;
            }

            Console.WriteLine(sum);
        }
    }
}
