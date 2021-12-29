using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Attributes;

namespace BudgetApps.API.Entities.LocationArea
{
    public class CashLocationsMiniDebts
    {
        [Identifier]
        public int ClmdId { get; set; }
        public double Value { get; set; }
    }
}
