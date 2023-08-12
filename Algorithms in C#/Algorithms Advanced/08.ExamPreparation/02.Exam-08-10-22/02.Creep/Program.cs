using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace _02.Creep
{
    public class Vine
    {
        public int From { get; set; }

        public int To { get; set; }

        public int Length { get; set; }

        public override string ToString()
        {
            return $"{this.From} {this.To}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int tumorsCount = int.Parse(Console.ReadLine());
            int vinesCount = int.Parse(Console.ReadLine());

            Dictionary<int, Dictionary<int, int>> graph = ReadGraph(tumorsCount, vinesCount);

            List<Vine> vinesTree = new List<Vine>();

            int[] parent = new int[tumorsCount + 1];
            for (int i = 0; i < parent.Length; i++)
            {
                parent[i] = i;
            }
            
            List<Vine> orderedVines = new List<Vine>();
            foreach (var tumor in graph)
            {
                foreach (var child in tumor.Value)
                {
                    Vine vine = new Vine
                    {
                        From = tumor.Key,
                        To = child.Key,
                        Length = child.Value
                    };

                    orderedVines.Add(vine);
                }
            }

            orderedVines = orderedVines.OrderBy(v => v.Length).ToList();

            foreach (Vine vine in orderedVines)
            {
                int firstNodeRoot = FindRoot(parent, vine.From);
                int secondNodeRoot = FindRoot(parent, vine.To);

                if (firstNodeRoot == secondNodeRoot)
                {
                    continue;
                }

                parent[firstNodeRoot] = secondNodeRoot;
                vinesTree.Add(vine);
            }

            int totalLength = 0;
            foreach (Vine vine in vinesTree)
            {
                Console.WriteLine(vine);
                totalLength += vine.Length;
            }

            Console.WriteLine(totalLength);
        }

        private static int FindRoot(int[] parent, int tumor)
        {
            while (parent[tumor] != tumor)
            {
                tumor = parent[tumor];
            }

            return tumor;
        }

        private static Dictionary<int, Dictionary<int, int>> ReadGraph(int tumors, int edges)
        {
            Dictionary<int, Dictionary<int, int>> graph = new Dictionary<int, Dictionary<int, int>>();

            for (int i = 0; i < tumors + 1; i++)
            {
                graph.Add(i, new Dictionary<int, int>());
            }

            for (int i = 0; i < edges; i++)
            {
                int[] edgeInfo = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                int from = edgeInfo[0];
                int to = edgeInfo[1];
                int length = edgeInfo[2];

                graph[from][to] = length;
            }

            return graph;
        }
    }
}