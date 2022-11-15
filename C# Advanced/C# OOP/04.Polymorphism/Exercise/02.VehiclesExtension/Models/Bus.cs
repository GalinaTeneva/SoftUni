
namespace VehiclesExtension.Models
{
    public class Bus : Vehicle
    {
        private const double FuelConsumptionIncrement = 1.4;

        public Bus(double tankCapacity, double fuelQuantity, double fuelConsumption)
            : base(tankCapacity, fuelQuantity, fuelConsumption)
        {
        }

        public override double ConsumptionIncrement => FuelConsumptionIncrement;
    }
}
