using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.TheBoringCompany
{
    public class Connection
    {
        public int FirstDistrict { get; set; }

        public int SecondDistrict { get; set; }

        public int Cost { get; set; }
    }

    internal class Program
    {
        public static Dictionary<int, Dictionary<int, int>> graph;
        public static HashSet<int> connectedDistricts;
        public static Dictionary<int, Dictionary<int, int>> nonConnectedConnections;

        static void Main(string[] args)
        {
            int districtsCount = int.Parse(Console.ReadLine());
            int connectionsCount = int.Parse(Console.ReadLine());
            int connectedDistrictsCount = int.Parse(Console.ReadLine());

            graph = new Dictionary<int, Dictionary<int, int>>();
            connectedDistricts = new HashSet<int>();
            nonConnectedConnections = new Dictionary<int, Dictionary<int, int>>();

            ReadGraph(connectionsCount, districtsCount);

            for (int i = 0; i < connectedDistrictsCount; i++)
            {
                int[] connectionnInfo = Console.ReadLine()
                    .Split()
                    .Select(c => int.Parse(c))
                    .ToArray();

                int firstDistrict = connectionnInfo[0];
                int secondDistrict = connectionnInfo[1];

                connectedDistricts.Add(firstDistrict);
                connectedDistricts.Add (secondDistrict);

                nonConnectedConnections[firstDistrict].Remove(secondDistrict);
                nonConnectedConnections[secondDistrict].Remove(firstDistrict);
            }

            List<Connection> orderedNonConnectedConnections = new List<Connection>();

            foreach (var pair in nonConnectedConnections)
            {
                foreach (var item in pair.Value)
                {
                    Connection connection = new Connection
                    {
                        FirstDistrict = pair.Key,
                        SecondDistrict = item.Key,
                        Cost = item.Value
                    };

                    orderedNonConnectedConnections.Add(connection);
                }
            }

            int minDistrict = graph.Keys.Max();
            int[] parent = new int[minDistrict + 1];
            for (int i = 0; i < parent.Length; i++)
            {
                parent[i] = i;
            }

            int minConnectedDistrict = connectedDistricts.OrderBy(d => d).First();
            foreach  (int district in connectedDistricts)
            {
                parent[district] = minConnectedDistrict;
            }

            int minBudget = 0;

            orderedNonConnectedConnections = orderedNonConnectedConnections.OrderBy(c => c.Cost).ToList();

            for (int i = 0; i < orderedNonConnectedConnections.Count;)
            {
                Connection connection = orderedNonConnectedConnections[i];

                orderedNonConnectedConnections.RemoveAt(i);

                int firstDistrictRoot = FindRoot(parent, connection.FirstDistrict);
                int secondDistrictRoot = FindRoot(parent, connection.SecondDistrict);

                if (firstDistrictRoot == secondDistrictRoot)
                {
                    continue;
                }

                if (firstDistrictRoot != minConnectedDistrict && secondDistrictRoot != minConnectedDistrict)
                {
                    orderedNonConnectedConnections.Insert(i + 2, connection);
                    continue;
                }

                minBudget += connection.Cost;

                parent[connection.FirstDistrict] = minConnectedDistrict;
                parent[connection.SecondDistrict] = minConnectedDistrict;
            }

            Console.WriteLine($"Minimum budget: {minBudget}");

        }

        private static int FindRoot(int[] parent, int district)
        {
            while (parent[district] != district)
            {
                district = parent[district];
            }

            return district;
        }

        private static void ReadGraph(int connectionsCount, int districtsCount)
        {
            for (int i = 0; i < districtsCount; i++)
            {
                graph[i] = new Dictionary<int, int>();
                nonConnectedConnections[i] = new Dictionary<int, int>();
            }

            for (int i = 0; i < connectionsCount; i++)
            {
                int[] connectionInfo = Console.ReadLine()
                    .Split()
                    .Select(c => int.Parse(c))
                    .ToArray();

                int firstDistrict = connectionInfo[0];
                int secondDistrict = connectionInfo[1];

                graph[firstDistrict][secondDistrict] = connectionInfo[2];
                graph[secondDistrict][firstDistrict] = connectionInfo[2];

                nonConnectedConnections[firstDistrict][secondDistrict] = connectionInfo[2];
                nonConnectedConnections[secondDistrict][firstDistrict] = connectionInfo[2];
            }
        }
    }
}