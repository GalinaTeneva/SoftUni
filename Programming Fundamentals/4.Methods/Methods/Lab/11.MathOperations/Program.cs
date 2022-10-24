using System;

namespace _11.MathOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            char symbol = char.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            double result =  CalculateResult(firstNumber, symbol, secondNumber);
            Console.WriteLine(result);
        }

        static double CalculateResult(int firstNum, char symbol, int secondNum)
        {
            double result = 0;
            if (symbol == '/')
            {
                result = firstNum / secondNum;
            }
            else if (symbol == '*')
            {
                result = firstNum * secondNum;
            }
            else if (symbol == '+')
            {
                result = firstNum + secondNum;
            }
            else if (symbol == '-')
            {
                result = firstNum - secondNum;
            }

            return result;
        }
    }
}
