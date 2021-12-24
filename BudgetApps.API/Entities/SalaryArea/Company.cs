using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Attributes;

namespace BudgetApps.API.Entities.SalaryArea
{
    public class Company
    {
        [Identifier]
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
