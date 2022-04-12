using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Services.CreditArea;

namespace BudgetApps.API.Services
{
    public class TotalValuesService
    {
        private readonly CurrentCashService _currentCashService;
        private readonly CreditService _creditService;
        public TotalValuesService(CurrentCashService currentCashService, CreditService creditService)
        {
            _currentCashService = currentCashService;
            _creditService = creditService;
            SumUah();
        }

        public double SumUah()
        {
            var currentCash = _currentCashService.GetCurrentCash();
            //fund total
            //fund balance
            var credit = _creditService.ActiveSum();
            //common ewer
            //common ewer credit
            //deposit

            return currentCash + credit;
        }
    }
}
