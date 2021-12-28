using System;
using System.Collections.Generic;
using BudgetApps.API.Entities.StackArea;
using BudgetApps.API.Helpers.Builders;
using BudgetApps.API.Interfaces;

namespace BudgetApps.API.Services.StackArea
{
    public class StackService : EntityBaseService
    {
        public StackService(IConnectionService connectionService, QueryBuilder queryBuilder) : base(connectionService, queryBuilder)
        {
        }

        #region Entities

        public IEnumerable<StackTypes> GetStackTypes()
        {
            return GetAll<StackTypes>();
        }

        public IEnumerable<Stack> GetStacks()
        {
            return GetAll<Stack>();
        }

        #endregion
    }
}
