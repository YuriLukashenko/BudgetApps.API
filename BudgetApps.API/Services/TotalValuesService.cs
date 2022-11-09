using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.DTOs.TotalValuesArea;
using BudgetApps.API.Services.CreditArea;
using BudgetApps.API.Services.DepositArea;
using BudgetApps.API.Services.EwerArea;
using BudgetApps.API.Services.FopArea;
using BudgetApps.API.Services.FundArea;
using BudgetApps.API.Services.ObligationArea;

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
        private readonly ObligationService _obligationService;
        public TotalValuesService(CurrentCashService currentCashService, CreditService creditService,
            DepositService depositService, FundService fundService,
            EwerService ewerService, RateService rateService,
            FopService fopService, ObligationService obligationService)
        {
            _currentCashService = currentCashService;
            _creditService = creditService;
            _depositService = depositService;
            _fundService = fundService;
            _ewerService = ewerService;
            _rateService = rateService;
            _fopService = fopService;
            _obligationService = obligationService;
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
            var obligation = _obligationService.ActiveSumByYear(DateTime.Today.Year);

            return currentCash + fundTotal + fundBalance + credit + commonEwer + commonEwerCredit + deposit + obligation;
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
            percents.Add("percent_uah", CalculatePercent(GetTotalUah(), total));
            percents.Add("percent_usd", CalculatePercent(GetTotalUsdInUah(), total));
            percents.Add("percent_eur", CalculatePercent(GetTotalEurInUah(), total));
            percents.Add("percent_pln", CalculatePercent(GetTotalPlnInUah(), total));
            percents.Add("percent_fop", CalculatePercent(GetTotalFopInUah(), total));

            return percents;
        }

        public double GetAvailable()
        {
            //todo implement
            return 0.0;
        }

        public double CalculatePercent(double value, double total)
        {
            return Math.Round(value / total * 100, 2);
        }

        public IEnumerable<Slice> GetSlices()
        {
            var totalUah = GetTotalUah();
            var totalUsd = GetTotalUsdInUah();
            var totalEur = GetTotalEurInUah();
            var totalPln = GetTotalPlnInUah();
            var totalFop = GetTotalFopInUah();
            var total = GetTotalValuesTotal();
            var available = GetAvailable();

            return new List<Slice>()
            {
                new() { Name = "Total", Value = total, Percent = 100 },
                new() { Name = "Available", Value = available, Percent = CalculatePercent(available, total) },
                new() { Name = "UAH", Value = totalUah, Percent = CalculatePercent(totalUah, total) },
                new() { Name = "USD", Value = totalUsd, Percent = CalculatePercent(totalUsd, total) },
                new() { Name = "EUR", Value = totalEur, Percent = CalculatePercent(totalEur, total) },
                new() { Name = "PLN", Value = totalPln, Percent = CalculatePercent(totalPln, total) },
                new() { Name = "FOP", Value = totalFop, Percent = CalculatePercent(totalFop, total) },
            };
        }
    }
}
