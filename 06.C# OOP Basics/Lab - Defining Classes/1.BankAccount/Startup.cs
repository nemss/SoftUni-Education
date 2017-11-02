using System.Dynamic;

namespace _1.BankAccount
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            var accounts = new Dictionary<int, BankAccount>();

            string input;
            while (!(input = Console.ReadLine()).Equals("End"))
            {
                var commandArguments = input.Split();
                var command = commandArguments[0];

                switch (command)
                {
                    case "Create":
                        Create(commandArguments, accounts);
                        break;
                    case "Deposit":
                        Deposit(commandArguments, accounts);
                        break;
                    case "Withdraw":
                        Withdraw(commandArguments, accounts);
                        break;
                    case "Print":
                        Print(commandArguments, accounts);
                        break;;
                }
            }


        }

        private static void Print(string[] commandArguments, Dictionary<int, BankAccount> accounts)
        {
            var id = int.Parse(commandArguments[1]);
            if (accounts.ContainsKey(id))
            {
                Console.WriteLine(accounts[id].ToString());
            }
            else
            {
                Console.WriteLine("Account does not exist");
            }

        }

        private static void Withdraw(string[] commandArguments, Dictionary<int, BankAccount> accounts)
        {
            var id = int.Parse(commandArguments[1]);
            var amount = double.Parse(commandArguments[2]);

            if (accounts.ContainsKey(id))
            {
                if (accounts[id].Balance < amount)
                {
                    Console.WriteLine("Insufficient balance");
                }
                else
                {
                    accounts[id].Withdraw(amount);

                }
            }
            else
            {
                Console.WriteLine("Account does not exist");
            }
        }

        private static void Deposit(string[] commandArguments, Dictionary<int, BankAccount> accounts)
        {
            var id = int.Parse(commandArguments[1]);
            var amount = double.Parse(commandArguments[2]);

            if (accounts.ContainsKey(id))
            {
                accounts[id].Deposit(amount);
            }
            else
            {
                Console.WriteLine("Account does not exist");
            }

        }

        private static void Create(string[] commandArguments, Dictionary<int, BankAccount> accounts)
        {
            var id = int.Parse(commandArguments[1]);
            if (accounts.ContainsKey(id))
            {
                Console.WriteLine("Account already exists");
            }
            else
            {
                var acc = new BankAccount();
                acc.ID = id;
                accounts.Add(id, acc);
            }
        }
    }
}
