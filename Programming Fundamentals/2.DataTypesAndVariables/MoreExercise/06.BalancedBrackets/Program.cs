using System;

namespace _06.BalancedBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            bool isBalanced = true;
            string previousBrecket = "";

            for (int currLine = 1; currLine <= lines; currLine++)
            {
                string currInput = Console.ReadLine().Trim();

                if (currInput == "(")
                {
                    if (previousBrecket == "(")
                    {
                        isBalanced = false;
                    }
                    previousBrecket = "(";
                }
                if (currInput == ")")
                {
                    if (previousBrecket != "(")
                    {
                        isBalanced = false;
                    }
                    previousBrecket = ")";
                }
            }

            if (previousBrecket == "(")
            {
                isBalanced = false;
            }

            if (isBalanced)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}
