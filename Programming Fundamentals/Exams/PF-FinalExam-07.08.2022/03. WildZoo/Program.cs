using System;
using System.Collections.Generic;

namespace _03._WildZoo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            List<string> areas = new List<string>();

            string input = Console.ReadLine();
            while (input != "EndDay")
            {
                string[] currCommand = input.Split(": ", StringSplitOptions.RemoveEmptyEntries);
                string commandType = currCommand[0];
                string[] commandTokens = currCommand[1].Split('-', StringSplitOptions.RemoveEmptyEntries);

                if (commandType == "Add")
                {
                    string name = commandTokens[0];
                    int food = int.Parse(commandTokens[1]);
                    string area = commandTokens[2];

                    bool contains = animals.Exists(t => t.Name == name);
                    if (!contains)
                    {
                        Animal currAnimal = new Animal(name, food, area);
                        animals.Add(currAnimal);
                    }
                    else
                    {
                        Animal currAnumal = animals.Find(t => t.Name == name);
                        currAnumal.Food += food;
                    }

                    if (!areas.Contains(area))
                    {
                        areas.Add(area);
                    }
                }
                else if (commandType == "Feed")
                {
                    string name = commandTokens[0];
                    int food = int.Parse(commandTokens[1]);

                    bool contains = animals.Exists(t => t.Name == name);
                    if (contains)
                    {
                        Animal currAnumal = animals.Find(t => t.Name == name);
                        currAnumal.Food -= food;

                        if (currAnumal.Food <= 0)
                        {
                            animals.Remove(currAnumal);
                            Console.WriteLine($"{name} was successfully fed");
                        }
                    }
                }
                input = Console.ReadLine();
            }

            Console.WriteLine("Animals:");
            foreach (var animal in animals)
            {
                Console.WriteLine($" {animal.Name} -> {animal.Food}g");
            }

            if (animals.Count > 0)
            {
                Console.WriteLine("Areas with hungry animals:");

                foreach (var area in areas)
                {
                    bool contains = animals.Exists(a => a.Area == area);
                    if (contains)
                    {
                        var humgryAnimalsList = animals.FindAll(a => a.Area == area);
                        Console.WriteLine($" {area}: {humgryAnimalsList.Count}");
                    }
                }
            }

        }
    }
    class Animal
    {
        public string Name { get; set; }
        public int Food { get; set; }
        public string Area { get; set; }

        public Animal(string name, int food, string area)
        {
            Name = name;
            Food = food;
            Area = area;
        }
    }
}
