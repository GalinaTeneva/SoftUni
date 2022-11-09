
namespace Vehicles.Models
{
    using Interfaces;

    public class Truck : Vehicle
    {
        private const double FuelConsumptionIncrement = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption, FuelConsumptionIncrement)
        {
        }

        public override void Refuel(double litters)
        {
            base.Refuel(litters * 0.95);
        }
    }
}
