using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Attributes;

namespace BudgetApps.API.Entities.CaseArea
{
    public class Cases
    {
        [Identifier]
        public int CId { get; set; }
        public double Usd { get; set; }
        public double Rate { get; set; }
        public DateTime Date { get; set; }
    }
}
