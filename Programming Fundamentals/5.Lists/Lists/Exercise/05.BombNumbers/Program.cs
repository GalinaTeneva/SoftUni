using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int[] bombNumAndPower = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int bombNum = bombNumAndPower[0];
            int bombPower = bombNumAndPower[1];

            for (int currentNumberIndex = 0; currentNumberIndex < numbers.Count; currentNumberIndex++)
            {
                if (numbers[currentNumberIndex] == bombNum)
                {
                    BombRange(numbers, bombPower, currentNumberIndex);
                }
            }

            Console.WriteLine(numbers.Sum());

        }

        private static void BombRange(List<int> numbers, int bombPower, int currentNumberIndex)
        {
            int start = Math.Max(0, currentNumberIndex - bombPower);
            int end = Math.Min(numbers.Count - 1, currentNumberIndex + bombPower);

            for (int i = start; i <= end; i++)
            {
                numbers[i] = 0;
            }
        }
    }
}
