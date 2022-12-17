
namespace NavalVessels.Models
{
    using Contracts;
    using Utilities.Messages;

    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Captain : ICaptain
    {
        private const int CombatExperienceIncrement = 10;

        private string fullName;
        private int combatExperience;
        private ICollection<IVessel> vessels;

        private Captain()
        {
            this.Vessels = new HashSet<IVessel>();
        }

        public Captain(string fullName)
            : this()
        {
            this.FullName = fullName;
        }

        public string FullName
        {
            get
            {
                return this.fullName;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(this.FullName), ExceptionMessages.InvalidCaptainName);
                }

                this.fullName = value;
            }
        }

        public int CombatExperience
        {
            get
            {
                return this.combatExperience;
            }
            private set
            {
                this.combatExperience = value;
            }
        }

        public ICollection<IVessel> Vessels
        {
            get
            {
                return this.vessels;
            }
            private set
            {
                this.vessels = value;
            }
        }

        public void AddVessel(IVessel vessel)
        {
            if (vessel == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidVesselForCaptain);
            }

            this.Vessels.Add(vessel);
        }

        public void IncreaseCombatExperience()
        {
            this.CombatExperience += CombatExperienceIncrement;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.FullName} has {this.CombatExperience} combat experience and commands {this.Vessels.Count} vessels.");

            foreach (IVessel vessel in Vessels)
            {
                sb.AppendLine(vessel.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
