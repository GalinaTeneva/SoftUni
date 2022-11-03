using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private Dictionary<Topping, double> toppingsCalories;
        //private double calories;

        public Pizza()
        {
            toppingsCalories = new Dictionary<Topping, double>();
        }

        public Pizza(string name, Dough dough)
            : this()
        {
            Name = name;
            Dough = dough;
        }

        public string Name
        {
            get
            { return name; }
            set
            {
                if (value.Length > 15 || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                name = value;
            }
        }

        public Dough Dough
        {
            get
            {
                return dough;
            }
            set
            {
                dough = value;
            }
        }

        public int ToppingsNum => toppingsCalories.Count;

        public double Calories => GetCalories();


        //public Dictionary<Topping, double> ToppingsCalories
        //{
        //    get { return toppingsCalories; }
        //    private set
        //    {
        //        ToppingsCalories = value;
        //    }
        //}

        public void AddTopping(Topping topping)
        {
            if (toppingsCalories.Count <= 10)
            {
                toppingsCalories[topping] = topping.CalculateCalories();
            }
            else
            {
                throw new InvalidOperationException("Number of toppings should be in range [0..10].");
            }
        }

        private double GetCalories()
        {
            double doughCalories = Dough.CalculateCalories();
            double toppingsCalories = this.toppingsCalories.Values.Sum();
            return doughCalories + toppingsCalories;
        }

        public override string ToString()
        {
            return $"{Name} - {Calories:F2} Calories.";
        }
    }
}
