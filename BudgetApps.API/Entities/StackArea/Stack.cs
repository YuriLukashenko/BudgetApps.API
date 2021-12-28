using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Attributes;

namespace BudgetApps.API.Entities.StackArea
{
    public class Stack
    {
        [Identifier]
        public int SId { get; set; }
        public int StId { get; set; }
        public DateTime Date { get; set; }
        public double Value { get; set; }

        public StackTypes StackTypes { get; set; }
    }
}
