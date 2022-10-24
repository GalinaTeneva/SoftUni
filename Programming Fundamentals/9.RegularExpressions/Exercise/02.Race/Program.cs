using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.Race
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> racersByDistance = new Dictionary<string, int>();
            string racersNames = Console.ReadLine();

            string namePattern = @"[a-zA-Z]+";
            string distancePattern = @"\d";

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end of race")
                {
                    break;
                }

                string currName = "";
                int currDistance = 0;

                MatchCollection nameParts = Regex.Matches(input, namePattern);
                MatchCollection distances = Regex.Matches(input, distancePattern);

                currName = string.Join("", nameParts);

                //foreach (Match match in nameParts)
                //{
                //    currName += match;
                //}

                if (racersNames.Contains(currName) && !racersByDistance.ContainsKey(currName))
                {
                    racersByDistance[currName] = 0;
                }

                if (racersByDistance.ContainsKey(currName))
                {
                    foreach (Match match in distances)
                    {
                        currDistance += int.Parse(match.ToString());
                    }

                    racersByDistance[currName] += currDistance;
                }
            }

            var winners = racersByDistance.OrderByDescending(x => x.Value).Take(3);
            var firstPlace = winners.Take(1);
            var secondPlace = winners.OrderByDescending(x => x.Value).Take(2).OrderBy(x => x.Value).Take(1);
            var thirdPlace = winners.OrderBy(x => x.Value).Take(1);

            foreach (var racer in firstPlace)
            {
                Console.WriteLine($"1st place: {racer.Key}");
            }
            foreach (var racer in secondPlace)
            {
                Console.WriteLine($"2nd place: {racer.Key}");
            }
            foreach (var racer in thirdPlace)
            {
                Console.WriteLine($"3rd place: {racer.Key}");
            }
        }
    }
}
