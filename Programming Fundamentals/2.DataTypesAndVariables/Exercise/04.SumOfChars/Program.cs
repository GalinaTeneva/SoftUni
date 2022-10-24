using System;

namespace _04.SumOfChars
{
    class Program
    {
        static void Main(string[] args)
        {
            byte inputsNum = byte.Parse(Console.ReadLine());

            int sumOfChars = 0;
            for (int currentInputs = 1; currentInputs <= inputsNum; currentInputs++)
            {
                char currentChar = char.Parse(Console.ReadLine());
                sumOfChars += currentChar;
            }

            Console.WriteLine($"The sum equals: {sumOfChars}");
        }
    }
}
