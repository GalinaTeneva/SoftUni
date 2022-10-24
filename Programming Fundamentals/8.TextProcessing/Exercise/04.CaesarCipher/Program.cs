using System;
using System.Text;

namespace _04.CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            StringBuilder newText = new StringBuilder();

            foreach (char character in text)
            {
                newText.Append((char)(character + 3));
            }

            Console.WriteLine(newText);
        }
    }
}
