using System;

namespace _08._Tennis_Ranklist
{
    class Program
    {
        static void Main(string[] args)
        {
            int tournamentsNumber = int.Parse(Console.ReadLine());
            int startingPoints = int.Parse(Console.ReadLine());

            int pointsForStageW = 2000;
            int pointsForStageF = 1200;
            int pointsForStageSF = 720;

            int finalPoints = startingPoints;
            double winningsCount = 0;
            for (int i = 1; i <= tournamentsNumber; i++)
            {

                string tournamentStage = Console.ReadLine();
                if (tournamentStage == "W")
                {
                    finalPoints += pointsForStageW;
                    winningsCount++;
                }
                else if (tournamentStage == "F")
                {
                    finalPoints += pointsForStageF;
                }
                else if (tournamentStage == "SF")
                {
                    finalPoints += pointsForStageSF;
                }
            }

            Console.WriteLine($"Final points: {finalPoints}");

            double averagePoint = (finalPoints - startingPoints) / tournamentsNumber;
            Console.WriteLine($"Average points: {averagePoint}");

            double tournamentsWinningsInPercent = winningsCount / tournamentsNumber * 100;
            Console.WriteLine($"{tournamentsWinningsInPercent:f2}%");
        }
    }
}
