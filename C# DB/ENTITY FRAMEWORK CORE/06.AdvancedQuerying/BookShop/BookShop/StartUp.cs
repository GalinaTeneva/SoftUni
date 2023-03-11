namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            using var dbContext = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            //02. Age Restriction
            //string ageRestrictionInput = Console.ReadLine();
            //string result = GetBooksByAgeRestriction(dbContext, ageRestrictionInput);

            //03. Golden Books
            string result = GetGoldenBooks(dbContext);

            Console.WriteLine(result);
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
    }
}


