using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            BankSystem bankSystem = new BankSystem();

            while (true)
            {
                Console.WriteLine("\nBank System Menu:");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Display Accounts");
                Console.WriteLine("3. Handle Transactions");
                Console.WriteLine("4. Delete Account");
                Console.WriteLine("5. Search Account");
                Console.WriteLine("6. Exit");

                Console.Write("Choose an option: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        bankSystem.CreateAccount();
                        break;
                    case 2:
                        bankSystem.DisplayAccounts();
                        break;
                    case 3:
                        bankSystem.HandleTransactions();
                        break;
                    case 4:
                        bankSystem.DeleteAccount();
                        break;
                    case 5:
                        bankSystem.SearchAccount();
                        break;
                    case 6:
                        Console.WriteLine("Exiting the system...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }

}
