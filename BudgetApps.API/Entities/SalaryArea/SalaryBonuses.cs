using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Attributes;

namespace BudgetApps.API.Entities.SalaryArea
{
    public class SalaryBonuses
    {
        [Identifier]
        public int SbId { get; set; }
        public string SeId { get; set;}
        public int SbtId { get; set; }
        public double UsdValue { get; set; }
        public string Comment { get; set; }

        public SalaryEnrollment SalaryEnrollment { get; set; }
        public SalaryBonusTypes SalaryBonusTypes { get; set; }
    }
}
