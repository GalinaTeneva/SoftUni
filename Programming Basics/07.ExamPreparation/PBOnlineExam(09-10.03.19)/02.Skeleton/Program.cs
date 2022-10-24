using System;

namespace _02.Skeleton
{
    class Program
    {
        static void Main(string[] args)
        {
            int controlMin = int.Parse(Console.ReadLine());
            int controlSec = int.Parse(Console.ReadLine());
            double chuteLength = double.Parse(Console.ReadLine());
            int secondsFor100Meters = int.Parse(Console.ReadLine());

            int controlInSeconds = (60 * controlMin) + controlSec;
            double delayInSeconds = (chuteLength / 120) * 2.5;

            double playerResult = (chuteLength / 100) * secondsFor100Meters - delayInSeconds;

            if (playerResult <= controlInSeconds)
            {
                Console.WriteLine("Marin Bangiev won an Olympic quota!");
                Console.WriteLine("His time is {0:F3}.", playerResult);
            }
            else
            {
                double diff = playerResult - controlInSeconds;
                Console.WriteLine("No, Marin failed! He was {0:F3} second slower.", diff);
            }
        }
    }
}
