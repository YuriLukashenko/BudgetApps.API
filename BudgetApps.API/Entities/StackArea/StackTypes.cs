using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Attributes;

namespace BudgetApps.API.Entities.StackArea
{
    public class StackTypes
    {
        [Identifier]
        public int StId { get; set; }
        public string Description { get; set; }
    }
}
