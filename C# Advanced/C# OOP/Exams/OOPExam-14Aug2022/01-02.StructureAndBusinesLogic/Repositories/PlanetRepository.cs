using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Repositories.Contracts;

using System.Collections.Generic;
using System.Linq;

namespace PlanetWars.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private readonly ICollection<IPlanet> planets;

        public PlanetRepository()
        {
            this.planets = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models
            => (IReadOnlyCollection<IPlanet>)this.planets;

        public IPlanet FindByName(string name)
        {
            return this.planets.FirstOrDefault(p => p.Name == name);
        }

        public void AddItem(IPlanet planet)
        {
            this.planets.Add(planet);
        }

        public bool RemoveItem(string planetName)
        {
            IPlanet planetToRemove = this.planets.FirstOrDefault(p => p.Name == planetName);
            return this.planets.Remove(planetToRemove);
        }
    }
}
