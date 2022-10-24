using System;

namespace _02._MuOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            int bitcoins = 0;
            int health = 100;
            string[] dungeonRooms = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);

            for (int currRoom = 0; currRoom < dungeonRooms.Length; currRoom++)
            {
                string[] commandTokens = dungeonRooms[currRoom].Split();
                string command = commandTokens[0];
                int number = int.Parse(commandTokens[1]);

                if (command == "potion")
                {
                    int oldHealth = health;
                    health += number;
                    if (health > 100)
                    {
                        health = 100;
                    }

                    Console.WriteLine($"You healed for {health - oldHealth} hp.");
                    Console.WriteLine($"Current health: {health} hp.");
                }
                else if (command == "chest")
                {
                    bitcoins += number;
                    Console.WriteLine($"You found {number} bitcoins.");
                }
                else
                {
                    string monster = commandTokens[0];
                    health -= number;

                    if (health > 0)
                    {
                        Console.WriteLine($"You slayed {monster}.");
                    }
                    else
                    {
                        Console.WriteLine($"You died! Killed by {monster}.");
                        Console.WriteLine($"Best room: {currRoom + 1}");
                        return;
                    }
                }
            }

            Console.WriteLine("You've made it!");
            Console.WriteLine($"Bitcoins: {bitcoins}");
            Console.WriteLine($"Health: {health}");
        }
    }
}
