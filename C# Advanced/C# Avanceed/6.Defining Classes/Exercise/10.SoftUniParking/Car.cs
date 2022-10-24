using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniParking
{
    public class Car
    {
        string make;
        string model;
        int horsePower;
        string registrationNumber;

        public Car(string make, string model, int horseower, string registrationNumber)
        {
            Make = make;
            Model = model;
            HorsePower = horseower;
            RegistrationNumber = registrationNumber;
        }

        public string Make
        {
            get { return make; }
            set { make = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public int HorsePower
        {
            get { return horsePower; }
            set { horsePower = value; }
        }

        public string RegistrationNumber
        {
            get { return registrationNumber; }
            set { registrationNumber = value; }
        }

        public override string ToString()
        {
            return $"Make: {this.Make}{Environment.NewLine}" +
                $"Model: {this.Model}{Environment.NewLine}" +
                $"HorsePower: {this.HorsePower}{Environment.NewLine}" +
                $"RegistrationNumber: {this.RegistrationNumber}";
        }
    }
}
