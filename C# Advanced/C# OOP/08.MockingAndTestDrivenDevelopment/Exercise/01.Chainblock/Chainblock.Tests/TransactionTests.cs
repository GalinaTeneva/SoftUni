
namespace Chainblock.Tests
{
    using Contracts;
    using Models;

    using NUnit.Framework;
    using System;

    [TestFixture]
    public class TransactionTests
    {
       [Test]
        public void ConstrustorShouldInitializeIdProperly()
        {
            int expectedId = 1;

            ITransaction transaction = new Transaction(expectedId, TransactionStatus.Successfull, "Pesho", "Gosho", 1000);

            int actualId = transaction.Id;
            Assert.AreEqual(expectedId, actualId);
        }

        [Test]
        public void ConstrustorShouldInitializeStatusProperly()
        {
            TransactionStatus expectedStatus = TransactionStatus.Unauthorized;

            ITransaction transaction = new Transaction(1, expectedStatus, "Pesho", "Gosho", 1000);

            TransactionStatus actualStatus = transaction.Status;

            Assert.AreEqual(expectedStatus, actualStatus);
        }

        [Test]
        public void ConstrustorShouldInitializeSenderProperly()
        {
            string expectedSender = "Pesho";

            ITransaction transaction = new Transaction(1, TransactionStatus.Successfull, expectedSender, "Gosho", 1000);

            string actualSender = transaction.From;

            Assert.AreEqual(expectedSender, actualSender);
        }

        [Test]
        public void ConstrustorShouldInitializeReceiverProperly()
        {
            string expectedReceiver = "Gosho";

            ITransaction transaction = new Transaction(1, TransactionStatus.Successfull, "Pesho", expectedReceiver, 1000);

            string actualReceiver = transaction.To;

            Assert.AreEqual(expectedReceiver, actualReceiver);
        }

        [Test]
        public void ConstrustorShouldInitializeAmountProperly()
        {
            decimal expectedAmount = 1000;

            ITransaction transaction = new Transaction(1, TransactionStatus.Successfull, "Pesho", "Gosho", expectedAmount);

            decimal actualAmount = transaction.Amount;

            Assert.AreEqual(expectedAmount, actualAmount);
        }

        [TestCase(-100)]
        [TestCase(-1)]
        [TestCase(0)]
        public void IDSetterShouldThrowExceptionWithZeroOrNegativeId(int id)
        {
            Assert.Throws<ArgumentException>(() =>
           {
               ITransaction transaction = new Transaction(id, TransactionStatus.Successfull, "Pesho", "Gosho", 1000);
           }, "Id should be a positive number!");
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("        ")]
        public void SenderSetterShouldThrowExceptionWithNullOrWhitespaceString(string sender)
        {
            Assert.Throws<ArgumentException>(() =>
           {
               ITransaction transaction = new Transaction(1, TransactionStatus.Successfull, sender, "Gosho", 1000);

           }, "Sender name cannot be null or whitespace string!");
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("        ")]
        public void ReceiverSetterShouldThrowExceptionWithNullOrWhitespaceString(string receiver)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                ITransaction transaction = new Transaction(1, TransactionStatus.Successfull, "Pesho", receiver, 1000);

           }, "Receiver name cannot be null or whitespace string!");
        }

        [TestCase(-500)]
        [TestCase(-0.0000000001)]
        [TestCase(0)]
        public void IDSetterShouldThrowExceptionWithZeroOrNegativeId(decimal amount)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                ITransaction transaction = new Transaction(1, TransactionStatus.Successfull, "Pesho", "Gosho", amount);
            }, "Amount should be a positive number!");
        }
    }
}
