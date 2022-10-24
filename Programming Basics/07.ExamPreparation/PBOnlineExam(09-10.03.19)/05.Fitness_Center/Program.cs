using System;

namespace _05.Fitness_Center
{
    class Program
    {
        static void Main(string[] args)
        {
            int visitorsNum = int.Parse(Console.ReadLine());

            int backTrainingCount = 0;
            int chestTrainingCount = 0;
            int legsTrainingCount = 0;
            int absTrainingCount = 0;
            int purchasingProteinShake = 0;
            int purchasingProteinBar = 0;

            for (int currentVisitor = 1; currentVisitor <= visitorsNum; currentVisitor++)
            {
                string visitorActivity = Console.ReadLine();

                if (visitorActivity == "Back")
                {
                    backTrainingCount++;
                }
                else if (visitorActivity == "Chest")
                {
                    chestTrainingCount++;
                }
                else if (visitorActivity == "Legs")
                {
                    legsTrainingCount++;
                }
                else if (visitorActivity == "Abs")
                {
                    absTrainingCount++;
                }
                else if (visitorActivity == "Protein shake")
                {
                    purchasingProteinShake++;
                }
                else if (visitorActivity == "Protein bar")
                {
                    purchasingProteinBar++;
                }
            }

            double peopleWorkingOutPercent = (double)(backTrainingCount + chestTrainingCount + legsTrainingCount + absTrainingCount) / visitorsNum * 100;
            double peoplelPurchasingProtein = (double)(purchasingProteinShake + purchasingProteinBar) / visitorsNum * 100;

            Console.WriteLine($"{backTrainingCount} - back");
            Console.WriteLine($"{chestTrainingCount} - chest");
            Console.WriteLine($"{legsTrainingCount} - legs");
            Console.WriteLine($"{absTrainingCount} - abs");
            Console.WriteLine($"{purchasingProteinShake} - protein shake");
            Console.WriteLine($"{purchasingProteinBar} - protein bar");
            Console.WriteLine($"{peopleWorkingOutPercent:F2}% - work out");
            Console.WriteLine($"{peoplelPurchasingProtein:F2}% - protein");
        }
    }
}
