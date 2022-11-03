using System;
using System.Collections.Generic;

namespace _03.ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private readonly List<Product> bag;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            this.bag = new List<Product>();
        }

        public string Name
        {
            get { return name; }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                name = value;
            }
        }

        public decimal Money
        {
            get { return money; }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                money = value;
            }
        }

        public IReadOnlyCollection<Product> Bag
        {
            get { return this.bag.AsReadOnly(); }
        }

        public void BuyProduct(Product product)
        {
            if (Money >= product.Cost)
            {
                bag.Add(product);
                Money -= product.Cost;
                Console.WriteLine($"{this.Name} bought {product.Name}");
            }
            else
            {
                Console.WriteLine($"{this.Name} can't afford {product.Name}");
            }
        }
    }
}
