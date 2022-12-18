using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;

using System.Collections.Generic;
using System.Linq;

namespace PlanetWars.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private readonly ICollection<IWeapon> weapons;

        public WeaponRepository()
        {
            this.weapons = new List<IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Models
            => (IReadOnlyCollection<IWeapon>)this.weapons;

        public IWeapon FindByName(string weaponTypeName)
        {
            return this.weapons.FirstOrDefault(w => w.GetType().Name == weaponTypeName);
        }

        public void AddItem(IWeapon weapon)
        {
            this.weapons.Add(weapon);
        }

        public bool RemoveItem(string weaponTypeName)
        {
            IWeapon weaponToRemove = this.weapons.FirstOrDefault(w => w.GetType().Name == weaponTypeName);
            return this.weapons.Remove(weaponToRemove);
        }
    }
}
