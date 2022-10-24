using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int studentsNum = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> studentRecord = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < studentsNum; i++)
            {
                string[] currStudentInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string studentName = currStudentInfo[0];
                decimal studentGrade = decimal.Parse(currStudentInfo[1]);

                if (!studentRecord.ContainsKey(studentName))
                {
                    studentRecord[studentName] = new List<decimal>();
                }

                studentRecord[studentName].Add(studentGrade);
            }


            foreach (var kvp in studentRecord)
            {
                string name = kvp.Key;
                string grades = string.Join(' ', kvp.Value.Select(g => g.ToString("F2")));
                decimal average = kvp.Value.Average();

                Console.WriteLine($"{name} -> {grades} (avg: {average:F2})");
            }

        }
    }
}
