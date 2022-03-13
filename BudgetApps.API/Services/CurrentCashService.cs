using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Services.FluxArea;
using BudgetApps.API.Services.RefluxArea;

namespace BudgetApps.API.Services
{
    public class CurrentCashService
    {
        private readonly FluxService _fluxService;
        private readonly RefluxService _refluxService;
        public CurrentCashService(FluxService fluxService, RefluxService refluxService)
        {
            _fluxService = fluxService;
            _refluxService = refluxService;
        }

        public double GetCurrentCash()
        {
            var fluxSum = FluxSum();
            var refluxSum = RefluxSum();

            return refluxSum;
        }

        public double FluxSum()
        {
            var fluxes = _fluxService.GetFluxes();
            return fluxes.Sum(x => x.Value);
        }

        public double RefluxSum()
        {
            var refluxes = _refluxService.GetRefluxes();
            return refluxes.Sum(x => x.Value);
        }
    }
}
