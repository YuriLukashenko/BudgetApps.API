using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Entities.EwerArea;
using BudgetApps.API.Helpers.Builders;
using BudgetApps.API.Interfaces;
using Newtonsoft.Json;

namespace BudgetApps.API.Services.EwerArea
{
    public class EwerService : EntityBaseService
    {
        public EwerService(IConnectionService connectionService, QueryBuilder queryBuilder) : base(connectionService, queryBuilder)
        {
        }

        #region Entities

        public IEnumerable<EwerCurrencyTypes> GetEwerCurrencyTypes()
        {
            return GetAll<EwerCurrencyTypes>();
        }
        public IEnumerable<Ewer> GetEwers()
        {
            return GetAll<Ewer>();
        }
        public IEnumerable<EwerCredit> GetEwerCredits()
        {
            return GetAll<EwerCredit>();
        }

        public IEnumerable<EwerSpend> GetEwerSpends()
        {
            return GetAll<EwerSpend>();
        }

        public IEnumerable<ClosedExchanges> GetClosedExchanges()
        {
            return GetAll<ClosedExchanges>();
        }

        #endregion
    }
}
