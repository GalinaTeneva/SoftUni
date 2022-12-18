using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Utilities.Messages;

using System;

namespace PlanetWars.Models.MilitaryUnits
{
    public abstract class MilitaryUnit : IMilitaryUnit
    {
        private double cost;
        private int enduranceLevel;

        protected MilitaryUnit(double cost)
        {
            this.Cost = cost;
            this.EnduranceLevel = 1;
        }

        public double Cost
        {
            get => cost;
            private set
            {
                cost = value;
            }
        }

        public int EnduranceLevel
        {
            get { return this.enduranceLevel; }
            private set
            {
                this.enduranceLevel = value;
            }
        }

        public void IncreaseEndurance()
        {
            this.EnduranceLevel++;

            if (this.EnduranceLevel > 20)
            {
                this.EnduranceLevel = 20;

                throw new ArgumentException(ExceptionMessages.EnduranceLevelExceeded);
            }
        }
    }
}
