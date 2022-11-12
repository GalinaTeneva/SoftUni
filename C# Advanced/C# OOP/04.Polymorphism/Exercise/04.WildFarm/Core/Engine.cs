
namespace WildFarm.Core
{
    using System;
    using System.Collections.Generic;

    using Interfaces;
    using Exceptions;
    using Factories.Interfaces;
    using IO.Interfaces;
    using Models.Interfaces;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly IAnimalFactory animalFactory;
        private readonly IFoodFactory foodFactory;

        private readonly ICollection<IAnimal> animals;

        public Engine()
        {
            this.animals = new HashSet<IAnimal>();
        }

        public Engine(IReader reader, IWriter writer, IAnimalFactory animalFactory, IFoodFactory foodFactory)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
            this.animalFactory = animalFactory;
            this.foodFactory = foodFactory;
        }

        public void Run()
        {
            string cmd;
            while ((cmd = this.reader.ReadLine()) != "End")
            {
                IAnimal currAnimal = null;
                try
                {
                    string[] cmdTokens = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    currAnimal = this.animalFactory.CreateAnimal(cmdTokens);

                    string[] foodTokens = this.reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string foodType = foodTokens[0];
                    int foodQuantity = int.Parse(foodTokens[1]);
                    IFood currFood = this.foodFactory.CreateFood(foodType, foodQuantity);

                    this.writer.WriteLine(currAnimal.ProduceSound());

                    currAnimal.Eat(currFood);

                }
                catch (InvalidAnimalTypeException iate)
                {
                    this.writer.WriteLine(iate.Message);
                }
                catch (InvalidFoodTypeException ifte)
                {
                    this.writer.WriteLine(ifte.Message);
                }
                catch (FoodNotEatenException fnee)
                {
                    this.writer.WriteLine(fnee.Message);
                }
                catch (Exception)
                {
                    throw;
                }

                this.animals.Add(currAnimal);
            }

            foreach (IAnimal animal in this.animals)
            {
                this.writer.WriteLine(animal);
            }
        }
    }
}
