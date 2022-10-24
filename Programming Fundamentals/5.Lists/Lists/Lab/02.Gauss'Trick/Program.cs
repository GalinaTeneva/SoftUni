using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Gauss_Trick
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            List<int> newNumbers = new List<int>();
            for (int i = 0; i < numbers.Count / 2; i++)
            {
                newNumbers.Add(numbers[i] + numbers[numbers.Count - 1]);
                numbers.RemoveAt(numbers.Count - 1);
                numbers.RemoveAt(i);
                i = -1;
            }

            if (numbers.Count % 2 != 0)
            {
                newNumbers.Add(numbers[numbers.Count / 2]);
            }

            Console.WriteLine(string.Join(" ", newNumbers));


        }
    }
}
