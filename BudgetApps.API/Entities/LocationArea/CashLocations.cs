using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Attributes;

namespace BudgetApps.API.Entities.LocationArea
{
    public class CashLocations
    {
        [Identifier]
        public int ClId { get; set; }
        public double Value { get; set; }
        public string LocationName { get; set; }
    }
}
