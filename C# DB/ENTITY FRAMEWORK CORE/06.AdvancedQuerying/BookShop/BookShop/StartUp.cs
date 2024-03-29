﻿namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System.Globalization;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var dbContext = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            //02. Age Restriction
            //string ageRestrictionInput = Console.ReadLine();
            //string result = GetBooksByAgeRestriction(dbContext, ageRestrictionInput);

            //03. Golden Books
            //string result = GetGoldenBooks(dbContext);

            //04. Books by Price
            //string result = GetBooksByPrice(dbContext);

            //05. Not Released In
            //int year = int.Parse(Console.ReadLine()!);
            //string result = GetBooksNotReleasedIn(dbContext, year);

            //06. Book Titles by Category
            //string input = Console.ReadLine();
            //string result = GetBooksByCategory(dbContext, input);

            //07. Released Before Date
            //string date = Console.ReadLine();
            //string result = GetBooksReleasedBefore(dbContext, date);

            //08. Author Search
            //string input = Console.ReadLine();
            //string result = GetAuthorNamesEndingIn(dbContext, input);

            //09. Book Search
            //string input = Console.ReadLine();
            //string result = GetBookTitlesContaining(dbContext, input);

            //10. Book Search by Author
            //string input = Console.ReadLine();
            //string result = GetBooksByAuthor(dbContext, input);

            //11. Count Books
            //int lengthCheck = int.Parse(Console.ReadLine());
            //int result = CountBooks(dbContext, lengthCheck);

            //12. Total Book Copies
            //string result = CountCopiesByAuthor(dbContext);

            //13. Profit by Category
            //string result = GetTotalProfitByCategory(dbContext);

            //14. Most Recent Books
            //string result = GetMostRecentBooks(dbContext);

            //15. Increase Prices
            //IncreasePrices(dbContext);

            //16. Remove Books
            RemoveBooks(dbContext);

            //Console.WriteLine(result);
        }

        //02. Age Restriction
        public static string GetBooksByAgeRestriction(BookShopContext dbContext, string command)
        {
            try
            {
                AgeRestriction ageRestriction = Enum.Parse<AgeRestriction>(command, true);

                string[] bookTitles = dbContext.Books
                    .Where(b => b.AgeRestriction == ageRestriction)
                    .OrderBy(b => b.Title)
                    .Select(b => b.Title)
                    .ToArray();

                return string.Join(Environment.NewLine, bookTitles);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        //03. Golden Books
        public static string GetGoldenBooks(BookShopContext dbContext)
        {
            string[] bookTitles = dbContext.Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            return string.Join(Environment.NewLine, bookTitles);
        }

        //04. Books by Price
        public static string GetBooksByPrice(BookShopContext dbContext)
        {
            var books = dbContext.Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        //05. Not Released In
        public static string GetBooksNotReleasedIn(BookShopContext dbContext, int year)
        {
            string[] books = dbContext.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            return String.Join(Environment.NewLine, books);
        }

        //06. Book Titles by Category
        public static string GetBooksByCategory(BookShopContext dbContext, string input)
        {
            string[] categories = input
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(c => c.ToLower())
                .ToArray();

            var books = dbContext.Books
                .Where(b => b.BookCategories
                    .Any(bc => categories.Contains(bc.Category.Name.ToLower())))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToArray();

            return string.Join(Environment.NewLine, books);
        }

        //07. Released Before Date
        public static string GetBooksReleasedBefore(BookShopContext dbContext, string dateString)
        {
            DateTime date = DateTime.Parse(dateString);

            var books = dbContext.Books
                .Where(b => b.ReleaseDate < date)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price,
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:F2}");
            }

            return sb.ToString().Trim();
        }

        //08. Author Search
        public static string GetAuthorNamesEndingIn(BookShopContext dbContext, string input)
        {
            string[] authors = dbContext.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .OrderBy(a => a.FirstName)
                .ThenBy(a => a.LastName)
                .Select(a => $"{a.FirstName} {a.LastName}")
                .ToArray();

            return string.Join(Environment.NewLine, authors);
        }

        //09. Book Search
        public static string GetBookTitlesContaining(BookShopContext dbContext, string input)
        {
            string[] books = dbContext.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToArray();

            return string.Join(Environment.NewLine, books);
        }

        //10. Book Search by Author
        public static string GetBooksByAuthor(BookShopContext dbContext, string input)
        {
            var books = dbContext.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    b.Title,
                    b.Author.FirstName,
                    b.Author.LastName
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} ({book.FirstName} {book.LastName})");
            }

            return sb.ToString().TrimEnd();
        }

        //11. Count Books
        public static int CountBooks(BookShopContext dbContext, int lengthCheck)
        {
            var books = dbContext.Books
                .Where(b => b.Title.Length > lengthCheck)
                .ToArray();

            return books.Count();
        }

        //12. Total Book Copies
        public static string CountCopiesByAuthor(BookShopContext dbContext)
        {
            var authors = dbContext.Authors
                .Select(a => new
                {
                    FullName = a.FirstName + " " + a.LastName,
                    TotalCopies = a.Books.Sum(b => b.Copies)
                })
                .ToArray()
                .OrderByDescending(b => b.TotalCopies);

            StringBuilder sb = new StringBuilder();

            foreach (var author in authors)
            {
                sb.AppendLine($"{author.FullName} - {author.TotalCopies}");
            }

            return sb.ToString().Trim();
        }

        //13. Profit by Category
        public static string GetTotalProfitByCategory(BookShopContext dbContext)
        {
            var categories = dbContext.Categories
                .Select(c => new
                {
                    c.Name,
                    TotalProfit = c.CategoryBooks
                        .Sum(cb => cb.Book.Price * cb.Book.Copies)
                })
                .ToArray()
                .OrderByDescending(c => c.TotalProfit)
                .ThenBy(c => c.Name);

            StringBuilder sb = new StringBuilder();

            foreach (var category in categories)
            {
                sb.AppendLine($"{category.Name} ${category.TotalProfit:F2}");
            }

            return sb.ToString().Trim();
        }

        //14. Most Recent Books
        public static string GetMostRecentBooks(BookShopContext dbContext)
        {
            var categories = dbContext.Categories
                .OrderBy(c => c.Name)
                .Select(c => new
                {
                    CategoryName = c.Name,
                    MostRecentBooks = c.CategoryBooks
                        .OrderByDescending(cb => cb.Book.ReleaseDate)
                        .Take(3)
                        .Select(cb => new
                        {
                            BookTitle = cb.Book.Title,
                            ReleaseYear = cb.Book.ReleaseDate.Value.Year
                        })
                        .ToArray()
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();
            foreach (var category in categories)
            {
                sb.AppendLine($"--{category.CategoryName}");

                foreach (var book in category.MostRecentBooks)
                {
                    sb.AppendLine($"{book.BookTitle} ({book.ReleaseYear})");
                }
            }

            return sb.ToString().Trim();
        }

        //15. Increase Prices
        public static void IncreasePrices(BookShopContext dbContext)
        {
            Book[] books = dbContext.Books
                .Where(b => b.ReleaseDate.HasValue &&
                            b.ReleaseDate.Value.Year < 2010)
                .ToArray();

            foreach (Book book in books)
            {
                book.Price += 5;
            }

            dbContext.SaveChanges();
        }

        //16. Remove Books
        public static int RemoveBooks(BookShopContext dbContext)
        {
            Book[] books = dbContext.Books
                .Where(b => b.Copies < 4200)
                .ToArray();

            foreach (Book book in books)
            {
                dbContext.Books.Remove(book);
            }

            dbContext.SaveChanges();

            return books.Length;
        }
    }
}


