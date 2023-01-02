using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Entities.ObligationArea;
using BudgetApps.API.Helpers.Builders;
using BudgetApps.API.Interfaces;

namespace BudgetApps.API.Services.ObligationArea
{
    public class ObligationService : EntityBaseService
    {
        private readonly IConnectionService _connectionService;
        public ObligationService(IConnectionService connectionService, QueryBuilder queryBuilder) : base(connectionService, queryBuilder)
        {
            _connectionService = connectionService;
        }

        #region Entities
        public IEnumerable<ObligationType> GetObligationTypes()
        {
            return GetAll<ObligationType>();
        }

        public IEnumerable<Obligation> GetObligations()
        {
            return GetAll<Obligation>();
        }

        #endregion

        public double ActiveSumByYear(int todayYear)
        {
            var obligations = GetObligations();
            return obligations.Where(x => x.StartDate.Year == todayYear).Sum(x => x.Value);
        }

        public double ActiveSum()
        {
            var obligations = GetObligations();
            return obligations.Sum(x => x.Value);
        }
    }
}
