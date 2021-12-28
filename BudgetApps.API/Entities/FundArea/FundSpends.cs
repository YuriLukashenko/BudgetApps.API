using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Attributes;

namespace BudgetApps.API.Entities.FundArea
{
    public class FundSpends
    {
        [Identifier]
        public int FuseId { get; set; }
        public DateTime Date { get; set; }
        public double Value { get; set; }
        public string Comment { get; set; }
    }
}
