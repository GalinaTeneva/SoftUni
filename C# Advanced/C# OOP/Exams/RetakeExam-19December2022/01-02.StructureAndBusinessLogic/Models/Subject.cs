using System;
using System.Collections.Generic;
using System.Text;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Models
{
    public abstract class Subject : ISubject
    {
        private string name;
        private double rate;

        public Subject(int subjectId, string subjectName, double subjectRate)
        {
            this.Id = subjectId;
            this.Name = subjectName;
            this.rate = subjectRate;
        }

        public int Id { get; private set; }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }

                this.name = value;
            }
        }

        public double Rate => this.rate;
    }
}
