using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Attributes;

namespace BudgetApps.API.Entities
{
    public class CurrentRate
    {
        [Identifier]
        public int CurrentId { get; set; }
        public DateTime Date { get; set; }
        public double Usd { get; set; }
        public double Eur { get; set; }
        public double Pln { get; set; }
    }
}
