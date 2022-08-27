using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.DTOs;
using BudgetApps.API.DTOs.Delta;
using BudgetApps.API.DTOs.IndexPeriod;
using BudgetApps.API.Helpers;

namespace BudgetApps.API.Services
{
    public class IndexPeriodService
    {
        public double CalculateIndex(double current, double index)
        {
            return current / index;
        }

        public IEnumerable<IndexResponse> EvaluateIndexPeriod(IEnumerable<BaseRequest> source, BinDefinition bin, DateTime index)
        {
            var indexValue = source.FirstOrDefault(x => x.Date.Year == index.Year && x.Date.Month == index.Month)?.Value;
            if (indexValue is null or 0)
                return null;

            return source.Select(x => new IndexResponse()
            {
                DisplayPeriod = FormatManager.IndexPeriodFormatting(BinDefinition.Month, x.Date, index),
                Value = CalculateIndex(x.Value, indexValue.Value)
            });
        }
    }
}
