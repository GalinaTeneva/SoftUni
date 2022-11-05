
namespace Cars
{
    public class Tesla : BaseElectricCar
    {
        public Tesla(string model, string color, int battery) : base(model, color, battery)
        {
        }

        public override string ToString()
        {
            return $"{Color} Seat {Model} with {Battery} Batteries";
        }
    }
}
