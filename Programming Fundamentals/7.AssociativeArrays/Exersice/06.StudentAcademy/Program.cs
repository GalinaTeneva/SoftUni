using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.StudentAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> studentsGradesPairs = new Dictionary<string, List<double>>();
            int studentsCount = int.Parse(Console.ReadLine());

            for (int currStudent = 1; currStudent <= studentsCount; currStudent++)
            {
                string currStudentName = Console.ReadLine();
                double currStudentGrade = double.Parse(Console.ReadLine());

                if (!studentsGradesPairs.ContainsKey(currStudentName))
                {
                    studentsGradesPairs[currStudentName] = new List<double>();
                }

                studentsGradesPairs[currStudentName].Add(currStudentGrade);
            }

            foreach (var studentGrdarePair in studentsGradesPairs)
            {
                if (studentGrdarePair.Value.Average() >= 4.50)
                {
                    Console.WriteLine($"{studentGrdarePair.Key} -> {studentGrdarePair.Value.Average():F2}");
                }
            }
        }
    }
}
