using System;

namespace _04._Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int studentsNum = int.Parse(Console.ReadLine());

            double studentsBelowThreeCounter = 0;
            double studentsBetweenThreeAndFourCounter = 0;
            double studentsBetweenFourAndFiveCounter = 0;
            double studentsAboveFiveCounter = 0;
            double gradesSum = 0;
            for (int currentStudent = 1; currentStudent <= studentsNum; currentStudent++)
            {
                double currentStudentGrade = double.Parse(Console.ReadLine());

                if (currentStudentGrade >= 2.00 && currentStudentGrade <= 2.99)
                {
                    studentsBelowThreeCounter++;
                    gradesSum += currentStudentGrade;
                }
                else if (currentStudentGrade >= 3.00 && currentStudentGrade <= 3.99)
                {
                    studentsBetweenThreeAndFourCounter++;
                    gradesSum += currentStudentGrade;
                }
                else if (currentStudentGrade >= 4.00 && currentStudentGrade <= 4.99)
                {
                    studentsBetweenFourAndFiveCounter++;
                    gradesSum += currentStudentGrade;
                }
                else if (currentStudentGrade >= 5.00)
                {
                    studentsAboveFiveCounter++;
                    gradesSum += currentStudentGrade;
                }
            }

            double studentsBelowThreePercent = studentsBelowThreeCounter / studentsNum * 100;
            double studentsBetweenThreeAndFourPercent = studentsBetweenThreeAndFourCounter / studentsNum * 100;
            double studentsBetweenFourAndFivePercent = studentsBetweenFourAndFiveCounter / studentsNum * 100;
            double studentsAboveFivePercent = studentsAboveFiveCounter / studentsNum * 100;

            Console.WriteLine($"Top students: {studentsAboveFivePercent:F2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {studentsBetweenFourAndFivePercent:F2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {studentsBetweenThreeAndFourPercent:F2}%");
            Console.WriteLine($"Fail: {studentsBelowThreePercent:F2}%");

            Console.WriteLine($"Average: {(gradesSum / studentsNum):F2}");
        }
    }
}
