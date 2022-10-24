using System;

namespace _04.Train_The_Trainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int juryNum = int.Parse(Console.ReadLine());
            double allGradesSum = 0;
            int allGradesCounter = 0;

            string presentationName;
            while ((presentationName = Console.ReadLine()) != "Finish")
            {
                double currentPresentationGradesSum = 0; 
                for (int jury = 1; jury <= juryNum; jury++)
                {
                    string currentGrade = Console.ReadLine();
                    allGradesCounter++;
                    currentPresentationGradesSum += double.Parse(currentGrade);
                    allGradesSum += double.Parse(currentGrade);
                }

                double averageGrade = currentPresentationGradesSum / juryNum;
                Console.WriteLine($"{presentationName} - {averageGrade:F2}.");
            }

            double finalAssesment = allGradesSum / allGradesCounter;
            Console.WriteLine("Student's final assessment is {0:F2}.", finalAssesment);
        }
    }
}
