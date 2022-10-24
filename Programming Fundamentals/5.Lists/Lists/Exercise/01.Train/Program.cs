using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine().Split().Select(int.Parse).ToList();
            int wagonsMaxCapacity = int.Parse(Console.ReadLine());

            while (true)
            {
                string[] command = Console.ReadLine().Split();

                if (command[0] == "end")
                {
                    break;
                }
                else if (command[0] == "Add")
                {
                    int newWagon = int.Parse(command[1]);
                    wagons.Add(newWagon);
                }
                else
                {
                    int passengersToAdd = int.Parse(command[0]);
                    wagons = AddPassengers(wagons, passengersToAdd, wagonsMaxCapacity);
                }
            }

            Console.WriteLine(string.Join(" ", wagons));
        }

        private static List<int> AddPassengers(List<int> numbers, int valueToAdd, int numberCapacity)
        {
            for (int currentNum = 0; currentNum < numbers.Count; currentNum++)
            {
                if (numbers[currentNum] + valueToAdd <= numberCapacity)
                {
                    numbers[currentNum] = numbers[currentNum] + valueToAdd;
                    break;
                }
            }

            return numbers;
        }
    }
}
