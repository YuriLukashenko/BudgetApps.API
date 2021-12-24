using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Attributes;

namespace BudgetApps.API.Entities.SalaryArea
{
    public class SalaryFormation
    {
        [Identifier]
        public int SfId { get; set; }
        public string SeId { get; set; }
        public double HoursCount { get; set; }
        public double Rate { get; set; }

        public SalaryEnrollment SalaryEnrollment { get; set; }
    }
}