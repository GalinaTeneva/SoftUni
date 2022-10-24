using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.EnergyDrinks
{
    class Program
    {
        static void Main(string[] args)
        {
            const int MaxCaffeine = 300;
            int drankCaffeine = 0;

            int[] caffeine = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] drinks = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Stack<int> caffeineStack = new Stack<int>(caffeine);
            Queue<int> drinksQueue = new Queue<int>(drinks);

            while (caffeineStack.Count != 0 && drinksQueue.Count != 0)
            {
                int currCaffeine = caffeineStack.Pop();
                int currDrink = drinksQueue.Dequeue();
                int currDrinkCaffeine = currCaffeine * currDrink;

                if (currDrinkCaffeine <= MaxCaffeine - drankCaffeine)
                {
                    drankCaffeine += currDrinkCaffeine;
                }
                else
                {
                    drinksQueue.Enqueue(currDrink);
                    drankCaffeine -= 30;

                    if (drankCaffeine < 0)
                    {
                        drankCaffeine = 0;
                    }
                }
            }

            if (drinksQueue.Count > 0)
            {
                Console.WriteLine($"Drinks left: {string.Join(", ", drinksQueue)}");
            }
            else
            {
                Console.WriteLine("At least Stamat wasn't exceeding the maximum caffeine.");
            }

            Console.WriteLine($"Stamat is going to sleep with {drankCaffeine} mg caffeine.");
        }
    }
}
