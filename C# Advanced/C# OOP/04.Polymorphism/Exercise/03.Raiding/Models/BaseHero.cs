
namespace Raiding.Models
{
    using Interfaces;

    public abstract class BaseHero : IBaseHero

    {
        public BaseHero(string name, int power)
        {
            Name = name;
            Power = power;
        }

        public string Name { get; private set; }

        public int Power { get; }

        public virtual string CastAbility()
        {
            return $"{GetType().Name} - {Name} cast ability for {Power}";
        }
    }
}
