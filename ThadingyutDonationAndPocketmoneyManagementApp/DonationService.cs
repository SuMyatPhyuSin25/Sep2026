using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThadingyutDonationAndPocketmoneyManagementApp;

namespace Sep2026.ThadingyutPocketmoneyManagementApp
{
    public class DonationService
    {
        private readonly List<DonationDto> Donations = new();//new->creating empty list

        //private -> Only methods inside DonationService can directly access this list.
        //readonly-> Cannot assign a different list to Donations after initialization, but can add items or remove items to it.


        public static decimal Balance { get; private set; } = 0;

        public void AddDonation(
            string no,
            string name,
            decimal amount,
            string place,
            DateOnly date,
            bool isPersonal,
            PocketMoneyService pocketMoneyService)
        {

            int maxId = Donations.Count == 0 ? 0 : Donations.Max(x => x.Id);

            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(place) ||
                amount <= 0)
            {
                Console.WriteLine("Invalid donation details.");
                return;
            }

            if (isPersonal)
            {
                if (!pocketMoneyService.DeductBalance(amount))
                {
                    Console.WriteLine("Donation cancelled.");
                    return;
                }
            }

            DonationDto donation = new DonationDto
            {
                Id = maxId + 1,
                No = no,
                DonorName = name,
                Amount = amount,
                Place = place,
                Date = date,
                IsPersonal = isPersonal
            };

            Donations.Add(donation);

            Console.WriteLine("Donation recorded successfully!");

            if (isPersonal)
            {

                pocketMoneyService.CheckBalance();
            }

           

            
        }

        public void ViewDonations()
        {
            Console.WriteLine("\n--- DONATION RECORDS ---");

            foreach (var donation in Donations)
            {
                string type = donation.IsPersonal
                    ? "Personal"
                    : "External";

                Console.WriteLine(
                    $"{donation.Id}. {donation.DonorName} | " +
                    $"{type} | {donation.Amount:N0} MMK | " +
                    $"{donation.Place} | " +
                    $"{donation.Date:dd/MM/yyyy}");
            }
        }

      




    }


}
