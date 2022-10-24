using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _04.StarEnigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int commandsNum = int.Parse(Console.ReadLine());

            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();

            string pattern = @".*@(?<planet>[A-z]+)[^@\-!:>]*:(?<population>\d+)[^@\-!:>]*!(?<action>A|D)![^@\-!:>]*->(?<soldiars>\d+).*";
            Regex regex = new Regex(pattern);

            for (int currCommand = 1; currCommand <= commandsNum; currCommand++)
            {
                string currEcryptedCommandSymbols = Console.ReadLine();
                StringBuilder sb = new StringBuilder();

                int specialLettersCount = 0;
                foreach (char symbol in currEcryptedCommandSymbols)
                {
                    char currSymbol = char.ToLower(symbol);
                    if (currSymbol == 's' || currSymbol == 't' || currSymbol == 'a' || currSymbol == 'r')
                    {
                        specialLettersCount++;
                    }
                }
                foreach (char symbol in currEcryptedCommandSymbols)
                {
                    char newSymbol = (char)((int)symbol - specialLettersCount);
                    sb.Append(newSymbol);
                }
                string currDecryptedCommand = sb.ToString();

                if (regex.IsMatch(currDecryptedCommand))
                {
                    char currAttackType = char.Parse(regex.Match(currDecryptedCommand).Groups["action"].ToString());
                    string currPlanet = regex.Match(currDecryptedCommand).Groups["planet"].ToString();
                    if (currAttackType == 'A')
                    {
                        attackedPlanets.Add(currPlanet);
                    }
                    else
                    {
                        destroyedPlanets.Add(currPlanet);
                    }
                }
            }

            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            foreach (var planet in attackedPlanets.OrderBy(x => x))
            {
                Console.WriteLine($"-> {planet}");
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            foreach (var planet in destroyedPlanets.OrderBy(x => x))
            {
                Console.WriteLine($"-> {planet}");
            }
        }
    }
}
