using System;

namespace _02._Exam_Preparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxFails = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            int taskscounter = 0;
            int gradesSum = 0;
            int failsCounter = 0;
            string lastTask = null;

            while (input != "Enough")
            {
                int grade = int.Parse(Console.ReadLine());

                gradesSum += grade;
                lastTask = input;
                taskscounter++;

                if (grade <= 4)
                {
                    failsCounter++;
                }


                if (failsCounter == maxFails)
                {
                    Console.WriteLine($"You need a break, {maxFails} poor grades.");
                    return;
                }

                input = Console.ReadLine();
            }

            double averageGrade = (double)gradesSum / taskscounter;
            Console.WriteLine($"Average score: {averageGrade:F2}");
            Console.WriteLine($"Number of problems: {taskscounter}");
            Console.WriteLine($"Last problem: {lastTask}");

        }
    }
}
