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
            var deposit = _depositService.ActiveSumByCurrency("UAH");
            var obligation = _obligationService.ActiveSum();

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

        public double GetUsdDepositInUah()
        {
            var usdDeposit = _depositService.ActiveSumByCurrency("USD");
            var rate = _rateService.GetRateByName("USD");
            return usdDeposit * rate;
        }

        public double GetTotalValuesTotal()
            => GetTotalUah() + GetTotalUsdInUah() 
                             + GetTotalEurInUah() 
                             + GetTotalPlnInUah() 
                             + GetTotalFopInUah();

        public IEnumerable<PercentDto> GetPercents()
        {
            var total = GetTotalValuesTotal();

            return new List<PercentDto>()
            {
                new() { CurrencyType = "uah", Percent = CalculatePercent(GetTotalUah(), total) },
                new() { CurrencyType = "usd", Percent = CalculatePercent(GetTotalUsdInUah(), total) },
                new() { CurrencyType = "eur", Percent = CalculatePercent(GetTotalEurInUah(), total) },
                new() { CurrencyType = "pln", Percent = CalculatePercent(GetTotalPlnInUah(), total) },
                new() { CurrencyType = "fop", Percent = CalculatePercent(GetTotalFopInUah(), total) }
            };
        }

        public double GetAvailable()
        {
            var currentCash = _currentCashService.GetCurrentCash();
            var fundTotal = _fundService.FundTotal();
            var commonEwerInUah = _ewerService.GetInUahUpToDate();
            var usdDepositInUah = GetUsdDepositInUah();
            var fopInUah = GetTotalFopInUah();

            return currentCash + fundTotal + commonEwerInUah + fopInUah - usdDepositInUah;
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

        public double CommonEwerWithoutUsdDeposit()
        {
            return _ewerService.CommonEwerByEct(_ewerService.GetEwerCurrencyTypeIdByName("USD") ?? 0)
                   - _depositService.ActiveSumByCurrency("USD");
        }

        public IEnumerable<CurrencyDetails> GetCurrencyDetails()
        {
            return new List<CurrencyDetails>()
            {
                new()
                {
                    Currency = "UAH", 
                    Details = new Details()
                    {
                        CurrentCash =  _currentCashService.GetCurrentCash(),
                        Fund = _fundService.FundTotal(),
                        Balance = _fundService.FundBalance(),
                        Credit = _creditService.ActiveSum(),
                        Ewer = _ewerService.CommonEwerByEct(_ewerService.GetEwerCurrencyTypeIdByName("UAH") ?? 0),
                        EwerCredit = _ewerService.CommonEwerCreditByEct(_ewerService.GetEwerCurrencyTypeIdByName("UAH") ?? 0),
                        Deposit = _depositService.ActiveSumByCurrency("UAH"),
                        Obligation = _obligationService.ActiveSum()
                    }
                },
                new()
                {
                    Currency = "FOP",
                    Details = new Details()
                    {
                        Total =  _fopService.GetWorkingBalance()
                    }
                },
                new()
                {
                    Currency = "USD",
                    Details = new Details()
                    {
                        Ewer = CommonEwerWithoutUsdDeposit(),
                        EwerCredit = _ewerService.CommonEwerCreditByEct(_ewerService.GetEwerCurrencyTypeIdByName("USD") ?? 0),
                        Deposit = _depositService.ActiveSumByCurrency("USD"),
                    }
                },
                new()
                {
                    Currency = "EUR",
                    Details = new Details()
                    {
                        Ewer = _ewerService.CommonEwerByEct(_ewerService.GetEwerCurrencyTypeIdByName("EUR") ?? 0),
                        EwerCredit = _ewerService.CommonEwerCreditByEct(_ewerService.GetEwerCurrencyTypeIdByName("EUR") ?? 0),
                    }
                },
                new()
                {
                    Currency = "PLN",
                    Details = new Details()
                    {
                        Ewer = _ewerService.CommonEwerByEct(_ewerService.GetEwerCurrencyTypeIdByName("PLN") ?? 0),
                        EwerCredit = _ewerService.CommonEwerCreditByEct(_ewerService.GetEwerCurrencyTypeIdByName("PLN") ?? 0),
                    }
                }
            };
        }
    }
}
