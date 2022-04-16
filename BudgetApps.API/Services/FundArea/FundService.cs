using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Entities.FundArea;
using BudgetApps.API.Helpers.Builders;
using BudgetApps.API.Interfaces;

namespace BudgetApps.API.Services.FundArea
{
    public class FundService : EntityBaseService
    {
        public FundService(IConnectionService connectionService, QueryBuilder queryBuilder) : base(connectionService, queryBuilder)
        {
        }

        #region Entities

        public IEnumerable<Girls> GetGirls()
        {
            return GetAll<Girls>();
        }

        public IEnumerable<FundSprints> GetFundSprints()
        {
            return GetAll<FundSprints>();
        }

        public IEnumerable<FundWithGirls> GetFundWithGirls()
        {
            return GetAll<FundWithGirls>();
        }

        public IEnumerable<FundDonations> GetFundDonations()
        {
            return GetAll<FundDonations>();
        }

        public IEnumerable<FundResearches> GetFundResearches()
        {
            return GetAll<FundResearches>();
        }

        public IEnumerable<FundSpends> GetFundSpends()
        {
            return GetAll<FundSpends>();
        }

        #endregion

        public IEnumerable<FundDonations> GetFundDonationsByYear(int year)
        {
            var donations = GetFundDonations();
            return donations.Where(x => x.Date.Year == year);
        }

        public double DonationSumByYear(int year)
        {
            var donations = GetFundDonationsByYear(year);

            return donations.Sum(x => x.Value);
        }

        public double TotalDonations()
        {
            var donations = GetFundDonations();
            return donations.Sum(x => x.Value);
        }

        public double TotalOnSex()
        {
            var withGirls = GetFundWithGirls();

            return withGirls
                .Where(x => x.CashSource == FundWithGirls.CashSourceDefinition.OnSex)
                .Sum(x => x.Value);
        }

        private double TotalResearches()
        {
            var researches = GetFundResearches();

            return researches
                .Select(x => x.Rate * x.Hours)
                .Sum();
        }

        public double FundTotal()
        {
            var totalDonations = TotalDonations();
            var totalOnSex = TotalOnSex();
            var totalResearches = TotalResearches();

            return totalDonations - totalOnSex - totalResearches;
        }

        public double FundBalance()
        {
            var totalResearches = TotalResearches();
            var totalOnSpend = TotalOnSpend();
            var totalSpends = TotalSpends();

            return totalResearches - totalOnSpend - totalSpends;
        }

        private double TotalOnSpend()
        {
            var withGirls = GetFundWithGirls();

            return withGirls
                .Where(x => x.CashSource == FundWithGirls.CashSourceDefinition.OnSpend)
                .Sum(x => x.Value);
        }

        private double TotalSpends()
        {
            var spends = GetFundSpends();

            return spends.Sum(x => x.Value);
        }
    }
}
