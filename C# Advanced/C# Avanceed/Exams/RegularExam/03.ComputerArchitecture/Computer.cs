using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
        private List<CPU> multiprocessor;

        public Computer(string model, int capacity)
        {
            Model = model;
            Capacity = capacity;
            Multiprocessor = new List<CPU>();
        }

        public string Model { get; set; }
        public int Capacity { get; set; }
        public List<CPU> Multiprocessor
        {
            get { return multiprocessor; }
            set { multiprocessor = value; }
        }

        public int Count => multiprocessor.Count;

        public void Add(CPU cpu)
        {
            if (multiprocessor.Count < Capacity)
            {
                multiprocessor.Add(cpu);
            }
        }

        public bool Remove(string brand)
        {
            if (multiprocessor.Any(c => c.Brand == brand))
            {
                multiprocessor.RemoveAll(c => c.Brand == brand);
                return true;
            }

            return false;
        }

        public CPU MostPowerful()
        {
            return multiprocessor.OrderByDescending(c => c.Frequency).First();
        }

        public CPU GetCPU(string brand)
        {
            return multiprocessor.FirstOrDefault(c => c.Brand == brand);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"CPUs in the Computer {Model}:");
            foreach (var cpu in multiprocessor)
            {
                sb.AppendLine(cpu.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
