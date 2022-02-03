using BudgetApps.API.DTOs.Flux;
using BudgetApps.API.DTOs.SalaryArea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApps.API.DTOs.Delta
{
    public class DeltaRequest
    {
        public DateTime Date { get; set; }

        public double Value { get; set; }

        public static IEnumerable<DeltaRequest> CreateFrom(IEnumerable<YearProfit> yearProfits)
        {
            return yearProfits.Select(x => new DeltaRequest()
            {
                Date = x.Date,
                Value = x.YearSum
            });
        }

        public static IEnumerable<DeltaRequest> CreateFrom(IEnumerable<MonthProfit> monthProfits)
        {
            return monthProfits.Select(x => new DeltaRequest()
            {
                Date = x.Date,
                Value = x.MonthSum
            });
        }

        public static IEnumerable<DeltaRequest> CreateFrom(IEnumerable<SalaryTotalByMonths> monthSalaries)
        {
            return monthSalaries.Select(x => new DeltaRequest()
            {
                Date = x.Date.Value,
                Value = x.Sum
            });
        }
    }
}
