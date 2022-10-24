using System;

namespace _02._Sleepy_Tom_Cat
{
    class Program
    {
        static void Main(string[] args)
        {
            int holidays = int.Parse(Console.ReadLine());

            int minutesSleepNeeded = 30000;
            int minutesForPlayPerWorkDay = 63;
            int minutesForPlayPerHoliday = 127;

            int workDays = 365 - holidays;
            double totalMinutesForPlay = holidays * minutesForPlayPerHoliday + workDays * minutesForPlayPerWorkDay;

            double diff = Math.Abs(totalMinutesForPlay - minutesSleepNeeded);
            int diffHours = (int)diff / 60;
            int diffMinutes = (int)diff % 60;

            if (totalMinutesForPlay >= minutesSleepNeeded)
            {
                Console.WriteLine("Tom will run away");
                Console.WriteLine($"{diffHours} hours and {diffMinutes} minutes more for play");
            }
            else
            {
                Console.WriteLine("Tom sleeps well");
                Console.WriteLine($"{diffHours} hours and {diffMinutes} minutes less for play") ;
            }
        }
    }
}
