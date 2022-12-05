
namespace Chainblock.Models
{
    using System;

    using Contracts;

    public class Transaction : ITransaction
    {
        private int id;
        private string from;
        private string to;
        private decimal amount;

        public Transaction(int id, TransactionStatus status, string from, string to, decimal amount)
        {
            this.Id = id;
            this.Status = status;
            this.From = from;
            this.To = to;
            this.Amount = amount;
        }

        public int Id
        {
            get { return this.id; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Id should be a positive number!");
                }

                this.id = value;
            }
        }

        public TransactionStatus Status { get; set; }

        public string From
        {
            get { return this.from; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Sender name cannot be null or whitespace string!");
                }

                this.from = value;
            }
        }

        public string To
        {
            get { return this.to; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Receiver name cannot be null or whitespace string!");
                }

                this.to = value;
            }
        }

        public decimal Amount
        {
            get { return this.amount; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Amount should be a positive number!");
                }

                this.amount = value;
            }
        }
    }
}
