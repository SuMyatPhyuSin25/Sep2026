using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sep2026.ThadingyutFestivalApp
{
    public class DonationDto
    {
        
        public int Id { get; set; }
        public string DonationNumber { get; set; }

        public string DonorName { get; set; }
        public decimal DonationAmount { get; set; }
        public string DonationPlace { get; set; } = string.Empty;
        public DateOnly DonationDate { get; set; }

    }
}

