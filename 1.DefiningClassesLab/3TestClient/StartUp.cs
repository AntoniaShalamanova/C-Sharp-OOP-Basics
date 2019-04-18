using System;
using System.Collections.Generic;

namespace BankAccount
{
    public class StartUp
    {
        static Dictionary<int, BankAccount> accounts;

        static void Main(string[] args)
        {
            accounts = new Dictionary<int, BankAccount>();
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] tokens = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string commmand = tokens[0];
                int id = int.Parse(tokens[1]);
                decimal amount = 0;

                switch (commmand)
                {
                    case "Create":
                        Create(id);
                        break;

                    case "Deposit":
                        amount = decimal.Parse(tokens[2]);
                        Deposit(id, amount);
                        break;

                    case "Withdraw":
                        amount = decimal.Parse(tokens[2]);
                        Withdraw(id, amount);
                        break;

                    case "Print":
                        Print(id);
                        break;

                    default:
                        break;
                }

                input = Console.ReadLine();
            }
        }

        private static void Print(int id)
        {
            if (accounts.ContainsKey(id))
            {
                Console.WriteLine(accounts[id]);
            }
            else
            {
                Console.WriteLine("Account does not exist");
            }
        }

        private static void Withdraw(int id, decimal amount)
        {
            if (accounts.ContainsKey(id))
            {
                accounts[id].Withdraw(amount);
            }
            else
            {
                Console.WriteLine("Account does not exist");
            }
        }

        private static void Deposit(int id, decimal amount)
        {
            if (accounts.ContainsKey(id))
            {
                accounts[id].Deposit(amount);
            }
            else
            {
                Console.WriteLine("Account does not exist");
            }
        }

        private static void Create(int id)
        {
            if (accounts.ContainsKey(id))
            {
                Console.WriteLine("Account already exists");
            }
            else
            {

                accounts[id] = new BankAccount(id);
            }
        }
    }
}
