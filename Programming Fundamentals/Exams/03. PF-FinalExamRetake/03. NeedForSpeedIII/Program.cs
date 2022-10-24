using System;
using System.Collections.Generic;

namespace _03._NeedForSpeedIII
{
    class Program
    {
        static void Main(string[] args)
        {
            const int MaxFuel = 75;
            List<Car> cars = new List<Car>();
            int carsCount = int.Parse(Console.ReadLine());

            for (int i = 1; i <= carsCount; i++)
            {
                string[] currCarInfo = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);
                string carName = currCarInfo[0];
                int carMileage = int.Parse(currCarInfo[1]);
                int carFuel = int.Parse(currCarInfo[2]);

                Car currCar = new Car
                {
                    Name = carName,
                    Mileage = carMileage,
                    Fuel = carFuel
                };
                cars.Add(currCar);
            }

            string input = Console.ReadLine();
            while (input != "Stop")
            {
                string[] currCommandInfo = input.Split(" : ", StringSplitOptions.RemoveEmptyEntries);
                string car = currCommandInfo[1];
                Car currCar = cars.Find(c => c.Name == car);

                if (currCommandInfo[0] == "Drive")
                {
                    int distance = int.Parse(currCommandInfo[2]);
                    int fuel = int.Parse(currCommandInfo[3]);

                    if (currCar.Fuel < fuel)
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                    else
                    {
                        currCar.Mileage += distance;
                        currCar.Fuel -= fuel;
                        Console.WriteLine($"{car} driven for {distance} kilometers. {fuel} liters of fuel consumed.");

                        if (currCar.Mileage >= 100_000)
                        {
                            Console.WriteLine($"Time to sell the {car}!");
                            cars.Remove(currCar);
                        }
                    }
                }
                else if (currCommandInfo[0] == "Refuel")
                {
                    int fuel = int.Parse(currCommandInfo[2]);
                    int fuelFreeSpace = MaxFuel - currCar.Fuel;
                    if (fuel <= fuelFreeSpace)
                    {
                        currCar.Fuel += fuel;
                        Console.WriteLine($"{car} refueled with {fuel} liters");
                    }
                    else
                    {
                        currCar.Fuel = MaxFuel;
                        Console.WriteLine($"{car} refueled with {fuelFreeSpace} liters");
                    }

                }
                else if (currCommandInfo[0] == "Revert")
                {
                    int km = int.Parse(currCommandInfo[2]);
                    currCar.Mileage -= km;
                    if (currCar.Mileage > 10_000)
                    {
                        Console.WriteLine($"{car} mileage decreased by {km} kilometers");
                    }
                    else
                    {
                        currCar.Mileage = 10_000;
                    }
                }
                input = Console.ReadLine();
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
    class Car
    {
        public string Name { get; set; }
        public int Mileage { get; set; }
        public int Fuel { get; set; }

        public override string ToString()
        {
            return $"{Name} -> Mileage: {Mileage} kms, Fuel in the tank: {Fuel} lt.";
        }
    }
}
