using System;
using System.Collections.Generic;
using System.Globalization;

public abstract class Account
{
    private double balance;
    public string AccountNumber { get; set; }
    public string AccountHolder { get; set; }
    public DateTime DateOpened { get; set; }
    public string Pin { get; set; }
    public List<string> TransactionHistory { get; set; }

    public Account(string accountNumber, string accountHolder, DateTime dateOpened, string pin, double initialBalance = 0)
    {
        AccountNumber = accountNumber;
        AccountHolder = accountHolder;
        DateOpened = dateOpened;
        Pin = pin;
        balance = initialBalance;
        TransactionHistory = new List<string>();
    }

    public double Balance
    {
        get { return balance; }
        protected set { balance = value; }
    }

    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            Balance += amount;
            TransactionHistory.Add($"Deposited ${amount}. New balance: ${Balance}.");
        }
        else
        {
            Console.WriteLine("Amount must be greater than zero.");
        }
    }

    public void Withdraw(double amount)
    {
        if (amount > 0 && amount <= Balance)
        {
            Balance -= amount;
            TransactionHistory.Add($"Withdrew ${amount}. New balance: ${Balance}.");
        }
        else
        {
            Console.WriteLine("Invalid withdrawal amount.");
        }
    }

    public void DisplayAccountDetails()
    {
        Console.WriteLine($"Account Number: {AccountNumber}");
        Console.WriteLine($"Account Holder: {AccountHolder}");
        Console.WriteLine($"Balance: ${Balance}");
        Console.WriteLine($"Date Opened: {DateOpened.ToShortDateString()}");
    }

    public void DisplayTransactionHistory()
    {
        Console.WriteLine("Transaction History:");
        foreach (var transaction in TransactionHistory)
        {
            Console.WriteLine(transaction);
        }
    }

    public abstract void CalculateInterest();
}

public class SavingsAccount : Account
{
    private double interestRate;

    public SavingsAccount(string accountNumber, string accountHolder, DateTime dateOpened, string pin, double interestRate, double initialBalance = 0)
        : base(accountNumber, accountHolder, dateOpened, pin, initialBalance)
    {
        this.interestRate = interestRate;
    }

    public override void CalculateInterest()
    {
        double interest = Balance * interestRate / 100;
        Balance += interest;
        TransactionHistory.Add($"Interest added: ${interest}. New balance: ${Balance}.");
    }
}

public class CheckingAccount : Account
{
    public CheckingAccount(string accountNumber, string accountHolder, DateTime dateOpened, string pin, double initialBalance = 0)
        : base(accountNumber, accountHolder, dateOpened, pin, initialBalance)
    {
    }

    public override void CalculateInterest()
    {
        Console.WriteLine("Checking accounts do not earn interest.");
    }
}

public class BankSystem
{
    private List<Account> accounts = new List<Account>();

    public void CreateAccount()
    {
        Console.WriteLine("Enter Account Type (Savings/Checking):");
        string accountType = Console.ReadLine().ToLower();

        Console.WriteLine("Enter Account Number:");
        string accountNumber = Console.ReadLine();

        Console.WriteLine("Enter Account Holder Name:");
        string accountHolder = Console.ReadLine();

        DateTime dateOpened = DateTime.Now;
        bool validDate = false;

        while (!validDate)
        {
            Console.WriteLine("Enter Date Opened (yyyy-mm-dd):");
            string dateInput = Console.ReadLine();
            validDate = TryParseDate(dateInput, out dateOpened);
            if (!validDate)
            {
                Console.WriteLine("Invalid date format. Please use the format yyyy-mm-dd.");
            }
        }

        Console.WriteLine("Enter a 4-digit PIN:");
        string pin = Console.ReadLine();

        if (accountType == "savings")
        {
            Console.WriteLine("Enter Interest Rate:");
            double interestRate = double.Parse(Console.ReadLine());

            accounts.Add(new SavingsAccount(accountNumber, accountHolder, dateOpened, pin, interestRate));
            Console.WriteLine("Savings Account created successfully!");
        }
        else if (accountType == "checking")
        {
            accounts.Add(new CheckingAccount(accountNumber, accountHolder, dateOpened, pin));
            Console.WriteLine("Checking Account created successfully!");
        }
        else
        {
            Console.WriteLine("Invalid account type.");
        }
    }

    private bool TryParseDate(string dateInput, out DateTime date)
    {
        return DateTime.TryParseExact(dateInput, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
    }

    public Account FindAccount(string accountNumber, string pin)
    {
        return accounts.Find(acc => acc.AccountNumber == accountNumber && acc.Pin == pin);
    }

    public void DisplayAccounts()
    {
        if (accounts.Count == 0)
        {
            Console.WriteLine("No accounts available.");
            return;
        }

        foreach (var account in accounts)
        {
            account.DisplayAccountDetails();
        }
    }

    public void HandleTransactions()
    {
        Console.WriteLine("Enter Account Number to access:");
        string accountNumber = Console.ReadLine();

        Console.WriteLine("Enter PIN:");
        string pin = Console.ReadLine();

        var account = FindAccount(accountNumber, pin);

        if (account != null)
        {
            account.DisplayAccountDetails();
            Console.WriteLine("Enter action (Deposit/Withdraw/Interest/Transactions):");
            string action = Console.ReadLine().ToLower();

            if (action == "deposit")
            {
                Console.WriteLine("Enter amount to deposit:");
                double amount = double.Parse(Console.ReadLine());
                account.Deposit(amount);
            }
            else if (action == "withdraw")
            {
                Console.WriteLine("Enter amount to withdraw:");
                double amount = double.Parse(Console.ReadLine());
                account.Withdraw(amount);
            }
            else if (action == "interest")
            {
                account.CalculateInterest();
            }
            else if (action == "transactions")
            {
                account.DisplayTransactionHistory();
            }
            else
            {
                Console.WriteLine("Invalid action.");
            }
        }
        else
        {
            Console.WriteLine("Account not found or incorrect PIN.");
        }
    }

    public void DeleteAccount()
    {
        Console.WriteLine("Enter Account Number to delete:");
        string accountNumber = Console.ReadLine();

        Console.WriteLine("Enter PIN:");
        string pin = Console.ReadLine();

        var account = FindAccount(accountNumber, pin);

        if (account != null)
        {
            accounts.Remove(account);
            Console.WriteLine("Account deleted successfully.");
        }
        else
        {
            Console.WriteLine("Account not found or incorrect PIN.");
        }
    }

    public void SearchAccount()
    {
        Console.WriteLine("Enter Account Number or Account Holder's Name to search:");
        string searchTerm = Console.ReadLine().ToLower();

        var foundAccounts = accounts.FindAll(acc => acc.AccountNumber.ToLower().Contains(searchTerm) || acc.AccountHolder.ToLower().Contains(searchTerm));

        if (foundAccounts.Count == 0)
        {
            Console.WriteLine("No accounts found.");
            return;
        }

        foreach (var account in foundAccounts)
        {
            account.DisplayAccountDetails();
        }
    }
}