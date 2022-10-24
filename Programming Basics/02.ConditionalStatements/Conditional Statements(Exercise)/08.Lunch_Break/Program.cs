using System;

namespace _08.Lunch_Break
{
    class Program
    {
        static void Main(string[] args)
        {
            string filmName = Console.ReadLine();
            int filmLength = int.Parse(Console.ReadLine());
            int lunchBreakLength = int.Parse(Console.ReadLine());

            double lunchTime = lunchBreakLength * 0.125;        // 1/8 = 0.125
            double restTime = lunchBreakLength * 0.25;          // 1/4 = 0.25

            double filmTime = lunchBreakLength - lunchTime - restTime;

            if (filmTime >= filmLength)
            {
                double timeLeft = filmTime - filmLength;
                Console.WriteLine($"You have enough time to watch {filmName} and left with {Math.Ceiling(timeLeft)} minutes free time.");
            }
            else
            {
                double timeShortage = filmLength - filmTime;
                Console.WriteLine($"You don't have enough time to watch {filmName}, you need {Math.Ceiling(timeShortage)} more minutes.");
            }
        }
    }
}
