using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06.VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            string inputLine = Console.ReadLine();
            while (inputLine != "End")
            {
                string[] vehicleInfo = inputLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                VehicleType vehicleType;
                bool isVehicleTypeParseSuccessful = Enum.TryParse(vehicleInfo[0], true, out vehicleType);

                if (isVehicleTypeParseSuccessful)
                {
                    string model = vehicleInfo[1];
                    string color = vehicleInfo[2];
                    int horsepower = int.Parse(vehicleInfo[3]);

                    Vehicle currVehicle = new Vehicle(vehicleType, model, color, horsepower);
                    vehicles.Add(currVehicle);
                }

                inputLine = Console.ReadLine();
            }

            while (inputLine != "Close the Catalogue")
            {
                string searchWord = inputLine;

                Vehicle vehicleToPring = vehicles.FirstOrDefault(vehicle => vehicle.Model == searchWord);

                //Vehicle vehicleToPring = vehicles.Find(vehicle => vehicle.Model == searchWord);
                Console.WriteLine(vehicleToPring);

                inputLine = Console.ReadLine();
            }

            List<Vehicle> cars = vehicles.Where(vehicle => vehicle.Type == VehicleType.Car).ToList();
            List<Vehicle> trucks = vehicles.FindAll(vehicle => vehicle.Type == VehicleType.Truck);
            double carsAverageHorsepower = cars.Count > 0 ? cars.Average(car => car.HorsePower) : 0.00;
            double trucsAverageHorsepower = trucks.Count > 0 ? trucks.Average(truck => truck.HorsePower) : 0.00;

            Console.WriteLine($"Cars have average horsepower of: {carsAverageHorsepower:F2}.");
            Console.WriteLine($"Trucks have average horsepower of: {trucsAverageHorsepower:F2}.");
        }

        enum VehicleType
        {
            Car,
            Truck
        }

        class Vehicle
        {
            public VehicleType Type { get; set; }
            public string Model { get; set; }
            public string Color { get; set; }
            public int HorsePower { get; set; }

            public Vehicle(VehicleType type, string model, string color, int horsepower)
            {
                this.Type = type;
                this.Model = model;
                this.Color = color;
                this.HorsePower = horsepower;
            }

            public override string ToString()
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine($"Type: {Type}");
                stringBuilder.AppendLine($"Model: {Model}");
                stringBuilder.AppendLine($"Color: {Color}");
                stringBuilder.AppendLine($"Horsepower: {HorsePower}");

                return stringBuilder.ToString().TrimEnd();
            }
        }
    }
}
