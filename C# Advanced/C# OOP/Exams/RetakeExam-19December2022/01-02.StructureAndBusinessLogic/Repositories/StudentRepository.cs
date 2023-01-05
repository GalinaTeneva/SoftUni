using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class StudentRepository : IRepository<IStudent>
    {
        private readonly ICollection<IStudent> students;

        public StudentRepository()
        {
            this.students = new List<IStudent>();
        }

        public IReadOnlyCollection<IStudent> Models
            => (IReadOnlyCollection<IStudent>)this.students;

        public void AddModel(IStudent student)
        {
            this.students.Add(student);
        }

        public IStudent FindById(int id)
        {
            return this.students.FirstOrDefault(s => s.Id == id);
        }

        public IStudent FindByName(string name)
        {
            string[] nameSplit = name.Split(" ");
            string firstName = nameSplit[0];
            string lastName = nameSplit[1];

            return this.students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);
        }
    }
}
