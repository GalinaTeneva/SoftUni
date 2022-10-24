using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.VehicleCatalogue
{
    class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }
    }

    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
    }

    class Catalogue
    {
        public Catalogue()
        {
            this.Cars = new List<Car>();
            this.Trucks = new List<Truck>();
        }

        public List<Car> Cars { get; set; }
        public List<Truck> Trucks { get; set; }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Catalogue catalogue = new Catalogue();

            string[] inputLine = Console.ReadLine().Split('/', StringSplitOptions.RemoveEmptyEntries);

            while (inputLine[0] != "end")
            {
                string brand = inputLine[1];
                string model = inputLine[2];

                if (inputLine[0] == "Car")
                {
                    int horsePower = int.Parse(inputLine[3]);

                    Car car = new Car
                    {
                        Brand = brand,
                        Model = model,
                        HorsePower = horsePower
                    };
                    catalogue.Cars.Add(car);

                }
                else if (inputLine[0] == "Truck")
                {
                    int weight = int.Parse(inputLine[3]);

                    Truck truck = new Truck
                    {
                        Brand = brand,
                        Model = model,
                        Weight = weight
                    };
                    catalogue.Trucks.Add(truck);
                }

                inputLine = Console.ReadLine().Split('/', StringSplitOptions.RemoveEmptyEntries);
            }

            if (catalogue.Cars.Count > 0)
            {
                Console.WriteLine("Cars:");

                List<Car> orderedCars = catalogue.Cars.OrderBy(car => car.Brand).ToList();
                foreach (Car car in orderedCars)
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }
            if (catalogue.Trucks.Count > 0)
            {
                Console.WriteLine("Trucks:");
                List<Truck> orderedTrucks = catalogue.Trucks.OrderBy(truck => truck.Brand).ToList();
                foreach (Truck truck in orderedTrucks)
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }

        }
    }
}
