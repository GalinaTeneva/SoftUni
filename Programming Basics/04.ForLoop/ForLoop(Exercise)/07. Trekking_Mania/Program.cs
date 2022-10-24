using System;

namespace _07._Trekking_Mania
{
    class Program
    {
        static void Main(string[] args)
        {
            int groupCount = int.Parse(Console.ReadLine());

            int mountaineersForMusala = 0;
            int mountaineersForMontBlanc = 0;
            int mountaineersForKilimanjaro = 0;
            int mountaineersForK2 = 0;
            int mountaineersForEverest = 0;
            double totalPeople = 0;

            for (int i = 0; i < groupCount; i++)
            {
                int currentGroupPeople = int.Parse(Console.ReadLine());

                totalPeople += currentGroupPeople;

                if (currentGroupPeople <= 5)
                {
                    mountaineersForMusala += currentGroupPeople;
                }
                else if (currentGroupPeople > 5 && currentGroupPeople <= 12)
                {
                    mountaineersForMontBlanc += currentGroupPeople;
                }
                else if (currentGroupPeople > 12 && currentGroupPeople <= 25)
                {
                    mountaineersForKilimanjaro += currentGroupPeople;
                }
                else if (currentGroupPeople > 25 && currentGroupPeople <= 40)
                {
                    mountaineersForK2 += currentGroupPeople;
                }
                else if (currentGroupPeople > 40)
                {
                    mountaineersForEverest += currentGroupPeople;
                }
            }

            double mountaineersForMusalaPercentage = mountaineersForMusala / totalPeople * 100;
            double mountaineersForMontBlancPercentage = mountaineersForMontBlanc / totalPeople * 100;
            double mountaineersForKilimanjaroPercentage = mountaineersForKilimanjaro / totalPeople * 100;
            double mountaineersForK2Percentage = mountaineersForK2 / totalPeople * 100;
            double mountaineersForEverestPercentage = mountaineersForEverest / totalPeople * 100;

            Console.WriteLine($"{mountaineersForMusalaPercentage:f2}%");
            Console.WriteLine($"{mountaineersForMontBlancPercentage:f2}%");
            Console.WriteLine($"{mountaineersForKilimanjaroPercentage:f2}%");
            Console.WriteLine($"{mountaineersForK2Percentage:f2}%");
            Console.WriteLine($"{mountaineersForEverestPercentage:f2}%");
        }
    }
}
