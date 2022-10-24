using System;
using System.Linq;

namespace _08.CondenseArrayToNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int[] numbers = new int[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                numbers[i] = int.Parse(input[i]);
            }

            int[] condensed = new int[numbers.Length];
            for (int i = 0; i < input.Length -1; i++)
            {
                for (int j = 0; j < numbers.Length - 1; j++)
                {
                    condensed[j] = numbers[j] + numbers[j + 1];
                }
                numbers = condensed;
            }

            Console.WriteLine(numbers[0]);
        }
    }
}
