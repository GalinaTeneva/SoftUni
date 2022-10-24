using System;

namespace _05.Tennis_Ranklist
{
    class Program
    {
        static void Main(string[] args)
        {
            int tournamentsNum = int.Parse(Console.ReadLine());
            int points = int.Parse(Console.ReadLine());

            int startingPoints = points;
            int winningsCounter = 0;
            for (int currentTournament = 1; currentTournament <= tournamentsNum; currentTournament++)
            {
                string currentTournamentStage = Console.ReadLine();
                if (currentTournamentStage == "W")
                {
                    points += 2000;
                    winningsCounter++;
                }
                else if (currentTournamentStage == "F")
                {
                    points += 1200;
                }
                else if (currentTournamentStage == "SF")
                {
                    points += 720;
                }
            }
            double averagePoints = (points - startingPoints) / (double)tournamentsNum;
            double winningsPercent = winningsCounter / (double)tournamentsNum * 100;

            Console.WriteLine($"Final points: {points}");
            Console.WriteLine($"Average points: {Math.Floor(averagePoints)}");
            Console.WriteLine($"{winningsPercent:F2}%");
        }
    }
}
