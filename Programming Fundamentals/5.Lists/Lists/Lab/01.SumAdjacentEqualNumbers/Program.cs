using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.SumAdjacentEqualNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine().Split().Select(double.Parse).ToList();

            for (int currentNum = 0; currentNum < numbers.Count - 1; currentNum++)
            {
                if (numbers[currentNum] == numbers[currentNum + 1])
                {
                    numbers[currentNum] += numbers[currentNum + 1];
                    numbers.RemoveAt(currentNum + 1);
                    currentNum = -1;
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
