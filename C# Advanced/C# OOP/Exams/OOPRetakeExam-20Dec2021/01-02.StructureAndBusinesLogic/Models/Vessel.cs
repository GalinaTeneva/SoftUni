
namespace NavalVessels.Models
{
    using Contracts;
    using Utilities.Messages;

    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Vessel : IVessel
    {
        private string name;
        private ICaptain captain;
        private double armorThickness;
        private double mainWeaponCaliber;
        private double speed;
        private ICollection<string> targets;

        private Vessel()
        {
            this.Targets = new List<string>();
        }

        protected Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
            : this()
        {
            this.Name = name;
            this.MainWeaponCaliber = mainWeaponCaliber;
            this.Speed = speed;
            this.ArmorThickness = armorThickness;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(this.Name), ExceptionMessages.InvalidVesselName);
                }

                this.name = value;
            }
        }

        public ICaptain Captain
        {
            get
            {
                return this.captain;
            }
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException(ExceptionMessages.InvalidCaptainToVessel);
                }

                this.captain = value;
            }
        }

        public double ArmorThickness
        {
            get
            {
                return this.armorThickness;
            }
            set
            {
                this.armorThickness = value;
            }
        }

        public double MainWeaponCaliber
        {
            get
            {
                return this.mainWeaponCaliber;
            }
            protected set
            {
                this.mainWeaponCaliber = value;
            }
        }

        public double Speed
        {
            get
            {
                return this.speed;
            }
            protected set
            {
                this.speed = value;
            }
        }

        public ICollection<string> Targets
        {
            get
            {
                return this.targets;
            }
            private set
            {
                this.targets = value;
            }
        }

        public void Attack(IVessel target)
        {
            if (target == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidTarget);
            }

            target.ArmorThickness -= this.MainWeaponCaliber;
            if (target.ArmorThickness < 0)
            {
                target.ArmorThickness = 0;
            }

            this.Targets.Add(target.Name);

            this.Captain.IncreaseCombatExperience();
            target.Captain.IncreaseCombatExperience();
        }

        public abstract void RepairVessel();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"- {this.Name}");
            sb.AppendLine($" *Type: {GetType().Name}");
            sb.AppendLine($" *Armor thickness: {this.ArmorThickness}");
            sb.AppendLine($" *Main weapon caliber: {this.MainWeaponCaliber}");
            sb.AppendLine($" *Speed: {this.Speed} knots");

            if (Targets.Count == 0)
            {
                sb.AppendLine(" *Targets: None");
            }
            else
            {
                sb.AppendLine($" *Targets: {string.Join(", ", Targets)}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
