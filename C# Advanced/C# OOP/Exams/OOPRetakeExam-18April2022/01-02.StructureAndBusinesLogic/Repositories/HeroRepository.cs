using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;

using System.Collections.Generic;
using System.Linq;

namespace Heroes.Repositories
{
    public class HeroRepository : IRepository<IHero>
    {
        private readonly ICollection<IHero> heroes;

        public HeroRepository()
        {
            this.heroes = new List<IHero>();
        }

        public IReadOnlyCollection<IHero> Models
            => (IReadOnlyCollection<IHero>)this.heroes;

        public void Add(IHero model)
        {
            this.heroes.Add(model);
        }

        public bool Remove(IHero model)
        {
            return this.heroes.Remove(model);
        }

        public IHero FindByName(string name)
        {
            return this.heroes.FirstOrDefault(h => h.Name == name);
        }
    }
}
