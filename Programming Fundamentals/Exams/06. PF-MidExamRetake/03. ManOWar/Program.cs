using System;
using System.Linq;

namespace _03._ManOWar
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] pirateShip = Console.ReadLine().Split('>', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] warship = Console.ReadLine().Split('>', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int maxHealth = int.Parse(Console.ReadLine());

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Retire")
                {
                    break;
                }

                string[] inputInfo = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string commmand = inputInfo[0];
                if (commmand == "Fire")
                {
                    int index = int.Parse(inputInfo[1]);
                    int damage = int.Parse(inputInfo[2]);

                    if (IsValid(index, warship))
                    {
                        warship[index] -= damage;
                        if (warship[index] <= 0)
                        {
                            Console.WriteLine("You won! The enemy ship has sunken.");
                            return;
                        }
                    }
                }
                else if (commmand == "Defend")
                {
                    int startIndex = int.Parse(inputInfo[1]);
                    int endIndex = int.Parse(inputInfo[2]);
                    int damage = int.Parse(inputInfo[3]);

                    if (IsValid(startIndex, pirateShip) && IsValid(endIndex, pirateShip))
                    {
                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            pirateShip[i] -= damage;

                            if (pirateShip[i] <= 0)
                            {
                                Console.WriteLine("You lost! The pirate ship has sunken.");
                                return;
                            }
                        }
                    }
                }
                else if (commmand == "Repair")
                {
                    int index = int.Parse(inputInfo[1]);
                    int health = int.Parse(inputInfo[2]);

                    if (IsValid(index, pirateShip))
                    {
                        pirateShip[index] += health;

                        if (pirateShip[index] > maxHealth)
                        {
                            pirateShip[index] = maxHealth;
                        }
                    }
                }
                else if (commmand == "Status")
                {
                    double needRepairHealth = maxHealth * 0.2;
                    var shipsForRepair = pirateShip.Where(e => e < needRepairHealth).ToArray().Length;
                    Console.WriteLine($"{shipsForRepair} sections need repair.");
                }
            }

            int pirateShipSum = pirateShip.Sum();
            int warshipSum = warship.Sum();
            Console.WriteLine($"Pirate ship status: {pirateShipSum}\n" +
                              $"Warship status: {warshipSum}");
        }

        private static bool IsValid(int index, int[] array)
        {
            if (index >= 0 && index < array.Length)
            {
                return true;
            }

            return false;
        }
    }
}
