using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Repositories.Contracts;
using PlanetWars.Utilities.Messages;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        private readonly IRepository<IMilitaryUnit> army;
        private readonly IRepository<IWeapon> weapons;

        private string name;
        private double budget;


        private Planet()
        {
            this.army = new UnitRepository();
            this.weapons = new WeaponRepository();
        }

        public Planet(string name, double budget)
            :this()
        {
            this.Name = name;
            this.Budget = budget;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }

                this.name = value;
            }
        }

        public double Budget
        {
            get { return this.budget; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }

                this.budget = value;
            }
        }

        public double MilitaryPower => CalculateMilitaryPower();

        public IReadOnlyCollection<IMilitaryUnit> Army => (IReadOnlyCollection<IMilitaryUnit>)this.army.Models;

        public IReadOnlyCollection<IWeapon> Weapons => (IReadOnlyCollection<IWeapon>)this.weapons.Models;

        public void AddUnit(IMilitaryUnit unit)
        {
            this.army.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            this.weapons.AddItem(weapon);
        }

        public void TrainArmy()
        {
            foreach (IMilitaryUnit unit in this.army.Models)
            {
                unit.IncreaseEndurance();
            }
        }

        public void Spend(double amount)
        {
            if (amount > this.Budget)
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }

            this.Budget -= amount;
        }

        public void Profit(double amount)
        {
            this.Budget += amount;
        }

        public string PlanetInfo()
        {
            string forcesResult = this.army.Models.Count == 0 ? "No units" : string.Join(", ", this.army.Models.GetType().Name);
            string militaryUnitsResult = this.weapons.Models.Count == 0 ? "No weapons" : string.Join(", ", this.weapons.Models.GetType().Name);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Planet: {this.Name}");
            sb.AppendLine($"--Budget: {this.Budget} billion QUID");
            sb.Append("--Forces: ");

            if (this.army.Models.Count == 0)
            {
                sb.AppendLine("No units");
            }
            else
            {
                var units = new Queue<string>();

                foreach (var unit in this.army.Models)
                {
                    units.Enqueue(unit.GetType().Name);
                }

                sb.AppendLine(string.Join(", ", units));
            }

            sb.Append("--Combat equipment: ");

            if (this.weapons.Models.Count == 0)
            {
                sb.AppendLine("No weapons");
            }
            else
            {
                var weapons = new Queue<string>();

                foreach (var weapon in this.weapons.Models)
                {
                    weapons.Enqueue(weapon.GetType().Name);
                }

                sb.AppendLine(string.Join(", ", weapons));
            }

            sb.AppendLine($"--Military Power: {this.MilitaryPower}");

            return sb.ToString().TrimEnd();
        }

        private double CalculateMilitaryPower()
        {
            double sumofUnitEndurances = this.army.Models.Sum(u => u.EnduranceLevel);
            double sumofWeaponDestructionLevels = this.weapons.Models.Sum(u => u.DestructionLevel);
            double totalAmount = sumofUnitEndurances + sumofWeaponDestructionLevels;

            if (this.army.FindByName("AnonymousImpactUnit") != null)
            {
                totalAmount += totalAmount * 0.30;
            }
            if (this.weapons.FindByName("NuclearWeapon") != null)
            {
                totalAmount += totalAmount * 0.45;
            }

            return Math.Round(totalAmount, 3);
        }
    }
}
