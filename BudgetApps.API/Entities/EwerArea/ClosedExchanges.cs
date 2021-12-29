using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Attributes;

namespace BudgetApps.API.Entities.EwerArea
{
    public class ClosedExchanges
    {
        [Identifier]
        public int CeId { get; set; }
        public int EctId { get; set; }
        public double Value { get; set; }
        public int Year { get; set; }

        public EwerCurrencyTypes EwerCurrencyTypes { get; set; }
    }
}
