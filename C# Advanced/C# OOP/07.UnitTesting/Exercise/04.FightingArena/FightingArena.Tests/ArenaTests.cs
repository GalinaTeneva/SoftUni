namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void SetUp()
        {
            this.arena = new Arena();
        }

        [Test]
        public void ConstructorShouldInitializeWarriorsCollection()
        {
            Arena ctorArena = new Arena();

            Assert.IsNotNull(ctorArena.Warriors);
        }

        [Test]
        public void EnrollingNonExistingWarriorShouldSuccess()
        {
            Warrior warrior = new Warrior("Pesho", 50, 100);

            this.arena.Enroll(warrior);

            bool isEnrolled = this.arena.Warriors.Contains(warrior);

            Assert.IsTrue(isEnrolled);
        }

        [Test]
        public void EnrollingSameWarriorShouldThrowException()

        {
            Warrior warrior = new Warrior("Pesho", 50, 100);

            this.arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() =>
           {
               this.arena.Enroll(warrior);
           }, "Warrior is already enrolled for the fights!");
        }

        [Test]
        public void EnrollingWarriorWithTheSameNameShouldThrowException()
        {
            Warrior firstwarrior = new Warrior("Pesho", 50, 100);
            Warrior secondwarrior = new Warrior("Pesho", 40, 60);

            this.arena.Enroll(firstwarrior);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Enroll(secondwarrior);
            }, "Warrior is already enrolled for the fights!");
        }

        [Test]
        public void CountShouldReturnEnrolledWarriorsCount()
        {
            Warrior firstwarrior = new Warrior("Pesho", 50, 100);
            Warrior secondwarrior = new Warrior("Gosho", 40, 60);

            this.arena.Enroll(firstwarrior);
            this.arena.Enroll(secondwarrior);

            int expectedCount = 2;
            int actualCount = this.arena.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void CountShouldReturnZeroWhenNoWarriorsAreEnrolled()
        {
            int expectedCount = 0;
            int actualCount = this.arena.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void FightShouldThrowExceptionWithNonExistingAttacker()
        {
            Warrior firstwarrior = new Warrior("Pesho", 50, 100);
            Warrior secondwarrior = new Warrior("Gosho", 40, 60);

            this.arena.Enroll(secondwarrior);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Fight(firstwarrior.Name, secondwarrior.Name);
            }, $"There is no fighter with name {firstwarrior.Name} enrolled for the fights!");
        }

        [Test]
        public void FightShouldThrowExceptionWithNonExistingDefender()
        {
            Warrior firstwarrior = new Warrior("Pesho", 50, 100);
            Warrior secondwarrior = new Warrior("Gosho", 40, 60);

            this.arena.Enroll(firstwarrior);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Fight(firstwarrior.Name, secondwarrior.Name);
            }, $"There is no fighter with name {secondwarrior.Name} enrolled for the fights!");
        }

        [Test]
        public void FightShouldSucceedWhenWarriorsExists()
        {
            Warrior firstWarrior = new Warrior("Pesho", 50, 100);
            Warrior secondWarrior = new Warrior("Gosho", 35, 100);

            int firstWarriorExpectedHp = firstWarrior.HP - secondWarrior.Damage;
            int secondWarriorExpectedHp = secondWarrior.HP - firstWarrior.Damage;

            this.arena.Enroll(firstWarrior);
            this.arena.Enroll(secondWarrior);

            this.arena.Fight(firstWarrior.Name, secondWarrior.Name);

            int firstWarriorActualHp = this.arena.Warriors.First(w => w.Name == firstWarrior.Name).HP;
            int secondWarriorActualHp = this.arena.Warriors.First(w => w.Name == secondWarrior.Name).HP;

            Assert.AreEqual(firstWarriorExpectedHp, firstWarriorActualHp);
            Assert.AreEqual(secondWarriorExpectedHp, secondWarriorActualHp);
        }
    }
}
