using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> passwordsByContests = new Dictionary<string, string>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end of contests")
                {
                    break;
                }

                string[] inputTokens = input.Split(':', StringSplitOptions.RemoveEmptyEntries);
                string contest = inputTokens[0];
                string password = inputTokens[1];

                passwordsByContests.Add(contest, password);
            }

            SortedDictionary<string, Dictionary<string, int>> usersPointsByContests = new SortedDictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end of submissions")
                {
                    break;
                }

                string[] inputTokens = input.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string contest = inputTokens[0];
                string password = inputTokens[1];
                string username = inputTokens[2];
                int points = int.Parse(inputTokens[3]);

                if (!passwordsByContests.ContainsKey(contest) || password != passwordsByContests[contest])
                {
                    continue;
                }

                if (!usersPointsByContests.ContainsKey(username))
                {
                    usersPointsByContests[username] = new Dictionary<string, int>();
                }

                if (!usersPointsByContests[username].ContainsKey(contest))
                {
                    usersPointsByContests[username][contest] = 0;
                }

                if (points > usersPointsByContests[username][contest])
                {
                    usersPointsByContests[username][contest] = points;
                }
            }

            string bestUser = usersPointsByContests.OrderByDescending(u => u.Value.Values.Sum()).First().Key;
            int bestUserPoints = usersPointsByContests[bestUser].Values.Sum();

            Console.WriteLine($"Best candidate is {bestUser} with total {bestUserPoints} points. \r\n" +
                $"Ranking:");

            foreach (var kvp in usersPointsByContests)
            {
                Console.WriteLine(kvp.Key);

                foreach (var pair in kvp.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {pair.Key} -> {pair.Value}");
                }
            }
        }
    }
}
