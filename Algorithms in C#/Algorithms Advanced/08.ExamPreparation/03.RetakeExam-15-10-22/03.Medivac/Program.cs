using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Medivac
{
    public class Unit
    {
        public int UnitNumber { get; set; }

        public int CapacityTaken { get; set; }

        public int UnitUrgency { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int medivacCapacity = int.Parse(Console.ReadLine());

            List<Unit> units = new List<Unit>();

            while (true)
            {
                string[] lineInfo = Console.ReadLine().Split();

                if (lineInfo[0] == "Launch")
                {
                    break;
                }

                units.Add(new Unit
                {
                    UnitNumber = int.Parse(lineInfo[0]),
                    CapacityTaken = int.Parse(lineInfo[1]),
                    UnitUrgency = int.Parse(lineInfo[2])
                });
            }

            int[,] dp = new int[units.Count + 1, medivacCapacity + 1];
            bool[,] used = new bool[units.Count + 1, medivacCapacity + 1];

            for (int row = 1; row < dp.GetLength(0); row++)
            {
                Unit unit = units[row - 1];

                for (int capacity = 1; capacity < dp.GetLength(1); capacity++)
                {
                    int excluding = dp[row - 1, capacity];

                    if (unit.CapacityTaken > capacity)
                    {
                        dp[row, capacity] = excluding;
                        continue;
                    }

                    int including = unit.UnitUrgency + dp[row - 1, capacity - unit.CapacityTaken];

                    if (including > excluding)
                    {
                        dp[row, capacity] = including;
                        used[row, capacity] = true;
                    }
                    else
                    {
                        dp[row, capacity] = excluding;
                    }
                }
            }

            int currCapacity = medivacCapacity;
            int totalCapacity = 0;
            SortedSet<int> takenUnits = new SortedSet<int>();

            for (int row  = dp.GetLength(0) - 1; row > 0; row--)
            {
                if (!used[row, currCapacity])
                {
                    continue;
                }

                Unit unit = units[row - 1];
                totalCapacity += unit.CapacityTaken;
                takenUnits.Add(unit.UnitNumber);
                currCapacity -= unit.CapacityTaken;

                if (currCapacity == 0)
                {
                    break;
                }
            }

            Console.WriteLine(totalCapacity);
            Console.WriteLine(dp[units.Count, medivacCapacity]);

            foreach (int unit  in takenUnits)
            {
                Console.WriteLine(unit);
            }
        }
    }
}