using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace _02.SocialMediaTracker
{
    public class Relationship
    {
        public string UserFrom { get; set; }

        public string UserTo { get; set; }

        public int Influence { get; set; }
    }

    internal class Program
    {
        public static Dictionary<string, List<Relationship>> allRelationships;
        public static Dictionary<string, double> influences;
        public static Dictionary<string, string> parentByUser;

        static void Main(string[] args)
        {
            int relationshipsCount = int.Parse(Console.ReadLine());

            allRelationships = new Dictionary<string, List<Relationship>>();

            influences = new Dictionary<string, double>();
            parentByUser = new Dictionary<string, string>();

            ReadMap(relationshipsCount);

            string startUser = Console.ReadLine();
            string destinationUser = Console.ReadLine();

            influences[startUser] = 0;

            Stack<string> sortedUsers = TopologicalSorting();

            while (sortedUsers.Count > 0)
            {
                string user = sortedUsers.Pop();

                foreach (Relationship relationship in allRelationships[user])
                {
                    double newInfluence = influences[relationship.UserFrom] + relationship.Influence;

                    if (newInfluence > influences[relationship.UserTo])
                    {
                        influences[relationship.UserTo] = newInfluence;
                        parentByUser[relationship.UserTo] = relationship.UserFrom;
                    }
                }
            }

            var path = new Stack<string>();
            var currNode = destinationUser;

            while (!string.IsNullOrEmpty(currNode))
            {
                path.Push(currNode);
                currNode = parentByUser[currNode];
            }

            Console.WriteLine($"({influences[destinationUser]}, {path.Count - 1})");
        }

        private static Stack<string> TopologicalSorting()
        {
            Stack<string> result = new Stack<string>();
            HashSet<string> visited = new HashSet<string>();

            foreach (string user in allRelationships.Keys)
            {
                DFS(user, visited, result);
            }

            return result;
        }

        private static void DFS(string user, HashSet<string> visited, Stack<string> result)
        {
            if (visited.Contains(user))
            {
                return;
            }

            visited.Add(user);

            foreach (Relationship relationship in allRelationships[user])
            {
                DFS(relationship.UserTo, visited, result);
            }

            result.Push(user);
        }

        private static void ReadMap(int relationshipsCount)
        {
            for (int i = 0; i < relationshipsCount; i++)
            {
                string[] relationshipsInfo = Console.ReadLine().Split();

                string firstUser = relationshipsInfo[0];
                string secondUser = relationshipsInfo[1];
                int influence = int.Parse(relationshipsInfo[2]);

                Relationship relationship = new Relationship
                {
                    UserFrom = firstUser,
                    UserTo = secondUser,
                    Influence = influence
                };

                if (!allRelationships.ContainsKey(firstUser))
                {
                    allRelationships[firstUser] = new List<Relationship>();
                }
                if (!allRelationships.ContainsKey(secondUser))
                {
                    allRelationships[secondUser] = new List<Relationship>();
                }

                allRelationships[firstUser].Add(relationship);

                if (!parentByUser.ContainsKey(firstUser))
                {
                    parentByUser[firstUser] = string.Empty;
                }
                if (!parentByUser.ContainsKey(secondUser))
                {
                    parentByUser[secondUser] = string.Empty;
                }

                if (!influences.ContainsKey(firstUser))
                {
                    influences[firstUser] = double.NegativeInfinity;
                }
                if (!influences.ContainsKey(secondUser))
                {
                    influences[secondUser] = double.NegativeInfinity;
                }
            }
        }
    }
}