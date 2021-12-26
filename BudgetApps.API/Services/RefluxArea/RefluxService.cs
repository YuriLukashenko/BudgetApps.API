using System.Collections.Generic;
using BudgetApps.API.Entities.RefluxArea;
using BudgetApps.API.Helpers.Builders;
using BudgetApps.API.Interfaces;

namespace BudgetApps.API.Services.RefluxArea
{
    public class RefluxService : EntityBaseService
    {
        private readonly IConnectionService _connectionService;
        public RefluxService(IConnectionService connectionService, QueryBuilder queryBuilder) : base(connectionService, queryBuilder)
        {
            _connectionService = connectionService;
        }   

        #region Entities

        public IEnumerable<Reflux> GetRefluxes()
        {
            return GetAll<Reflux>();
        }

        public IEnumerable<RefluxHistory> GetRefluxHistories()
        {
            return GetAll<RefluxHistory>();
        }

        public IEnumerable<RefluxTypes> GetRefluxTypes()
        {
            return GetAll<RefluxTypes>();
        }

        #endregion
    }
}
