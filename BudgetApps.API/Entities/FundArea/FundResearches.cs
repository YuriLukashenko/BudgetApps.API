using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Attributes;

namespace BudgetApps.API.Entities.FundArea
{
    public class FundResearches
    {
        [Identifier]
        public int FurId { get; set; }
        public double Hours { get; set; }
        public double Rate { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
    }
}
