using System;

namespace _01._Old_Books
{
    class Program
    {
        static void Main(string[] args)
        {
            string bookName = Console.ReadLine();

            int bookCounter = 0;

            string currentBook = Console.ReadLine();
            while (currentBook != "No More Books")
            {
                if (currentBook == bookName)
                {
                    break;
                }

                bookCounter++;
                currentBook = Console.ReadLine();
            }

            if (currentBook == bookName)
            {
                Console.WriteLine($"You checked {bookCounter} books and found it.");
            }
            else
            {
                Console.WriteLine($"The book you search is not here!");
                Console.WriteLine($"You checked {bookCounter} books.");
            }
        }
    }
}
