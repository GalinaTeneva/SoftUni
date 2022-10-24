using System;
using System.Collections.Generic;

namespace _07.ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> cars = new HashSet<string>();

            while (true)
            {
                string[] inputInfo = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

                if (inputInfo[0] == "END")
                {
                    break;
                }

                string direction = inputInfo[0];
                string carNumber = inputInfo[1];

                switch (direction)
                {
                    case "IN":
                        cars.Add(carNumber);
                        break;
                    case "OUT":
                        cars.Remove(carNumber);
                        break;
                }
            }

            if (cars.Count > 0)
            {
                foreach (string car in cars)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
