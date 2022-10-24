using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> clothesValues = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            int rackCapacity = int.Parse(Console.ReadLine());

            int racksCount = 1;
            int currRackSum = 0;

            while (clothesValues.Count > 0)
            {
                bool isThereFreeSpace = currRackSum < rackCapacity && clothesValues.Peek() <= rackCapacity - currRackSum;
                if (isThereFreeSpace)
                {
                    currRackSum += clothesValues.Pop();
                }
                else
                {
                    racksCount++;
                    currRackSum = 0;
                }
            }

            Console.WriteLine(racksCount);

        }
    }
}
