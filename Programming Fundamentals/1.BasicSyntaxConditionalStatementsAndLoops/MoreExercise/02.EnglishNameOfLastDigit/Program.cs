using System;

namespace _02.EnglishNameOfLastDigit
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputNum = Console.ReadLine();

            char lastSymbol = inputNum[inputNum.Length - 1];

            string spelling = string.Empty;
            switch(lastSymbol)
            {
                case '0':
                    spelling = "zero";
                    break;
                case '1':
                    spelling = "one";
                    break;
                case '2':
                    spelling = "two";
                    break;
                case '3':
                    spelling = "three";
                    break;
                case '4':
                    spelling = "four";
                    break;
                case '5':
                    spelling = "five";
                    break;
                case '6':
                    spelling = "six";
                    break;
                case '7':
                    spelling = "seven";
                    break;
                case '8':
                    spelling = "eight";
                    break;
                case '9':
                    spelling = "nine";
                    break;
            }

            Console.WriteLine(spelling);
        }
    }
}
