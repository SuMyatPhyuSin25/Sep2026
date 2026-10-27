
using System;
using System.Globalization;
using System.Numerics;
using System.Transactions;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Sep2026.ThadingyutPocketmoneyManagementApp;


class Program
{
    
     
    static PocketMoneyService pocketMoneyService = new();
    static DonationService donationService = new();

    static void Main(string[] args)
    {

 

        while (true)
        {
            Console.WriteLine("\n===== THADINGYUT FESTIVAL =====");
            Console.WriteLine("1. Donation Management");
            Console.WriteLine("2. Pocket Money Management");
            Console.WriteLine("3. Expense Management");
            Console.WriteLine("4. Check Balance");
            Console.WriteLine("5. Exit");
            Console.Write("Choose: ");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    DonationMenu();
                    break;

                case "2":
                    PocketMoneyMenu();
                    break;

                case "3":
                    ExpenseMenu();
                    break;

                case "4":
                    pocketMoneyService.CheckBalance();
                    break;

                case "5":
                    return;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    static void DonationMenu()
    {
        while (true)
        {
            Console.WriteLine("\n--- DONATION MANAGEMENT ---");
            Console.WriteLine("1. Make Personal Donation");
            Console.WriteLine("2. Others Donation");
            Console.WriteLine("3. View Donations");
            Console.WriteLine("4. Back");
            Console.Write("Choose: ");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    AddDonation(true);
                    break;

                case "2":
                    AddDonation(false);
                    break;

                case "3":
                    donationService.ViewDonations();
                    break;

                case "4":
                    return;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    static void PocketMoneyMenu()
    {
        while (true)
        {
            Console.WriteLine("\n--- POCKET MONEY MANAGEMENT ---");
          
            Console.WriteLine("1. Receive Pocket Money");
            Console.WriteLine("2. View Pocket Money");
            Console.WriteLine("3. Back");
            Console.Write("Choose: ");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                //case "1":
                //    decimal balance = ReadPositiveAmount(
                //        "Enter Initial Balance: ");

                //    pocketMoneyService.SetInitialBalance(balance);
                //    break;

                case "1":
                    AddPocketMoney();
                    break;

                case "2":
                    pocketMoneyService.ViewPocketMoney();
                    break;

                case "3":
                    return;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    static void ExpenseMenu()
    {
        while (true)
        {
            Console.WriteLine("\n--- EXPENSE MANAGEMENT ---");
            Console.WriteLine("1. Add Expense");
            Console.WriteLine("2. View Expenses");
            Console.WriteLine("3. Back");
            Console.Write("Choose: ");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    AddExpense();
                    break;

                case "2":
                    pocketMoneyService.ViewExpenses();
                    break;

                case "3":
                    return;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    static void AddDonation(bool isPersonal)
    {
        string name;

        Console.Write("Enter your initial current amount: ");

        

     
        if (isPersonal)
        {

            if (decimal.TryParse(Console.ReadLine(), out decimal initialAmount)
        && initialAmount >= 0)
            {
                pocketMoneyService.SetInitialBalance(initialAmount);
                //Console.WriteLine("Initial balance saved successfully!");
            }
            else
            {
                Console.WriteLine("Invalid amount. Please restart and try again.");
                return;
            }

            Console.WriteLine("Enter donation number: ");
            string number = Console.ReadLine();


            Console.Write("Enter  Name: ");
               name = Console.ReadLine() ?? "";

            decimal amount = ReadPositiveAmount(
        "Enter Donation Amount: ");



            if (isPersonal && amount > pocketMoneyService.Balance)
            {
                Console.WriteLine("Insufficient balance!");
                return;
            }

            if (amount > initialAmount)
            {
                Console.WriteLine("Insufficient balance!");
                return;

            }

            Console.Write("Enter Donation Place: ");

            string place = Console.ReadLine() ?? "";

            DateOnly date = ReadDate(
                "Enter Donation Date (dd/MM/yyyy): ");

            donationService.AddDonation(
                number,
                name,
                amount,
                place,
                date,
                isPersonal,
                pocketMoneyService);


        }
        else
        {
            Console.Write("Enter your initial current amount: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal initialAmount)
          && initialAmount >= 0)
            {
                
                Console.WriteLine("Initial balance saved successfully!");
            }
            else
            {
                Console.WriteLine("Invalid amount. Please restart and try again.");
                return;

            }

            Console.WriteLine("Enter donation number: ");
            string number = Console.ReadLine();


            Console.Write("Enter Donor Name: ");
            name = Console.ReadLine() ?? "";

            decimal amount = ReadPositiveAmount(
          "Enter Donation Amount: ");



            if (isPersonal && amount > pocketMoneyService.Balance)
            {
                Console.WriteLine("Insufficient balance!");
                return;
            }

            if (amount > initialAmount)
            {
                Console.WriteLine("Insufficient balance!");
                return;

            }

            Console.Write("Enter Donation Place: ");

            string place = Console.ReadLine() ?? "";

            DateOnly date = ReadDate(
                "Enter Donation Date (dd/MM/yyyy): ");

            donationService.AddDonation(
                number,
                name,
            
                amount,
                place,
                date,
                isPersonal,
                pocketMoneyService);

        }

      
      


    }

   


    


    static void AddPocketMoney()
    {
        Console.Write("Enter Giver Name: ");
        string name = Console.ReadLine() ?? "";

        decimal amount = ReadPositiveAmount(
            "Enter Received Amount: ");

        DateOnly date = ReadDate(
            "Enter Received Date (dd/MM/yyyy): ");

        pocketMoneyService.AddPocketMoney(name, amount, date);
    }

    static void AddExpense()
    {

        Console.Write("Enter your initial current amount: ");


        if (decimal.TryParse(Console.ReadLine(), out decimal initialAmount)
        && initialAmount >= 0)
        {
            pocketMoneyService.SetInitialBalance(initialAmount);
            //Console.WriteLine("Initial balance saved successfully!");
        }




        if (pocketMoneyService.Balance > 0)
        {
            pocketMoneyService.CheckBalance();


        }


        Console.Write("Enter Expense Description: ");
        string description = Console.ReadLine() ?? "";

        decimal amount = ReadPositiveAmount(
            "Enter Expense Amount: ");

        if(amount > initialAmount)
        {
            Console.WriteLine("Insufficient balance!");
            return;
        }

        DateOnly date = ReadDate(
            "Enter Expense Date (dd/MM/yyyy): ");

        pocketMoneyService.AddExpense(description, amount, date);
    }

    static decimal ReadPositiveAmount(string message)
    {
        while (true)
        {
            Console.Write(message);

            if (decimal.TryParse(Console.ReadLine(), out decimal amount)
                && amount > 0)
            {
                return amount;
            }

            Console.WriteLine("Enter a valid positive amount.");
        }
    }

 
    static DateOnly ReadDate(string message)
    {
        while (true)
        {
            Console.Write(message);

            string input = Console.ReadLine() ?? "";

            if (DateOnly.TryParseExact(
                input,
                "dd/MM/yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateOnly date))
            {
                return date;
            }

            Console.WriteLine(
                "Invalid date.");
        }
    }
}
