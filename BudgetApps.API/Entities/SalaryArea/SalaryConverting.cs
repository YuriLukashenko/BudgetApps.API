using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Attributes;

namespace BudgetApps.API.Entities.SalaryArea
{
    public class SalaryConverting
    {
        [Identifier]
        public int ScId { get; set; }
        public double Usd { get; set; }
        public DateTime Date { get; set; }
        public double ExRate { get; set; }
    }
}
