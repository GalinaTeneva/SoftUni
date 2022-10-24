using System;
using System.Text;

namespace _02.RepeatStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] separateWords = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            //string newText = "";
            //foreach (string word in separateWords)
            //{
            //    for (int i = 1; i <= word.Length; i++)
            //    {
            //        newText += word;
            //    }
            //}

            //Console.WriteLine(newText);


            string[] separateWords = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            StringBuilder newText = new StringBuilder();

            foreach (string word in separateWords)
            {
                for (int i = 1; i <= word.Length; i++)
                {
                    newText.Append(word);
                }
            }

            Console.WriteLine(newText);
        }
    }
}
