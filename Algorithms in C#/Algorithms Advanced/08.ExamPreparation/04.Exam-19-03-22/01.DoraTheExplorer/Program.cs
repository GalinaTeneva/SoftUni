using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace _01.DoraTheExplorer
{
    public class Connection
    {
        public int FirstCity { get; set; }

        public int SecondCity { get; set; }

        public int Minutes { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int connectionsCount = int.Parse(Console.ReadLine());

            Dictionary<int, List<Connection>> map = ReadMap(connectionsCount);

            int exploringMinutes = int.Parse(Console.ReadLine());
            int startCity = int.Parse(Console.ReadLine());
            int endCity = int.Parse(Console.ReadLine());

            int biggestCity = map.Keys.Max();

            int[] parent = new int[biggestCity + 1];
            double[] minutes = new double[biggestCity + 1];

            for (int i = 0; i < parent.Length; i++)
            {
                parent[i] = -1;
                minutes[i] = double.PositiveInfinity;
            }

            var bag = new OrderedBag<int>(Comparer<int>.Create((f, s) => minutes[f].CompareTo(minutes[s])));
            bag.Add(startCity);

            minutes[startCity] = 0;

            while (bag.Count > 0)
            {
                int minCity = bag.RemoveFirst();

                if (minCity == endCity)
                {
                    break;
                }

                if (double.IsPositiveInfinity(minutes[minCity]))
                {
                    break;
                }

                foreach (var connection in map[minCity])
                {
                    int otherCity = connection.FirstCity == minCity ? connection.SecondCity : connection.FirstCity;

                    if (double.IsPositiveInfinity(minutes[otherCity]))
                    {
                        bag.Add(otherCity);
                    }

                    double newDistance = minutes[minCity] + connection.Minutes + exploringMinutes;

                    if (newDistance < minutes[otherCity])
                    {
                        minutes[otherCity] = newDistance;
                        parent[otherCity] = minCity;

                        bag = new OrderedBag<int>(bag, Comparer<int>.Create((f, s) => minutes[f].CompareTo(minutes[s])));
                    }
                }
            }

            Stack<int> path = new Stack<int>();
            int city = endCity;

            while (parent[city] != -1)
            {
                path.Push(city);
                city = parent[city];
            }

            path.Push(startCity);

            double totalMinutes = minutes[endCity] - exploringMinutes;

            Console.WriteLine($"Total time: {totalMinutes}");
            Console.WriteLine(string.Join(Environment.NewLine, path));
        }
        private static Dictionary<int, List<Connection>> ReadMap(int connections)
        {
            Dictionary<int, List<Connection>> result = new Dictionary<int, List<Connection>>();

            for (int i = 0; i < connections; i++)
            {
                string[] connectionInfo = Console.ReadLine()
                    .Split(new char[] { ',', ' ' });

                int firstCity = int.Parse(connectionInfo[0]);
                int secondCity = int.Parse(connectionInfo[2]);
                int minutes = int.Parse(connectionInfo[4]);

                Connection connection = new Connection
                {
                    FirstCity = firstCity,
                    SecondCity = secondCity,
                    Minutes = minutes
                };

                if (!result.ContainsKey(firstCity))
                {
                    result[firstCity] = new List<Connection>();
                }

                if (!result.ContainsKey(secondCity))
                {
                    result[secondCity] = new List<Connection>();
                }

                result[firstCity].Add(connection);
                result[secondCity].Add(connection);
            }

            return result;
        }
    }
}