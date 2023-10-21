using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BankConsoleApp.Utilities.Exceptions.BankOperationsExceptions;

namespace BankConsoleApp.Models
{
    internal class Account :IAccount
    {
        public int AccountId { get; }
        public decimal Balance { get; private set; }
        private List<Transaction> transactions;

        public string Username => throw new NotImplementedException();

        public string Environment => throw new NotImplementedException();

        public AccountId HomeAccountId => throw new NotImplementedException();
        public Account(int accountId)
        {
            AccountId = accountId;
            Balance = 0;
            transactions = new List<Transaction>();
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new InvalidAmountException();
            }

            Balance += amount;
            transactions.Add(new Transaction(transactions.Count + 1, amount, "Deposit"));
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new InvalidAmountException();
            }

            if (Balance < amount)
            {
                throw new InsufficientFundsException();
            }

            Balance -= amount;
            transactions.Add(new Transaction(transactions.Count + 1, amount, "Withdraw"));
        }
    }
}
