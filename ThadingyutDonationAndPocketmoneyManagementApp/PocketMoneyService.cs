using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThadingyutDonationAndPocketmoneyManagementApp;

namespace Sep2026.ThadingyutPocketmoneyManagementApp
{
    public class PocketMoneyService
    {
        private readonly List<PocketMoneyDto> PocketMoneys = new();
        private readonly List<ExpenseDto> Expenses = new();


        public decimal Balance { get; private set; } = 0;

        //private bool initialBalanceSet = false;

        public void SetInitialBalance(decimal amount)
        {
            //if (initialBalanceSet)
            //{
            //    Console.WriteLine("Initial balance is already set.");
            //    return;
            //}

            if (amount < 0)
            {
                Console.WriteLine("Invalid amount.");
                return;
            }

            Balance = amount;
            //initialBalanceSet = true;

            Console.WriteLine($"Initial Balance: {Balance:N0} MMK");
        }

        public void AddPocketMoney(
            string name, decimal amount, DateOnly date)
        {


            if (string.IsNullOrWhiteSpace(name) || amount <= 0)
            {
                Console.WriteLine("Invalid pocket money.");
                return;
            }
            int maxId = PocketMoneys.Count == 0 ? 0 : PocketMoneys.Max(x => x.Id);

            PocketMoneyDto money = new PocketMoneyDto
            {
                Id = maxId + 1,
                GiverName = name,
                Amount = amount,
                Date = date
            };

            PocketMoneys.Add(money);

            Balance += amount;

            Console.WriteLine("Pocket money received!");
            CheckBalance();
        }

        public bool DeductBalance(decimal amount)
        {
            if (amount <= 0 || amount > Balance)
            {
                Console.WriteLine("Insufficient balance or invalid amount.");
                return false;
            }

            Balance -= amount;
            return true;
        }

        public void AddExpense(
            string description, decimal amount, DateOnly date)
        {

            int maxId = Expenses.Count == 0 ? 0 : Expenses.Max(x => x.Id);

            if (string.IsNullOrWhiteSpace(description))
            {
                Console.WriteLine("Description is required.");
                return;
            }

            if (!DeductBalance(amount))
            {
                return;
            }

            Expenses.Add(new ExpenseDto
            {
                Id = maxId + 1,
                Description = description,
                Amount = amount,
                Date = date
            });

            Console.WriteLine("Expense recorded!");
            CheckBalance();
        }

        public void ViewPocketMoney()
        {
            Console.WriteLine("\n--- POCKET MONEY RECORDS ---");

            foreach (var money in PocketMoneys)
            {
                Console.WriteLine(
                    $"{money.Id}. {money.GiverName} | " +
                    $"{money.Amount:N0} MMK | {money.Date:dd/MM/yyyy}");
            }
        }

        public void ViewExpenses()
        {
            Console.WriteLine("\n--- EXPENSE RECORDS ---");

            foreach (var expense in Expenses)
            {
                Console.WriteLine(
                    $"{expense.Id}. {expense.Description} | " +
                    $"{expense.Amount:N0} MMK | {expense.Date:dd/MM/yyyy}");
            }
        }

        public void CheckBalance()
        {
            Console.WriteLine($"Current Balance: {Balance:N0} MMK");

            //if(Balance <=0)
            //{
            //    Console.WriteLine("Not enough amount!");
            //    return;
            //}
        }
    }
}
