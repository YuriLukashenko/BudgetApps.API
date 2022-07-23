using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Entities;
using BudgetApps.API.Helpers.Builders;
using BudgetApps.API.Interfaces;

namespace BudgetApps.API.Services
{
    public class RateService : EntityBaseService
    {
        public RateService(IConnectionService connectionService, QueryBuilder queryBuilder) : base(
            connectionService, queryBuilder)
        {
        }

        #region Entities

        public IEnumerable<CurrentRate> GetCurrentRates()
        {
            return GetAll<CurrentRate>();
        }

        public CurrentRate GetLast()
        {
            var currentRates = GetCurrentRates();
            return currentRates.LastOrDefault();
        }

        public double GetRateByName(string name)
        {
            var last = GetLast();
            name = name.ToUpper();
            if (name == "USD") return last.Usd;
            if (name == "EUR") return last.Eur;
            if (name == "PLN") return last.Pln;

            return 1;
        }

        #endregion
    }
}
