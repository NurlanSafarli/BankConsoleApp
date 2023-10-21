using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Utilities.Exceptions
{
    internal class BankOperationsExceptions : Exception
    {
        public class InsufficientFundsException : Exception
        {
            public InsufficientFundsException() : base("Eziz istifadeçi, hesabınızdakı balans çıxış etmek istediyiniz mebleğden kiçikdir.") { }
        }
        public class AccountNotFoundException : Exception
        {
            public AccountNotFoundException() : base("Daxil etdiyiniz hesab mövcud deyil.") { }
        }
        public class InvalidAmountException : Exception
        {
            public InvalidAmountException() : base("Daxil etdiyiniz mebleğ sıfırdan kiçik ve ya menasızdır.") { }
        }




    }
}
