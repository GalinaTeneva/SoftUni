using Heroes.Core.Contracts;
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Models.Map;
using Heroes.Models.Weapons;
using Heroes.Repositories;
using Heroes.Repositories.Contracts;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IHero> heroes;
        private readonly IRepository<IWeapon> weapons;

        public Controller()
        {
            this.heroes = new HeroRepository();
            this.weapons = new WeaponRepository();
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            if (this.heroes.FindByName(name) != null)
            {
                throw new InvalidOperationException($"The hero {name} already exists.");
            }
            
            if (type == "Knight")
            {
                IHero hero = new Knight(name, health, armour);
                this.heroes.Add(hero);

                return $"Successfully added Sir {name} to the collection.";
            }
            else if (type == "Barbarian")
            {
                IHero hero = new Barbarian(name, health, armour);
                this.heroes.Add(hero);

                return $"Successfully added Barbarian {name} to the collection.";
            }
            else
            {
                throw new InvalidOperationException("Invalid hero type.");
            }
        }

        public string CreateWeapon(string type, string name, int durability)
        {
            if (this.weapons.FindByName(name) != null)
            {
                throw new InvalidOperationException($"The weapon {name} already exists.");
            }

            IWeapon weapon;
            if (type == "Claymore")
            {
                weapon = new Claymore(name, durability);
            }
            else if (type == "Mace")
            {
                weapon = new Mace(name, durability);
            }
            else
            {
                throw new InvalidOperationException("Invalid weapon type.");
            }

            this.weapons.Add(weapon);
            return $"A {type.ToLower()} {name} is added to the collection.";
        }

        public string AddWeaponToHero(string weaponName, string heroName)
        {
            IHero hero = this.heroes.FindByName(heroName);
            IWeapon weapon = this.weapons.FindByName(weaponName);

            if (hero == null)
            {
                throw new InvalidOperationException($"Hero {heroName} does not exist.");
            }

            if (weapon == null)
            {
                throw new InvalidOperationException($"Weapon {weaponName} does not exist.");
            }

            if (hero.Weapon != default)
            {
                throw new InvalidOperationException($"Hero {heroName} is well-armed.");
            }

            hero.AddWeapon(weapon);
            string weaponType = weapon.GetType().Name.ToLower();
            this.weapons.Remove(weapon);
            return $"Hero {heroName} can participate in battle using a {weaponType}.";
        }

        public string StartBattle()
        {
            IMap map = new Map();
            ICollection<IHero> heroesForBattle =
                (ICollection<IHero>)this.heroes.Models
                .Where(h => h.Weapon != null && h.IsAlive == true)
                .ToList();
            return map.Fight(heroesForBattle);
        }

        public string HeroReport()
        {
            var orderedHeroes = this.heroes.Models
                .OrderBy(h => h.GetType().Name)
                .ThenByDescending(h => h.Health)
                .ThenBy(h => h.Name);

            StringBuilder sb = new StringBuilder();

            foreach (IHero hero in orderedHeroes)
            {
                sb.AppendLine($"{hero.GetType().Name}: {hero.Name}");
                sb.AppendLine($"--Health: {hero.Health}");
                sb.AppendLine($"--Armour: {hero.Armour}");

                if (hero.Weapon == default)
                {
                    sb.AppendLine("--Weapon: Unarmed");
                }
                else
                {
                    sb.AppendLine($"--Weapon: {hero.Weapon.Name}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
