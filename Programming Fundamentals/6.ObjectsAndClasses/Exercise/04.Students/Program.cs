using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Students
{
    class Program
    {
        static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();

            for (int currStudent = 1; currStudent <= studentsCount; currStudent++)
            {
                string[] currStudentInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string firstName = currStudentInfo[0];
                string lastName = currStudentInfo[1];
                double grade = double.Parse(currStudentInfo[2]);

                Student student = new Student
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Grade = grade
                };

                students.Add(student);
            }

            List<Student> orderedStudents = students.OrderByDescending(student => student.Grade).ToList();
            foreach (Student student in orderedStudents)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}: {student.Grade:F2}");
            }
        }
    }

    class Student
    {
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public double Grade { set; get; }

    }

}
