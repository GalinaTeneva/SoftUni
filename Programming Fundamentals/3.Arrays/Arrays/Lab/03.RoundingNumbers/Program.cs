using System;
using System.Linq;

namespace _03.RoundingNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string values = Console.ReadLine();

            string[] numbers = values.Split(" ");
            double[] numbersArr = new double[numbers.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbersArr[i] = double.Parse(numbers[i]);
            }

            for (int i = 0; i < numbersArr.Length; i++)
            {
                Console.WriteLine($"{numbersArr[i]} => {(int)Math.Round(numbersArr[i], MidpointRounding.AwayFromZero)}");
            }

            //double[] numbersArr = Console.ReadLine().Split().Select(double.Parse).ToArray();

            //for (int i = 0; i < numbersArr.Length; i ++)
            //{
            //    Console.WriteLine($"{numbersArr[i]} => {Math.Round(numbersArr[i],MidpointRounding.AwayFromZero)}");
            //}
        }
    }
}
