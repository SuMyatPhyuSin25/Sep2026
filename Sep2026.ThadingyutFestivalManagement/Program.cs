using System;
using System.Globalization;
using System.Numerics;
using System.Transactions;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Sep2026.ThadingyutFestivalApp;


class Program
{

    static void Main(string[] args)
    {
        bool isRunning = true;



        while (isRunning)
        {
            Console.WriteLine(" THADINGYUT FESTIVAL MANAGEMENT");
            Console.WriteLine("====================================");
            Console.WriteLine("1. Donation Management");
            Console.WriteLine("2. Pocket Money Management");
            Console.WriteLine("3. Exit");
            Console.WriteLine("====================================");
            Console.Write("Please select an option: ");
            string option = Console.ReadLine() ?? "";
            switch (option)
            {
                case "1":
                    DonationMenu();

                    break;


                case "2":
                    PocketMoneyMenu();
                    break;


                case "3":
                    isRunning = false;
                    break;
            }


        }


    }

    public static void DonationMenu()
    {

        Console.WriteLine("\n--- DONATION MANAGEMENT ---");
        Console.WriteLine("1. Make Donation");
        Console.WriteLine("2. View All Donation");
        Console.WriteLine("3. Back to main menu");



        Console.Write("Choose an option to manage donation: ");
        string chooseOption = Console.ReadLine() ?? "";


        switch (chooseOption)
        {
            case "1":
                AddDonation();
                break;

            case "2":
                ViewAllDonation();
                break;

            case "3":
                return;


            default:
                break;




        }




    }

    public static void AddDonation()
    {



        Console.Write("Enter Donor Number: ");
        string number = Console.ReadLine();

        Console.Write("Enter Donor Name: ");
        string name = Console.ReadLine();


        //Check current balance before asking for other details



        Console.Write("Enter Donation Amount: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal amount)
      || amount <= 0)
        {
            Console.WriteLine("Invalid donation amount.");
            return;
        }

        decimal currentAmount = CheckBalance(amount);

        if (currentAmount <= 0 || amount > currentAmount)
        {
            return;
        }


        Console.Write("Enter Donation Place: ");
        string place = Console.ReadLine();

        Console.Write("Enter donated Date (dd/MM/yyyy): ");

        string inputDate = Console.ReadLine() ?? "";

        if (DateOnly.TryParseExact(
    inputDate,
    "dd/MM/yyyy",
    CultureInfo.InvariantCulture,
    DateTimeStyles.None,
    out DateOnly donationDate))
        {


            DonationService donationService = new DonationService();
            donationService.MakeDonation(number, name, amount, place, donationDate);
            decimal remainingBalance = currentAmount - amount;
            Console.WriteLine($"Remaining balance: {remainingBalance:N0} MMK");
            donationService.ShowDonations();

            PocketMoneyService pocketMoneyService = new PocketMoneyService();

           

            //if (pocketMoneyService.DeductPocketMoney(amount))
            //{
            //    donationService.MakeDonation(
            //        number, name, amount, place, donationDate);

               
            //}
           

        }
        else
        {
            Console.WriteLine("Invalid date. Please try again.");
        }

    }




    public static decimal CheckBalance(decimal amount)
    {
        Console.Write("Enter your current amount (MMK): ");

        if (!decimal.TryParse(Console.ReadLine(), out decimal currentAmount)
            || currentAmount <= 0)
        {
            Console.WriteLine("Invalid amount or insufficient pocket money.");
            return 0;
        }

        if (amount > currentAmount)
        {
            Console.WriteLine("Insufficient pocket money for this donation.");
            return 0;
        }

        Console.WriteLine($"Current pocket money: {currentAmount:N0} MMK");

        return currentAmount;
    }


    public static void ViewAllDonation()
    {

        DonationService donationService = new DonationService();
        donationService.ViewAllDonationRecords();

    }


    public static void PocketMoneyMenu()
    {
        Console.WriteLine("\n--- Pocket Money MANAGEMENT ---");
        Console.WriteLine("1. Receive Pocket Money");
        Console.WriteLine("2. View Pocket Money Records");
        Console.WriteLine("3. Make Expense");
        Console.WriteLine("4: Check Remaining Balance");
        Console.WriteLine("5. Back to main menu");


        Console.Write("Select an option: ");
        string selectedOption = Console.ReadLine() ?? "";

        switch (selectedOption)
        {
            case "1":
                ReceivePocketMoney();
                break;

            case "2":
                ViewPocketMoneyRecord();
                break;

            case "3":
                AddExpense();
                break;

            case "4":
                PocketMoneyService pocketMoneyService = new PocketMoneyService();
                pocketMoneyService.CheckRemainingBalance();
                break;


            case "5":
                return;

            default:
                break;




        }





    }


    public static void ReceivePocketMoney()
    {

        Console.Write("Enter Giver Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Giver Amount: ");
        decimal.TryParse(Console.ReadLine(), out decimal amount);


        Console.Write("Enter received Date (dd/MM/yyyy): ");

        string inputDate = Console.ReadLine() ?? "";

        if (DateOnly.TryParseExact(
        inputDate,
        "dd/MM/yyyy",
        CultureInfo.InvariantCulture,
        DateTimeStyles.None,
        out DateOnly receivedDate))
        {
            //Console.WriteLine($"Donation Date: {donationDate:dd/MM/yyyy}");
            PocketMoneyService pocketMoneyService = new PocketMoneyService();
            pocketMoneyService.AddPocketMoney(name, amount, receivedDate);
            pocketMoneyService.ShowPocketMoney();


           

        }
        else
        {
            Console.WriteLine("Invalid date. Please try again.");
        }





    }


    public static void ViewPocketMoneyRecord()
    {
        PocketMoneyService pocketMoneyService = new PocketMoneyService();
        pocketMoneyService.ViewAllPocketMoneyRecords();


    }

    public static void AddExpense()
    {

        Console.WriteLine("Enter expense amount: ");
        decimal.TryParse(Console.ReadLine(), out decimal amount);



        Console.Write("Enter Expense Date (dd/MM/yyyy): ");

        string inputDate = Console.ReadLine() ?? "";

        if (DateOnly.TryParseExact(
        inputDate,
        "dd/MM/yyyy",
        CultureInfo.InvariantCulture,
        DateTimeStyles.None,
        out DateOnly expenseDate))
        {
            //Console.WriteLine($"Donation Date: {donationDate:dd/MM/yyyy}");
            ExpenseService expenseService = new ExpenseService();
            expenseService.MakeExpense(amount, expenseDate);

            expenseService.ShowAllExpenses();


        }
        else
        {
            Console.WriteLine("Invalid date. Please try again.");
        }





    }







}
