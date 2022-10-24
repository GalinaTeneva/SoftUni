using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PlantDiscovery
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Plant> plantsCollection = new List<Plant>();

            int plantsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < plantsCount; i++)
            {
                string[] currPlantInfo = Console.ReadLine().Split("<->", StringSplitOptions.RemoveEmptyEntries);
                string currPlantName = currPlantInfo[0];
                int currPlantRarity = int.Parse(currPlantInfo[1]);
                Plant currPlant = new Plant(currPlantName, currPlantRarity);


                if (!plantsCollection.Exists(p => p.Name == currPlantName))
                {
                    plantsCollection.Add(currPlant);
                }
                else
                {
                    Plant existingPlant = plantsCollection.Find(p => p.Name == currPlantName);
                    existingPlant.Rarity = currPlantRarity;
                }
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Exhibition")
                {
                    break;
                }

                string[] commandInfo = command.Split(": ", StringSplitOptions.RemoveEmptyEntries);
                string currCommandType = commandInfo[0];
                string[] commandTokens = commandInfo[1].Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                if (!plantsCollection.Exists(p => p.Name == commandTokens[0]))
                {
                    Console.WriteLine("error");
                    continue;
                }

                if (currCommandType == "Rate")
                {
                    Rate(commandTokens[0], double.Parse(commandTokens[1]), plantsCollection);
                }
                else if (currCommandType == "Update")
                {
                    Update(commandTokens[0], int.Parse(commandTokens[1]), plantsCollection);
                }
                else if (currCommandType == "Reset")
                {
                    Reset(commandTokens[0], plantsCollection);
                }
            }

            Console.WriteLine("Plants for the exhibition:");
            foreach (var plant in plantsCollection)
            {
                double averageRating = 0;
                if (plant.Rating.Count != 0)
                {
                    averageRating = plant.Rating.Average();
                }
                Console.WriteLine($"- {plant.Name}; Rarity: {plant.Rarity}; Rating: {averageRating:F2}");
            }
        }

        private static void Rate(string plant, double rating, List<Plant> plantsCollection)
        {
            Plant currPlant = plantsCollection.Find(p => p.Name == plant);
            currPlant.Rating.Add(rating);
        }

        private static void Update(string plant, int newRarity, List<Plant> plantsCollection)
        {
            Plant currPlant = plantsCollection.Find(p => p.Name == plant);
            currPlant.Rarity = newRarity;
        }

        private static void Reset(string plant, List<Plant> plantsCollection)
        {
            Plant currPlant = plantsCollection.Find(p => p.Name == plant);
            currPlant.Rating.Clear();
        }
    }
    class Plant
    {
        public string Name { get; set; }
        public int Rarity { get; set; }
        public List<double> Rating { get; set; } = new List<double>();

        public Plant(string name, int rarity)
        {
            Name = name;
            Rarity = rarity;
        }
    }
}
