using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        private Dictionary<string, Renovator> renovatorsCollection;
        private string name;
        private int neededRenovators;
        private string project;

        public Catalog(string name, int neededRenovators, string project)
        {
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;

            renovatorsCollection = new Dictionary<string, Renovator>();
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int NeededRenovators
        {
            get { return neededRenovators; }
            set { neededRenovators = value; }
        }
        public string Project
        {
            get { return project; }
            set { project = value; }
        }

        public int Count { get { return renovatorsCollection.Count; } }

        public string AddRenovator(Renovator renovator) 
        {
            string line = string.Empty;

            if (String.IsNullOrEmpty(renovator.Name) || String.IsNullOrEmpty(renovator.Type))
            {
                line = "Invalid renovator's information.";
            }
            else if (NeededRenovators <= renovatorsCollection.Count)
            {
                line = "Renovators are no more needed.";
            }
            else if (renovator.Rate > 350)
            {
                line = "Invalid renovator's rate.";
            }
            else
            {
                line = $"Successfully added {renovator.Name} to the catalog.";
                renovatorsCollection.Add(renovator.Name, renovator);
            }

            return line;
        }

        public bool RemoveRenovator(string name)
        {
            if (renovatorsCollection.ContainsKey(name))
            {
                renovatorsCollection.Remove(name);
                return true;
            }
            else
            {
                return false;
            }
        }

        public int RemoveRenovatorBySpecialty(string type)
        {
            int removedCounter = 0;

            foreach (var item in renovatorsCollection)
            {
                if (item.Value.Type == type)
                {
                    renovatorsCollection.Remove(item.Key);
                    removedCounter++;
                }
            }

            return removedCounter;
        }

        public Renovator HireRenovator(string name)
        {
            if (renovatorsCollection.ContainsKey(name))
            {
                renovatorsCollection[name].Hired = true;
                return renovatorsCollection[name];
            }
            else
            {
                return null;
            }
        }

        public List<Renovator> PayRenovators(int days)
        {
            List < Renovator > sorted = new List<Renovator>();
            foreach (var item in renovatorsCollection)
            {
                if (item.Value.Days >= days)
                {
                    sorted.Add(item.Value);
                }
            }

            return sorted;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Renovators available for Project {Project}:");

            foreach (var item in renovatorsCollection)
            {
                if (!item.Value.Hired)
                {
                    sb.AppendLine(item.Value.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
