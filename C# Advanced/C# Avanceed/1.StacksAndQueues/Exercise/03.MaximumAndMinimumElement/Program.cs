using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int queriesNum = int.Parse(Console.ReadLine());

            Stack<int> elements = new Stack<int>();

            for (int currQuery = 1; currQuery <= queriesNum; currQuery++)
            {
                int[] currQueryArg = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int currQueryType = currQueryArg[0];

                if (currQueryType == 1)
                {
                    elements.Push(currQueryArg[1]);
                }

                if (elements.Count == 0)
                {
                    continue;
                }

                if (currQueryType == 2)
                {
                    elements.Pop();
                }
                else if (currQueryType == 3)
                {
                    Console.WriteLine(elements.Max());
                }
                else if (currQueryType == 4)
                {
                    Console.WriteLine(elements.Min());
                }
            }

            Console.WriteLine(string.Join(", ", elements));
        }
    }
}
