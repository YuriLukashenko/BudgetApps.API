using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Attributes;

namespace BudgetApps.API.Entities.FundArea
{
    public class Girls
    {
        [Identifier]
        public int GId { get; set; }
        public string Name { get; set; }
    }
}
