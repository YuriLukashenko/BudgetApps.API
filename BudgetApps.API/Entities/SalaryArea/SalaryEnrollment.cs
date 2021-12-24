using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Attributes;

namespace BudgetApps.API.Entities.SalaryArea
{
    public class SalaryEnrollment
    {
        [Identifier]
        public string SeId { get; set; }
        public DateTime Date { get; set; }
        public int CompanyId { get; set; }

        public Company Company { get; set; }
    }
}
