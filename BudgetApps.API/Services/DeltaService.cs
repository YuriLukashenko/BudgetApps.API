using BudgetApps.API.DTOs;
using BudgetApps.API.DTOs.Delta;
using System;
using System.Collections.Generic;

namespace BudgetApps.API.Services
{
    public class DeltaService
    {
        public string DeltaPeriodFormatting(BinDefenition bin, DateTime date)
        {
            switch (bin)
            {
                case BinDefenition.Year:
                    return $"{date:yyyy} vs {date.AddYears(-1):yyyy}";
                case BinDefenition.Quarter:
                    return $"{GetQuarterName(date)} vs {GetQuarterName(date.AddMonths(-3))} ({date:yyyy})";
                case BinDefenition.Month:
                    return $"{date:MMM yyyy} vs {date.AddMonths(-1):MMM yyyy}";
                default:
                    return string.Empty;
            }
        }

        public string GetQuarterName(DateTime date)
        {
            return "Q" + (date.Month + 2) / 3;
        }

        public double CalculateDelta(double next, double prev)
        {
            return prev != 0.0 ? (next / prev) - 1.0 : 0.0;
        }

        public IEnumerable<DeltaResponse> EvaluateDelta(IEnumerable<DeltaRequest> source, BinDefenition bin) 
        {
            var response = new List<DeltaResponse>();
            DeltaRequest prev = null;
            var next = new DeltaRequest();

            foreach (var request in source)
            {
                next = request;
                response.Add(new DeltaResponse()
                {
                    DisplayPeriod = DeltaPeriodFormatting(bin, next.Date),
                    Value = prev != null ? CalculateDelta(next.Value, prev.Value) : 0.0
                });
                prev = request;
            }

            return response;
        }
    }
}
