using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.DTOs.Flux;
using BudgetApps.API.Entities.Flux;
using BudgetApps.API.Interfaces;
using Dapper;

namespace BudgetApps.API.Services.Flux
{
    public class FluxService
    {
        private readonly IConnectionService _connectionService;
        public FluxService(IConnectionService connectionService)
        {
            _connectionService = connectionService;
        }

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
