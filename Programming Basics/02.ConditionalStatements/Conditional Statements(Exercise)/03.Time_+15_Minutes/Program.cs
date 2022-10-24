using System;

namespace _03.Time__15_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            int newMinutes = minutes + 15;

            if (newMinutes >= 60)
            {
                hours += 1;
                newMinutes = newMinutes - 60;     // newMinutes -= 60
            }
            
            if (hours >= 24)
            {
                hours = 0;
            }

            Console.WriteLine($"{hours}:{newMinutes:D2}");
        }
    }
}
