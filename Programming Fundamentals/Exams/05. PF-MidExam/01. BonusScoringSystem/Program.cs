using System;

namespace _01._BonusScoringSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());
            int lecturesCount = int.Parse(Console.ReadLine());
            double bonus = int.Parse(Console.ReadLine());

            double maxBonus = 0;
            double maxAttendances = 0;
            for (int i = 1; i <= studentsCount; i++)
            {
                double currStudentAttendances = int.Parse(Console.ReadLine());
                double currStudentBonus = currStudentAttendances / lecturesCount * (5 + bonus);

                if (currStudentBonus > maxBonus)
                {
                    maxBonus = currStudentBonus;
                    maxAttendances = currStudentAttendances;
                }
            }

            Console.WriteLine($"Max Bonus: {Math.Ceiling(maxBonus)}.");
            Console.WriteLine($"The student has attended {maxAttendances} lectures.");

        }
    }
}
