using System;

namespace _04._Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            int goal = 10000;
            int stepsSum = 0;

            while (stepsSum < goal)
            {
                string input = Console.ReadLine();

                if (input == "Going home")
                {
                    input = Console.ReadLine();
                    stepsSum += int.Parse(input);
                    break;
                }

                stepsSum += int.Parse(input);
            }

            if (stepsSum >= goal)
            {
                int diff = stepsSum - goal;
                Console.WriteLine("Goal reached! Good job!");
                Console.WriteLine($"{diff} steps over the goal!");
            }
            else
            {
                int diff = goal - stepsSum;
                Console.WriteLine($"{diff} more steps to reach goal.");
            }
        }
    }
}
