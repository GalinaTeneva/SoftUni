using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.BattlePoints
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] energyCost = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] battlePoints = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int initialEnergy = int.Parse(Console.ReadLine());

            int[,] dp = new int[energyCost.Length + 1, initialEnergy + 1];
            bool[,] isSpend = new bool[energyCost.Length + 1, initialEnergy + 1];

            for (int row = 1; row < dp.GetLength(0); row++)
            {
                int enemyIdx = row - 1;

                for (int energy = 1; energy < dp.GetLength(1); energy++)
                {
                    int excluding = dp[row - 1, energy];

                    if (energyCost[enemyIdx] > energy)
                    {
                        dp[row, energy] = excluding;
                        continue;
                    }

                    int including = battlePoints[enemyIdx] + dp[row - 1, energy - energyCost[enemyIdx]];

                    if (including > excluding)
                    {
                        dp[row, energy] = including;
                        isSpend[row, energy] = true;
                    }
                    else
                    {
                        dp[row, energy] = excluding;
                    }
                }
            }

            int currEnergy = initialEnergy;
            int totalPoints = 0;

            for (int row = dp.GetLength(0) - 1; row > 0; row--)
            {
                int enemyIdx = row - 1;

                if (!isSpend[row, currEnergy])
                {
                    continue;
                }

                totalPoints += battlePoints[enemyIdx];
                currEnergy -= energyCost[enemyIdx];

                if (currEnergy == 0)
                {
                    break;
                }
            }

            Console.WriteLine(totalPoints);
        }
    }
}