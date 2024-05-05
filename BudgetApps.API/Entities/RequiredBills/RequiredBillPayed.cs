using BudgetApps.API.Attributes;
using System;

namespace BudgetApps.API.Entities.RequiredBills
{
    public class RequiredBillPayed
    {
        [Identifier]
        public int RId { get; set; }
        public int CategoryId { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; }
    }
}
