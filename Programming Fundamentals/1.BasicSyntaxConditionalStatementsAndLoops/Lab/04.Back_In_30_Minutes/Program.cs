using System;

namespace _04.Back_In_30_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            if ((minutes += 30) >= 60)
            {
                minutes -= 60;
                hour++;
            }
            if (hour == 24)
            {
                hour = 0;
            }

            Console.WriteLine($"{hour}:{minutes:D2}");
        }
    }
}
