
namespace Raiding.Factories
{
    using System;

    using Interfaces;
    using Models;
    using Models.Interfaces;

    public class HeroFactory : IHeroFactory
    {
        public IBaseHero CreateHero(string name, string type)
        {
            IBaseHero hero;
            if (type == "Druid")
            {
                hero = new Druid(name);
            }
            else if (type == "Paladin")
            {
                hero = new Paladin(name);
            }
            else if (type == "Rogue")
            {
                hero = new Rogue(name);
            }
            else if (type == "Warrior")
            {
                hero = new Warrior(name);
            }
            else
            {
                throw new ArgumentException("Invalid hero!");
            }

            return hero;
        }
    }
}
