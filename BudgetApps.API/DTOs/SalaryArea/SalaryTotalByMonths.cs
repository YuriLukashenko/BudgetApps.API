using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApps.API.DTOs.SalaryArea
{
    public class SalaryTotalByMonths
    {
        public string SeId { get; set; }
        public DateTime? Date { get; set; }
        public double Sum { get; set; }
    }
}
