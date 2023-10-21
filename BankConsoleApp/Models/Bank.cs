using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BankConsoleApp.Utilities.Exceptions.BankOperationsExceptions;

namespace BankConsoleApp.Models
{
    internal class Bank
    {
        private List<IAccount> accounts;
        public Bank()
        {
            accounts = new List<IAccount>();
        }


        public IAccount CreateAccount()
        {
            int accountId = accounts.Count + 1;
            IAccount account = new Account(accountId);
            accounts.Add(account);
            return account;
        }

        public void DepositMoney(int accountId, decimal amount)
        {
            try
            {
                IAccount account = FindAccount(accountId);
                account.Deposit(amount);
                Console.WriteLine($."{amount:C} Manat pul hesabınıza yatırıldı.");
            }
            catch (InvalidAmountException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (AccountNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Xeta baş verdi. emeliyyatı tekrarlayın.");
            }
        }

        public void WithdrawMoney(int accountId, decimal amount)
        {
            try
            {
                IAccount account = FindAccount(accountId);
                account.Withdraw(amount);
                Console.WriteLine($"{amount:C} Manat pul hesabınızdan çıxarıldı.");
            }
            catch (InvalidAmountException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (AccountNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Xeta baş verdi.emeliyyatı tekrarlayın.");
            }
        }

        public void TransferMoney(int fromAccountId, int toAccountId, decimal amount)
        {
            try
            {
                IAccount fromAccount = FindAccount(fromAccountId);
                IAccount toAccount = FindAccount(toAccountId);
                fromAccount.Withdraw(amount);
                toAccount.Deposit(amount);
                Console.WriteLine($"{amount:C} Manat pul köçürüldü.");
            }
            catch (InvalidAmountException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (AccountNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Xeta baş verdi. emeliyyatı tekrarlayın.");
            }
        }

        public List<IAccount> GetAllAccounts()
        {
            return accounts;
        }

        private IAccount FindAccount(int accountId)
        {
            IAccount account = accounts.Find(a => a.AccountId == accountId);
            if (account == null)
            {
                throw new AccountNotFoundException();
            }
            return account;
        }
    }
}
