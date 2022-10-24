using System;

namespace _06.Basketball_Tournament
{
    class Program
    {
        static void Main(string[] args)
        {
            string input =" ";

            int winningsCounter = 0;
            int lossesCounter = 0;
            double totalMatches = 0;
            while ((input = Console.ReadLine()) != "End of tournaments")
            {
                string tournamentName = input;
                int currentTournamentMatches = int.Parse(Console.ReadLine());
                totalMatches += currentTournamentMatches;

                for (int currentMatch = 1; currentMatch <= currentTournamentMatches; currentMatch++)
                {
                    int dessyTeamPoints = int.Parse(Console.ReadLine());
                    int otherTeamPoints = int.Parse(Console.ReadLine());

                    int diff = Math.Abs(dessyTeamPoints - otherTeamPoints);
                    if (dessyTeamPoints > otherTeamPoints)
                    {
                        winningsCounter++;
                        Console.WriteLine($"Game {currentMatch} of tournament {tournamentName}: win with {diff} points.");
                    }
                    else
                    {
                        lossesCounter++;
                        Console.WriteLine($"Game {currentMatch} of tournament {tournamentName}: lost with {diff} points.");
                    }
                }
            }

            double winningsPercent = winningsCounter / totalMatches * 100;
            double lossesPercent = lossesCounter / totalMatches * 100;

            Console.WriteLine($"{winningsPercent:F2}% matches win");
            Console.WriteLine($"{lossesPercent:F2}% matches lost");
        }
    }
}
