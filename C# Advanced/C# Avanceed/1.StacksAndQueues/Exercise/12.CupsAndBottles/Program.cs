using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cupsArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] bottlesArr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> cupsVolume = new Queue<int>(cupsArr);
            Stack<int> bottlesLitters = new Stack<int>(bottlesArr);

            int wastedLitters = 0;
            bool areBottlesFinished = false;

            while (cupsVolume.Count > 0)
            {
                int currCup = cupsVolume.Dequeue();
                int currBottle = 0;

                while (currCup > 0)
                {
                    currBottle = bottlesLitters.Pop();

                    if (currBottle >= currCup)
                    {
                        wastedLitters += currBottle - currCup;
                        currCup = 0;
                    }
                    else
                    {
                        currCup -= currBottle;
                    }

                    if (bottlesLitters.Count == 0)
                    {
                        areBottlesFinished = true;
                        break;
                    }
                }

                if (areBottlesFinished)
                {
                    break;
                }
            }

            if (cupsVolume.Count == 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottlesLitters)}");
            }
            else
            {
                Console.WriteLine($"Cups: {string.Join(" ", cupsVolume)}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedLitters}");
        }
    }
}
