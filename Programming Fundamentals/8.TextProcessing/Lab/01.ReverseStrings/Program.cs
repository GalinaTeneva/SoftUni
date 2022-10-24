using System;

namespace _01.ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string text = Console.ReadLine();
                if (text == "end")
                {
                    break;
                }

                string newText = string.Empty;
                for (int i = text.Length - 1; i >= 0; i--)
                {
                    newText += text[i];
                }

                Console.WriteLine($"{text} = {newText}");
            }
        }
    }
}
