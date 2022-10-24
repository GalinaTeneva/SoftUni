using System;
using System.Collections.Generic;

namespace _03._P_rates
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Town> townsList = new List<Town>();

            string input = Console.ReadLine();
            while (input != "Sail")
            {
                string[] currTownInfo = input.Split("||", StringSplitOptions.RemoveEmptyEntries);
                string name = currTownInfo[0];
                int population = int.Parse(currTownInfo[1]);
                int gold = int.Parse(currTownInfo[2]);

                bool contains = townsList.Exists(t => t.Name == name);
                if (contains)
                {
                    Town town = townsList.Find(t => t.Name == name);
                    town.Population += population;
                    town.Gold += gold;
                }
                else
                {
                    Town currTown = new Town(name, population, gold);
                    townsList.Add(currTown);
                }

                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            while (input != "End")
            {
                string[] commandInfo = input.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string commandType = commandInfo[0];
                string town = commandInfo[1];

                if (commandType == "Plunder")
                {
                    Plunder(town, int.Parse(commandInfo[2]), int.Parse(commandInfo[3]), townsList);
                }
                else if (commandType == "Prosper")
                {
                    int gold = int.Parse(commandInfo[2]);
                    if (gold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                        input = Console.ReadLine();
                        continue;
                    }

                    Prosper(town, gold, townsList);
                }

                input = Console.ReadLine();
            }

            if (townsList.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {townsList.Count} wealthy settlements to go to:");

                foreach (var town in townsList)
                {
                    Console.WriteLine(town);
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }

        private static void Plunder(string town, int people, int gold, List<Town> townsList)
        {
            Town currTown = townsList.Find(t => t.Name == town);
            currTown.Population -= people;
            currTown.Gold -= gold;

            Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");

            if (currTown.Gold <= 0 || currTown.Population <= 0)
            {
                townsList.Remove(currTown);
                Console.WriteLine($"{town} has been wiped off the map!");
            }
        }

        private static void Prosper(string town, int gold, List<Town> townsList)
        {
            Town currTown = townsList.Find(t => t.Name == town);
            currTown.Gold += gold;

            Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {currTown.Gold} gold.");
        }
    }
    class Town
    {
        public string Name { get; set; }
        public int Population { get; set; }
        public int Gold { get; set; }

        public Town(string name, int population, int gold)
        {
            Name = name;
            Population = population;
            Gold = gold;
        }

        public override string ToString()
        {
            return $"{Name} -> Population: {Population} citizens, Gold: {Gold} kg";
        }
    }
}
