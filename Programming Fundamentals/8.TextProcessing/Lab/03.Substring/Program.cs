using System;

namespace _03.Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string textToRemove = Console.ReadLine();
            string text = Console.ReadLine();

            while (text.Contains(textToRemove))
            {
                int startIndex = text.IndexOf(textToRemove);

                text = text.Remove(startIndex, textToRemove.Length);
            }

            Console.WriteLine(text);
        }
    }
}
