using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppAssignment7
{
    class Program
    {
        private static readonly Account Account = new Account();

        static void Main(string[] args)
        {
            Account.Balance = 100;

            Console.Write("Pick type of transaction, options \"Deposit\" and \"Withdraw\": ");
            string typeOfTransaction = Console.ReadLine();
            Console.Write("Enter amount: ");
            string amount = Console.ReadLine();

            double balance = 0;

            if (typeOfTransaction != null)
            {
                switch (typeOfTransaction.ToLower())
                {
                    case "deposit":
                        balance = Deposit(Convert.ToDouble(amount));
                        break;
                    case "withdraw":
                        balance = Withdraw(Convert.ToDouble(amount));
                        break;
                }
            }

            Console.WriteLine("Balance: " + balance);
        }

        private static double Deposit(double amount)
        {
            // Does not work in Visual Studio 2017

            //Contract.Requires(amount > 0.0, "Amount should be greater than 0");
            //Contract.Requires<NegativeNumberException>(amount > 0.0, "Amount should be greater than 0");

            double newBalance = Account.Balance;

            if (amount > 0)
            {
                newBalance += amount;
            }
            else
            {
                throw new NegativeNumberException();
            }

            return newBalance;
        }
        private static double Withdraw(double amount)
        {
            // Does not work in Visual Studio 2017

            //Contract.Requires(amount > 0.0, "Amount should be greater than 0");
            //Contract.Requires<NegativeNumberException>(amount > 0.0, "Amount should be greater than 0");
            //Contract.Ensures(Contract.Result<double>() >= 0.0,
            //    "The balance at the end should be greater than or equal to 0");
            //Contract.EnsuresOnThrow<InsufficientFundsException>(Contract.Result<double>() >= 0.0,
            //    "The balance at the end should be greater than or equal to 0");

            double newBalance = Account.Balance;

            if (amount > 0)
            {
                newBalance -= amount;
            }
            else
            {
                throw new NegativeNumberException();
            }
            if (newBalance < 0)
            {
                throw new InsufficientFundsException();
            }

            return newBalance;
        }
    }
}
