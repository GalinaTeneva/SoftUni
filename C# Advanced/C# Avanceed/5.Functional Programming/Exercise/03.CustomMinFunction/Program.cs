using System;
using System.Linq;

namespace _03.CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> smallestNum = (nums) =>
            {
                int min = int.MaxValue;

                foreach (int num in nums)
                {
                    if (num < min)
                    {
                        min = num;
                    }
                }

                return min;
            };

            int[] nums = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(smallestNum(nums));
        }
    }
}
