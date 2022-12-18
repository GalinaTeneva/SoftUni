using NUnit.Framework;
using System;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            private Weapon defWeapon;
            private Planet defPlanet;

            [SetUp]
            public void SetUp()
            {
                defWeapon = new Weapon("Name", 10, 5);
                defPlanet = new Planet("Name", 1000);
            }

            [Test]
            public void Test_WeaponCtorShouldWorkProperly()
            {
                Weapon newWeapon = new Weapon("Weapon", 20, 2);

                Assert.AreEqual("Weapon", newWeapon.Name);
                Assert.AreEqual(20, newWeapon.Price);
                Assert.AreEqual(2, newWeapon.DestructionLevel);
            }

            [Test]
            public void Test_PriceShouldThroeExceptionWhenBelowZero()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Weapon newWeapon = new Weapon("Weapon", -20, 2);
                }, "Price cannot be negative.");
            }

            [Test]
            public void Test_IncreaseDestructionLevel_ShouldIncreaseProperly()
            {
                this.defWeapon.IncreaseDestructionLevel();

                Assert.AreEqual(6, defWeapon.DestructionLevel);
            }

            [Test]
            public void Test_IsNuclear_ShouldBeFalseWhenDestructionLevelIsBelow10()
            {
                Assert.IsFalse(defWeapon.IsNuclear);
            }

            [Test]
            public void Test_IsNuclear_ShouldBeTrueWhenInitializeWeaponWithDestructionLevelAbove10()
            {
                Weapon newWeapon = new Weapon("Weapon", 20, 20);
                Assert.IsTrue(newWeapon.IsNuclear);
            }

            [Test]
            public void Test_IsNuclear_ShouldBeTrueWhenDestructionLevelReaches10()
            {
                Weapon newWeapon = new Weapon("Weapon", 20, 19);
                newWeapon.IncreaseDestructionLevel();
                Assert.IsTrue(newWeapon.IsNuclear);
            }


            [Test]
            public void Test_PlanetCtorShouldWorkProperly()
            {
                Planet newPlanet = new Planet("Planet", 500);

                Assert.AreEqual("Planet", newPlanet.Name);
                Assert.AreEqual(500, newPlanet.Budget);
            }

            [TestCase(null)]
            [TestCase("")]
            public void Test_PlanetNameShouldThrowExceptionWhenNullOrEmpty(string name)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Planet planet = new Planet(name, 600);
                });
            }

            [TestCase(-1)]
            [TestCase(-300)]
            public void Test_PlanetBudgetShouldThrowExceptionWhenNegative(int budget)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Planet planet = new Planet("Planet", budget);
                });
            }

            [Test]
            public void Test_Profit_ShouldIncreaseBudget()
            {
                double amount = 300;

                double expectedResult = this.defPlanet.Budget + amount;

                this.defPlanet.Profit(amount);

                double actualResult = this.defPlanet.Budget;

                Assert.AreEqual(expectedResult, actualResult);
            }

            [Test]
            public void Test_SpendFunds_ShouldDecreaseBudget()
            {
                double amount = 300;

                double expectedResult = this.defPlanet.Budget - amount;

                this.defPlanet.SpendFunds(amount);

                double actualResult = this.defPlanet.Budget;

                Assert.AreEqual(expectedResult, actualResult);
            }

            [Test]
            public void Test_SpendFunds_ShouldThrowExceptionWhenGivenAmountIsBiggerThanTheBudget()
            {
                double amount = 1500;

                Assert.Throws<InvalidOperationException>(() =>
                {
                    this.defPlanet.SpendFunds(amount);
                }, "Not enough funds to finalize the deal.");
            }

            [Test]
            public void Test_AddWeapon_ShouldAddNewWeapon()
            {
                this.defPlanet.AddWeapon(defWeapon);

                Assert.AreEqual(1, this.defPlanet.Weapons.Count);
            }

            [Test]
            public void Test_AddWeapon_ShouldThrowExceptionWhenAddingExistingWeapon()
            {
                this.defPlanet.AddWeapon(defWeapon);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    this.defPlanet.AddWeapon(defWeapon);
                }, $"There is already a {defWeapon.Name} weapon.");
            }

            [Test]
            public void Test_RemoveWeapon_ShouldWorkProperly()
            {
                this.defPlanet.AddWeapon(defWeapon);
                this.defPlanet.RemoveWeapon(defWeapon.Name);

                Assert.AreEqual(0, this.defPlanet.Weapons.Count);
            }

            [Test]
            public void Test_UpgradeWeapon_ShouldWorkProperly()
            {
                this.defPlanet.AddWeapon(this.defWeapon);

                int expectedResult = this.defWeapon.DestructionLevel + 1;

                this.defPlanet.UpgradeWeapon(this.defWeapon.Name);

                int actualResult = this.defWeapon.DestructionLevel;

                Assert.AreEqual(expectedResult, actualResult);
            }

            [Test]
            public void Test_UpgradeWeapon_ShouldThrowExceptionWhenWeaponDoesNotExists()
            {
                Assert.Throws<InvalidOperationException>(() =>
                {
                    this.defPlanet.UpgradeWeapon(this.defWeapon.Name);
                }, $"{this.defWeapon.Name} does not exist in the weapon repository of {this.defPlanet.Name}");
            }

            [Test]
            public void Test_DestructOpponent_ShouldDestroyWeakerOpponet()
            {
                Planet newPlanet = new Planet("New Planet", 2000);

                this.defPlanet.AddWeapon(this.defWeapon);

                string actualResult = this.defPlanet.DestructOpponent(newPlanet);
                string expectedResult = $"{newPlanet.Name} is destructed!";

                Assert.AreEqual(expectedResult, actualResult);
            }

            [Test]
            public void Test_DestructOpponent_ShouldThrowExceptionWhenOpponetIsStronger()
            {
                Planet newPlanet = new Planet("New Planet", 2000);

                newPlanet.AddWeapon(this.defWeapon);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    this.defPlanet.DestructOpponent(newPlanet);
                }, $"{newPlanet.Name} is too strong to declare war to!");
            }
        }
    }
}
