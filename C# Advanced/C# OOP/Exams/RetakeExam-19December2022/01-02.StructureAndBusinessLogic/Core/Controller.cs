using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories;
using UniversityCompetition.Repositories.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Core
{
    public class Controller : IController
    {
        private readonly IRepository<ISubject> subjects;
        private readonly IRepository<IStudent> students;
        private readonly IRepository<IUniversity> universities;

        public Controller()
        {
            this.subjects = new SubjectRepository();
            this.students = new StudentRepository();
            this.universities = new UniversityRepository();
        }

        public string AddSubject(string subjectName, string subjectType)
        {
            if (subjectType != "TechnicalSubject" && subjectType != "EconomicalSubject" && subjectType != "HumanitySubject")
            {
                return string.Format(OutputMessages.SubjectTypeNotSupported, subjectType);
            }

            if (this.subjects.FindByName(subjectName) != null)
            {
                return string.Format(OutputMessages.AlreadyAddedSubject, subjectName);
            }

            ISubject subject;
            if (subjectType == "TechnicalSubject")
            {
                subject = new TechnicalSubject(this.subjects.Models.Count + 1, subjectName);
            }
            else if (subjectType == "EconomicalSubject")
            {
                subject = new EconomicalSubject(this.subjects.Models.Count + 1, subjectName);
            }
            else
            {
                subject = new HumanitySubject(this.subjects.Models.Count + 1, subjectName);
            }

            this.subjects.AddModel(subject);
            return string.Format(OutputMessages.SubjectAddedSuccessfully, subjectType, subjectName, nameof(SubjectRepository));
        }

        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {
            if (this.universities.FindByName(universityName) != null)
            {
                return string.Format(OutputMessages.AlreadyAddedUniversity, universityName);
            }

            List<int> requiredSubjectsIds = new List<int>();

            foreach (string requiredSubject in requiredSubjects)
            {
                ISubject subject = this.subjects.Models.First(s => s.Name == requiredSubject);
                int subjectId = subject.Id;

                requiredSubjectsIds.Add(subjectId);
            }

            IUniversity university = new University(this.universities.Models.Count + 1, universityName, category, capacity, requiredSubjectsIds);
            this.universities.AddModel(university);
            return string.Format(OutputMessages.UniversityAddedSuccessfully, universityName, nameof(UniversityRepository));
        }

        public string AddStudent(string firstName, string lastName)
        {
            string fullName = firstName + " " + lastName;

            if (this.students.FindByName(fullName) != null)
            {
                return string.Format(OutputMessages.AlreadyAddedStudent, firstName, lastName);
            }

            IStudent student = new Student(this.students.Models.Count + 1, firstName, lastName);
            this.students.AddModel(student);

            return string.Format(OutputMessages.StudentAddedSuccessfully, firstName, lastName, nameof(StudentRepository));
        }

        public string TakeExam(int studentId, int subjectId)
        {
            IStudent student = this.students.FindById(studentId);
            ISubject subject = this.subjects.FindById(subjectId);

            if (student == null)
            {
                return OutputMessages.InvalidStudentId;
            }

            if (subject == null)
            {
                return OutputMessages.InvalidSubjectId;
            }

            bool isExamCovered = student.CoveredExams.Any(e => e == subjectId);
            if (isExamCovered)
            {
                return string.Format(OutputMessages.StudentAlreadyCoveredThatExam, student.FirstName, student.LastName, subject.Name);
            }

            student.CoverExam(subject);
            return string.Format(OutputMessages.StudentSuccessfullyCoveredExam, student.FirstName, student.LastName, subject.Name);
        }

        public string ApplyToUniversity(string studentName, string universityName)
        {
            string[] nameSplit = studentName.Split(" ");
            string firstName = nameSplit[0];
            string lastName = nameSplit[1];

            IStudent student = this.students.FindByName(studentName);
            if (student == null)
            {
                return string.Format(OutputMessages.StudentNotRegitered, firstName, lastName);
            }

            IUniversity university = this.universities.FindByName(universityName);
            if (university == null)
            {
                return string.Format(OutputMessages.UniversityNotRegitered, universityName);
            }

            bool areExamsTaken = true;
            foreach (var rs in university.RequiredSubjects)
            {
                if (!student.CoveredExams.Any(e => e == rs))
                {
                    areExamsTaken = false;
                    break;
                }
            }

            if (!areExamsTaken)
            {
                return string.Format(OutputMessages.StudentHasToCoverExams, studentName, universityName);
            }

            IUniversity joinedUniversity = student.University;

            if (joinedUniversity != null)
            {
                if (joinedUniversity.Name == universityName)
                {
                    return string.Format(OutputMessages.StudentAlreadyJoined, student.FirstName, student.LastName, universityName);
                }
            }

            student.JoinUniversity(university);
            return string.Format(OutputMessages.StudentSuccessfullyJoined, student.FirstName, student.LastName, universityName);
        }

        public string UniversityReport(int universityId)
        {
            IUniversity university = this.universities.FindById(universityId);

            List<IStudent> currUniversityStudents = this.students.Models.Where(s => s.University == university).ToList();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"*** {university.Name} ***");
            sb.AppendLine($"Profile: {university.Category}");
            sb.AppendLine($"Students admitted: {currUniversityStudents.Count}");
            sb.AppendLine($"University vacancy: {university.Capacity - currUniversityStudents.Count}");

            return sb.ToString().TrimEnd();
        }
    }
}
