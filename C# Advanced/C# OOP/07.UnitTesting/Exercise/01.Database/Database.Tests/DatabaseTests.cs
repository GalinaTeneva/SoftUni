namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        private Database defaultDb;

        [SetUp]
        public void SetUp()
        {
            this.defaultDb = new Database();
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5})]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16})]
        public void ConstructorShouldInitializeDataWithCorrectCount(int[] data)
        {
            //Arrange

            //Act
            Database db = new Database(data);

            //Assert
            int expectedCount = data.Length;
            int actualCount = db.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17})]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 })]
        public void ConstructorShouldThrowExcpetionWhenInputDataIsAbove16Count(int[] data)
        {
            //AAA
            Assert.Throws<InvalidOperationException>(() =>
            {
                Database db = new Database(data);
            }, "Array's capacity must be exactly 16 integers!");
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void ConstructorShouldAddElementsIntoDataField(int[] data)
        {
            Database db = new Database(data);

            int[] expextedData = data;
            int[] actualData = db.Fetch();

            CollectionAssert.AreEqual(expextedData, actualData);
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void CountShouldReturnCorrectCount(int[] data)
        {
            //Arrange
            Database db = new Database(data);

            //Act
            int expectedCount = data.Length;
            int actualCount = db.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddingElementsShouldIncreaseCount()
        {
            int expectedCount = 5;
            for (int i = 1; i <= expectedCount; i++)
            {
                this.defaultDb.Add(i);
            }

            int actualCount = this.defaultDb.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddingElementsShoouldAddThemToTheDataCollection()
        {
            int[] expectedData = new int[5];
            for (int i = 1; i <= 5; i++)
            {
                this.defaultDb.Add(i);
                expectedData[i - 1] = i;
            }

            int[] actualData = this.defaultDb.Fetch();

            CollectionAssert.AreEqual(expectedData, actualData);
        }

        [Test]
        public void AddingMoreThan16ElementsShouldThrowAnException()
        {
            for (int i = 1; i <= 16; i++)
            {
                this.defaultDb.Add(i);
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.defaultDb.Add(17);
            }, "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void RemovingElementShoulsDecreaseCount()
        {
            int initialCount = 5;
            for (int i = 1; i <= initialCount; i++)
            {
                this.defaultDb.Add(i);
            }

            int removeCount = 2;
            for (int i = 1; i <= removeCount; i++)
            {
                this.defaultDb.Remove();
            }

            int expectedCount = initialCount - removeCount;
            int actualCount = this.defaultDb.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void RemovingElementsShouldRemoveItFromTheDataCollection()
        {
            int initialCount = 5;
            for (int i = 1; i <= initialCount; i++)
            {
                this.defaultDb.Add(i);
            }

            int removeCount = 2;
            for (int i = 1; i <= removeCount; i++)
            {
                this.defaultDb.Remove();
            }

            int[] expectedData = new int[] { 1, 2, 3 };
            int[] actualData = this.defaultDb.Fetch();

            CollectionAssert.AreEqual(expectedData, actualData);
        }

        [Test]
        public void RemoveShouldThrowExceptionWhenThereAreNoElementsInDatabase()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.defaultDb.Remove();
            }, "The collection is empty!");
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void FetchShouldReturnCollectionWithElementsInTheDatabase(int[] data)
        {
            Database db = new Database(data);

            int[] expectedData = data;
            int[] actualData = db.Fetch();

            Assert.AreEqual(expectedData, actualData);
        }
    }
}
