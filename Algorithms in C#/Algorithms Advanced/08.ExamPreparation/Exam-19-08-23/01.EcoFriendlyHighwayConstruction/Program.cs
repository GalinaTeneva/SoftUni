using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.EcoFriendlyHighwayConstruction
{
    public class Connection
    {
        public string FirstTown { get; set; }

        public string SecondTown { get; set; }

        public int Cost { get; set; }

        public int EnvironmentCost { get; set; }
    }

    internal class Program
    {
        public static List<Connection> allConnections;
        public static Dictionary<string, string> parent;

        static void Main(string[] args)
        {
            int connectionsCount = int.Parse(Console.ReadLine());

            parent = new Dictionary<string, string>();
            allConnections = new List<Connection>();

            ReadMap(connectionsCount);

            var sortedConnections = allConnections
                .OrderBy(c => c.Cost + c.EnvironmentCost)
                .ToArray();

            int totalCost = 0;

            foreach (Connection connection in sortedConnections)
            {
                string firstConnectionRoot = FindRoot(connection.FirstTown);
                string secondConnectionRoot = FindRoot(connection.SecondTown);

                if (firstConnectionRoot != secondConnectionRoot)
                {
                    parent[firstConnectionRoot] = secondConnectionRoot;
                    totalCost += connection.Cost + connection.EnvironmentCost;
                }
            }

            Console.WriteLine($"Total cost of building highways: {totalCost}");
        }

        private static string FindRoot(string node)
        {
            while (parent[node] != node)
            {
                node = parent[node];
            }

            return node;
        }

        private static void ReadMap(int connections)
        {
            for (int i = 0; i < connections; i++)
            {
                string[] connectionInfo = Console.ReadLine().Split();

                string firstTown = connectionInfo[0];
                string secondTown = connectionInfo[1];
                int cost = int.Parse(connectionInfo[2]);
                int environmentCost = 0;

                if (connectionInfo.Length == 4)
                {
                    environmentCost = int.Parse(connectionInfo[3]);
                }

                Connection connection = new Connection
                {
                    FirstTown = firstTown,
                    SecondTown = secondTown,
                    Cost = cost,
                    EnvironmentCost = environmentCost
                };

                if (!parent.ContainsKey(firstTown))
                {
                    parent[firstTown] = firstTown;
                }

                if (!parent.ContainsKey(secondTown))
                {
                    parent[secondTown] = secondTown;
                }

                allConnections.Add(connection);
            }
        }
    }
}