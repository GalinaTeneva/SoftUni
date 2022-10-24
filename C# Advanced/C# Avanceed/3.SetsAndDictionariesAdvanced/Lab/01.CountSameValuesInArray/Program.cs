using System;
using System.Collections.Generic;

namespace _01.CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputNums = Console.ReadLine().Split();

            Dictionary<double, int> numsByCount = new Dictionary<double, int>();

            foreach (string str in inputNums)
            {
                double num = double.Parse(str);

                if (!numsByCount.ContainsKey(num))
                {
                    numsByCount[num] = 0;
                }

                numsByCount[num]++;
            }

            foreach (var kvp in numsByCount)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
            }
        }
    }
}
