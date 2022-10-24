using System;
using System.Linq;

namespace _03.Largest3Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputNums = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .ToArray();

            int[] largestThreeNums = inputNums.OrderByDescending(n => n).Take(3).ToArray();

            Console.WriteLine(string.Join(' ', largestThreeNums));
        }
    }
}
