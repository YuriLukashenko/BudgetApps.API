using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Attributes;

namespace BudgetApps.API.Entities.FundArea
{
    public class FundSprints
    {
        [Identifier]
        public int FusId { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public int GId { get; set; }

        public Girls Girls { get; set; }
    }
}
