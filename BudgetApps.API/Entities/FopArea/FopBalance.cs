using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Attributes;

namespace BudgetApps.API.Entities.FopArea
{
    public class FopBalance
    {
        [Identifier]
        public int FopId { get; set; }
        public double Value { get; set; }
        public string Type { get; set; } //Cumulative, Working
    }
}
