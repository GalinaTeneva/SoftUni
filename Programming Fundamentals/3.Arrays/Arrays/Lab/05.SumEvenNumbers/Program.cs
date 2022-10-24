using System;
using System.Linq;

namespace _05.SumEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] input = Console.ReadLine().Split(" ");

            //int[] numbers = new int[input.Length];
            //for (int i = 0; i < input.Length; i++)
            //{
            //    numbers[i] = int.Parse(input[i]);
            //}

            //int sum = 0;
            //for (int i = 0; i < numbers.Length; i++)
            //{
            //    bool isEven = numbers[i] % 2 == 0;
            //    if (isEven)
            //    {
            //        sum += numbers[i];
            //    }
            //}

            //Console.WriteLine(sum);


            int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int sum = 0;
            foreach (int number in numbers)
            {
                bool isEven = number % 2 == 0;
                if (isEven)
                {
                    sum += number;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
