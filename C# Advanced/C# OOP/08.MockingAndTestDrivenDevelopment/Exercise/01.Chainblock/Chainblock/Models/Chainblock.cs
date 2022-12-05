
namespace Chainblock.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;

    public class Chainblock : IChainblock
    {
        private ICollection<ITransaction> transactions;

        public Chainblock()
        {
            this.transactions = new HashSet<ITransaction>();
        }

        public int Count => this.transactions.Count;

        public void Add(ITransaction tx)
        {
            if (this.Contains(tx))
            {
                throw new InvalidOperationException("You cannot add already existing transaction!");
            }

            this.transactions.Add(tx);
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            try
            {
                ITransaction transaction = this.GetById(id);

                transaction.Status = newStatus;
            }
            catch (InvalidOperationException)
            {
                throw new ArgumentException("You can not change the status of non existing transaction!");
            }
        }

        public bool Contains(ITransaction tx)
        {
            return this.Contains(tx.Id);
        }

        public bool Contains(int id)
        {
            return this.transactions.Any(tx => tx.Id == id);
        }

        public IEnumerable<ITransaction> GetAllInAmountRange(decimal lo, decimal hi)
        {
            return transactions.Where(tx => tx.Amount > lo && tx.Amount < hi).ToArray();
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            return this.transactions
                .OrderByDescending(tx => tx.Amount)
                .ThenBy(tx => tx.Id)
                .ToArray();
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            ICollection<string> receiversWithGivenStatus = this.transactions
               .Where(tx => tx.Status == status)
               .OrderBy(tx => tx.Amount)
               .Select(tx => tx.To)
               .ToArray();

            if (receiversWithGivenStatus.Count == 0)
            {
                throw new InvalidOperationException("There are no transactions with the provided status!");
            }

            return receiversWithGivenStatus;
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            ICollection<string> sendersWithGivenStatus = this.transactions
                .Where(tx => tx.Status == status)
                .OrderBy(tx => tx.Amount)
                .Select(tx => tx.From)
                .ToArray();

            if (sendersWithGivenStatus.Count == 0)
            {
                throw new InvalidOperationException("There are no transactions with the provided status!");
            }

            return sendersWithGivenStatus;
        }

        public ITransaction GetById(int id)
        {
            ITransaction transaction = this.transactions.FirstOrDefault(tx => tx.Id == id);

            if (transaction == null)
            {
                throw new InvalidOperationException("Transaction with provided id does not exsts!");
            }

            return transaction;
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, decimal lo, decimal hi)
        {
            ICollection<ITransaction> wantedTransactions = this.transactions
                .Where(tx => tx.To == receiver)
                .TakeWhile(tx => tx.Amount >= lo && tx.Amount < hi)
                .OrderByDescending(tx => tx.Amount)
                .ThenBy(tx => tx.Id)
                .ToArray();

            if (wantedTransactions.Count == 0)
            {
                throw new InvalidOperationException("There are no transactions with the given parameters!");
            }

            return wantedTransactions;
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            ICollection<ITransaction> wantedTransactions = this.transactions
                .Where(tx => tx.To == receiver)
                .OrderByDescending(tx => tx.Amount)
                .ThenBy(tx => tx.Id)
                .ToArray();

            if (wantedTransactions.Count == 0)
            {
                throw new InvalidOperationException("There are no transactions with the provided receiver!");
            }

            return wantedTransactions;
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, decimal amount)
        {
            ICollection<ITransaction> wantedTransactions = this.transactions
                .Where(tx => tx.From == sender)
                .TakeWhile(tx => tx.Amount > amount)
                .OrderByDescending(tx => tx.Amount)
                .ToArray();

            if (wantedTransactions.Count == 0)
            {
                throw new InvalidOperationException("There are no transactions with the provided params!");
            }

            return wantedTransactions;
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            ICollection<ITransaction> wantedTransactions = this.transactions
                .Where(tx => tx.From == sender)
                .OrderByDescending(tx => tx.Amount)
                .ToArray();

            if (wantedTransactions.Count == 0)
            {
                throw new InvalidOperationException("There are no transactions with the provided sender!");
            }

            return wantedTransactions;
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            ICollection<ITransaction> wantedTransactions = this.transactions
                .Where(tx => tx.Status == status)
                .OrderByDescending(tx => tx.Amount)
                .ToArray();

            if (wantedTransactions.Count == 0)
            {
                throw new InvalidOperationException("There are no transactions with the provided status!");
            }

            return wantedTransactions;
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, decimal amount)
        {
            return transactions
                .Where(tx => tx.Status == status)
                .TakeWhile(tx => tx.Amount <= amount)
                .OrderByDescending(tx => tx.Amount)
                .ToArray();
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        public void RemoveTransactionById(int id)
        {
            try
            {
                ITransaction transaction = this.GetById(id);

                this.transactions.Remove(transaction);
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException("You cannot remove non-existing transaction!");
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}
