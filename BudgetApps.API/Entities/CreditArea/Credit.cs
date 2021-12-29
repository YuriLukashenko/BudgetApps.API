using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Attributes;

namespace BudgetApps.API.Entities.CreditArea
{
    public class Credit
    {
        [Identifier]
        public int CrId { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Comment { get; set; }
    }
}
