using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Repositories.Contracts;

using System.Collections.Generic;
using System.Linq;

namespace PlanetWars.Repositories
{
    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private readonly ICollection<IMilitaryUnit> units;

        public UnitRepository()
        {
            this.units = new List<IMilitaryUnit>();
        }

        public IReadOnlyCollection<IMilitaryUnit> Models
            => (IReadOnlyCollection<IMilitaryUnit>)this.units;

        public IMilitaryUnit FindByName(string unitTypeName)
        {
            return this.units.FirstOrDefault(u => u.GetType().Name == unitTypeName);
        }

        public void AddItem(IMilitaryUnit unit)
        {
            this.units.Add(unit);
        }

        public bool RemoveItem(string unitTypeName)
        {
            IMilitaryUnit unitToRemove = this.units.FirstOrDefault(u => u.GetType().Name == unitTypeName);
            return this.units.Remove(unitToRemove);
        }
    }
}
