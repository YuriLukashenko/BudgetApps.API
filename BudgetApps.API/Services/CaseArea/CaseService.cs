using System.Collections.Generic;
using BudgetApps.API.Entities.CaseArea;
using BudgetApps.API.Helpers.Builders;
using BudgetApps.API.Interfaces;

namespace BudgetApps.API.Services.CaseArea
{
    public class CaseService : EntityBaseService
    {
        public CaseService(IConnectionService connectionService, QueryBuilder queryBuilder) : base(connectionService, queryBuilder)
        {

        }

        #region Entities
        public IEnumerable<Cases> GetCases()
        {
            return GetAll<Cases>();
        }

        public IEnumerable<CasePayoutPeople> GetCasePayoutPeople()
        {
            return GetAll<CasePayoutPeople>();
        }

        public IEnumerable<CasePayouts> GetCasePayouts()
        {
            return GetAll<CasePayouts>();
        }

        public IEnumerable<CasePayoutInitial> GetCasePayoutInitials()
        {
            return GetAll<CasePayoutInitial>();
        }

        #endregion
    }
}
