using System;
using System.Collections.Generic;

namespace _04.Students
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
            string input = Console.ReadLine();
            List<Student> students = new List<Student>();
 
            while (input != "end")
            {
                string[] studentInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string firstName = studentInfo[0];
                string lastName = studentInfo[1];
                int  age = int.Parse(studentInfo[2]);
                string homeTown = studentInfo[3];

                Student student = new Student()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age,
                    HomeTown = homeTown,
                };

                students.Add(student);
                    
                input = Console.ReadLine();
            }

            string searchTown = Console.ReadLine();
            List<Student> filteredStudents = students.FindAll(student => student.HomeTown == searchTown);

            foreach (Student student in filteredStudents)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
            }
         

        }
    }
}
