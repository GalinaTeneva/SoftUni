using System;

namespace _08.FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            double firstNumFactorial = CalcFactorial(firstNum);
            double secondNumFactorial = CalcFactorial(secondNum);

            double result = Devision(firstNumFactorial, secondNumFactorial);
            Console.WriteLine($"{result:F2}");
        }

        private static double Devision(double firstNum, double secondNum) => firstNum / secondNum;
        

        private static double CalcFactorial(int number)
        {
            double factorial = 1;
            for (int currentDigit = 1; currentDigit <= number; currentDigit++)
            {
                factorial *= currentDigit;
            }

            return factorial;
        }
    }
}
