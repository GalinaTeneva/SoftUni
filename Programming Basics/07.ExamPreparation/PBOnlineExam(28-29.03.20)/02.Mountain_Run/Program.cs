using System;

namespace _02.Mountain_Run
{
    class Program
    {
        static void Main(string[] args)
        {
            double record = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double secondsForOneMeter = double.Parse(Console.ReadLine());


            double delay = Math.Floor(distance / 50) * 30;
            double georgeTime = (distance * secondsForOneMeter) + delay;

            if (georgeTime < record)
            {
                Console.WriteLine($"Yes! The new record is {georgeTime:F2} seconds.");
            }
            else
            {
                double diff = georgeTime - record;
                Console.WriteLine($"No! He was {diff:F2} seconds slower.");
            }
        }
    }
}
