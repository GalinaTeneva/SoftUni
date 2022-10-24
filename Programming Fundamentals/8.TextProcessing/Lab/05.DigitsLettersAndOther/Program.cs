using System;
using System.Text;

namespace _05.DigitsLettersAndOther
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();

            StringBuilder letters = new StringBuilder();
            StringBuilder digits = new StringBuilder();
            StringBuilder character = new StringBuilder();

            foreach (char symbol in inputString)
            {
                if (char.IsDigit(symbol))
                {
                    letters.Append(symbol);
                }
                if (char.IsLetter(symbol))
                {
                    digits.Append(symbol);
                }
                if (!char.IsLetterOrDigit(symbol))
                {
                    character.Append(symbol);
                }
            }

            Console.WriteLine(letters);
            Console.WriteLine(digits);
            Console.WriteLine(character);
        }
    }
}
