using System;

namespace _03.Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            switch (command)
            {
                case "add":
                    AddNums(firstNum, secondNum);
                    break;
                case "multiply":
                    MultiplyNums(firstNum, secondNum);
                    break;
                case "subtract":
                    SubtractNums(firstNum, secondNum);
                    break;
                case "divide":
                    DivideNums(firstNum, secondNum);
                    break;
            }
        }

        static void AddNums(int firstNum, int secondNum)
        {
            Console.WriteLine(firstNum + secondNum);
        }
        static void MultiplyNums(int firstNum, int secondNum)
        {
            Console.WriteLine(firstNum * secondNum);
        }
        static void SubtractNums(int firstNum, int secondNum)
        {
            Console.WriteLine(firstNum - secondNum);
        }
        static void DivideNums(int firstNum, int secondNum)
        {
            Console.WriteLine(firstNum / secondNum);
        }
    }
}
