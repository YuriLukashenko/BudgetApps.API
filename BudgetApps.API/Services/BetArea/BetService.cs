using System.Collections.Generic;
using BudgetApps.API.Entities.BetArea;
using BudgetApps.API.Helpers.Builders;
using BudgetApps.API.Interfaces;

namespace BudgetApps.API.Services.BetArea
{
    public class BetService : EntityBaseService
    {
        public BetService(IConnectionService connectionService, QueryBuilder queryBuilder) : base(connectionService, queryBuilder)
        {
        }

        #region Entities
        public IEnumerable<Bets> GetBets()
        {
            return GetAll<Bets>();
        }

        #endregion
    }
}
