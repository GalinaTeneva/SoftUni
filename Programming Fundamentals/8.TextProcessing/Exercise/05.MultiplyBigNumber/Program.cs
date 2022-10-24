using System;
using System.Collections.Generic;
using System.Text;

namespace _05.MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstNumString = Console.ReadLine();
            int secondNum = int.Parse(Console.ReadLine());

            if (secondNum == 0)
            {
                Console.WriteLine(0);
                return;
            }

            StringBuilder newNumber = new StringBuilder();
            int remainder = 0;

            for (int i = firstNumString.Length - 1; i >= 0; i--)
            {
                char currNum = firstNumString[i];
                int currNumDigit = int.Parse(currNum.ToString());

                int currProduct = (secondNum * currNumDigit) + remainder;
                int currNewDigit = currProduct % 10;
                remainder = currProduct / 10;

                newNumber.Append(currNewDigit.ToString());
            }

            if (remainder != 0)
            {
                newNumber.Append(remainder);
            }

            StringBuilder reversedString = new StringBuilder();
            for (int i = newNumber.Length - 1; i >= 0; i--)
            {
                reversedString.Append(newNumber[i]);
            }

            Console.WriteLine(reversedString);
        }
    }
}
