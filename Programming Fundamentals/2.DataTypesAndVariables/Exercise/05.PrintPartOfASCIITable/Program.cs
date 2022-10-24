using System;

namespace _05.PrintPartOfASCIITable
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingIndex = int.Parse(Console.ReadLine());
            int endingIndex = int.Parse(Console.ReadLine());

            for (int currentIndex = startingIndex; currentIndex <= endingIndex; currentIndex++)
            {
                char currentChar = (char)currentIndex;
                Console.Write(currentChar + " ");
            }
        }
    }
}
