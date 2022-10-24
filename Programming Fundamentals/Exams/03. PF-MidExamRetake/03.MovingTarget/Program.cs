using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MovingTarget
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine().Split().Select(int.Parse).ToList();
            string[] currentCommand = Console.ReadLine().Split();

            while (currentCommand[0] != "End")
            {
                int targetIndex = int.Parse(currentCommand[1]);
                if (currentCommand[0] == "Shoot")
                {
                    int power = int.Parse(currentCommand[2]);
                    targets = ShootTarget(targets, targetIndex, power);

                }
                else if (currentCommand[0] == "Add")
                {
                    if (targetIndex >= 0 && targetIndex < targets.Count)
                    {
                        int value = int.Parse(currentCommand[2]);
                        targets.Insert(targetIndex, value);
                    }
                    else
                    {
                        Console.WriteLine("Invalid placement!");
                    }
                }
                else if (currentCommand[0] == "Strike")
                {
                    int radius = int.Parse(currentCommand[2]);
                    bool isTargetValid = targetIndex >= 0 && targetIndex < targets.Count;

                    int startIndex = targetIndex - radius;
                    bool isStartIndexValid = startIndex >= 0 && startIndex < targets.Count;
                    int endIndex = targetIndex + radius;
                    bool isEndIndexValid = endIndex >= 0 && endIndex < targets.Count;
                    if (isTargetValid && isStartIndexValid && isEndIndexValid)
                    {
                        targets.RemoveRange(startIndex, 2 * radius + 1);
                    }
                    else
                    {
                        Console.WriteLine("Strike missed!");
                    }
                }

                currentCommand = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join("|", targets));
        }

        static List<int> ShootTarget(List<int> targets, int targetIndex, int shootPower)
        {
            if (targetIndex >= 0 &&  targetIndex < targets.Count)
            {
                targets[targetIndex] -= shootPower;

                if (targets[targetIndex] <= 0)
                {
                    targets.RemoveAt(targetIndex);
                }
            }
                return targets;
        }
    }
}
