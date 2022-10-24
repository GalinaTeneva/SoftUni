using System;
using System.Linq;

namespace _05.AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int[]> add = nums =>
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    nums[i]++;
                }

                return nums;
            };

            Func<int[], int[]> multiply = nums =>
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    nums[i] *= 2;
                }

                return nums;
            };

            Func<int[], int[]> subtract = nums =>
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    nums[i]--;
                }

                return nums;
            };

            Action<int[]> print = nums => Console.WriteLine(String.Join(" ", nums));

            int[] nums = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "end")
                {
                    break;
                }

                Operation(add, multiply, subtract, print, nums, command);
            }
        }

        private static void Operation(Func<int[], int[]> add, Func<int[], int[]> multiply, Func<int[], int[]> subtract, Action<int[]> print, int[] nums, string command)
        {
            switch (command)
            {
                case "add":
                    add(nums);
                    break;
                case "multiply":
                    multiply(nums);
                    break;
                case "subtract":
                    subtract(nums);
                    break;
                case "print":
                    print(nums);
                    break;
            }
        }
    }
}
