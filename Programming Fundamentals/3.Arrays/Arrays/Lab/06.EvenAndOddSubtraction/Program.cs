using System;
using System.Linq;

namespace _06.EvenAndOddSubtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] input = Console.ReadLine().Split();

            //int[] numbers = new int[input.Length];
            //for (int i = 0; i < input.Length; i++)
            //{
            //    numbers[i] = int.Parse(input[i]);
            //}

            //int evenSum = 0;
            //int oddSum = 0;
            //for (int i = 0; i < numbers.Length; i++)
            //{
            //    if (numbers[i] % 2 == 0)
            //    {
            //        evenSum += numbers[i];
            //    }
            //    else
            //    {
            //        oddSum += numbers[i];
            //    }
            //}

            //Console.WriteLine(evenSum - oddSum);


            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int evenSum = 0;
            int oddSum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    evenSum += numbers[i];
                }
                else
                {
                    oddSum += numbers[i];
                }
            }

            Console.WriteLine(evenSum - oddSum);
        }
    }
}
