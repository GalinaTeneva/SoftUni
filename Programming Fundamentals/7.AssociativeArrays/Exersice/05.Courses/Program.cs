using System;
using System.Collections.Generic;

namespace _05.Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> coursesInfo = new Dictionary<string, List<string>>();
            string[] currCourseInfo = Console.ReadLine().Split(" : ", StringSplitOptions.RemoveEmptyEntries);

            while (currCourseInfo[0] != "end")
            {
                string currCourseName = currCourseInfo[0];
                string currStudentName = currCourseInfo[1];

                if (!coursesInfo.ContainsKey(currCourseName))
                {
                    coursesInfo[currCourseName] = new List<string>();
                }

                coursesInfo[currCourseName].Add(currStudentName);

                currCourseInfo = Console.ReadLine().Split(" : ", StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var course in coursesInfo)
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");

                foreach (string student in course.Value)
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}
