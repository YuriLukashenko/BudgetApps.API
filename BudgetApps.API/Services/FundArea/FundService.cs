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
    }
}
