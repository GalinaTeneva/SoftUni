using System;

namespace _06.Operations_Between_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            char symbol = char.Parse(Console.ReadLine());

            double result = 0;
            
            if (symbol == '+' || symbol == '-' || symbol == '*')
            {
                switch (symbol)
                {
                    case '+':
                        result = num1 + num2;
                        break;
                    case '-':
                        result = num1 - num2;
                        break;
                    case '*':
                        result = num1 * num2;
                        break;
                }

                bool isEven = result % 2 == 0;

                if (isEven)
                {
                    Console.WriteLine($"{num1} {symbol} {num2} = {result} - even");
                }
                else
                {
                    Console.WriteLine($"{num1} {symbol} {num2} = {result} - odd");
                }
            }
            else if (num2 == 0)
            {
                Console.WriteLine($"Cannot divide {num1} by zero");
            }
            else if (symbol == '/')
            {
                result = (double)num1 / num2;
                Console.WriteLine($"{num1} / {num2} = {result:f2}");
            }
            else if (symbol == '%')
            {
                result = num1 % num2;
                Console.WriteLine($"{num1} % {num2} = {result}");
            }
        }
    }
}
