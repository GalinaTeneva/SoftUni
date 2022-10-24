using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            int divider = int.Parse(Console.ReadLine());

            Func<List<int>, Predicate<int>, List<int>> exclude = (nums, match) =>
            {
                List<int> result = new List<int>();

                for (int i = 0; i < nums.Count; i++)
                {
                    if (!match(nums[i]))
                    {
                        result.Add(nums[i]);
                    }
                }

                return result;
            };

            numbers = exclude(numbers, n => n % divider == 0);
            numbers.Reverse();

            Console.WriteLine(String.Join(' ', numbers));
        }
    }
}
