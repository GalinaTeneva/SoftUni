﻿
namespace Cars
{
    public abstract class BaseElectricCar : BaseCar
    {
        public BaseElectricCar(string model, string color, int battery) : base(model, color)
        {
            Battery = battery;
        }

        public int Battery { get; set; }
    }
}
