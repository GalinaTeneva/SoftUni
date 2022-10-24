﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _07.RawData
{
    public class Car
    {
        public Car(string model, Engine engine, Cargo cargo, double tire1Pressure, int tire1Age, double tire2Pressure, int tire2Age, double tire3Pressure, int tire3Age, double tire4Pressure, int tire4Age)
        {
            Model = model;
            Engine = engine;
            Cargo = cargo;
            Tires = new Tire[4];
            Tires[0] = new Tire { Pressure = tire1Pressure, Age = tire1Age };
            Tires[1] = new Tire { Pressure = tire2Pressure, Age = tire2Age };
            Tires[2] = new Tire { Pressure = tire3Pressure, Age = tire3Age };
            Tires[3] = new Tire { Pressure = tire4Pressure, Age = tire4Age };
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public Tire[] Tires { get; set; }
    }
}
