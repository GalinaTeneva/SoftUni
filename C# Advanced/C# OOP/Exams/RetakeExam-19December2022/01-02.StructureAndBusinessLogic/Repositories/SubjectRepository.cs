using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class SubjectRepository : IRepository<ISubject>
    {
        private readonly ICollection<ISubject> subjects;

        public SubjectRepository()
        {
            this.subjects = new List<ISubject>();
        }

        public IReadOnlyCollection<ISubject> Models
            => (IReadOnlyCollection<ISubject>)this.subjects;

        public void AddModel(ISubject subject)
        {
            this.subjects.Add(subject);
        }

        public ISubject FindById(int id)
        {
            return this.subjects.FirstOrDefault(s => s.Id == id);
        }

        public ISubject FindByName(string name)
        {
            return this.subjects.FirstOrDefault(s => s.Name == name);
        }
    }
}
