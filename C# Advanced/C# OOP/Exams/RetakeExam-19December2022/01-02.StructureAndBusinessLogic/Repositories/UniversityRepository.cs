using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class UniversityRepository : IRepository<IUniversity>
    {
        private readonly ICollection<IUniversity> universities;

        public UniversityRepository()
        {
            this.universities = new List<IUniversity>();
        }

        public IReadOnlyCollection<IUniversity> Models
            => (IReadOnlyCollection<IUniversity>)this.universities;

        public void AddModel(IUniversity university)
        {
            this.universities.Add(university);
        }

        public IUniversity FindById(int id)
        {
            return this.universities.FirstOrDefault(u => u.Id == id);
        }

        public IUniversity FindByName(string name)
        {
            return this.universities.FirstOrDefault(u => u.Name == name);
        }
    }
}
