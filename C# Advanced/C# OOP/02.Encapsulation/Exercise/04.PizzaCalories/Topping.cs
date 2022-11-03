using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Topping
    {
        private const double ConstCalories = 2;
        private const double MeatModifier = 1.2;
        private const double VeggiesModifier = 0.8;
        private const double CheeseModifier = 1.1;
        private const double SauceModifier = 0.9;

        private string toppingType;
        private double weigh;
        //private double calories;

        public Topping(string toppingType, double weigh)
        {
            ToppingType = toppingType;
            Weigh = weigh;
        }

        public string ToppingType
        {
            get { return toppingType; }
            set
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                toppingType = value;
            }
        }

        public double Weigh
        {
            get { return weigh; }
            set
            {
                if (value <= 0 || value > 50)
                {
                    throw new ArgumentException($"{ToppingType} weight should be in the range [1..50].");
                }

                weigh = value;
            }
        }

        public double Calories => CalculateCalories();

        public double CalculateCalories()
        {
            double calories = ConstCalories * Weigh;

            switch (ToppingType.ToLower())
            {
                case "meat":
                    calories *= MeatModifier;
                    break;
                case "veggies":
                    calories *= VeggiesModifier;
                    break;
                case "cheese":
                    calories *= CheeseModifier;
                    break;
                case "sauce":
                    calories *= SauceModifier;
                    break;
            }

            return calories;
        }
    }
}
