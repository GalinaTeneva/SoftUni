using System;

namespace _07._Football_League
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalSeatsInTheStadium = int.Parse(Console.ReadLine());
            int totalFansNum = int.Parse(Console.ReadLine());

            double totalFansForSectorA = 0;
            double totalFansForSectorB = 0;
            double totalFansForSectorV = 0;
            double totalFansForSectorG = 0;

            for (int currentFan = 1; currentFan <= totalFansNum; currentFan++)
            {
                char currentFanSector = char.Parse(Console.ReadLine());

                if (currentFanSector == 'A')
                {
                    totalFansForSectorA++;
                }
                else if (currentFanSector == 'B')
                {
                    totalFansForSectorB++;
                }
                else if (currentFanSector == 'V')
                {
                    totalFansForSectorV++;
                }
                else if (currentFanSector == 'G')
                {
                    totalFansForSectorG++;
                }
            }

            Console.WriteLine($"{(totalFansForSectorA / totalFansNum * 100):F2}%");
            Console.WriteLine($"{(totalFansForSectorB / totalFansNum * 100):F2}%");
            Console.WriteLine($"{(totalFansForSectorV / totalFansNum * 100):F2}%");
            Console.WriteLine($"{(totalFansForSectorG / totalFansNum * 100):F2}%");
            Console.WriteLine($"{(totalFansNum / (double)totalSeatsInTheStadium * 100):F2}%");


        }
    }
}
