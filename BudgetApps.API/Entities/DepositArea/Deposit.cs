using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Attributes;
using BudgetApps.API.Entities.EwerArea;

namespace BudgetApps.API.Entities.DepositArea
{
    public class Deposit
    {
        [Identifier]
        public int DId { get; set; }
        public DateTime Date { get; set; }
        public double Value { get; set; }
        public int EctId { get; set; }
        public double Percent { get; set; }
        public double Term { get; set; }
        public bool IsOpen { get; set; }
        public double Rate { get; set; }

        public EwerCurrencyTypes EwerCurrencyTypes { get; set; }
    }
}
