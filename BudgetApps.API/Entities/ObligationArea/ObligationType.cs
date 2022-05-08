using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Attributes;

namespace BudgetApps.API.Entities.ObligationArea
{
    public class ObligationType
    {
        [Identifier]
        public int OtId { get; set; }
        public string Type { get; set; }
    }
}
