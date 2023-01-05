using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;

using System.Collections.Generic;
using System.Linq;

namespace Heroes.Repositories
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

        public void Add(IWeapon model)
        {
            this.weapons.Add(model);
        }

        public bool Remove(IWeapon model)
        {
            return this.weapons.Remove(model);
        }

        public IWeapon FindByName(string name)
        {
            return this.weapons.FirstOrDefault(w => w.Name == name);
        }
    }
}
