using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Repositories.Contracts;
using PlanetWars.Utilities.Messages;

using System;
using System.Linq;
using System.Text;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IPlanet> planets;

        public Controller()
        {
            this.planets = new PlanetRepository();
        }

        public string CreatePlanet(string name, double budget)
        {
            if (this.planets.Models.Any(p => p.Name == name))
            {
                return string.Format(OutputMessages.ExistingPlanet, name);
            }

            this.planets.AddItem(new Planet(name, budget));
            return string.Format(OutputMessages.NewPlanet, name);
        }

        public string AddUnit(string unitTypeName, string planetName)
        {
            IPlanet planet = planets.FindByName(planetName);

            if (planet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (unitTypeName != "SpaceForces" && unitTypeName != "StormTroopers" && unitTypeName != "AnonymousImpactUnit")
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }

            if (planet.Army.Any(u => u.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
            }

            IMilitaryUnit unit;
            if (unitTypeName == "SpaceForces")
            {
                unit = new SpaceForces();
            }
            else if (unitTypeName == "StormTroopers")
            {
                unit = new StormTroopers();
            }
            else
            {
                unit = new AnonymousImpactUnit();
            }

            planet.Spend(unit.Cost);
            planet.AddUnit(unit);

            return string.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            IPlanet planet = planets.FindByName(planetName);

            if (planet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (planet.Weapons.Any(w => w.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
            }

            if (weaponTypeName != "SpaceMissiles" && weaponTypeName != "NuclearWeapon" && weaponTypeName != "BioChemicalWeapon")
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }

            IWeapon weapon;
            if (weaponTypeName == "SpaceMissiles")
            {
                weapon = new SpaceMissiles(destructionLevel);
            }
            else if (weaponTypeName == "NuclearWeapon")
            {
                weapon = new NuclearWeapon(destructionLevel);
            }
            else
            {
                weapon = new BioChemicalWeapon(destructionLevel);
            }

            planet.Spend(weapon.Price);
            planet.AddWeapon(weapon);

            return string.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
        }

        public string SpecializeForces(string planetName)
        {
            const double SpecializeForcesCost = 1.25;

            IPlanet planet = planets.FindByName(planetName);

            if (planet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (planet.Army.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NoUnitsFound);
            }

            planet.TrainArmy();
            planet.Spend(SpecializeForcesCost);

            return string.Format(OutputMessages.ForcesUpgraded, planetName);
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            IPlanet firstPlanet = planets.Models.First(p => p.Name == planetOne);
            IPlanet secondPlanet = planets.Models.First(p => p.Name == planetTwo);

            bool firstHasNuclearWeapon = firstPlanet.Weapons.Any(w => w.GetType().Name == "NuclearWeapon");
            bool secondHasNuclearWeapon = secondPlanet.Weapons.Any(w => w.GetType().Name == "NuclearWeapon");

            IPlanet winner;
            IPlanet loser;
            if (firstPlanet.MilitaryPower == secondPlanet.MilitaryPower)
            {
                if ((firstHasNuclearWeapon && secondHasNuclearWeapon) || (!firstHasNuclearWeapon && !secondHasNuclearWeapon))
                {
                    firstPlanet.Spend(firstPlanet.Budget / 2);
                    secondPlanet.Spend(secondPlanet.Budget / 2);

                    return OutputMessages.NoWinner;
                }

                if (firstHasNuclearWeapon)
                {
                    winner = firstPlanet;
                    loser = secondPlanet;
                }
                else
                {
                    winner = secondPlanet;
                    loser = firstPlanet;
                }
            }
            else
            {
                if (firstPlanet.MilitaryPower > secondPlanet.MilitaryPower)
                {
                    winner = firstPlanet;
                    loser = secondPlanet;
                }
                else
                {
                    winner = secondPlanet;
                    loser = firstPlanet;
                }
            }

            double loserForcesCost = loser.Army.Sum(u => u.Cost);
            double loserWeaponsCost = loser.Weapons.Sum(w => w.Price);

            winner.Spend(winner.Budget / 2);
            winner.Profit(loser.Budget / 2);
            winner.Profit(loserForcesCost + loserWeaponsCost);

            string winnerName = winner.Name;
            string loserName = loser.Name;

            planets.RemoveItem(loserName);
            return string.Format(OutputMessages.WinnigTheWar, winnerName, loserName);
        }

        public string ForcesReport()
        {
            var orderedPlanets = this.planets.Models
                .OrderByDescending(p => p.MilitaryPower)
                .ThenBy(p => p.Name);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");

            foreach (IPlanet planet in orderedPlanets)
            {
                sb.AppendLine(planet.PlanetInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
