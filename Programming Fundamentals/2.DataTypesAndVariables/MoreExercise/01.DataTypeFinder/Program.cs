using System;

namespace _01.DataTypeFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int integerNum;
            double floatingPointNum;
            char character;
            bool boolean;

            string inputType = string.Empty;

            while (input != "END")
            {
                if (int.TryParse(input, out integerNum))
                {
                    inputType = "integer";
                }
                else if (double.TryParse(input, out floatingPointNum))
                {
                    inputType = "floating point";
                }
                else if (char.TryParse(input, out character))
                {
                    inputType = "character";
                }
                else if (bool.TryParse(input, out boolean))
                {
                    inputType = "boolean";
                }
                else
                {
                    inputType = "string";
                }

                Console.WriteLine($"{input} is {inputType} type");

                input = Console.ReadLine();
            }
        }
    }
}
