using System;

namespace _02._Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysForStatistics = int.Parse(Console.ReadLine());
            int avaiableMedics = 7;

            int treatedPatientsCounter = 0;
            int untreatedPatientsCounter = 0;
            for (int currentDay = 1; currentDay <= daysForStatistics; currentDay++)
            {
                int currentDayPatientNum = int.Parse(Console.ReadLine());

                if ((currentDay % 3 == 0) && (untreatedPatientsCounter > treatedPatientsCounter))
                {
                    avaiableMedics++;
                }

                if (currentDayPatientNum > avaiableMedics)
                {
                    treatedPatientsCounter += avaiableMedics;
                    untreatedPatientsCounter += (currentDayPatientNum - avaiableMedics);
                }
                else if (currentDayPatientNum <= avaiableMedics)
                {
                    treatedPatientsCounter += currentDayPatientNum;
                }
            }

            Console.WriteLine($"Treated patients: {treatedPatientsCounter}.");
            Console.WriteLine($"Untreated patients: {untreatedPatientsCounter}.");
        }
    }
}
