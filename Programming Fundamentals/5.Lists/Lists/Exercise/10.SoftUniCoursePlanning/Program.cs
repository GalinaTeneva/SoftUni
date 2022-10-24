using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.SoftUniCoursePlanning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> initialSchedule = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "course start")
                {
                    break;
                }

                string[] currentCommand = input.Split(":");
                string currentLesson = currentCommand[1];
                if (currentCommand[0] == "Add")
                {
                    if (!initialSchedule.Contains(currentLesson))
                    {
                        initialSchedule.Add(currentLesson);
                    }
                }
                else if (currentCommand[0] == "Insert")
                {
                    int index = int.Parse(currentCommand[2]);
                    if (!initialSchedule.Contains(currentLesson))
                    {
                        initialSchedule.Insert(index, currentLesson);
                    }
                }
                else if (currentCommand[0] == "Remove")
                {
                    if (initialSchedule.Contains(currentLesson))
                    {
                        initialSchedule.Remove(currentLesson);
                    }
                    if (initialSchedule.Contains(currentLesson + "-Exercise"))
                    {
                        initialSchedule.Remove(currentLesson + "-Exercise");
                    }

                }
                else if (currentCommand[0] == "Swap")
                {
                    string firstLesson = currentCommand[1];
                    string secondLesson = currentCommand[2];
                    initialSchedule = SwapLessons(initialSchedule, firstLesson, secondLesson);
                }
                else if (currentCommand[0] == "Exercise")
                {
                    initialSchedule = AddExercise(initialSchedule, currentLesson);
                }
            }

            foreach (string lesson in initialSchedule)
            {
                Console.WriteLine($"{initialSchedule.IndexOf(lesson) + 1}.{lesson}");
            }
        }

        private static List<string> AddExercise(List<string> initialSchedule, string currentLesson)
        {
            string currentExerciseName = currentLesson + "-Exercise";
            if (initialSchedule.Contains(currentLesson) && !initialSchedule.Contains(currentExerciseName))
            {
                int indexOfCurrentLesson = initialSchedule.IndexOf(currentLesson);
                initialSchedule.Insert(indexOfCurrentLesson + 1, currentExerciseName);
            }
            else if (!initialSchedule.Contains(currentLesson) && !initialSchedule.Contains(currentExerciseName))
            {
                initialSchedule.Add(currentLesson);
                initialSchedule.Add(currentExerciseName);
            }

            return initialSchedule;
        }

        private static List<string> SwapLessons(List<string> initialSchedule, string firstLesson, string secondLesson)
        {
            if (initialSchedule.Contains(firstLesson) && initialSchedule.Contains(secondLesson))
            {
                int firstLessonIndex = initialSchedule.IndexOf(firstLesson);
                int secondLessonIndex = initialSchedule.IndexOf(secondLesson);
                initialSchedule[firstLessonIndex] = secondLesson;
                initialSchedule[secondLessonIndex] = firstLesson;

                if (initialSchedule.Contains(firstLesson + "-Exercise") && initialSchedule.Contains(secondLesson + "-Exercise"))
                {
                    int firstExerciseIndex = initialSchedule.IndexOf(firstLesson + "-Exercise");
                    int secondExerciseIndex = initialSchedule.IndexOf(secondLesson + "-Exercise");
                    initialSchedule[firstExerciseIndex] = secondLesson + "-Exercise";
                    initialSchedule[secondExerciseIndex] = firstLesson + "-Exercise";
                }
                else if (initialSchedule.Contains(firstLesson + "-Exercise"))
                {
                    int firstExerciseIndex = initialSchedule.IndexOf(firstLesson + "-Exercise");
                    initialSchedule.Insert(secondLessonIndex + 1, firstLesson + "-Exercise");
                    initialSchedule.RemoveAt(firstExerciseIndex + 1);
                }
                else if (initialSchedule.Contains(secondLesson + "-Exercise"))
                {
                    int secondExerciseIndex = initialSchedule.IndexOf(secondLesson + "-Exercise");
                    initialSchedule.Insert(firstLessonIndex + 1, secondLesson + "-Exercise");
                    initialSchedule.RemoveAt(secondExerciseIndex + 1);
                }

            }
            return initialSchedule;
        }
    }
}
