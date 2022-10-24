using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    public class Zoo
    {
        private List<Animal> animals;

        public Zoo(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            animals = new List<Animal>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public List<Animal> Animals
        {
            get { return animals; }
            set { animals = value; }
        }

        public int Count { get { return animals.Count; } }

        public string AddAnimal(Animal animal)
        {
            if (animals.Count < Capacity)
            {
                if (String.IsNullOrEmpty(animal.Species))
                {
                    return "Invalid animal species.";
                }
                else if (animal.Diet != "herbivore" && animal.Diet != "carnivore")
                {
                    return "Invalid animal diet.";
                }

                animals.Add(animal);
                return $"Successfully added {animal.Species} to the zoo.";
            }

            return "The zoo is full.";
        }

        public int RemoveAnimals(string species)
        {
            return animals.RemoveAll(a => a.Species == species);
        }

        public List<Animal> GetAnimalsByDiet(string diet)
        {
            return animals.FindAll(a => a.Diet == diet);
        }

        public Animal GetAnimalByWeight(double weight)
        {
            return animals.Find(a => a.Weight == weight);
        }

        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            List<Animal> sorted = animals.FindAll(a => a.Length >= minimumLength && a.Length <= maximumLength);
            return $"There are {sorted.Count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
}
