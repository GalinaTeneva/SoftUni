using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace _05.CableNetwork
{
    public class Edge
    {
        public int First { get; set; }

        public int Second { get; set; }

        public int Weight { get; set; }
    }

    internal class Program
    {
        public static HashSet<int> forestNodes;
        public static Dictionary<int, List<Edge>> graph;

        static void Main(string[] args)
        {
            int budged = int.Parse(Console.ReadLine());
            int nodes = int.Parse(Console.ReadLine());
            int edges = int.Parse(Console.ReadLine());

            forestNodes = new HashSet<int>();

            graph = ReadGraph(edges);

            int usedBudget = Prim(budged);
            Console.WriteLine($"Budget used: {usedBudget}");
        }

        private static int Prim(int budget)
        {
            int usedBudget = 0;

            var bag = new OrderedBag<Edge>(Comparer<Edge>.Create((f, s) => f.Weight - s.Weight));
            foreach (var n in forestNodes)
            {
                bag.AddMany(graph[n]);
            }

            while (bag.Count > 0)
            {
                Edge minEdge = bag.RemoveFirst();

                int nonTreeNode = -1;

                if (forestNodes.Contains(minEdge.First) &&
                    !forestNodes.Contains(minEdge.Second))
                {
                    nonTreeNode = minEdge.Second;
                }

                if (forestNodes.Contains(minEdge.Second) &&
                    !forestNodes.Contains(minEdge.First))
                {
                    nonTreeNode = minEdge.First;
                }

                if (nonTreeNode == -1)
                {
                    continue;
                }

                forestNodes.Add(nonTreeNode);
                bag.AddMany(graph[nonTreeNode]);

                int newUsedBudget = usedBudget + minEdge.Weight;

                if (newUsedBudget >= budget)
                {
                    return usedBudget;
                }
                else
                {
                    usedBudget = newUsedBudget;
                }
            }
            return usedBudget;
        }

        private static Dictionary<int, List<Edge>> ReadGraph(int edges)
        {
            Dictionary<int, List<Edge>> result = new Dictionary<int, List<Edge>>();

            for (int n = 0; n < edges; n++)
            {
                string[] currEdgeInfo = Console.ReadLine().Split();

                int firstNode = int.Parse(currEdgeInfo[0]);
                int secondNode = int.Parse(currEdgeInfo[1]);
                int weight = int.Parse(currEdgeInfo[2]);

                Edge edge = new Edge
                {
                    First = firstNode,
                    Second = secondNode,
                    Weight = weight
                };

                if (!result.ContainsKey(firstNode))
                {
                    result[firstNode] = new List<Edge>();
                }

                if (!result.ContainsKey(secondNode))
                {
                    result[secondNode] = new List<Edge>();
                }

                result[firstNode].Add(edge);
                result[secondNode].Add(edge);

                if (currEdgeInfo.Length == 4)
                {
                    forestNodes.Add(firstNode);
                    forestNodes.Add(secondNode);
                }
            }

            return result;
        }
    }
}