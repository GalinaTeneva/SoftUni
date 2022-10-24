using System;

namespace _06.World_Swimming_Record
{
    class Program
    {
        static void Main(string[] args)
        {
            double record = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double secondsForMeter = double.Parse(Console.ReadLine());

            double delayPerFifteen = Math.Floor(distance / 15);
            double totalDelay = delayPerFifteen * 12.5;

            double secondsForTheDistance = distance * secondsForMeter + totalDelay;

            if (secondsForTheDistance < record)
            {
                Console.WriteLine($" Yes, he succeeded! The new world record is {secondsForTheDistance:F2} seconds.");
            }
            else
            {
                double secondsOverTheRecord = secondsForTheDistance - record;
                Console.WriteLine($"No, he failed! He was {secondsOverTheRecord:F2} seconds slower.");
            }
        }
    }
}
