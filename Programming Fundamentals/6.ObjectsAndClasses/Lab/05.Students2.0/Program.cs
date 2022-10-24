using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Students2._0
{
    class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string HomeTown { get; set; }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            string[] studentInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            List<Student> students = new List<Student>();

            while (studentInfo[0] != "end") 
            {
                string firstName = studentInfo[0];
                string lastName = studentInfo[1];
                int age = int.Parse(studentInfo[2]);
                string homeTown = studentInfo[3];

                bool isStudentExisting = IsStudentExisting(students, firstName, lastName);
                if (!isStudentExisting)
                {
                    Student student = new Student();
                    student.FirstName = firstName;
                    student.LastName = lastName;
                    student.Age = age;
                    student.HomeTown = homeTown;

                    students.Add(student);
                }
                else
                {
                    Student student = GetStudent(students, firstName, lastName);
                    student.Age = age;
                    student.HomeTown = homeTown;
                }
                
                studentInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            string searchTown = Console.ReadLine();
            List<Student> filteredStudents = students.Where(student => student.HomeTown == searchTown).ToList();

            foreach(Student student in filteredStudents)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
            }
        }

        private static Student GetStudent(List<Student> students, string firstName, string lastName)
        {
            Student existingStudent = null;

            foreach (Student student in students)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    existingStudent = student;
                }
            }

            return existingStudent;
        }

        private static bool IsStudentExisting(List<Student> students, string firstName, string lastName)
        {
            foreach (Student student in students)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
