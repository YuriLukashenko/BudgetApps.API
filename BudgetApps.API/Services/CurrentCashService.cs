using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Services.ArmyArea;
using BudgetApps.API.Services.BetArea;
using BudgetApps.API.Services.CaseArea;
using BudgetApps.API.Services.CreditArea;
using BudgetApps.API.Services.DepositArea;
using BudgetApps.API.Services.EwerArea;
using BudgetApps.API.Services.FluxArea;
using BudgetApps.API.Services.FundArea;
using BudgetApps.API.Services.ObligationArea;
using BudgetApps.API.Services.RefluxArea;

namespace BudgetApps.API.Services
{
    public class CurrentCashService
    {
        private readonly FluxService _fluxService;
        private readonly RefluxService _refluxService;
        private readonly EwerService _ewerService;
        private readonly CaseService _caseService;
        private readonly CreditService _creditService;
        private readonly FundService _fundService;
        private readonly BetService _betService;
        private readonly ArmyService _armyService;
        private readonly DepositService _depositService;
        private readonly ObligationService _obligationService;

        public CurrentCashService(FluxService fluxService, RefluxService refluxService,
            EwerService ewerService, CaseService caseService, 
            CreditService creditService, FundService fundService, 
            BetService betService, ArmyService armyService, 
            DepositService depositService, ObligationService obligationService)
        {
            _fluxService = fluxService;
            _refluxService = refluxService;
            _ewerService = ewerService;
            _caseService = caseService;
            _creditService = creditService;
            _fundService = fundService;
            _betService = betService;
            _armyService = armyService;
            _depositService = depositService;
            _obligationService = obligationService;
        }

        public double GetCurrentCash()
        {
            var fluxSum = FluxSum();
            var refluxSum = RefluxSum();
            var ewerSum = EwerSum();
            var caseSum = CaseSum();
            var creditSum = CreditSum();
            var donationSum = DonationSum();
            var betSum = BetSum();
            var armySum = ArmySum();
            var depositSum = DepositSum();
            var obligationSum = ObligationSum();

            return fluxSum - refluxSum - ewerSum - caseSum - creditSum - donationSum + betSum - armySum - depositSum - obligationSum;
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
            var armies = _armyService.GetArmies();

            return armies.Where(x => x.Date.Year == DateTime.Today.Year)
                .Sum(x => x.Value);
        }

        public double EwerSum()
        {
            var ewers = _ewerService.GetEwerViewByYear(DateTime.Today.Year);

            return ewers.Sum(x => x.InUah);
        }

        public double CaseSum()
        {
            var cases = _caseService.GetCaseViewsByYear(DateTime.Today.Year);

            return cases.Sum(x => x.InUah);
        }

        public double CreditSum() => _creditService.ActiveSum();

        public double DonationSum() => _fundService.DonationSumByYear(DateTime.Today.Year);

        public double BetSum()
        {
            var bets = _betService.GetBetsByYear(DateTime.Today.Year).ToList();

            var outcomeSum = bets.Sum(x => x.Outcome);
            var betSum = bets.Sum(x => x.Bet);
            var commissions = bets.Sum(x => x.Commission);

            return outcomeSum - betSum - commissions;
        }

        public double DepositSum() => _depositService.ActiveSumByCurrency("UAH");

        public double ObligationSum() => _obligationService.ActiveSum();
    }
}
