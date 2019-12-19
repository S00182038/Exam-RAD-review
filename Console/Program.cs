using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DomainClasses;
using System.Globalization;

namespace ConsoleS00168420
{
    class Program
    {
        private static DataContext customerContext = new DataContext();
        static void Main(string[] args)
        {
            get_transactions();
        }

        /* 
         * get_transactions method asks for the account id and then once provided a correct number, (number > 0) get the transactions from the database. 
         */
        static void get_transactions()
        {
            uint accountID = 0;
            bool isValid = false;

            while (isValid != true)
            {
                Console.Write("Please enter account id: ");
                isValid = uint.TryParse(Console.ReadLine(), out accountID);

                if (!isValid)
                {
                    Console.WriteLine("Wrong number entered! Try Again!\n");
                }                    
            }

            List<Transactions> transactions = customerContext.Transactions.Where(x => x.AccountID == accountID).ToList();

            if (transactions != null && transactions.Count > 0)
            {
                Console.WriteLine($"\nTransactions for account number {accountID}:");
                transactions.ForEach(transaction =>
                {
                    Console.WriteLine($"{transaction.ID} - {transaction.TransactionType.ToString()} of {transaction.Amount.ToString("c2", CultureInfo.GetCultureInfo("en-IE"))} made on {transaction.TransactionDate}");
                });
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("No transactions found for this account!");
                Console.ReadKey();
            }
        }
    }
}
