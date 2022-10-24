using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BaristaContest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Drink> drinks = new List<Drink>()
            {
                { new Drink("Cortado", 50)},
                { new Drink("Espresso", 75)},
                { new Drink("Capuccino", 100)},
                { new Drink("Americano", 150)},
                { new Drink("Latte", 200)}
            };

            int[] coffee = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] milk = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> coffeeQueue = new Queue<int>(coffee);
            Stack<int> milkStack = new Stack<int>(milk);

            while (coffeeQueue.Count != 0 && milkStack.Count != 0)
            {
                int currCoffee = coffeeQueue.Dequeue();
                int currMilk = milkStack.Pop();

                int sumDrink = currCoffee + currMilk;
                bool isValid = drinks.Any(d => d.Volume == sumDrink);
                if (isValid)
                {
                    var drink = drinks.First(d => d.Volume == sumDrink);
                    drink.Count++;
                }
                else
                {
                    milkStack.Push(currMilk - 5);
                }
            }

            if (coffeeQueue.Count == 0 && milkStack.Count == 0)
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
            }
            else
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
            }

            Console.WriteLine(coffeeQueue.Count == 0 ? "Coffee left: none" : $"Coffee left: {string.Join(", ", coffeeQueue)}");
            Console.WriteLine(milkStack.Count == 0 ? "Milk left: none" : $"Milk left: {string.Join(", ", milkStack)}");

            var sortedDrinks = drinks.OrderBy(d => d.Count).ThenByDescending(d => d.Name);

            foreach (var drink in sortedDrinks)
            {
                if (drink.Count > 0)
                {
                    Console.WriteLine($"{drink.Name}: {drink.Count}");
                }
            }
        }
    }

    class Drink
    {
        public Drink(string name, int volume)
        {
            Name = name;
            Volume = volume;
        }
        public string Name { get; set; }

        public int Volume { get; set; }

        public int Count { get; set; }
    }
}
