using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Services.CreditArea;
using BudgetApps.API.Services.DepositArea;
using BudgetApps.API.Services.EwerArea;
using BudgetApps.API.Services.FopArea;
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
        private readonly RateService _rateService;
        private readonly FopService _fopService;
        public TotalValuesService(CurrentCashService currentCashService, CreditService creditService,
            DepositService depositService, FundService fundService,
            EwerService ewerService, RateService rateService,
            FopService fopService)
        {
            _currentCashService = currentCashService;
            _creditService = creditService;
            _depositService = depositService;
            _fundService = fundService;
            _ewerService = ewerService;
            _rateService = rateService;
            _fopService = fopService;
        }

        public double GetTotalUah()
        {
            var id = _ewerService.GetEwerCurrencyTypeIdByName("UAH");
            if (id == null) return double.NaN;

            var currentCash = _currentCashService.GetCurrentCash();
            var fundTotal = _fundService.FundTotal();
            var fundBalance = _fundService.FundBalance();
            var credit = _creditService.ActiveSum();
            var commonEwer = _ewerService.CommonEwerByEct(id.Value);
            var commonEwerCredit = _ewerService.CommonEwerCreditByEct(id.Value);
            var deposit = _depositService.ActiveSumByYear(DateTime.Today.Year);

            return currentCash + fundTotal + fundBalance + credit + commonEwer + commonEwerCredit + deposit;
        }

        public double GetTotalUsd()
        {
            var id = _ewerService.GetEwerCurrencyTypeIdByName("USD");
            if (id == null) return double.NaN;

            var commonEwer = _ewerService.CommonEwerByEct(id.Value); 
            var commonEwerCredit = _ewerService.CommonEwerCreditByEct(id.Value);

            return commonEwer + commonEwerCredit;
        }

        public double GetTotalEur()
        {
            var id = _ewerService.GetEwerCurrencyTypeIdByName("EUR");
            if (id == null) return double.NaN;

            var commonEwer = _ewerService.CommonEwerByEct(id.Value);
            var commonEwerCredit = _ewerService.CommonEwerCreditByEct(id.Value);

            return commonEwer + commonEwerCredit;
        }

        public double GetTotalPln()
        {
            var id = _ewerService.GetEwerCurrencyTypeIdByName("PLN");
            if (id == null) return double.NaN;

            var commonEwer = _ewerService.CommonEwerByEct(id.Value);
            var commonEwerCredit = _ewerService.CommonEwerCreditByEct(id.Value);

            return commonEwer + commonEwerCredit;
        }

        public double GetTotalUsdInUah()
        {
            var total = GetTotalUsd();
            var rate = _rateService.GetRateByName("USD");
            return total * rate;
        }

        public double GetTotalEurInUah()
        {
            var total = GetTotalEur();
            var rate = _rateService.GetRateByName("EUR");
            return total * rate;
        }

        public double GetTotalPlnInUah()
        {
            var total = GetTotalPln();
            var rate = _rateService.GetRateByName("PLN");
            return total * rate;
        }

        public double GetTotalFopInUah()
        {
            var total = _fopService.GetWorkingBalance();
            var rate = _rateService.GetRateByName("USD");
            return total * rate;
        }

        public double GetTotalValuesTotal()
            => GetTotalUah() + GetTotalUsdInUah() 
                             + GetTotalEurInUah() 
                             + GetTotalPlnInUah() 
                             + GetTotalFopInUah();

        public Dictionary<string, double> GetPercents()
        {
            var percents = new Dictionary<string, double>();

            var total = GetTotalValuesTotal();

            percents.Add("total_inuah", total);
            percents.Add("percent_uah", Math.Round(GetTotalUah() / total * 100, 2));
            percents.Add("percent_usd", Math.Round(GetTotalUsdInUah() / total * 100, 2));
            percents.Add("percent_eur", Math.Round(GetTotalEurInUah() / total * 100, 2));
            percents.Add("percent_pln", Math.Round(GetTotalPlnInUah() / total * 100, 2));
            percents.Add("percent_fop", Math.Round(GetTotalFopInUah() / total * 100, 2));

            return percents;
        }
    }
}
