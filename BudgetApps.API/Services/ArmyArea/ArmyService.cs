using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Entities.ArmyArea;
using BudgetApps.API.Helpers.Builders;
using BudgetApps.API.Interfaces;

namespace BudgetApps.API.Services.ArmyArea
{
    public class ArmyService : EntityBaseService
    {
        public ArmyService(IConnectionService connectionService, QueryBuilder queryBuilder) : base(connectionService, queryBuilder)
        {
        }

        #region Entities

        public IEnumerable<Army> GetArmies()
        {
            return GetAll<Army>();
        }

        #endregion
    }
}
