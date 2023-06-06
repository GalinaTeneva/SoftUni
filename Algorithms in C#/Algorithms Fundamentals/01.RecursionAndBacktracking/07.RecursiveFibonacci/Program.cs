using System;
using System.Collections.Generic;

namespace _07.RecursiveFibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            long result = GetFibonacci(num);
            Console.WriteLine(result);
        }

        //private static long GetFibonacci(int number)
        //{
        //    if (number <= 1)
        //    {
        //        return 1;
        //    }

        //    return GetFibonacci(number - 1) + GetFibonacci(number - 2);
        //}

        private static long GetFibonacci(int number)
        {
            int[] arr = new int[number + 1];
            arr[0] = 1;
            arr[1] = 1;

            for (int i = 2; i <= number; i++)
            {
                arr[i] = arr[i - 1] + arr[i - 2];
            }

            return arr[number];
        }
    }
}