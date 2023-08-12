using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _03.Code
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] firstMessage = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] secondMessage = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[,] lcs = new int[firstMessage.Length + 1, secondMessage.Length + 1];

            for (int row = 1; row <= firstMessage.Length; row++)
            {
                for (int col = 1; col <= secondMessage.Length; col++)
                {
                    if (firstMessage[row - 1] == secondMessage[col - 1])
                    {
                        lcs[row, col] = lcs[row - 1, col - 1] + 1;
                    }
                    else
                    {
                        lcs[row, col] = Math.Max(lcs[row - 1, col], lcs[row, col - 1]);
                    }
                }
            }

            int[] equalParts = new int[lcs[firstMessage.Length, secondMessage.Length]];

            int r = firstMessage.Length;
            int c = secondMessage.Length;
            int idx = equalParts.Length - 1;

            while (r > 0 && c > 0)
            {
                if (firstMessage[r - 1] == secondMessage[c - 1])
                {
                    equalParts[idx] = firstMessage[r - 1];
                    idx--;
                    r--;
                    c--;
                }
                else if (lcs[r - 1, c] > lcs[r, c - 1])
                {
                    r--;
                }
                else
                {
                    c--;
                }
            }

            Console.WriteLine(string.Join(" ", equalParts));
            Console.WriteLine(equalParts.Length);
        }
    }
}