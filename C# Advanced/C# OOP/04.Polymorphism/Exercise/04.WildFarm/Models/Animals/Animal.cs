
namespace WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Interfaces;
    using Exceptions;

    public abstract class Animal : IAnimal
    {
        private Animal()
        {
            this.FoodEaten = 0;
        }

        protected Animal(string name, double weight)
            : this()
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name { get; private set; }

        public double Weight { get; private set; }

        public int FoodEaten { get; private set; }

        protected abstract double WeightMultiplier { get; }

        public abstract IReadOnlyCollection<Type> PreffferedFoods { get; }

        public void Eat(IFood food)
        {
            if (!PreffferedFoods.Any(f => food.GetType().Name == f.Name))
            {
                throw new FoodNotEatenException(string.Format(ExceptionMessages.FoodNotEatenExceptionMessage, this.GetType().Name, food.GetType().Name));
            }

            this.Weight += food.Quantity * this.WeightMultiplier;
            this.FoodEaten += food.Quantity;
        }

        public abstract string ProduceSound();

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }
    }
}
