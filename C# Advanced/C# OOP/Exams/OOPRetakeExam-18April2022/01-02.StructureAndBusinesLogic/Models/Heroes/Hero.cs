using System;

using Heroes.Models.Contracts;

namespace Heroes.Models.Heroes
{
    public abstract class Hero : IHero
    {
        private string name;
        private int health;
        private int armour;
        private IWeapon weapon;

        public Hero(string name, int health, int armour)
        {
            this.Name = name;
            this.Health = health;
            this.Armour = armour;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Hero name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public int Health
        {
            get { return this.health; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero health cannot be below 0.");
                }

                this.health = value;
            }
        }

        public int Armour
        {
            get { return this.armour; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero armour cannot be below 0.");
                }

                this.armour = value;
            }
        }

        public bool IsAlive => IsAliveChecker();

        public IWeapon Weapon
        {
            get { return this.weapon; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("Weapon cannot be null.");
                }

                this.weapon = value;
            }
        }

        public void AddWeapon(IWeapon weapon)
        {
            this.Weapon = weapon;
        }

        public void TakeDamage(int points)
        {
            if (points > this.Armour)
            {
                if (points - this.Armour >= this.Health)
                {
                    this.Health = 0;
                    return;
                }

                this.Health -= points - this.Armour;
                this.Armour = 0;
                return;
            }

            this.Armour -= points;
        }

        private bool IsAliveChecker()
        {
            if (this.Health > 0)
            {
                return true;
            }

            return false;
        }
    }
}
