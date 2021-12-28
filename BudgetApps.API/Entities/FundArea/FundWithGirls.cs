using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Attributes;

namespace BudgetApps.API.Entities.FundArea
{

    public class FundWithGirls
    {
        public enum CashSourceDefinition {OnSex = 1, OnSpend = 2, Aside = 3};

        [Identifier]
        public int FuwgId { get; set; }
        public int GId { get; set; }
        public double Value { get; set; }
        public CashSourceDefinition CashSource { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }

        public Girls Girls { get; set; }
    }
}
