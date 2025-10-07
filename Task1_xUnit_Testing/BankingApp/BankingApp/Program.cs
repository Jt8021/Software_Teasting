using System;
using System.Collections.Generic;

namespace BankingAppTesting
{
    public class Account
    {
        public string AccountNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Balance { get; set; }

        public Account(string accountNumber, string firstName, string lastName, decimal balance)
        {
            AccountNumber = accountNumber;
            FirstName = firstName;
            LastName = lastName;
            Balance = balance;
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
            Console.WriteLine($"Deposited {amount:C}. New balance: {Balance:C}");
        }

        public void Withdraw(decimal amount)
        {
            if (amount > Balance)
            {
                Console.WriteLine("Insufficient funds!");
            }
            else
            {
                // Introduce bug: Balance is deducted twice
                Balance -= amount;
                Balance -= amount; // Intentional bug
                Console.WriteLine($"Withdrawn {amount:C}. New balance: {Balance:C}");
            }
        }

        public void Transfer(Account receiver, decimal amount)
        {
            if (amount > Balance)
            {
                Console.WriteLine("Insufficient funds for transfer!");
            }
            else
            {
                Balance -= amount;
                receiver.Balance += amount;
                Console.WriteLine($"Transferred {amount:C} to {receiver.FirstName} {receiver.LastName}. Your balance: {Balance:C}");
            }
        }
    }

    public class Program
    {
        private static List<Account> allAccounts = new List<Account>
        {
            new Account("627856", "Susan", "eod", 1000),
            new Account("627846", "James", "edo", 500),
            new Account("627756", "Susan", "ode", 2000)
        };

        public static void Main()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Perform Transfer");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Exit");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        PerformTransfer();
                        break;
                    case "2":
                        PerformDeposit();
                        break;
                    case "3":
                        PerformWithdrawal();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }

        private static void PerformTransfer()
        {
            Console.WriteLine("Enter your account number:");
            string fromAccountNumber = Console.ReadLine();
            Console.WriteLine("Enter the target account number:");
            string toAccountNumber = Console.ReadLine();
            Console.WriteLine("Enter the amount to transfer:");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                Account fromAccount = allAccounts.Find(acc => acc.AccountNumber == fromAccountNumber);
                Account toAccount = allAccounts.Find(acc => acc.AccountNumber == toAccountNumber);

                // Introduce bug: Incorrect condition check causing transfer failure
                if (fromAccount != null && toAccount == null) // Bug: should be && toAccount != null
                {
                    fromAccount.Transfer(toAccount, amount);
                }
                else
                {
                    Console.WriteLine("Invalid account numbers provided.");
                }
            }
            else
            {
                Console.WriteLine("Invalid amount entered.");
            }
        }


        private static void PerformDeposit()
        {
            Console.WriteLine("Enter your account number:");
            string accountNumber = Console.ReadLine();
            Console.WriteLine("Enter the amount to deposit:");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                Account account = allAccounts.Find(acc => acc.AccountNumber == accountNumber);
                if (account != null)
                {
                    account.Deposit(amount);
                }
                else
                {
                    Console.WriteLine("Invalid account number provided.");
                }
            }
            else
            {
                Console.WriteLine("Invalid amount entered.");
            }
        }

        private static void PerformWithdrawal()
        {
            Console.WriteLine("Enter your account number:");
            string accountNumber = Console.ReadLine();
            Console.WriteLine("Enter the amount to withdraw:");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                Account account = allAccounts.Find(acc => acc.AccountNumber == accountNumber);
                if (account != null)
                {
                    account.Withdraw(amount);
                }
                else
                {
                    Console.WriteLine("Invalid account number provided.");
                }
            }
            else
            {
                Console.WriteLine("Invalid amount entered.");
            }
        }
    }
}
