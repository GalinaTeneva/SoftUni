using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            double averageNum = numbers.Average();
            numbers.Sort();
            numbers.Reverse();
            int maxNumGreaterThenAverage = 5;
            int numsGreaterThanAverage = 0;
            for (int currentNumIndex = 0; currentNumIndex < numbers.Count; currentNumIndex++)
            {
                if (numbers[currentNumIndex] > averageNum)
                {
                    Console.Write(numbers[currentNumIndex] + " ");
                    numsGreaterThanAverage++;
                    if (numsGreaterThanAverage == maxNumGreaterThenAverage)
                    {
                        break;
                    }
                }
            }

            if (numsGreaterThanAverage == 0)
            {
                Console.WriteLine("No");
            }
        }
    }
}
