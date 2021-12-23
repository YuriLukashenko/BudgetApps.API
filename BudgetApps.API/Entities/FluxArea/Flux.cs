using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApps.API.Entities.FluxArea
{
    public class Flux
    {
        public int FId { get; set; }
        public int FtId { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }

        public FluxTypes FluxTypes { get; set; }
    }
}
