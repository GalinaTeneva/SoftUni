using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.AppendArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> initialLine = Console.ReadLine().Split('|').ToList();

            List<int> resultLine = new List<int>();

            for (int currGroupOfNums = initialLine.Count - 1; currGroupOfNums >= 0; currGroupOfNums--)
            {
                List<int> listOfCurrGroup = initialLine[currGroupOfNums].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                resultLine.AddRange(listOfCurrGroup);
            }

            Console.WriteLine(string.Join(" ", resultLine));
        }
    }
}
