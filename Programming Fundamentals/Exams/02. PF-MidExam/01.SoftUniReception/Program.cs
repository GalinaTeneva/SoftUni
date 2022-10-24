using System;

namespace _01.SoftUniReception
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstemployeeProductivityPerHour = int.Parse(Console.ReadLine());
            int secondemployeeProductivityPerHour = int.Parse(Console.ReadLine());
            int thirdemployeeProductivityPerHour = int.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());

            int productiviityOfAllEmployees = firstemployeeProductivityPerHour + secondemployeeProductivityPerHour + thirdemployeeProductivityPerHour;

            int timeNeeded = 0;
            while (studentsCount > 0)
            {
                studentsCount -= productiviityOfAllEmployees;
                timeNeeded++;
                if (timeNeeded % 4 == 0)
                {timeNeeded++;
                }
            }
            Console.WriteLine($"Time needed: {timeNeeded}h.");
        }
    }
}
