namespace UniversityLibrary.Test
{
    using NUnit.Framework;
    using System;
    using System.Text;

    [TestFixture]
    public class Tests
    {
        private TextBook defBook;
        private UniversityLibrary defLibrary;

        [SetUp]
        public void Setup()
        {
            string bookTitle = "Title";
            string author = "Author";
            string category = "Category";

            defBook = new TextBook(bookTitle, author, category);
            defLibrary = new UniversityLibrary();
        }

        [Test]
        public void Test_CtorShouldSetTitleProperly()
        {
            Assert.That(this.defBook.Title, Is.EqualTo("Title"));
        }

        [Test]
        public void Test_CtorShouldSetAuthorProperly()
        {
            Assert.That(this.defBook.Author, Is.EqualTo("Author"));
        }

        [Test]
        public void Test_CtorShouldSetCategoryProperly()
        {
            Assert.That(this.defBook.Category, Is.EqualTo("Category"));
        }

        [Test]
        public void Test_ToString_ShouldWorkProperly()
        {
            string expectedResult =
                $"Book: {this.defBook.Title} - {this.defBook.InventoryNumber}" + Environment.NewLine
                + $"Category: {this.defBook.Category}" + Environment.NewLine
                + $"Author: {this.defBook.Author}";
            string actualResult = this.defBook.ToString();

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Test_AddTextBookToLibrary_ShouldAddBooksProperly()
        {
            this.defLibrary.AddTextBookToLibrary(defBook);
            Assert.That(defLibrary.Catalogue, Has.Count.EqualTo(1));
        }

        [Test]
        public void Test_AddTextBookToLibrary_ShouldChangeInventoryNumber()
        {
            TextBook newBook = new TextBook("New Book", "New Author", "New Category");

            this.defLibrary.AddTextBookToLibrary(defBook);
            this.defLibrary.AddTextBookToLibrary(newBook);

            Assert.That(newBook.InventoryNumber, Is.EqualTo(2));
        }

        [Test]
        public void Test_AddTextBookToLibrary_ShouldReturnMessage()
        {
            TextBook newBook = new TextBook("New Book", "New Author", "New Category");

            string actualResult = this.defLibrary.AddTextBookToLibrary(newBook);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Book: {newBook.Title} - {newBook.InventoryNumber}");
            sb.AppendLine($"Category: {newBook.Category}");
            sb.AppendLine($"Author: {newBook.Author}");


            string expectedResult = sb.ToString().TrimEnd();

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Test_LoanTextBook_ShouldReturnPositiveStatementWhenBorowingAvaiableBook()
        {
            string studentName = "Ivan";

            this.defLibrary.AddTextBookToLibrary(defBook);

            string expectedResult = $"{this.defBook.Title} loaned to {studentName}.";
            string actualResult = this.defLibrary.LoanTextBook(defBook.InventoryNumber, studentName);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Test_LoanTextBook_ShouldReturnNegativeStatementWhenBorowingAlreadyBorowedBook()
        {
            string studentName = "Ivan";

            this.defLibrary.AddTextBookToLibrary(defBook);
            this.defLibrary.LoanTextBook(defBook.InventoryNumber, studentName);

            string expectedResult = $"{studentName} still hasn't returned {this.defBook.Title}!";
            string actualResult = this.defLibrary.LoanTextBook(defBook.InventoryNumber, studentName);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Test_ReturnTextBook_ShouldReturnPositiveMessage()
        {
            string studentName = "Ivan";

            this.defLibrary.AddTextBookToLibrary(defBook);
            this.defLibrary.LoanTextBook(defBook.InventoryNumber, studentName);

            string expectedResult = $"{this.defBook.Title} is returned to the library.";
            string actualResult = this.defLibrary.ReturnTextBook(defBook.InventoryNumber);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Test_ReturnTextBook_ShouldChangeBookHolderToEmpty()
        {
            string studentName = "Ivan";

            this.defLibrary.AddTextBookToLibrary(this.defBook);
            this.defLibrary.LoanTextBook(this.defBook.InventoryNumber, studentName);
            this.defLibrary.ReturnTextBook(this.defBook.InventoryNumber);

            string expectedResult = string.Empty;
            string actualResult = this.defBook.Holder;

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
    }
}