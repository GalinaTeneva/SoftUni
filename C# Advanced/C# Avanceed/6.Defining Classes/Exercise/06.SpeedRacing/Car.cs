using System;
using System.Collections.Generic;
using System.Text;

namespace _06.SpeedRacing
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        double fuelConsumptionPerKilometer;
        double travelledDistance;

        public Car()
        {
            TravelledDistace = 0;
        }

        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
            : this()
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public double FuelAmount
        {
            get { return fuelAmount; }
            set { fuelAmount = value; }
        }
        public double FuelConsumptionPerKilometer
        {
            get { return fuelConsumptionPerKilometer; }
            set { fuelConsumptionPerKilometer = value; }
        }
        public double TravelledDistace
        {
            get { return travelledDistance; }
            set { travelledDistance = value; }
        }

        public void Drive(double distance)
        {
            double neededFuel = distance * FuelConsumptionPerKilometer;
            if (FuelAmount >= neededFuel)
            {
                FuelAmount -= neededFuel;
                TravelledDistace += distance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

    }
}
