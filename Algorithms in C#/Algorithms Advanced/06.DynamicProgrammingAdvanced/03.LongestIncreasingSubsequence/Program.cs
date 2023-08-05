using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.LongestIncreasingSubsequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] length = new int[numbers.Length];
            int[] parent = new int[numbers.Length];

            int bestLength = 0;
            int bestIndex = 0;

            for (int curr = 0; curr < numbers.Length; curr++)
            {
                int currNum = numbers[curr];
                int currLength = 1;
                int currParent = -1;

                for (int prev = curr - 1; prev >= 0; prev--)
                {
                    int prevNum = numbers[prev];
                    int prevLength = length[prev];

                    if (currNum > prevNum &&
                        prevLength + 1 >= currLength)
                    {
                        currLength = prevLength + 1;
                        currParent = prev;
                    }
                }

                length[curr] = currLength;
                parent[curr] = currParent;

                if (currLength > bestLength)
                {
                    bestLength = currLength;
                    bestIndex = curr;
                }
            }

            Stack<int> lis = new Stack<int>();

            while (bestIndex != -1)
            {
                lis.Push(numbers[bestIndex]);
                bestIndex = parent[bestIndex];
            }

            Console.WriteLine(string.Join(" ", lis));
        }
    }
}