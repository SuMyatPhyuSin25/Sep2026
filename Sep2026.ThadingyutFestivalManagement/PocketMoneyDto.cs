using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sep2026.ThadingyutFestivalApp
{
    public class PocketMoneyDto
    {
        public int Id { get; set; }
        public string GiverName { get; set; } 
        public decimal ReceivedAmount { get; set; }
        public DateOnly DateReceived { get; set; }
    }
}
