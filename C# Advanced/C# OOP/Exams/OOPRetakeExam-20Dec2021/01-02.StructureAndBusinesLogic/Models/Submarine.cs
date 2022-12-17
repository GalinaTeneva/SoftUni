
namespace NavalVessels.Models
{
    using Contracts;

    using System.Text;

    public class Submarine : Vessel, ISubmarine
    {
        private const double InitialArmorThickness = 200;

        private bool submergeMode;

        public Submarine(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, InitialArmorThickness)
        {
        }

        public bool SubmergeMode
        {
            get
            {
                return this.submergeMode;
            }
            private set
            {
                this.submergeMode = value;
            }
        }

        public override void RepairVessel()
        {
            this.ArmorThickness = InitialArmorThickness;
        }

        public void ToggleSubmergeMode()
        {
            if (!this.SubmergeMode)
            {
                this.MainWeaponCaliber += 40;
                this.Speed -= 4;
            }
            else
            {
                this.MainWeaponCaliber -= 40;
                this.Speed += 4;
            }

            this.SubmergeMode = !this.SubmergeMode;
        }

        public override string ToString()
        {
            string submergeMode = this.SubmergeMode ? "ON" : "OFF";

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($" *Submerge mode: {submergeMode}");

            return sb.ToString().TrimEnd();
        }
    }
}
