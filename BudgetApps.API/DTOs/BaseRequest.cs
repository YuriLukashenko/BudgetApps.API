using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.DTOs.Delta;
using BudgetApps.API.DTOs.Flux;
using BudgetApps.API.DTOs.SalaryArea;

namespace BudgetApps.API.DTOs
{
    public class BaseRequest
    {
        public DateTime Date { get; set; }
        public double Value { get; set; }

        public static IEnumerable<BaseRequest> CreateFrom(IEnumerable<YearProfit> yearProfits)
        {
            return yearProfits.Select(x => new BaseRequest()
            {
                Date = x.Date,
                Value = x.YearSum
            });
        }

        public static IEnumerable<BaseRequest> CreateFrom(IEnumerable<MonthProfit> monthProfits)
        {
            return monthProfits.Select(x => new BaseRequest()
            {
                Date = x.Date,
                Value = x.MonthSum
            });
        }

        public static IEnumerable<BaseRequest> CreateFrom(IEnumerable<QuarterProfit> quarterProfits)
        {
            return quarterProfits.Select(x => new BaseRequest()
            {
                Date = x.Date,
                Value = x.QuarterSum
            });
        }

        public static IEnumerable<BaseRequest> CreateFrom(IEnumerable<SalaryTotalByMonths> monthSalaries)
        {
            return monthSalaries.Select(x => new BaseRequest()
            {
                Date = x.Date.Value,
                Value = x.Sum
            });
        }
    }
}
