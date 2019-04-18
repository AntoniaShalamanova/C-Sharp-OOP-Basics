using System;
using System.Collections.Generic;

namespace BankAccount
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            BankAccount account1 = new BankAccount(1, 5);
            BankAccount account2 = new BankAccount(2, 7);
            BankAccount account3 = new BankAccount(3, 6);

            List<BankAccount> accounts = new List<BankAccount>() { account1, account2, account3 };

            Person person = new Person("Pesho", 45, accounts);

            Console.WriteLine(person.GetBalance());
        }
    }
}
