using System;

namespace _08._Graduation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();

            double gradesSum = 0;
            int offCounter = 0;


            int yearsCounter = 1;
            while (yearsCounter <= 12)
            {
                double grade = double.Parse(Console.ReadLine());

                if (grade < 4)
                {
                    offCounter++;

                    if (offCounter == 2)
                    {
                        Console.WriteLine($"{name} has been excluded at {yearsCounter} grade");
                        return;
                    }

                    continue;
                }

                yearsCounter++;
                gradesSum += grade;
            }

            Console.WriteLine($"{name} graduated. Average grade: {(gradesSum/12):F2}");
        }
    }
}
