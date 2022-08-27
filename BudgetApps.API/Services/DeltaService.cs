using BudgetApps.API.DTOs;
using BudgetApps.API.DTOs.Delta;
using System;
using System.Collections.Generic;
using BudgetApps.API.Helpers;

namespace BudgetApps.API.Services
{
    public class DeltaService
    {
        public double CalculateDelta(double next, double prev)
        {
            return prev != 0.0 ? (next / prev) - 1.0 : 0.0;
        }

        public IEnumerable<DeltaResponse> EvaluateDelta(IEnumerable<BaseRequest> source, BinDefinition bin) 
        {
            var response = new List<DeltaResponse>();
            BaseRequest prev = null;
            var next = new BaseRequest();

            foreach (var request in source)
            {
                next = request;
                response.Add(new DeltaResponse()
                {
                    DisplayPeriod = FormatManager.DeltaPeriodFormatting(bin, next.Date),
                    Value = prev != null ? CalculateDelta(next.Value, prev.Value) : 0.0
                });
                prev = request;
            }

            return response;
        }
    }
}
