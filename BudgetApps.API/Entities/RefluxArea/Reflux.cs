using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApps.API.Entities.RefluxArea
{
    public class Reflux
    {
        public int RId { get; set; }
        public int RtId { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }

        public RefluxTypes RefluxTypes { get; set; }
    }
}
