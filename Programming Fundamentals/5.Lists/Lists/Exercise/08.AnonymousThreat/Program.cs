using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.AnonymousThreat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> initialInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            string[] command = Console.ReadLine().Split();
            while (command[0] != "3:1")
            {
                if (command[0] == "merge")
                {
                    int startIndex = int.Parse(command[1]);
                    int endIndex = int.Parse(command[2]);

                    if (startIndex < 0 || startIndex > initialInput.Count - 1)
                    {
                        startIndex = 0;
                    }
                    if (endIndex > initialInput.Count - 1 || endIndex < 0)
                    {
                        endIndex = initialInput.Count - 1;
                    }

                    MergeElements(initialInput, startIndex, endIndex);
                }
                else if (command[0] == "divide")
                {
                    int index = int.Parse(command[1]);
                    int partitions = int.Parse(command[2]);

                    DivideElement(initialInput, index, partitions);
                }

                command = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(" ", initialInput));
        }

        private static List<string> MergeElements(List<string> initialInput, int startIndex, int endIndex)
        {
            string mergedString = string.Empty;
            for (int i = startIndex; i <= endIndex; i++)
            {
                mergedString += initialInput[i];
            }
            initialInput.RemoveRange(startIndex, endIndex - startIndex + 1);
            initialInput.Insert(startIndex, mergedString);
            return initialInput;
        }

        private static List<string> DivideElement(List<string> initialInput, int index, int partitions)
        {
            List<string> dividedList = new List<string>();
            string dividingWord = initialInput[index];
            initialInput.RemoveAt(index);
            int newWordsLength = dividingWord.Length / partitions;

            for (int i = 0; i < partitions; i++)
            {
                if (i == partitions - 1)
                {
                    dividedList.Add(dividingWord.Substring(i * newWordsLength));
                }
                else
                {
                    dividedList.Add(dividingWord.Substring(i * newWordsLength, newWordsLength));
                }
            }

            initialInput.InsertRange(index, dividedList);

            return initialInput;
        }
    }
}
