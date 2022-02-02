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

    public class YearProfit
    {
        public DateTime Date { get; set; }
        public double YearSum { get; set; }
    }

    public class DeltaResponse
    {
        public string DisplayPeriod { get; set; }

        public double Value { get; set; }
    }
}
