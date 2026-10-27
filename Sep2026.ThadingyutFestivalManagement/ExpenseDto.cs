using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sep2026.ThadingyutFestivalApp
{
   public class ExpenseDto
    {
        public int Id { get; set; }

        public decimal ExpenseAmount {  get; set; }

        public DateOnly ExpenseDate { get; set; }
    }
}
