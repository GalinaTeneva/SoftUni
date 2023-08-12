using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace _02.ChainLightning
{
    public class Road
    {
        public int FirstNeighborhood { get; set; }

        public int SecondNeighborhood { get; set; }

        public int Distance { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int neighboorhoodsCount = int.Parse(Console.ReadLine());
            int distancesCount = int.Parse(Console.ReadLine());

            List<Road>[] map = new List<Road>[neighboorhoodsCount];

            for (int i = 0; i < neighboorhoodsCount; i++)
            {
                map[i] = new List<Road>();
            }

            int lightningsCount = int.Parse(Console.ReadLine());

            ReadMap(map, distancesCount);


            HashSet<int> forestNeighborhood = new HashSet<int>();
            int[] neighborhoodDamage = new int[neighboorhoodsCount];

            for (int lightning = 0; lightning < lightningsCount; lightning++)
            {
                int[] lightningInfo = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                int startNeighborhood = lightningInfo[0];
                int lightningDamage = lightningInfo[1];

                Prim(map, neighborhoodDamage, lightningDamage, startNeighborhood);
            }

            Console.WriteLine(neighborhoodDamage.Max());
        }

        private static void Prim(List<Road>[] map, int[] damageByNeighborhood, int damage, int start)
        {
            HashSet<int> tree = new HashSet<int>();
            tree.Add(start);

            damageByNeighborhood[start] += damage;

            int[] jumps = new int[map.Length];

            var bag = new OrderedBag<Road>(Comparer<Road>.Create((f, s) => f.Distance.CompareTo(s.Distance)));

            bag.AddMany(map[start]);

            while (bag.Count > 0)
            {
                Road minRoad = bag.RemoveFirst();

                int treeNeighborhood = -1;
                int nonTreeNeighborhood = -1;

                if (tree.Contains(minRoad.FirstNeighborhood) &&
                    !tree.Contains(minRoad.SecondNeighborhood))
                {
                    treeNeighborhood = minRoad.FirstNeighborhood;
                    nonTreeNeighborhood = minRoad.SecondNeighborhood;
                }

                if (tree.Contains(minRoad.SecondNeighborhood) &&
                    !tree.Contains(minRoad.FirstNeighborhood))
                {
                    treeNeighborhood = minRoad.SecondNeighborhood;
                    nonTreeNeighborhood = minRoad.FirstNeighborhood;
                }

                if (nonTreeNeighborhood == -1)
                {
                    continue;
                }

                tree.Add(nonTreeNeighborhood);
                bag.AddMany(map[nonTreeNeighborhood]);
                jumps[nonTreeNeighborhood] = jumps[treeNeighborhood] + 1;
                damageByNeighborhood[nonTreeNeighborhood] += CalcDamage(damage, jumps[nonTreeNeighborhood]);
            }
        }

        private static int CalcDamage(int damage, int jumps)
        {
            for (int i = 0; i < jumps; i++)
            {
                damage /= 2;
            }

            return damage;
        }

        private static void ReadMap(List<Road>[] map, int distancesCount)
        {
            for (int road = 0; road < distancesCount; road++)
            {
                int[] roadData = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                int firstNeighborhood = roadData[0];
                int secondNeighborhood = roadData[1];

                Road currRoad = new Road
                {
                    FirstNeighborhood = firstNeighborhood,
                    SecondNeighborhood = secondNeighborhood,
                    Distance = roadData[2]
                };

                map[firstNeighborhood].Add(currRoad);
                map[secondNeighborhood].Add(currRoad);
            }
        }
    }
}