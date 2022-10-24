using System;

namespace _06.Strong_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();

            int sumOfFactorials = 0;
            for (int i = 0; i < number.Length; i++)
            {
                char currentDigit = number[i];
                int currentDigitInteger = int.Parse(currentDigit.ToString());

                int currentDigitFactorial = 1;
                for (int j = 1; j <= currentDigitInteger; j++)
                {
                    currentDigitFactorial *= j;
                }

                sumOfFactorials += currentDigitFactorial;
            }

            //if (sumOfFactorials == int.Parse(number))
            //{
            //    Console.WriteLine("yes");
            //}
            //else
            //{
            //    Console.WriteLine("no");
            //}

            Console.WriteLine((sumOfFactorials == int.Parse(number)) ? "yes" : "no");

        }
    }
}
