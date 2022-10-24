using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CarSalesman
{
    public class Engine
    {
        private string model;
        int power;
        int displacement;
        string efficiency;

        public Engine(string model, int power)
        {
            Model = model;
            Power = power;
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public int Power
        {
            get { return power; }
            set { power = value; }
        }

        public int Displacement
        {
            get { return displacement; }
            set { displacement = value; }
        }

        public string Efficiency
        {
            get { return efficiency; }
            set { efficiency = value; }
        }

        public override string ToString()
        {
            string displacement = Displacement == 0 ? "n/a" : this.Displacement.ToString();
            string efficiency = Efficiency ?? "n/a";

            return $"{this.Model}:{Environment.NewLine}" +
                $"    Power: {this.Power}{Environment.NewLine}" +
                $"    Displacement: {displacement}{Environment.NewLine}" +
                $"    Efficiency: {efficiency}";
        }
    }
}
