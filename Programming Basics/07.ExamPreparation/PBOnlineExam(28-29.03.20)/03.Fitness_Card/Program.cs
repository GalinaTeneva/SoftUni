using System;

namespace _03.Fitness_Card
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            char gender = char.Parse(Console.ReadLine());
            int age = int.Parse(Console.ReadLine());
            string sport = Console.ReadLine();

            double price = 0;
            switch (sport)
            {
                case "Gym":
                    switch (gender)
                    {
                        case 'm':
                            price = 42;
                            break;
                        case 'f':
                            price = 35;
                            break;
                    }
                    break;
                case "Boxing":
                    switch (gender)
                    {
                        case 'm':
                            price = 41;
                            break;
                        case 'f':
                            price = 37;
                            break;
                    }
                    break;
                case "Yoga":
                    switch (gender)
                    {
                        case 'm':
                            price = 45;
                            break;
                        case 'f':
                            price = 42;
                            break;
                    }
                    break;
                case "Zumba":
                    switch (gender)
                    {
                        case 'm':
                            price = 34;
                            break;
                        case 'f':
                            price = 31;
                            break;
                    }
                    break;
                case "Dances":
                    switch (gender)
                    {
                        case 'm':
                            price = 51;
                            break;
                        case 'f':
                            price = 53;
                            break;
                    }
                    break;
                case "Pilates":
                    switch (gender)
                    {
                        case 'm':
                            price = 39;
                            break;
                        case 'f':
                            price = 37;
                            break;
                    }
                    break;
            }

            if (age <= 19)
            {
                price -= price * 0.2;
            }

            if (price <= budget)
            {
                Console.WriteLine($"You purchased a 1 month pass for {sport}.");
            }
            else
            {
                double diff = price - budget;
                Console.WriteLine($"You don't have enough money! You need ${diff:F2} more.");
            }
        }
    }
}
