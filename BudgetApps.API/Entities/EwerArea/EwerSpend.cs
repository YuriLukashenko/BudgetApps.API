using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Attributes;

namespace BudgetApps.API.Entities.EwerArea
{
    public class EwerSpend
    {
        [Identifier]
        public int EsId { get; set; }
        public int EctId { get; set; }
        public DateTime Date { get; set; }
        public double Value { get; set; }
        public double Rate { get; set; }
        public string Comment { get; set; }

        public EwerCurrencyTypes EwerCurrencyTypes { get; set; }
    }
}
