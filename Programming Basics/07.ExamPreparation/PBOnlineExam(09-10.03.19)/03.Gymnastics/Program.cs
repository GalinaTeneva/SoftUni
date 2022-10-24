using System;

namespace _03.Gymnastics
{
    class Program
    {
        static void Main(string[] args)
        {
            string country = Console.ReadLine();
            string apparatus = Console.ReadLine();

            double difficultyAssessment = 0;
            double performanceAssessment = 0;
            if (country == "Russia")
            {
                switch (apparatus)
                {
                    case "ribbon":
                        difficultyAssessment = 9.100;
                        performanceAssessment = 9.400;
                        break;
                    case "hoop":
                        difficultyAssessment = 9.300;
                        performanceAssessment = 9.800;
                        break;
                    case "rope":
                        difficultyAssessment = 9.600;
                        performanceAssessment = 9.000;
                        break;
                }
            }
            else if (country == "Bulgaria")
            {
                switch (apparatus)
                {
                    case "ribbon":
                        difficultyAssessment = 9.600;
                        performanceAssessment = 9.400;
                        break;
                    case "hoop":
                        difficultyAssessment = 9.550;
                        performanceAssessment = 9.750;
                        break;
                    case "rope":
                        difficultyAssessment = 9.500;
                        performanceAssessment = 9.400;
                        break;
                }
            }
            else if (country == "Italy")
            {
                switch (apparatus)
                {
                    case "ribbon":
                        difficultyAssessment = 9.200;
                        performanceAssessment = 9.500;
                        break;
                    case "hoop":
                        difficultyAssessment = 9.450;
                        performanceAssessment = 9.350;
                        break;
                    case "rope":
                        difficultyAssessment = 9.700;
                        performanceAssessment = 9.150;
                        break;
                }
            }

            double finalAssessment = difficultyAssessment + performanceAssessment;

            double pointsToMaxResult = 20 - finalAssessment;
            double pointsToMaxResultPercent = (pointsToMaxResult / 20) * 100;

            Console.WriteLine($"The team of {country} get {finalAssessment:F3} on {apparatus}.");
            Console.WriteLine($"{pointsToMaxResultPercent:F2}%");
        }
    }
}
