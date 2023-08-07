using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.LongestZigzagSubsequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[,] dp = new int[2, numbers.Length];
            dp[0, 0] = dp[1, 0] = 1;

            int[,] parent = new int[2, numbers.Length];
            parent[0, 0] = parent[1, 0] = -1;

            int bestLength = 0;
            int lastRow = 0;
            int lastCol = 0;

            for (int curr = 1; curr < dp.GetLength(1); curr++)
            {
                int currNum = numbers[curr];

                for (int prev = curr - 1; prev >= 0; prev--)
                {
                    int prevNum = numbers[prev];

                    if (currNum > prevNum &&
                        dp[1, prev] >= dp[0, curr])
                    {
                        dp[0, curr] = dp[1, prev] + 1;
                        parent[0, curr] = prev;
                    }

                    if (prevNum > currNum &&
                        dp[0, prev] + 1 >= dp[1, curr])
                    {
                        dp[1, curr] = dp[0, prev] + 1;
                        parent[1, curr] = prev;
                    }
                }

                if (dp[0, curr] > bestLength)
                {
                    bestLength = dp[0, curr];
                    lastRow = 0;
                    lastCol = curr;
                }
                if (dp[1, curr] > bestLength)
                {
                    bestLength = dp[1, curr];
                    lastRow = 1;
                    lastCol = curr;
                }
            }

            Stack<int> seq = new Stack<int>();

            while (lastCol != -1)
            {
                seq.Push(numbers[lastCol]);
                lastCol = parent[lastRow, lastCol];
                lastRow = lastRow == 0 ? 1 : 0;
            }

            Console.WriteLine(string.Join(" ", seq));
        }
    }
}