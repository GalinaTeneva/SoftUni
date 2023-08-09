using System;
using System.Collections.Generic;
using System.Linq;

using Wintellect.PowerCollections;

namespace _01.TourdeSofia
{
    public class Street
    {
        public int JunctionFrom { get; set; }

        public int JunctionTo { get; set; }

        public int Distance { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int junctionsNum = int.Parse(Console.ReadLine());
            int streetsNum = int.Parse(Console.ReadLine());
            int startJunction = int.Parse(Console.ReadLine());

            List<Street>[] map = new List<Street>[junctionsNum];

            for (int i = 0; i < junctionsNum; i++)
            {
                map[i] = new List<Street>();
            }

            ReadMap(streetsNum, map);

            double[] distance = new double[junctionsNum];

            for (int street = 0; street < junctionsNum; street++)
            {
                distance[street] = double.PositiveInfinity;
            }

            var bag = new OrderedBag<int>(Comparer<int>.Create((f, s) => (distance[f].CompareTo(distance[s]))));

            foreach (Street street in map[startJunction])
            {
                bag.Add(street.JunctionTo);

                distance[street.JunctionTo] = street.Distance;

                bag = new OrderedBag<int>(bag, Comparer<int>.Create((f, s) => (distance[f].CompareTo(distance[s]))));
            }

            while (bag.Count != 0)
            {
                int minJuncton = bag.RemoveFirst();

                if (minJuncton == startJunction)
                {
                    break;
                }

                foreach (Street street in map[minJuncton])
                {
                    if (double.IsPositiveInfinity(distance[street.JunctionTo]))
                    {
                        bag.Add(street.JunctionTo);
                    }

                    double newDistance = distance[minJuncton] + street.Distance;

                    if (newDistance < distance[street.JunctionTo])
                    {
                        distance[street.JunctionTo] = newDistance;

                        bag = new OrderedBag<int>(bag, Comparer<int>.Create((f, s) => (distance[f].CompareTo(distance[s]))));
                    }
                }
            }

            if (double.IsPositiveInfinity(distance[startJunction]))
            {
                Console.WriteLine(distance.Count(d => !double.IsPositiveInfinity(d)) + 1);
            }
            else
            {
                Console.WriteLine(distance[startJunction]);
            }
        }

        private static void ReadMap(int streetsNum, List<Street>[] map)
        {
            for (int street = 0; street < streetsNum; street++)
            {
                int[] currStreetInfo = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                int junctionFrom = currStreetInfo[0];
                int junctionTo = currStreetInfo[1];
                int distance = currStreetInfo[2];

                Street currStreet = new Street
                {
                    JunctionFrom = junctionFrom,
                    JunctionTo = junctionTo,
                    Distance = distance
                };

                map[junctionFrom].Add(currStreet);
            }
        }
    }
}