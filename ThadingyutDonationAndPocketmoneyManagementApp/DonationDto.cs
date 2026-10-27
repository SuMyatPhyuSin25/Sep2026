using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThadingyutDonationAndPocketmoneyManagementApp
{
    public class DonationDto
    {
        public int Id { get; set; }

        public string No { get; set; }
        public string DonorName { get; set; }
        public decimal Amount { get; set; }
        public string Place { get; set; } 
        public DateOnly Date { get; set; }
        public bool IsPersonal { get; set; }

    }
}
