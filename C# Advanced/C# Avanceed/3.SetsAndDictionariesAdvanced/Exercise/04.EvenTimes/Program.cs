using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> numsByCount = new Dictionary<int, int>();

            int linesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < linesCount; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (!numsByCount.ContainsKey(num))
                {
                    numsByCount.Add(num, 0);
                }

                numsByCount[num]++;
            }

            Console.WriteLine(numsByCount.First(n => n.Value % 2 == 0).Key);
        }
    }
}
