using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Attributes;

namespace BudgetApps.API.Entities.EwerArea
{
    public class EwerCurrencyTypes
    {
        [Identifier]
        public int EctId { get; set; }
        public string Name { get; set; }
    }
}
