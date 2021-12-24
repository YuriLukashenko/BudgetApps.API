using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Attributes;

namespace BudgetApps.API.Entities.SalaryArea
{
    public class Taxes
    {
        [Identifier]
        public int TaxId { get; set; }
        public string SeId { get; set; }
        public double ExRate { get; set; }
        public DateTime Date { get; set; }

        public SalaryEnrollment SalaryEnrollment { get; set; }
    }
}
