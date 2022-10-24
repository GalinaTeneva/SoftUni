using System;
using System.Linq;

namespace _03.HeartDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] houses = Console.ReadLine().Split("@", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string[] command = Console.ReadLine().Split();

            int currentHouseOfCupid = 0;
            int housesWithHolidayCounter = 0;
            while (command[0] != "Love!")
            {
                int jumpLength = int.Parse(command[1]);
                currentHouseOfCupid += jumpLength;

                if (currentHouseOfCupid >= houses.Length)
                {
                    currentHouseOfCupid = 0;
                }

                if (houses[currentHouseOfCupid] != 0)
                {
                    houses[currentHouseOfCupid] -= 2;

                    if (houses[currentHouseOfCupid] == 0)
                    {
                        Console.WriteLine($"Place {currentHouseOfCupid} has Valentine's day.");
                        housesWithHolidayCounter++;
                    }
                }
                else
                {
                    Console.WriteLine($"Place {currentHouseOfCupid} already had Valentine's day.");
                }

                command = Console.ReadLine().Split();
            }

            Console.WriteLine($"Cupid's last position was {currentHouseOfCupid}.");

            if (housesWithHolidayCounter == houses.Length)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Cupid has failed {houses.Length - housesWithHolidayCounter} places.");
            }
        }
    }
}
