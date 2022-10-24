using System;

namespace _04.Trekking_Mania
{
    class Program
    {
        static void Main(string[] args)
        {
            int groupsNum = int.Parse(Console.ReadLine());

            double totalPeople = 0;
            int peopleForMusala = 0;
            int peopleForMontblan = 0;
            int peopleForKilimanjaro = 0;
            int peopleForK2 = 0;
            int peopleForEverest = 0;

            for (int currentGroup = 1; currentGroup <= groupsNum; currentGroup++)
            {
                int peopleInCurrentGroup = int.Parse(Console.ReadLine());

                if (peopleInCurrentGroup <= 5)
                {
                    peopleForMusala += peopleInCurrentGroup;
                    totalPeople += peopleInCurrentGroup;
                }
                else if (peopleInCurrentGroup >= 6 && peopleInCurrentGroup <= 12)
                {
                    peopleForMontblan += peopleInCurrentGroup;
                    totalPeople += peopleInCurrentGroup;
                }
                else if (peopleInCurrentGroup >= 13 && peopleInCurrentGroup <= 25)
                {
                    peopleForKilimanjaro += peopleInCurrentGroup;
                    totalPeople += peopleInCurrentGroup;
                }
                else if (peopleInCurrentGroup >= 26 && peopleInCurrentGroup <= 40)
                {
                    peopleForK2 += peopleInCurrentGroup;
                    totalPeople += peopleInCurrentGroup;
                }
                else if (peopleInCurrentGroup >= 41)
                {
                    peopleForEverest += peopleInCurrentGroup;
                    totalPeople += peopleInCurrentGroup;
                }
            }

            double groupMusalaPercent = peopleForMusala / totalPeople * 100;
            double groupMontblanPercent = peopleForMontblan / totalPeople * 100;
            double groupKilimanjaroPercent = peopleForKilimanjaro / totalPeople * 100;
            double groupK2Percent = peopleForK2 / totalPeople * 100;
            double groupEverestPercent = peopleForEverest / totalPeople * 100;

            Console.WriteLine($"{groupMusalaPercent:F2}%");
            Console.WriteLine($"{groupMontblanPercent:F2}%");
            Console.WriteLine($"{groupKilimanjaroPercent:F2}%");
            Console.WriteLine($"{groupK2Percent:F2}%");
            Console.WriteLine($"{groupEverestPercent:F2}%");
        }
    }
}
