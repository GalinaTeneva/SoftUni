using FrontDeskApp;
using NUnit.Framework;
using System;

namespace BookigApp.Tests
{
    [TestFixture]
    public class Tests
    {
        private Hotel defHotel;

        [SetUp]
        public void Setup()
        {
            this.defHotel = new Hotel("Name", 3);
        }

        [Test]
        public void CtorShouldInitializePropertiesProperly()
        {
            Assert.AreEqual("Name", defHotel.FullName);
            Assert.AreEqual(3, defHotel.Category);
        }

        [TestCase(null)]
        [TestCase("  ")]
        public void IfFullNameIsNullOrWhiteSpaceShouldThrowAnException(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Hotel newHotel = new Hotel(name, 2);
            });
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(6)]
        public void IfCategoryIsBelowOneOrAboveFiveShouldThrowAnException(int category)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Hotel newHotel = new Hotel("Name", category);
            });
        }

        [Test]
        public void AddRoomShouldWorkProperly()
        {
            Room room = new Room(2, 10);
            this.defHotel.AddRoom(room);

            Assert.AreEqual(1, this.defHotel.Rooms.Count);
        }

        [TestCase(0)]
        [TestCase(-2)]
        public void BookRoomShouldThrowAnExceptionWhenAdultsAreBelowOrEqualToZero(int adults)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.defHotel.BookRoom(adults, 2, 3, 300);
            });
        }

        [TestCase(-1)]
        [TestCase(-3)]
        public void BookRoomShouldThrowAnExceptionWhenChildrenAreBelowZero(int children)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.defHotel.BookRoom(2, children, 3, 300);
            });
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void BookRoomShouldThrowAnExceptionWhenResidenceDurationIsBelowOne(int residenceDuration)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.defHotel.BookRoom(2, 0, residenceDuration, 300);
            });
        }

        [Test]
        public void BookRoomShouldWorkProperlyWithCorrectData()
        {
            Room firstRoom = new Room(6, 20);
            Room secondRoom = new Room(2, 50);

            this.defHotel.AddRoom(firstRoom);
            this.defHotel.AddRoom(secondRoom);

            this.defHotel.BookRoom(2, 2, 1, 1000);

            Assert.AreEqual(1, this.defHotel.Bookings.Count);
            Assert.AreEqual(1 * 20, this.defHotel.Turnover);
        }

        [Test]
        public void BookRoomShouldNotBookWhenNotEnoughBudget()
        {
            Room firstRoom = new Room(6, 100);
            Room secondRoom = new Room(2, 150);

            this.defHotel.AddRoom(firstRoom);
            this.defHotel.AddRoom(secondRoom);

            this.defHotel.BookRoom(2, 2, 5, 50);

            Assert.AreEqual(0, this.defHotel.Bookings.Count);
        }

        [Test]
        public void BookRoomShouldNotBookWhenNotEnoughBeds()
        {
            Room firstRoom = new Room(2, 100);
            Room secondRoom = new Room(2, 150);

            this.defHotel.AddRoom(firstRoom);
            this.defHotel.AddRoom(secondRoom);

            this.defHotel.BookRoom(2, 2, 5, 50);

            Assert.AreEqual(0, this.defHotel.Bookings.Count);
        }
    }
}