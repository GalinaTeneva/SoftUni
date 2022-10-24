using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            Predicate<int> isEven = (num) => num % 2 == 0;
            Predicate<int> isOdd = num => num % 2 != 0;

            int[] startAndEndNums = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string command = Console.ReadLine();

            List<int> nums = new List<int>();
            for (int i = startAndEndNums[0]; i <= startAndEndNums[1]; i++)
            {
                nums.Add(i);
            }

            switch (command)
            {
                case "even":
                    nums = nums.FindAll(isEven);
                    Console.WriteLine(string.Join(' ', nums));
                    break;
                case "odd":
                    nums = nums.FindAll(isOdd);
                    Console.WriteLine(string.Join(' ', nums));
                    break;
            }
        }
    }
}
