using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Models
{
    internal class Transaction
    {
        public int TransactionId { get; }
        public decimal Amount { get; }
        public DateTime TransactionDate { get; }
        public string TransactionType { get; }

        public Transaction(int transactionId, decimal amount, string transactionType)
        {
            TransactionId = transactionId;
            Amount = amount;
            TransactionDate = DateTime.Now;
            TransactionType = transactionType;
        }

    }
}
