using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TheV_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, HashSet<string>>> vloggers = new Dictionary<string, Dictionary<string, HashSet<string>>>();

            string input = Console.ReadLine();
            while (true)
            {
                if (input == "Statistics")
                {
                    break;
                }

                string[] inputTokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string vloggerName = inputTokens[0];
                string cmd = inputTokens[1];

                if (cmd == "joined")
                {
                    if (!vloggers.ContainsKey(vloggerName))
                    {
                        vloggers[vloggerName] = new Dictionary<string, HashSet<string>>();
                        vloggers[vloggerName].Add("followers", new HashSet<string>());
                        vloggers[vloggerName].Add("following", new HashSet<string>());
                    }
                }
                else if (cmd == "followed")
                {
                    string vloggerToFollow = inputTokens[2];

                    if (!vloggers.ContainsKey(vloggerName) 
                        || !vloggers.ContainsKey(vloggerToFollow)
                        || vloggerName == vloggerToFollow)
                    {
                        input = Console.ReadLine();
                        continue;
                    }
                   
                    vloggers[vloggerName]["following"].Add(vloggerToFollow);
                    vloggers[vloggerToFollow]["followers"].Add(vloggerName);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");


            var sortedVlogers = vloggers.OrderByDescending(v => v.Value["followers"].Count).ThenBy(v => v.Value["following"].Count).ToDictionary(x => x.Key, x => x.Value);

            int counter = 0;
            foreach (var kvp in sortedVlogers)
            {
                Console.WriteLine($"{++counter}. {kvp.Key} : {kvp.Value["followers"].Count} followers, {kvp.Value["following"].Count} following");
                if (counter == 1)
                {
                    foreach (var item in kvp.Value["followers"].OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {item}");
                    }
                }
            }
        }
    }
}
