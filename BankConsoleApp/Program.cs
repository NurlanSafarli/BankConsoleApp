using BankConsoleApp.Models;

namespace BankConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();
            int choice;
          
            

            Console.WriteLine("Xoş gelmisiniz!");
            do
            {
                Console.WriteLine("1. Yeni hesab yarat");
                Console.WriteLine("2. Pul yatır");
                Console.WriteLine("3. Pul çıxart");
                Console.WriteLine("4. Bütün hesabların siyahısı");
                Console.WriteLine("5. Hesablar arası pul köçürme");
                Console.WriteLine("0. Çıxış");
                Console.Write("Seçiminizi daxil edin: ");
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            IAccount account = bank.CreateAccount();
                            Console.WriteLine($"Yeni hesab yaratıldı. Hesab nömresi: {account.AccountId}");
                            break;
                        case 2:
                            Console.Write("Hesab nömresini daxil edin: ");
                            if (int.TryParse(Console.ReadLine(), out int depositAccountId))
                            {
                                Console.Write("Yatırılacaq mebleği daxil edin: ");
                                if (decimal.TryParse(Console.ReadLine(), out decimal depositAmount))
                                {
                                    bank.DepositMoney(depositAccountId, depositAmount);
                                }
                                else
                                {
                                    Console.WriteLine("Yatırılacaq mebleği düzgün daxil edin.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Hesab nömresini düzgün daxil edin.");
                            }
                            break;
                        case 3:
                            Console.Write("Hesab nömresini daxil edin: ");
                            if (int.TryParse(Console.ReadLine(), out int withdrawAccountId))
                            {
                                Console.Write("Çıxarılacaq mebleği daxil edin: ");
                                if (decimal.TryParse(Console.ReadLine(), out decimal withdrawAmount))
                                {
                                    bank.WithdrawMoney(withdrawAccountId, withdrawAmount);
                                }
                                else
                                {
                                    Console.WriteLine("Çıxarılacaq mebleği düzgün daxil edin.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Hesab nömresini düzgün daxil edin.");
                            }
                            break;
                        case 4:
                            List<IAccount> accounts = bank.GetAllAccounts();
                            Console.WriteLine("Bütün hesablar:");
                            foreach (IAccount a in accounts)
                            {
                                Console.WriteLine($"Hesab nömresi: {a.AccountId}, Balans: {a.Balance:C}"+"");
                            }
                            break;
                        case 5:
                            Console.Write("Gönderecek hesab nömresini daxil edin: ");
                            if (int.TryParse(Console.ReadLine(), out int fromAccountId))
                            {
                                Console.Write("Alacaq hesab nömresini daxil edin: ");
                                if (int.TryParse(Console.ReadLine(), out int toAccountId))
                                {
                                    Console.Write("Köçürülecek mebleği daxil edin: ");
                                    if (decimal.TryParse(Console.ReadLine(), out decimal transferAmount))
                                    {
                                        bank.TransferMoney(fromAccountId, toAccountId, transferAmount);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Köçürülecek mebleği düzgün daxil edin.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Alacaq hesab nömresini düzgün daxil edin.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Gönderecek hesab nömresini düzgün daxil edin.");
                            }
                            break;
                        case 0:
                            Console.WriteLine("Çıxış edildi.");
                            break;
                        default:
                            Console.WriteLine("Düzgün bir seçim daxil edin.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Düzgün bir seçim daxil edin.");
                }

            } while (choice != 0);
        }
    }
 }
