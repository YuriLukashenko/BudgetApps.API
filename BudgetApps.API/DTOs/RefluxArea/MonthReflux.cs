using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApps.API.DTOs.RefluxArea
{
    public class MonthReflux
    {
        public int RId { get; set; }
        public DateTime Date { get; set; }
        public double MonthSum { get; set; }
    }
}
