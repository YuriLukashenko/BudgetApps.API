using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Services.ArmyArea;
using BudgetApps.API.Services.FluxArea;
using BudgetApps.API.Services.RefluxArea;

namespace BudgetApps.API.Services
{
    public class CurrentCashService
    {
        private readonly FluxService _fluxService;
        private readonly RefluxService _refluxService;
        private readonly ArmyService _armyService;

        public CurrentCashService(FluxService fluxService, RefluxService refluxService, ArmyService armyService)
        {
            _fluxService = fluxService;
            _refluxService = refluxService;
            _armyService = armyService;
        }

        public double GetCurrentCash()
        {
            var fluxSum = FluxSum();
            var refluxSum = RefluxSum();
            var armySum = ArmySum();

            return armySum;
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

        public double ArmySum()
        {
            var army = _armyService.GetArmies();

            return army.Where(x => x.Date.Year == DateTime.Today.Year)
                .Sum(x => x.Value);
        }
    }
}
