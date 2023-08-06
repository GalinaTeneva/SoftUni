using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.LongestStringChain
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] strings = Console.ReadLine().Split();

            int[] bestLength = new int[strings.Length];
            int[] parent = new int[strings.Length];

            int maxLength = 0;
            int bestIdx = 0;

            for (int idx = 0; idx < strings.Length; idx++)
            {
                string currString = strings[idx];

                int currLength = 1;
                int currParent = -1;

                for (int prev = idx - 1; prev >= 0; prev--)
                {
                    string prevString = strings[prev];
                    int prevMaxLength = bestLength[prev];

                    if (currString.Length > strings[prev].Length &&
                        prevMaxLength + 1 >= currLength)
                    {
                        currLength = prevMaxLength + 1;
                        currParent = prev;
                    }
                }

                bestLength[idx] = currLength;
                parent[idx] = currParent;

                if (currLength > maxLength)
                {
                    maxLength = currLength;
                    bestIdx = idx;
                }
            }

            Stack<string> lis = new Stack<string>();

            while (bestIdx != -1)
            {
                lis.Push(strings[bestIdx]);
                bestIdx = parent[bestIdx];
            }

            Console.WriteLine(string.Join(" ", lis));
        }
    }
}