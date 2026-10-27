using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sep2026.ThadingyutFestivalApp
{
  public class PocketMoneyService
    {
        public static List<PocketMoneyDto> PocketMoneys = new List<PocketMoneyDto>();
        public static decimal Balance { get; private set; } = 0;

        public void AddPocketMoney( string name, decimal amount, DateOnly receivedDate)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Amount must be greater than zero.");
                return;
            }

            int maxId = PocketMoneys.Count == 0 ? 0 : PocketMoneys.Max(x => x.Id);
            PocketMoneyDto pocketMoney = new PocketMoneyDto
            {
                Id = maxId + 1,
                GiverName = name,
                ReceivedAmount = amount,
                DateReceived = receivedDate


            };

            
            PocketMoneys.Add(pocketMoney);
            Balance += amount;

            Console.Write($"You got new Pocket money! ");
            //Console.WriteLine($"Current Balance: {Balance:N0} MMK");
            CheckRemainingBalance();



        }

        public bool DeductPocketMoney(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Expense must be greater than zero.");
                return false;
            }

            if (amount > Balance)
            {
                Console.WriteLine("Insufficient pocket money!");
                return false;
            }

            Balance -= amount;
            return true;
        }

        public void CheckRemainingBalance()
        {
            Console.WriteLine("========== REMAINING BALANCE ==========");
            Console.WriteLine($"Remaining Pocket Money: {Balance:N0} MMK");
            Console.WriteLine("=======================================");
        }

        public void ShowPocketMoney()
        {
            foreach (var pocketMoney in PocketMoneys)
            {

                Console.WriteLine($"Id: {pocketMoney.Id}, Number: {pocketMoney.GiverName}, Amount: {pocketMoney.ReceivedAmount}, Date: {pocketMoney.DateReceived}");
            }
        }


        public void ViewAllPocketMoneyRecords()
        {
            if (PocketMoneys.Count == 0)
            {
                Console.WriteLine("No pocket money is found.");
                return;
            }

            Console.WriteLine("\n========== Pocket Money Records ==========");

            foreach (PocketMoneyDto pocketMoney in PocketMoneys)
            {
                Console.WriteLine($"ID: {pocketMoney.Id}");
       
                Console.WriteLine($"Giver Name: {pocketMoney.GiverName}");
                Console.WriteLine($"Amount: {pocketMoney.ReceivedAmount:N0} MMK");
             
                Console.WriteLine($"Donation Date: {pocketMoney.DateReceived:dd/MM/yyyy}");
                Console.WriteLine("-----------------------------------");
            }
        }

    }
}
