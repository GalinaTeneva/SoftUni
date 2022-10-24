using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> allCarTires = new List<Tire[]>();

            string command = Console.ReadLine();
            while (command != "No more tires")
            {
                List<Tire> currCarTires = new List<Tire>();

                int year;

                int[] tiresYears = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Where(i => int.TryParse(i, out year))
                    .Select(int.Parse)
                    .ToArray();

                double[] tiresPressures = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Where(i => !int.TryParse(i, out year))
                    .Select(double.Parse)
                    .ToArray();

                for (int i = 0; i < tiresYears.Length; i++)
                {
                    Tire currTire = new Tire(tiresYears[i], tiresPressures[i]);
                    currCarTires.Add(currTire);
                }

                allCarTires.Add(currCarTires.ToArray());

                command = Console.ReadLine();
            }

            List<Engine> allEngines = new List<Engine>();

            command = Console.ReadLine();
            while (command != "Engines done")
            {
                string[] currEngineTokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int horsePower = int.Parse(currEngineTokens[0]);
                double cubicCapacity = double.Parse(currEngineTokens[1]);

                allEngines.Add(new Engine(horsePower, cubicCapacity));

                command = Console.ReadLine();
            }

            List<Car> allCars = new List<Car>();

            command = Console.ReadLine();
            while (command != "Show special")
            {
                string[] carInfo = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string make = carInfo[0];
                string model = carInfo[1];
                int year = int.Parse(carInfo[2]);
                double fuelQuantity = double.Parse(carInfo[3]);
                double fuelConsumption = double.Parse(carInfo[4]);
                int engineIndex = int.Parse(carInfo[5]);
                int tiresIndex = int.Parse(carInfo[6]);

                Car currCar = new Car(make, model, year, fuelQuantity, fuelConsumption, allEngines[engineIndex], allCarTires[tiresIndex]);
                allCars.Add(currCar);

                command = Console.ReadLine();
            }

            var specialCars = allCars.Where(c => c.Year >= 2017 && c.Engine.HorsePower > 330 && c.Tires.Sum(t => t.Pressure) >= 9 && c.Tires.Sum(t => t.Pressure) <= 10);

            foreach (Car car in specialCars)
            {
                car.Drive(20);
            }

            foreach (Car car in specialCars)
            {
                Console.WriteLine(car.WhoAmI());
            }
        }
    }
}
