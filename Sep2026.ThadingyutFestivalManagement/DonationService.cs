using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sep2026.ThadingyutFestivalApp
{
    public class DonationService
    {
        public static List<DonationDto> Donations = new List<DonationDto>();

        public void MakeDonation(string no, string name, decimal amount, string place, DateOnly  donationDate )
        {


            //decimal remainingAmount = currentAmount - amount;

            int maxId = Donations.Count == 0 ? 0 : Donations.Max(x => x.Id);
            DonationDto donation = new DonationDto
            {
                Id = maxId + 1,
                DonationNumber = no,
                DonorName = name,
                DonationAmount = amount,
                DonationPlace = place,
                DonationDate = donationDate


            };

            Donations.Add(donation);

            Console.WriteLine("Donation is made successfully!");



        }

       

        public void ShowDonations()
        {
            foreach (var donation in Donations)
            {

                Console.WriteLine($"No: {donation.Id}, Number: {donation.DonationNumber}, Name: {donation.DonorName}, Amount: {donation.DonationAmount}, Place: {donation.DonationPlace}, Date: {donation.DonationDate}");
            }
        }


        public void ViewAllDonationRecords()
        {
            if (Donations.Count == 0)
            {
                Console.WriteLine("No donations found.");
                return;
            }

            Console.WriteLine("\n========== ALL DONATIONS ==========");

            foreach (DonationDto donation in Donations)
            {
                Console.WriteLine($"ID: {donation.Id}");
                Console.WriteLine($"Number: {donation.DonationNumber}");
                Console.WriteLine($"Donor Name: {donation.DonorName}");
                Console.WriteLine($"Amount: {donation.DonationAmount}");
                Console.WriteLine($"Place: {donation.DonationPlace}");
                Console.WriteLine($"Donation Date: {donation.DonationDate:dd/MM/yyyy}");
                Console.WriteLine("-----------------------------------");
            }
        }

     
    }

   

}

