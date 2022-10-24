using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.MealPlan
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> mealsCalories = new Dictionary<string, int>()
            {
                {"salad", 350 },
                {"soup", 490 },
                {"pasta", 680 },
                {"steak", 790 }
            };

            string[] meals = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int[] calories = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<string> mealsQueue = new Queue<string>(meals);
            Stack<int> caloriesStack = new Stack<int>(calories);

            int eatenMeals = 0;

            while (mealsQueue.Count != 0 && caloriesStack.Count != 0)
            {
                string currMeal = mealsQueue.Dequeue();
                int currCalories = caloriesStack.Pop();
                int currMealCalories = mealsCalories[currMeal];

                currCalories -= currMealCalories;
                eatenMeals++;

                if (currCalories < 0)
                {
                    int currMealLeftCalories = Math.Abs(currCalories);
                    if (caloriesStack.Count == 0)
                    {
                        break;
                    }
                    currCalories = caloriesStack.Pop();
                    currCalories -= currMealLeftCalories;
                }

                caloriesStack.Push(currCalories);
            }

            if (mealsQueue.Count == 0)
            {
                Console.WriteLine($"John had {eatenMeals} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", caloriesStack)} calories.");
            }
            if (caloriesStack.Count == 0)
            {
                Console.WriteLine($"John ate enough, he had {eatenMeals} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", mealsQueue)}.");
            }
        }
    }
}
