
namespace Chainblock.Tests
{
    using NUnit.Framework;

    using Contracts;
    using Models;
    using System;
    using System.Reflection;
    using System.Linq;
    using System.Collections.Generic;

    [TestFixture]
    public class ChainblockTests
    {
        private IChainblock chainblock;
        private ITransaction testTransaction;

        [SetUp]
        public void SetUp()
        {
            this.chainblock = new Chainblock();
            this.testTransaction = new Transaction(1, TransactionStatus.Successfull, "Pesho", "Gosho", 1000);
        }

        [Test]
        public void ConstructorShouldInitializeTransactionsCollection()
        {
            Type chainblockType = this.chainblock.GetType();
            FieldInfo transactionsField = chainblockType
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(fi => fi.Name == "transactions");

            object value = transactionsField.GetValue(this.chainblock);
            Assert.IsNotNull(value);
        }

        [Test]
        public void AddShouldAppendTheTransactionToDataCollection()
        {
            this.chainblock.Add(this.testTransaction);

            bool transactionAdded = this.chainblock.Contains(this.testTransaction);
            Assert.IsTrue(transactionAdded);
        }

        [Test]
        public void AddShouldIncreaseCount()
        {
            this.chainblock.Add(this.testTransaction);

            int expectedCount = 1;
            int actualCount = this.chainblock.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddShouldThrowExceptionWhenAddingSameTransaction()
        {
            this.chainblock.Add(this.testTransaction);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.chainblock.Add(this.testTransaction);
            }, "You cannot add already existing transaction!");
        }

        [Test]
        public void AddShouldThrowExceptionWhenAddingExistingId()
        {
            this.chainblock.Add(this.testTransaction);
            ITransaction secondTransaction = new Transaction(this.testTransaction.Id, TransactionStatus.Aborted, "Ivan", "Misho", 500);

            Assert.Throws<InvalidOperationException>(() =>
           {
               this.chainblock.Add(secondTransaction);
           }, "You cannot add already existing transaction!");
        }

        [Test]
        public void ContainsByTransactionShouldReturnTrueWhenExists()
        {
            this.chainblock.Add(this.testTransaction);

            bool transactionExists = this.chainblock.Contains(this.testTransaction);

            Assert.IsTrue(transactionExists);
        }

        [Test]
        public void ContainsByTransactionShouldReturnFalseWhenDoesNotExists()
        {
            bool transactionExists = this.chainblock.Contains(this.testTransaction);

            Assert.IsFalse(transactionExists);
        }

        [Test]
        public void ContainsByIdShouldReturnTrueWhenExists()
        {
            this.chainblock.Add(this.testTransaction);

            bool transactionExists = this.chainblock.Contains(this.testTransaction.Id);

            Assert.IsTrue(transactionExists);
        }

        [Test]
        public void ContainsByIdShouldReturnFalseWhenDoesNotExists()
        {
            bool transactionExists = this.chainblock.Contains(this.testTransaction.Id);

            Assert.IsFalse(transactionExists);
        }

        [Test]
        public void CountShouldReturnZeroWhenNoTrnsactionsAreAdded()
        {
            int expectedCount = 0;
            int actualCount = this.chainblock.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void ChangeTransactionStatusShouldThrowExceptionWithNonExistingId()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.chainblock.ChangeTransactionStatus(1, TransactionStatus.Failed);
            }, "You cannot change the status of a non existing transaction!");
        }

        [Test]
        public void ChangeTransactionStatusShouldChangeStatusIfItIsDifferent()
        {
            this.chainblock.Add(this.testTransaction);

            TransactionStatus expectedStatus = TransactionStatus.Unauthorized;

            this.chainblock.ChangeTransactionStatus(this.testTransaction.Id, expectedStatus);

            ITransaction changedTransaction = this.chainblock.GetById(this.testTransaction.Id);

            TransactionStatus actualStatus = changedTransaction.Status;

            Assert.AreEqual(expectedStatus, actualStatus);
        }

        [Test]
        public void ChangeTransactionStatusShouldRemainStatusIfItIsTheSame()
        {
            this.chainblock.Add(this.testTransaction);

            TransactionStatus expectedStatus = this.testTransaction.Status;

            this.chainblock.ChangeTransactionStatus(this.testTransaction.Id, expectedStatus);

            ITransaction changedTransaction = this.chainblock.GetById(this.testTransaction.Id);

            TransactionStatus actualStatus = changedTransaction.Status;

            Assert.AreEqual(expectedStatus, actualStatus);
        }

        [Test]
        public void GetByIdShouldThrowExceptionWithNonExistingId()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.chainblock.GetById(10);
            }, "Transaction with the provided Id does not exists!");
        }

        [Test]
        public void GetByIdShouldReturnCorrectTransactionWhenExists()
        {
            this.chainblock.Add(this.testTransaction);

            ITransaction actualTransaction = this.chainblock.GetById(this.testTransaction.Id);

            Assert.AreEqual(this.testTransaction, actualTransaction);
        }

        [Test]
        public void RemoveTransactionByIdShouldThrowExceptionWithNonExistingId()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.chainblock.RemoveTransactionById(10);
            }, "You cannot remove non-existing transaction!");
        }

        [Test]
        public void RemoveTransactionByIdShouldRemoveTransactionFromDataCollectionWhenExists()
        {
            this.chainblock.Add(this.testTransaction);

            ITransaction newTransaction = new Transaction(2, TransactionStatus.Failed, "Ivan", "Miro", 600);
            this.chainblock.Add(newTransaction);

            this.chainblock.RemoveTransactionById(newTransaction.Id);

            bool transactionExists = this.chainblock.Contains(newTransaction);

            Assert.IsFalse(transactionExists);
        }

        [Test]
        public void RemoveTransactionByIdShouldDecreaseCountWhenExists()
        {
            this.chainblock.Add(this.testTransaction);

            ITransaction newTransaction = new Transaction(2, TransactionStatus.Failed, "Ivan", "Miro", 600);
            this.chainblock.Add(newTransaction);

            this.chainblock.RemoveTransactionById(newTransaction.Id);

            int expectedCount = 1;
            int actualCount = this.chainblock.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void GetByTransactionStatusShouldThrowExceptionWhenThereAreNoTransactionsAtAll()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.chainblock.GetByTransactionStatus(TransactionStatus.Failed);
            }, "There are no transactions with the provided status!");
        }

        [Test]
        public void GetByTransactionStatusShouldThrowExceptionWhenThereAreNoTransactionsWithGivenStatus()
        {
            this.chainblock.Add(this.testTransaction);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.chainblock.GetByTransactionStatus(TransactionStatus.Aborted);
            }, "There are no transactions with the provided status!");
        }

        [Test]
        public void GetByTransactionStatusShouldReturnOneTransactionWhenThereIsOne()
        {
            ICollection<ITransaction> transactionsToAppend = new HashSet<ITransaction>()
            {
                this.testTransaction,
                new Transaction(2, TransactionStatus.Aborted, "Ivan", "Gosho", 200)
            };

            foreach (ITransaction transaction in transactionsToAppend)
            {
                this.chainblock.Add(transaction);
            }

            TransactionStatus wantedStatus = TransactionStatus.Successfull;
            ICollection<ITransaction> expectedTransactions = transactionsToAppend.Where(tx => tx.Status == wantedStatus).ToArray();
            ICollection<ITransaction> actualTransactions = this.chainblock.GetByTransactionStatus(wantedStatus).ToArray();

            CollectionAssert.AreEqual(expectedTransactions, actualTransactions);
        }

        [Test]
        public void GetByTransactionStatusShouldReturnManyTransactionsOrderedCorrectly()
        {
            ICollection<ITransaction> transactionsToAppend = new HashSet<ITransaction>()
            {
                this.testTransaction,
                new Transaction(2, TransactionStatus.Aborted, "Ivan", "Gosho", 200),
                new Transaction(3, TransactionStatus.Successfull, "Misho", "Pesho", 500),
                new Transaction(4, TransactionStatus.Successfull, "Misho", "Ivan", 100),
            };

            foreach (ITransaction transaction in transactionsToAppend)
            {
                this.chainblock.Add(transaction);
            }

            TransactionStatus wantedStatus = TransactionStatus.Successfull;
            ICollection<ITransaction> expectedTransactions = transactionsToAppend
                .Where(tx => tx.Status == wantedStatus)
                .OrderByDescending(tx => tx.Amount)
                .ToArray();
            ICollection<ITransaction> actualTransactions = this.chainblock.GetByTransactionStatus(wantedStatus).ToArray();

            CollectionAssert.AreEqual(expectedTransactions, actualTransactions);
        }

        [Test]
        public void GetAllSendersWithTransactionStatusShouldThrowExceptionWhenThereAreNoTransactionsAtAll()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Failed);
            }, "There are no transactions with the provided status!");
        }

        [Test]
        public void GetAllSendersWithTransactionStatusShouldThrowExceptionWhenThereAreNoTransactionsWithGivenStatus()
        {
            this.chainblock.Add(this.testTransaction);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Aborted);
            }, "There are no transactions with the provided status!");
        }

        [Test]
        public void GetAllSendersWithTransactionStatusShouldReturnOneNameWhenThereIsOneTransactionWithGivenStatus()
        {
            this.chainblock.Add(this.testTransaction);

            TransactionStatus wantedStatus = this.testTransaction.Status;

            ICollection<string> expectedOutput = new string[] { this.testTransaction.From };
            ICollection<string> actualOutput = this.chainblock.GetAllSendersWithTransactionStatus(wantedStatus).ToArray();

            CollectionAssert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void GetAllSendersWithTransactionStatusShouldReturnManyNamesOrderedWhenThereAreMoreTransactionsWithGivenStatus()
        {
            ICollection<ITransaction> transactionsToAppend = new HashSet<ITransaction>()
            {
                this.testTransaction,
                new Transaction(2, TransactionStatus.Aborted, "Ivan", "Gosho", 200),
                new Transaction(3, TransactionStatus.Successfull, "Marin", "Pesho", 500),
                new Transaction(4, TransactionStatus.Successfull, "Misho", "Manol", 100),
            };

            foreach (ITransaction transaction in transactionsToAppend)
            {
                this.chainblock.Add(transaction);
            }

            TransactionStatus wantedStatus = TransactionStatus.Successfull;

            ICollection<string> expectedOutput = transactionsToAppend
                .Where(tx => tx.Status == wantedStatus)
                .OrderBy(tx => tx.Amount)
                .Select(tx => tx.From)
                .ToArray();
            ICollection<string> actualOutput = this.chainblock
                .GetAllSendersWithTransactionStatus(wantedStatus)
                .ToArray();

            CollectionAssert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void GetAllSendersWithTransactionStatusShouldReturnManyNamesDuplicatedOrderedWhenThereAreMoreTransactionsWithGivenStatus()
        {
            ICollection<ITransaction> transactionsToAppend = new HashSet<ITransaction>()
            {
                this.testTransaction,
                new Transaction(2, TransactionStatus.Aborted, "Ivan", "Gosho", 200),
                new Transaction(3, TransactionStatus.Successfull, "Misho", "Pesho", 500),
                new Transaction(4, TransactionStatus.Successfull, "Misho", "Ivan", 100),
            };

            foreach (ITransaction transaction in transactionsToAppend)
            {
                this.chainblock.Add(transaction);
            }

            TransactionStatus wantedStatus = TransactionStatus.Successfull;

            ICollection<string> expectedOutput = transactionsToAppend
                .Where(tx => tx.Status == wantedStatus)
                .OrderBy(tx => tx.Amount)
                .Select(tx => tx.From)
                .ToArray();
            ICollection<string> actualOutput = this.chainblock
                .GetAllSendersWithTransactionStatus(wantedStatus)
                .ToArray();

            CollectionAssert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void GetAllReceiversWithTransactionStatusShouldThrowExceptionWhenThereAreNoTransactionsAtAll()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Failed);
            }, "There are no transactions with the provided status!");
        }

        [Test]
        public void GetAllReceiversWithTransactionStatusShouldThrowExceptionWhenThereAreNoTransactionsWithGivenStatus()
        {
            this.chainblock.Add(this.testTransaction);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Aborted);
            }, "There are no transactions with the provided status!");
        }

        [Test]
        public void GetAllReceiversWithTransactionStatusShouldReturnOneNameWhenThereIsOneTransactionWithGivenStatus()
        {
            this.chainblock.Add(this.testTransaction);

            TransactionStatus wantedStatus = this.testTransaction.Status;

            ICollection<string> expectedOutput = new string[] { this.testTransaction.To };
            ICollection<string> actualOutput = this.chainblock.GetAllReceiversWithTransactionStatus(wantedStatus).ToArray();

            CollectionAssert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void GetAllReceiversWithTransactionStatusShouldReturnManyNamesOrderedWhenThereAreMoreTransactionsWithGivenStatus()
        {
            ICollection<ITransaction> transactionsToAppend = new HashSet<ITransaction>()
            {
                this.testTransaction,
                new Transaction(2, TransactionStatus.Aborted, "Ivan", "Pesho", 200),
                new Transaction(3, TransactionStatus.Successfull, "Marin", "Pesho", 500),
                new Transaction(4, TransactionStatus.Successfull, "Misho", "Manol", 100),
            };

            foreach (ITransaction transaction in transactionsToAppend)
            {
                this.chainblock.Add(transaction);
            }

            TransactionStatus wantedStatus = TransactionStatus.Successfull;

            ICollection<string> expectedOutput = transactionsToAppend
                .Where(tx => tx.Status == wantedStatus)
                .OrderBy(tx => tx.Amount)
                .Select(tx => tx.To)
                .ToArray();
            ICollection<string> actualOutput = this.chainblock
                .GetAllReceiversWithTransactionStatus(wantedStatus)
                .ToArray();

            CollectionAssert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void GetAllReceiversWithTransactionStatusShouldReturnManyNamesDuplicatedOrderedWhenThereAreMoreTransactionsWithGivenStatus()
        {
            ICollection<ITransaction> transactionsToAppend = new HashSet<ITransaction>()
            {
                this.testTransaction,
                new Transaction(2, TransactionStatus.Aborted, "Ivan", "Gosho", 200),
                new Transaction(3, TransactionStatus.Successfull, "Misho", "Pesho", 500),
                new Transaction(4, TransactionStatus.Successfull, "Misho", "Ivan", 100),
            };

            foreach (ITransaction transaction in transactionsToAppend)
            {
                this.chainblock.Add(transaction);
            }

            TransactionStatus wantedStatus = TransactionStatus.Successfull;

            ICollection<string> expectedOutput = transactionsToAppend
                .Where(tx => tx.Status == wantedStatus)
                .OrderBy(tx => tx.Amount)
                .Select(tx => tx.To)
                .ToArray();
            ICollection<string> actualOutput = this.chainblock
                .GetAllReceiversWithTransactionStatus(wantedStatus)
                .ToArray();

            CollectionAssert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void GetAllOrderedByAmountDescThenByIDShouldReturnEmptyCollectionWhenThereAreNoTransactions()
        {
            ICollection<ITransaction> actualTransactions = this.chainblock
                .GetAllOrderedByAmountDescendingThenById()
                .ToArray();

            CollectionAssert.IsEmpty(actualTransactions);
        }

        [Test]
        public void GetAllOrderedByAmountDescThenByIDShouldReturnManyTransactionsOrderedByAmountDesc()
        {
            ICollection<ITransaction> transactionsToAppend = new HashSet<ITransaction>()
            {
                this.testTransaction,
                new Transaction(2, TransactionStatus.Aborted, "Ivan", "Pesho", 200),
                new Transaction(3, TransactionStatus.Successfull, "Marin", "Pesho", 500),
                new Transaction(4, TransactionStatus.Successfull, "Misho", "Manol", 100),
            };

            foreach (ITransaction transaction in transactionsToAppend)
            {
                this.chainblock.Add(transaction);
            }

            ICollection<ITransaction> expectedOutput = transactionsToAppend
                .OrderByDescending(tx => tx.Amount)
                .ThenBy(tx => tx.Id)
                .ToArray();
            ICollection<ITransaction> actualOutput = this.chainblock
                .GetAllOrderedByAmountDescendingThenById()
                .ToArray();

            CollectionAssert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void GetAllOrderedByAmountDescThenByIDShouldReturnManyTransactionsOrderedByAmountDescThenByIdIfSameAmount()
        {
            ICollection<ITransaction> transactionsToAppend = new HashSet<ITransaction>()
            {
                this.testTransaction,
                new Transaction(3, TransactionStatus.Successfull, "Marin", "Pesho", 200),
                new Transaction(2, TransactionStatus.Aborted, "Ivan", "Pesho", 200),
                new Transaction(4, TransactionStatus.Successfull, "Misho", "Manol", 100),
            };

            foreach (ITransaction transaction in transactionsToAppend)
            {
                this.chainblock.Add(transaction);
            }

            ICollection<ITransaction> expectedOutput = transactionsToAppend
                .OrderByDescending(tx => tx.Amount)
                .ThenBy(tx => tx.Id)
                .ToArray();
            ICollection<ITransaction> actualOutput = this.chainblock
                .GetAllOrderedByAmountDescendingThenById()
                .ToArray();

            CollectionAssert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void GetBySenderOrderedByAmountDescendingShouldThrowExceptionWhenThereAreNoTransactions()
        {
            this.chainblock.Add(this.testTransaction);

            string sender = "Misho";

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.chainblock.GetBySenderOrderedByAmountDescending(sender);
            }, "There are no transactions with the provided sender!");
        }

        [Test]
        public void GetBySenderOrderedByAmountDescendingShouldReturnManyTransactionsOrderedByAmountDesc()
        {
            ICollection<ITransaction> transactionsToAppend = new HashSet<ITransaction>()
            {
                this.testTransaction,
                new Transaction(2, TransactionStatus.Aborted, "Ivan", "Pesho", 200),
                new Transaction(3, TransactionStatus.Successfull, "Marin", "Pesho", 500),
                new Transaction(4, TransactionStatus.Successfull, "Marin", "Manol", 100),
            };

            foreach (ITransaction transaction in transactionsToAppend)
            {
                this.chainblock.Add(transaction);
            }

            string sender = "Marin";

            ICollection<ITransaction> expectedOutput = transactionsToAppend
                .Where(tx => tx.From == sender)
                .OrderByDescending(tx => tx.Amount)
                .ToArray();
            ICollection<ITransaction> actualOutput = this.chainblock
                .GetBySenderOrderedByAmountDescending(sender)
                .ToArray();

            CollectionAssert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenByIdShouldThrowExceptionWhenThereAreNoTransactions()
        {
            this.chainblock.Add(this.testTransaction);

            string receiver = "Misho";

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.chainblock.GetBySenderOrderedByAmountDescending(receiver);
            }, "There are no transactions with the provided receiver!");
        }

        [Test]
        public void GGetByReceiverOrderedByAmountThenByIdShouldReturnManyTransactionsOrderedByAmountDesc()
        {
            ICollection<ITransaction> transactionsToAppend = new HashSet<ITransaction>()
            {
                this.testTransaction,
                new Transaction(2, TransactionStatus.Aborted, "Ivan", "Pesho", 200),
                new Transaction(3, TransactionStatus.Successfull, "Gosho", "Marin", 500),
                new Transaction(4, TransactionStatus.Successfull, "Pesho", "Manol", 100),
            };

            foreach (ITransaction transaction in transactionsToAppend)
            {
                this.chainblock.Add(transaction);
            }

            string receiver = "Marin";

            ICollection<ITransaction> expectedOutput = transactionsToAppend
                .Where(tx => tx.To == receiver)
                .OrderByDescending(tx => tx.Amount)
                .ThenBy(tx => tx.Id)
                .ToArray();
            ICollection<ITransaction> actualOutput = this.chainblock
                .GetByReceiverOrderedByAmountThenById(receiver)
                .ToArray();

            CollectionAssert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmountShouldReturnEmptyCollectionWhenThereAreNoTransactionsWithGivenStatusAndMaxAmount()
        {
            ICollection<ITransaction> transactionsToAppend = new HashSet<ITransaction>()
            {
                this.testTransaction,
                new Transaction(2, TransactionStatus.Aborted, "Ivan", "Pesho", 200),
                new Transaction(3, TransactionStatus.Successfull, "Gosho", "Marin", 500),
                new Transaction(4, TransactionStatus.Successfull, "Pesho", "Manol", 100),
            };

            foreach (ITransaction transaction in transactionsToAppend)
            {
                this.chainblock.Add(transaction);
            }

            TransactionStatus status = TransactionStatus.Failed;
            int maxAmount = 50;

            ICollection<ITransaction> transactions = transactionsToAppend
                .Where(tx => tx.Status == status)
                .TakeWhile(tx => tx.Amount <= maxAmount)
                .OrderByDescending(tx => tx.Amount)
                .ToArray();

            CollectionAssert.IsEmpty(transactions);
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmountShouldReturnEmptyCollectionWithCorrenctGivenStatusButIncorrectGivenMaxAmount()
        {
            ICollection<ITransaction> transactionsToAppend = new HashSet<ITransaction>()
            {
                this.testTransaction,
                new Transaction(2, TransactionStatus.Aborted, "Ivan", "Pesho", 200),
                new Transaction(3, TransactionStatus.Successfull, "Gosho", "Marin", 500),
                new Transaction(4, TransactionStatus.Successfull, "Pesho", "Manol", 100),
            };

            foreach (ITransaction transaction in transactionsToAppend)
            {
                this.chainblock.Add(transaction);
            }

            TransactionStatus status = TransactionStatus.Successfull;
            int maxAmount = 50;

            ICollection<ITransaction> transactions = transactionsToAppend
                .Where(tx => tx.Status == status)
                .TakeWhile(tx => tx.Amount <= maxAmount)
                .OrderByDescending(tx => tx.Amount)
                .ToArray();

            CollectionAssert.IsEmpty(transactions);
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmountShouldReturnEmptyCollectionWithIncorrenctGivenStatusButCorrectGivenMaxAmount()
        {
            ICollection<ITransaction> transactionsToAppend = new HashSet<ITransaction>()
            {
                this.testTransaction,
                new Transaction(2, TransactionStatus.Aborted, "Ivan", "Pesho", 200),
                new Transaction(3, TransactionStatus.Successfull, "Gosho", "Marin", 500),
                new Transaction(4, TransactionStatus.Successfull, "Pesho", "Manol", 100),
            };

            foreach (ITransaction transaction in transactionsToAppend)
            {
                this.chainblock.Add(transaction);
            }

            TransactionStatus status = TransactionStatus.Failed;
            int maxAmount = 500;

            ICollection<ITransaction> transactions = transactionsToAppend
                .Where(tx => tx.Status == status)
                .TakeWhile(tx => tx.Amount <= maxAmount)
                .OrderByDescending(tx => tx.Amount)
                .ToArray();

            CollectionAssert.IsEmpty(transactions);
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmountShouldReturnManyWithGivenStatusAndToMaxAmount()
        {
            ICollection<ITransaction> transactionsToAppend = new HashSet<ITransaction>()
            {
                this.testTransaction,
                new Transaction(2, TransactionStatus.Aborted, "Ivan", "Pesho", 200),
                new Transaction(3, TransactionStatus.Successfull, "Gosho", "Marin", 500),
                new Transaction(4, TransactionStatus.Successfull, "Pesho", "Manol", 100),
            };

            foreach (ITransaction transaction in transactionsToAppend)
            {
                this.chainblock.Add(transaction);
            }

            TransactionStatus status = TransactionStatus.Successfull;
            int maxAmount = 500;

            ICollection<ITransaction> expectedOutput = transactionsToAppend
                .Where(tx => tx.Status == status)
                .TakeWhile(tx => tx.Amount <= maxAmount)
                .OrderByDescending(tx => tx.Amount)
                .ToArray();
            ICollection<ITransaction> actualOutput = this.chainblock
                .GetByTransactionStatusAndMaximumAmount(status, maxAmount)
                .ToArray();

            CollectionAssert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescendingShouldReturnExceptionWhenThereAreNoTransactionsCompliantToBothParams()
        {
            this.chainblock.Add(this.testTransaction);

            string sender = "Marin";
            decimal amount = 50;

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.chainblock.GetBySenderAndMinimumAmountDescending(sender, amount);
            }, "There are no transactions with the provided params!");
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescendingShouldReturnExceptionWhenThereAreNoTransactionsCompliantToSenderParam()
        {
            this.chainblock.Add(this.testTransaction);

            string sender = "Marin";
            decimal amount = 1000;

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.chainblock.GetBySenderAndMinimumAmountDescending(sender, amount);
            }, "There are no transactions with the provided params!");
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescendingShouldReturnExceptionWhenThereAreNoTransactionsCompliantToAmountParam()
        {
            this.chainblock.Add(this.testTransaction);

            string sender = "Pesho";
            decimal amount = 5000;

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.chainblock.GetBySenderAndMinimumAmountDescending(sender, amount);
            }, "There are no transactions with the provided params!");
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescendingShouldReturnAllTransactionsWhenThereAreTransactionsCompliantToBothParams()
        {
            ICollection<ITransaction> transactionsToAppend = new HashSet<ITransaction>()
            {
                this.testTransaction,
                new Transaction(2, TransactionStatus.Aborted, "Ivan", "Pesho", 200),
                new Transaction(3, TransactionStatus.Successfull, "Gosho", "Marin", 500),
                new Transaction(4, TransactionStatus.Successfull, "Pesho", "Manol", 100),
            };

            foreach (ITransaction transaction in transactionsToAppend)
            {
                this.chainblock.Add(transaction);
            }

            string sender = "Pesho";
            decimal amount = 500;

            ICollection<ITransaction> expectedOutput = transactionsToAppend
                .Where(tx => tx.From == sender)
                .TakeWhile(tx => tx.Amount > amount)
                .OrderByDescending(tx => tx.Amount)
                .ToArray();
            ICollection<ITransaction> actualOutput = this.chainblock
                .GetBySenderAndMinimumAmountDescending(sender, amount)
                .ToArray();

            CollectionAssert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void GetByReceiverAndAmountRangeShouldReturnExceptionWhenThereAreNoTransactionsCompliantToReceiverParam()
        {
            string receiver = "Pesho";

            this.chainblock.Add(this.testTransaction);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.chainblock.GetByReceiverAndAmountRange(receiver, 20, 100);
            }, "There are no transactions with the given parameters!");
        }

        [TestCase("Gosho", 70, 80)]
        [TestCase("Gosho", 101, 200)]
        public void GetByReceiverAndAmountRangeShouldReturnExceptionWhenThereAreNoTransactionsInTheGivenAmountRange(string receiver, decimal lo, decimal hi)
        {
            ICollection<ITransaction> transactionsToAppend = new HashSet<ITransaction>()
            {
                this.testTransaction,
                new Transaction(2, TransactionStatus.Aborted, "Ivan", "Gosho", 200),
                new Transaction(3, TransactionStatus.Successfull, "Gosho", "Marin", 500),
                new Transaction(4, TransactionStatus.Successfull, "Pesho", "Gosho", 100),
            };

            foreach (ITransaction transaction in transactionsToAppend)
            {
                this.chainblock.Add(transaction);
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.chainblock
                .GetByReceiverAndAmountRange(receiver, lo, hi)
                .ToArray();
            }, "There are no transactions with the given parameters!");
        }

        [TestCase(70, 300)]
        [TestCase(250, 499)]
        [TestCase(101, 910)]
        public void GetAllInAmountRangeShouldReturnAllTransactionsBetweenGivenAmounts(int lo, int hi)
        {
            ICollection<ITransaction> transactionsToAppend = new HashSet<ITransaction>()
            {
                this.testTransaction,
                new Transaction(2, TransactionStatus.Aborted, "Ivan", "Gosho", 200),
                new Transaction(3, TransactionStatus.Successfull, "Gosho", "Marin", 500),
                new Transaction(4, TransactionStatus.Successfull, "Pesho", "Gosho", 100),
            };

            foreach (ITransaction transaction in transactionsToAppend)
            {
                this.chainblock.Add(transaction);
            }

            ICollection<ITransaction> expectedOutput = transactionsToAppend
                .Where(tx => tx.Amount >= lo && tx.Amount <= hi)
                .ToArray();
            ICollection<ITransaction> actualOutput = this.chainblock
                .GetAllInAmountRange(lo, hi)
                .ToArray();

            CollectionAssert.AreEqual(expectedOutput, actualOutput);
        }

        [TestCase(70, 80)]
        [TestCase(550, 1000)]
        [TestCase(500, 800)]
        public void GetAllInAmountRangeShouldReturnEmptyCollectionWhenThereAreNoTransactionsBetweenGivenAmounts(int lo, int hi)
        {
            ICollection<ITransaction> transactionsToAppend = new HashSet<ITransaction>()
            {
                this.testTransaction,
                new Transaction(2, TransactionStatus.Aborted, "Ivan", "Gosho", 200),
                new Transaction(3, TransactionStatus.Successfull, "Gosho", "Marin", 500),
                new Transaction(4, TransactionStatus.Successfull, "Pesho", "Gosho", 100),
            };

            foreach (ITransaction transaction in transactionsToAppend)
            {
                this.chainblock.Add(transaction);
            }

            ICollection<ITransaction> wantedTransactions = transactionsToAppend
                .Where(tx => tx.Amount > lo && tx.Amount < hi)
                .ToArray();

            CollectionAssert.IsEmpty(wantedTransactions);
        }
    }
}