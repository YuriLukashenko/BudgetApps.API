using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Attributes;

namespace BudgetApps.API.Entities.SalaryArea
{
    public class SalaryBonusTypes
    {
        [Identifier]
        public int SbtId { get; set; }
        public string Name { get; set; }
    }
}
