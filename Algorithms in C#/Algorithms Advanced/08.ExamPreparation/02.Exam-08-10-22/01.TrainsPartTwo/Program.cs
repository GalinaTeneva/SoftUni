using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace _01.TrainsPartTwo
{
    public class Track
    {
        public int FirstDepot { get; set; }

        public int SecondDepot { get; set; }

        public int Distance { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int depotsCount = int.Parse(Console.ReadLine());
            int tracksCount = int.Parse(Console.ReadLine());

            int[] deliveryInfo = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int startDepot = deliveryInfo[0];
            int endDepot = deliveryInfo[1];

            List<Track>[] map = ReadMap(tracksCount, depotsCount);

            double[] distance = new double[map.Length];
            int[] parent = new int[map.Length];

            for (int i = 0; i < map.Length; i++)
            {
                distance[i] = double.PositiveInfinity;
                parent[i] = -1;
            }

            var bag = new OrderedBag<int>(Comparer<int>.Create((f, s) => distance[f].CompareTo(distance[s])));

            bag.Add(startDepot);

            distance[startDepot] = 0;

            while (bag.Count > 0)
            {
                int minDepot = bag.RemoveFirst();

                if (double.IsPositiveInfinity(distance[minDepot]))
                {
                    break;
                }

                if (minDepot == endDepot)
                {
                    break;
                }

                foreach (Track track in map[minDepot])
                {
                    int otherDepot = track.FirstDepot == minDepot ? track.SecondDepot : track.FirstDepot;

                    if (double.IsPositiveInfinity(distance[otherDepot]))
                    {
                        bag.Add(otherDepot);
                    }

                    double newDistance = distance[minDepot] + track.Distance;

                    if (newDistance < distance[otherDepot])
                    {
                        distance[otherDepot] = newDistance;
                        parent[otherDepot] = minDepot;

                        bag = new OrderedBag<int>(bag, Comparer<int>.Create((f, s) => distance[f].CompareTo(distance[s])));
                    }
                }
            }

            Stack<int> path = new Stack<int> ();

            int depot = endDepot;

            while (depot != -1)
            {
                path.Push (depot);
                depot = parent[depot];
            }

            Console.WriteLine(string.Join(" ", path));
            Console.WriteLine(distance[endDepot]);
        }

        private static List<Track>[] ReadMap(int tracks, int depots)
        {
            List<Track>[] map = new List<Track>[depots];

            for (int i = 0; i < map.Length; i++)
            {
                map[i] = new List<Track>();
            }

            for (int i = 0; i < tracks; i++)
            {
                int[] currTrackInfo = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                Track track = new Track
                {
                    FirstDepot = currTrackInfo[0],
                    SecondDepot = currTrackInfo[1],
                    Distance = currTrackInfo[2]
                };

                map[currTrackInfo[0]].Add(track);
                map[currTrackInfo[1]].Add(track);
            }

            return map;
        }
    }
}