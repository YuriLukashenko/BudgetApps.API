using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Services.CreditArea;
using BudgetApps.API.Services.DepositArea;
using BudgetApps.API.Services.EwerArea;
using BudgetApps.API.Services.FundArea;

namespace BudgetApps.API.Services
{
    public class TotalValuesService
    {
        private readonly CurrentCashService _currentCashService;
        private readonly CreditService _creditService;
        private readonly DepositService _depositService;
        private readonly FundService _fundService;
        private readonly EwerService _ewerService;
        public TotalValuesService(CurrentCashService currentCashService, CreditService creditService,
            DepositService depositService, FundService fundService,
            EwerService ewerService)
        {
            _currentCashService = currentCashService;
            _creditService = creditService;
            _depositService = depositService;
            _fundService = fundService;
            _ewerService = ewerService;
        }

        public double GetTotalUah()
        {
            var currentCash = _currentCashService.GetCurrentCash();
            var fundTotal = _fundService.FundTotal();
            var fundBalance = _fundService.FundBalance();
            var credit = _creditService.ActiveSum();
            var commonEwerUah = _ewerService.CommonEwerUah();
            var commonEwerCredit = _ewerService.CommonEwerCreditUah();
            var deposit = _depositService.ActiveSumByYear(DateTime.Today.Year);

            return currentCash + fundTotal + fundBalance + credit + commonEwerUah + commonEwerCredit + deposit;
        }
    }
}
