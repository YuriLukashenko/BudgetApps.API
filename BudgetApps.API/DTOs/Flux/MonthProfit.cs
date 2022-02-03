using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApps.API.DTOs.Flux
{
    public class MonthProfit
    {
        public DateTime Date { get; set; }
        public double MonthSum { get; set; }
    }

    public class QuarterProfit
    {
        public DateTime Date { get; set; }
        public double QuarterSum { get; set; }
    }

    public class YearProfit
    {
        public DateTime Date { get; set; }
        public double YearSum { get; set; }
    }
}
