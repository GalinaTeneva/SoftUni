using System;

namespace _03.CharactersInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            char charOne = char.Parse(Console.ReadLine());
            char charTwo = char.Parse(Console.ReadLine());

            PrintCharsInbetween(charOne, charTwo);
        }

        static void PrintCharsInbetween(char charOne, char charTwo)
        {
            if (charOne < charTwo)
            {
                for (int currentChar = charOne + 1; currentChar < charTwo; currentChar++)
                {
                    Console.Write((char)currentChar + " ");
                }
            }
            else
            {
                for (int currentChar = charTwo + 1; currentChar < charOne; currentChar++)
                {
                    Console.Write((char)currentChar + " ");
                }
            }

        }
    }
}
