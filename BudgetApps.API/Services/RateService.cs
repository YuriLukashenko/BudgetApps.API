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

        #endregion
    }
}
