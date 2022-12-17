
namespace NavalVessels.Repositories
{
    using Models.Contracts;
    using Contracts;

    using System.Collections.Generic;
    using System.Linq;

    public class VesselRepository : IRepository<IVessel>
    {
        private readonly ICollection<IVessel> models;

        public VesselRepository()
        {
            this.models = new HashSet<IVessel>();
        }

        public IReadOnlyCollection<IVessel> Models
            => (IReadOnlyCollection<IVessel>)this.models;

        public void Add(IVessel vessel)
        {
            this.models.Add(vessel);
        }

        public IVessel FindByName(string name)
        {
            return this.models.FirstOrDefault(v => v.Name == name);
        }

        public bool Remove(IVessel vessel)
        {
            return this.Remove(vessel);
        }
    }
}
