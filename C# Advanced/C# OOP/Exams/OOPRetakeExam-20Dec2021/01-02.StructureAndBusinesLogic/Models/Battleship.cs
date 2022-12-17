
namespace NavalVessels.Models
{
    using Contracts;

    using System.Text;

    public class Battleship : Vessel, IBattleship
    {
        private const double InitialArmourThickness = 300;

        private bool sonarMode;

        public Battleship(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, InitialArmourThickness)
        {
        }

        public bool SonarMode
        {
            get
            {
                return this.sonarMode;
            }
            private set
            {
                this.sonarMode = value;
            }
        }

        public override void RepairVessel()
        {
            this.ArmorThickness = InitialArmourThickness;
        }

        public void ToggleSonarMode()
        {
            if (!this.SonarMode)
            {
                this.MainWeaponCaliber += 40;
                this.Speed -= 5;
            }
            else
            {
                this.MainWeaponCaliber -= 40;
                this.Speed += 5;
            }

            this.SonarMode = !this.SonarMode;
        }

        public override string ToString()
        {
            string sonarMode = this.SonarMode ? "ON" : "OFF";

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($" *Sonar mode: {sonarMode}");

            return sb.ToString().TrimEnd();
        }
    }
}
