using System;

namespace _05._Firm
{
    class Program
    {
        static void Main(string[] args)
        {
            int hoursNeeded = int.Parse(Console.ReadLine());
            int givenDays = int.Parse(Console.ReadLine());
            int workersWithOvertime = int.Parse(Console.ReadLine());

            int workHoursPerDay = 8;
            double daysForTrainingPercent = 0.1;
            int maxHoursOvertimePerWorker = 2;

            double actualWorkDays = givenDays - givenDays * daysForTrainingPercent;
            double normalWorkHours = actualWorkDays * workHoursPerDay;
            double overtimeHours = maxHoursOvertimePerWorker * workersWithOvertime * givenDays;
            double actualWorkHours = normalWorkHours + overtimeHours;

            double roundedWorkHours = Math.Floor(actualWorkHours);

            if (roundedWorkHours >= hoursNeeded)
            {
                double hoursLeft = roundedWorkHours - hoursNeeded;
                Console.WriteLine($"Yes!{hoursLeft} hours left.");
            }
            else
            {
                double hoursShortage = hoursNeeded - roundedWorkHours;
                Console.WriteLine($"Not enough time!{hoursShortage} hours needed.");
            }
        }
    }
}
