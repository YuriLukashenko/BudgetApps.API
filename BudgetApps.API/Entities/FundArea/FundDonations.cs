using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Attributes;

namespace BudgetApps.API.Entities.FundArea
{
    public class FundDonations
    {
        [Identifier]
        public int FudId { get; set; }
        public int FusId { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; }

        public FundSprints FundSprints { get; set; }
    }
}
