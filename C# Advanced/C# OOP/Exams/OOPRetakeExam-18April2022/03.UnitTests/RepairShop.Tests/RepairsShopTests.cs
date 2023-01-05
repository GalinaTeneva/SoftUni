using NUnit.Framework;
using System;

namespace RepairShop.Tests
{
    [TestFixture]
    public class Tests
    {
        //public class RepairsShopTests
        //{

        //}

        private Car defaultCar;
        private Garage defaultGarage;

        [SetUp]
        public void SetUp()
        {
            defaultCar = new Car("BMV", 2);
            defaultGarage = new Garage("Garage", 3);
        }

        [Test]
        public void Test_CtorShouldInitializeNameProperly()
        {
            string expectedName = "Garage";

            Garage garage = new Garage(expectedName, 5);

            string actualName = garage.Name;

            Assert.AreEqual(expectedName, actualName);
        }

        [Test]
        public void Test_CtorShouldInitializeMechanicsAvaiableProperly()
        {
            int expectedMechanicsCount = 5;

            Garage garage = new Garage("Garage", expectedMechanicsCount);

            int actualMechanicsCount = garage.MechanicsAvailable;

            Assert.AreEqual(expectedMechanicsCount, actualMechanicsCount);
        }

        [Test]
        public void Test_CtorShouldInitializeCarListProperly()
        {
            int expectedCarsCount = 0;
            int actualCarsCount = this.defaultGarage.CarsInGarage;

            Assert.AreEqual(expectedCarsCount, actualCarsCount);
        }

        [TestCase(null)]
        [TestCase("")]
        public void Test_NameShouldThrowWhenNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Garage garage = new Garage(name, 5);
            }, $"{nameof(name)}, Invalid garage name.");
        }

        [TestCase(-1)]
        [TestCase(-9)]
        public void Test_MechanicsAvailableShouldThrowWhenBelowZero(int mechanics)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Garage garage = new Garage("NewGarage", mechanics);
            });
        }

        [Test]
        public void Test_CarsInGarageShouldReturnProperCount()
        {
            this.defaultGarage.AddCar(defaultCar);
            this.defaultGarage.AddCar(new Car("SecondCar", 3));
            this.defaultGarage.AddCar(new Car("ThirdCar", 1));

            int expectedCount = 3;
            int actualCount = this.defaultGarage.CarsInGarage;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void Test_AddCarShoulChangeCarCountProperly()
        {
            this.defaultGarage.AddCar(defaultCar);

            int expectedCarsCount = 1;
            int actualCarsCount = this.defaultGarage.CarsInGarage;

            Assert.AreEqual(expectedCarsCount, actualCarsCount);
        }

        [Test]
        public void Test_AddCarShoulThrowWhenNoMechanicsAvailable()
        {
            this.defaultGarage.AddCar(defaultCar);
            this.defaultGarage.AddCar(new Car("SecondCar", 3));
            this.defaultGarage.AddCar(new Car("ThirdCar", 1));

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.defaultGarage.AddCar(new Car("FourthCar", 1));
            }, "No mechanic available.");
        }

        [Test]
        public void Test_FixCarShouldChangeFixedCarIssuesToZero()
        {
            this.defaultGarage.AddCar(this.defaultCar);
            this.defaultGarage.FixCar(this.defaultCar.CarModel);

            int expectedResult = 0;
            int actualResult = this.defaultCar.NumberOfIssues;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Test_FixCarShouldReturnWantedCar()
        {
            Car newCar = new Car("NewCar", 1);
            this.defaultGarage.AddCar(newCar);

            Car expectedResult = newCar;
            Car actualResult = this.defaultGarage.FixCar("NewCar");

            Assert.AreSame(expectedResult, actualResult);
        }

        [Test]
        public void Test_FixCarShouldThrowWhenCarDoesNotExist()
        {
            this.defaultGarage.AddCar(this.defaultCar);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.defaultGarage.FixCar("NewCar");
            }, "The car NewCar doesn't exist.");
        }

        [Test]
        public void Test_RemoveFixedCarsShouldDecreaseCarsInGarage()
        {
            this.defaultGarage.AddCar(this.defaultCar);
            this.defaultGarage.AddCar(new Car("NewCar", 1));
            this.defaultGarage.FixCar(this.defaultCar.CarModel);
            this.defaultGarage.RemoveFixedCar();

            int expectedResult = 1;
            int actualResult = this.defaultGarage.CarsInGarage;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Test_RemoveFixedCarsShouldReturnProperFixedCarsCount()
        {
            this.defaultGarage.AddCar(this.defaultCar);
            this.defaultGarage.AddCar(new Car("NewCar", 1));
            this.defaultGarage.FixCar(this.defaultCar.CarModel);
            this.defaultGarage.FixCar("NewCar");

            int expectedResult = 2;
            int actualResult = this.defaultGarage.RemoveFixedCar();

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Test_RemoveFixedCarsShouldThrowWhenThereIsNoCarsToFix()
        {
            this.defaultGarage.AddCar(this.defaultCar);
            this.defaultGarage.AddCar(new Car("NewCar", 1));

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.defaultGarage.RemoveFixedCar();
            }, "No fixed cars available.");
        }

        [Test]
        public void Test_ReportShouldReturnCorrectString()
        {
            this.defaultGarage.AddCar(this.defaultCar);
            this.defaultGarage.AddCar(new Car("NewCar", 1));

            string expectrdResult = "There are 2 which are not fixed: BMV, NewCar.";
            string actualResult = this.defaultGarage.Report();

            Assert.AreEqual(expectrdResult, actualResult);
        }
    }
}