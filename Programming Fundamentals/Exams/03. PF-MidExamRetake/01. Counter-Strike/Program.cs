using System;

namespace _01._Counter_Strike
{
    class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            int battlesWon = 0;
            while (input != "End of battle")
            {
                int distance = int.Parse(input);
                if (energy < distance)
                {
                    Console.WriteLine($"Not enough energy! Game ends with {battlesWon} won battles and {energy} energy");
                    break;
                }

                battlesWon++;
                energy -= distance;

                if (battlesWon % 3 == 0)
                {
                    energy += battlesWon;
                }

                input = Console.ReadLine();
            }

            if (input == "End of battle")
            {
                Console.WriteLine($"Won battles: {battlesWon}. Energy left: {energy}");
            }
        }
    }
}
