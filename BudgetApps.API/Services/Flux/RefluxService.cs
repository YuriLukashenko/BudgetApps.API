using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Entities.RefluxArea;
using BudgetApps.API.Interfaces;

namespace BudgetApps.API.Services.Flux
{
    public class RefluxService : EntityBaseService
    {
        private readonly IConnectionService _connectionService;
        public RefluxService(IConnectionService connectionService) : base(connectionService)
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
