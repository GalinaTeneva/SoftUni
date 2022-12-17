namespace Book.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using NUnit.Framework;

    [TestFixture]
    public class Tests
    {
        private Book defaultBook;

        [SetUp]
        public void SetUp()
        {
            this.defaultBook = new Book("Ilinden", "Dimitar Talev");
        }

        [Test]
        public void CtorShouldInitializeBookNameCorrectly()
        {
            string expectedBookName = "Ilinden";
            Book book = new Book(expectedBookName, "Dimitar Talev");

            string actualBookName = book.BookName;
            Assert.AreEqual(expectedBookName, book.BookName);
        }

        [Test]
        public void CtorShouldInitializeAuthorNameCorrectly()
        {
            string expectedAuthorName = "Dimitar Talev";
            Book book = new Book("Ilinden", expectedAuthorName);

            string actualAuthorName = book.Author;
            Assert.AreEqual(expectedAuthorName, actualAuthorName);
        }

        [Test]
        public void CtorShouldInitializeFootNoteCorrectly()
        {
            Type bookType = this.defaultBook.GetType();
            FieldInfo dictFieldInfo = bookType
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(fi => fi.Name == "footnote");

            object fieldValue = dictFieldInfo.GetValue(this.defaultBook);
            Assert.IsNotNull(fieldValue);
        }

        [Test]
        public void CountShouldReturnZeroWhenNoFootNotesAdded()
        {
            int expectedCount = 0;
            int actualCount = defaultBook.FootnoteCount;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void CountShouldReturnCorrectCountWhenFootNotesAdded()
        {
            this.defaultBook.AddFootnote(5, "hgghjgkjhu");
            this.defaultBook.AddFootnote(7, "mmmmmmmmmm");

            int expectedCount = 2;
            int actualCount = defaultBook.FootnoteCount;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestCase("RealName")]
        [TestCase("1")]
        [TestCase("   ")]
        public void BookNameShouldReturnCorrectValues(string bookName)
        {
            Book book = new Book(bookName, "Author");

            string expectedBookName = bookName;
            string actualBookName = book.BookName;

            Assert.AreEqual(expectedBookName, actualBookName);
        }

        [TestCase(null)]
        [TestCase("")]
        public void BookNameShouldThrowExceptionWhenBookNameIsNullOtEmpty(string bookName)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book(bookName, "Author");
            }, "Invalid BookName!");
        }

        [TestCase("RealName")]
        [TestCase("1")]
        [TestCase("   ")]
        public void AuthorShouldReturnCorrectValues(string author)
        {
            Book book = new Book("Book", author);

            string expectedAuthorName = author;
            string actualAuthorName = book.Author;

            Assert.AreEqual(expectedAuthorName, actualAuthorName);
        }

        [TestCase(null)]
        [TestCase("")]
        public void AuthorShouldThrowExceptionWhenBookNameIsNullOtEmpty(string author)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book("Book", author);
            }, "Invalid Author!");
        }

        [Test]
        public void AddingFootNoteShouldIncreaseCount()
        {
            this.defaultBook.AddFootnote(5, "hgghjgkjhu");

            int expectedCount = 1;
            int actualCount = defaultBook.FootnoteCount;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddingFootNoteShouldAddKeyInTheDictionary()
        {
            int addedKey = 1;
            this.defaultBook.AddFootnote(addedKey, "Some text");

            Type bookType = this.defaultBook.GetType();
            FieldInfo dictFieldInfo = bookType
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(fi => fi.Name == "footnote");

            Dictionary<int, string> fieldValue = (Dictionary<int, string>)dictFieldInfo.GetValue(this.defaultBook);
            bool containsKey = fieldValue.ContainsKey(addedKey);

            Assert.IsTrue(containsKey);
        }

        [Test]
        public void AddingExistingFootNoteShouldThrowException()
        {
            this.defaultBook.AddFootnote(1, "Some Text");
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.defaultBook.AddFootnote(1, "Another Text");
            }, "Footnote already exists!");
        }

        [Test]
        public void FindFootNoteShouldReturnCorrectTextWhenExisting()
        {
            int footKey = 1;
            string footText = "Some text";
            this.defaultBook.AddFootnote(footKey, footText);

            string expetedResult = $"Footnote #{footKey}: {footText}";
            string actualResult = this.defaultBook.FindFootnote(footKey);

            Assert.AreEqual(expetedResult, actualResult);
        }

        [Test]
        public void FindFootNoteShouldThrowExceptionWhenThereAreKeysButPassedKeyDoesNotExists()
        {
            this.defaultBook.AddFootnote(1, "Some text");
            this.defaultBook.AddFootnote(2, "Another text");

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.defaultBook.FindFootnote(3);
            }, "Footnote doesn't exists!");
        }

        [Test]
        public void FindFootNoteShouldThrowExceptionWhenThereAreNoKeysAtAll()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.defaultBook.FindFootnote(3);
            }, "Footnote doesn't exists!");
        }

        [Test]
        public void AlterFootNoteShouldChangeTextWhenFootNoteExists()
        {
            int footKey = 1;
            string footText = "Some text";
            this.defaultBook.AddFootnote(footKey, footText);

            string expectedText = "New text";
            this.defaultBook.AlterFootnote(footKey, expectedText);

            Type bookType = this.defaultBook.GetType();
            FieldInfo dictFieldInfo = bookType
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(fi => fi.Name == "footnote");

            Dictionary<int, string> fieldValue = (Dictionary<int, string>)dictFieldInfo.GetValue(this.defaultBook);
            string actualText = fieldValue[footKey];

            Assert.AreEqual(expectedText, actualText);
        }

        [Test]
        public void AlterFootNoteShouldThrowExceptionWhenThereAreFootNotesButPassedKeyDoesNotExists()
        {
            this.defaultBook.AddFootnote(1, "Some text");
            this.defaultBook.AddFootnote(2, "Another text");

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.defaultBook.AlterFootnote(3, "New text");
            }, "Footnote does not exists!");
        }

        [Test]
        public void AlterFootNoteShouldThrowExceptionWhenThereAreNoKeysAtAll()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.defaultBook.AlterFootnote(3, "New text");
            }, "Footnote does not exists!");
        }
    }
}