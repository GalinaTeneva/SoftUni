using System;
using System.Text;

namespace _01._PasswordReset
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            while (true)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "Done")
                {
                    break;
                }
                else if (command[0] == "TakeOdd")
                {
                    text = TakeOdd(text);
                }
                else if (command[0] == "Cut")
                {
                    text = Cut(int.Parse(command[1]), int.Parse(command[2]), text);
                }
                else if (command[0] == "Substitute")
                {
                    bool containsIndexes = ContainsIndexes(command[1], text);
                    if (containsIndexes)
                    {
                        text = Substitute(command[1], command[2], text);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                        continue;
                    }
                }

                Console.WriteLine(text);
            }

            Console.WriteLine($"Your password is: {text}");
        }

        private static string TakeOdd(string text)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                if (i % 2 == 1)
                {
                    sb.Append(text[i]);
                }
            }

            return sb.ToString();
        }

        private static string Cut(int index, int lenght, string text)
        {
            return text.Remove(index, lenght);
        }

        private static bool ContainsIndexes(string substring, string text)
        {
            return text.Contains(substring);
        }
        private static string Substitute(string substring, string substitute, string text)
        {
            return text.Replace(substring, substitute);
        }

    }
}
