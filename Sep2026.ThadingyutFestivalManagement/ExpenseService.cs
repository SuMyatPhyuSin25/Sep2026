using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sep2026.ThadingyutFestivalApp
{
    public class ExpenseService
    {
        public static List<ExpenseDto> Expenses = new List<ExpenseDto>();

        private readonly PocketMoneyService pocketMoneyService =
      new PocketMoneyService();



        public void MakeExpense( decimal amount,  DateOnly expenseDate)
        {
            bool isDeducted =
            pocketMoneyService.DeductPocketMoney(amount);

            if (!isDeducted)
            {
                return;
            }

            int maxId = Expenses.Count == 0 ? 0 : Expenses.Max(x => x.Id);
            ExpenseDto expense = new ExpenseDto
            {
                Id = maxId + 1,
                ExpenseAmount = amount,
                ExpenseDate = expenseDate
                


            };

            Expenses.Add(expense);

            Console.WriteLine("Expense recorded successfully!");
            Console.WriteLine($"Remaining Balance: {PocketMoneyService.Balance:N0} MMK");



        }

        public void ShowAllExpenses()
        {
            foreach (var expense in Expenses)
            {

                Console.WriteLine($"No: {expense.Id}, Amount: {expense.ExpenseAmount},  Date: {expense.ExpenseDate}");
            }
        }


        public void ViewAllExpensesRecords()
        {
            if (Expenses.Count == 0)
            {
                Console.WriteLine("No expenses found.");
                return;
            }

            Console.WriteLine("\n========== ALL EXPENSES ==========");

            foreach (ExpenseDto expense in Expenses)
            {
                Console.WriteLine($"ID: {expense.Id}");
                Console.WriteLine($"Expense amount: {expense.ExpenseAmount}");
                Console.WriteLine($"Expense Date: {expense.ExpenseDate:dd/MM/yyyy}");
                Console.WriteLine("-----------------------------------");
            }
        }
    


}
}
