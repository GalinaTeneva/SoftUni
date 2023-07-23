using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.CheapTownTour
{
    public class Road
    {
        public int FirstTown { get; set; }

        public int SecondTown { get; set; }

        public int RoadCost { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int townsNum = int.Parse(Console.ReadLine());
            int roadsNum = int.Parse(Console.ReadLine());

            var roads = new List<Road>();

            for (int r = 0; r < roadsNum; r++)
            {
                int[] currRoadInfo = Console.ReadLine()
                    .Split(" - ")
                    .Select(int.Parse)
                    .ToArray();

                int firstTown = currRoadInfo[0];
                int secondTown = currRoadInfo[1];

                roads.Add(new Road()
                {
                    FirstTown = firstTown,
                    SecondTown = secondTown,
                    RoadCost = currRoadInfo[2]
                });
            }

            var prev = new int[townsNum];
            for (int town = 0; town < prev.Length; town++)
            {
                prev[town] = town;
            }

            var sortedRoads = roads.OrderBy(r => r.RoadCost).ToList();
            int minCostTrip = 0;

            foreach (Road roaad in sortedRoads)
            {
                int firstTownRoot = FindRootTown(roaad.FirstTown, prev);
                int secondTownRoot = FindRootTown(roaad.SecondTown, prev);

                if (firstTownRoot != secondTownRoot)
                {
                    minCostTrip += roaad.RoadCost;
                    prev[firstTownRoot] = secondTownRoot;
                }
            }

            Console.WriteLine($"Total cost: {minCostTrip}");
        }

        private static int FindRootTown(int town, int[] parent)
        {
            while (parent[town] != town)
            {
                town = parent[town];
            }

            return town;
        }
    }
}