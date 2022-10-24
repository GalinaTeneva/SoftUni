using System;

namespace _06.Tournament_Of_Christmas
{
    class Program
    {
        static void Main(string[] args)
        {
            int tournamentDays = int.Parse(Console.ReadLine());
            double totalMoney = 0;
            int totalwinnings = 0;
            int totalLosses = 0;

            for (int day = 1; day <= tournamentDays; day++)
            {
                double moneyForTheDay = 0;
                int daylyWinningsCounter = 0;
                int daylyLossesCounter = 0;
                string game;
                while ((game = Console.ReadLine()) != "Finish")
                {
                    string result = Console.ReadLine();

                    if (result == "win")
                    {
                        daylyWinningsCounter++;
                        moneyForTheDay += 20;
                    }
                    else if (result == "lose")
                    {
                        daylyLossesCounter++;
                    }

                }

                if (daylyWinningsCounter > daylyLossesCounter)
                {
                    moneyForTheDay += moneyForTheDay * 0.1;
                    totalwinnings++;
                }
                else
                {
                    totalLosses++;
                }

                totalMoney += moneyForTheDay;
            }
            if (totalwinnings > totalLosses)
            {
                totalMoney += totalMoney * 0.2;
                Console.WriteLine($"You won the tournament! Total raised money: {totalMoney:F2}");
            }
            else
            {
                Console.WriteLine($"You lost the tournament! Total raised money: {totalMoney:F2}");
            }
        }
    }
}
