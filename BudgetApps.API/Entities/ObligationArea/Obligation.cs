using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Attributes;

namespace BudgetApps.API.Entities.ObligationArea
{
    public class Obligation
    {
        [Identifier]
        public int OId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Value { get; set; }
        public double Rate { get; set; }
        public int OtId { get; set; }
        public int Percent { get; set; }

        public ObligationType ObligationType { get; set; }
    }
}
