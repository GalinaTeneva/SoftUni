using System;
using System.Linq;

namespace _02._ShootForTheWin
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] targets = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int shootTargetsCounter = 0;
            string input = Console.ReadLine();
            while (input != "End")
            {
                int currTargetIndex = int.Parse(input);

                if (currTargetIndex < 0 || currTargetIndex >= targets.Length)
                {
                    input = Console.ReadLine();
                    continue;
                }

                int currTargetValue = targets[currTargetIndex];

                if (targets[currTargetIndex] != -1)
                {
                    targets[currTargetIndex] = -1;
                    shootTargetsCounter++;

                    for (int i = 0; i < targets.Length; i++)
                    {
                        if (targets[i] != -1 && targets[i] > currTargetValue)
                        {
                            targets[i] -= currTargetValue;
                        }
                        else if (targets[i] != -1 && targets[i] <= currTargetValue)
                        {
                            targets[i] += currTargetValue;
                        }
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Shot targets: {shootTargetsCounter} -> {string.Join(" ", targets)}");
        }
    }
}
