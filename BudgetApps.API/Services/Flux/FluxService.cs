using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.DTOs.Flux;
using BudgetApps.API.Entities.FluxArea;
using BudgetApps.API.Helpers.Builders;
using BudgetApps.API.Interfaces;
using BudgetApps.API.ViewModels;
using Dapper;

namespace BudgetApps.API.Services.Flux
{
    public class FluxService : EntityBaseService
    {
        private readonly IConnectionService _connectionService;
        public FluxService(IConnectionService connectionService, QueryBuilder queryBuilder) : base(connectionService, queryBuilder)
        {
            _connectionService = connectionService;
        }

        #region Entities

        public IEnumerable<Entities.FluxArea.Flux> GetFluxes()
        {
            return GetAll<Entities.FluxArea.Flux>();
        }

        public IEnumerable<FluxHistory> GetFluxHistories()
        {
            return GetAll<FluxHistory>();
        }

        public IEnumerable<FluxTypes> GetFluxTypes()
        {
            return GetAll<FluxTypes>();
        }

        #endregion

        public IEnumerable<FluxViewModel> GetFlux2021()
        {
            IEnumerable<FluxViewDTO> response = null;
            using (var connection = _connectionService.Connect())
            {
                connection.Open();

                response = connection.Query<FluxViewDTO>("select * from dbo.flux_2021");
                connection.Close();
            }

            return FluxViewModel.MapFrom(response);
        }
    }
}
