using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Entities.SalaryArea;
using BudgetApps.API.Helpers.Builders;
using BudgetApps.API.Interfaces;

namespace BudgetApps.API.Services.Flux
{
    public class SalaryService : EntityBaseService
    {
        public SalaryService(IConnectionService connectionService, QueryBuilder queryBuilder) : base(connectionService, queryBuilder)
        {
        }

        #region Entities
        public IEnumerable<Company> GetCompanies()
        {
            return GetAll<Company>();
        }

        public IEnumerable<SalaryFormation> GetSalaryFormations()
        {
            return GetAll<SalaryFormation>();
        }

        public IEnumerable<SalaryEnrollment> GetSalaryEnrollments()
        {
            return GetAll<SalaryEnrollment>();
        }

        public IEnumerable<SalaryBonuses> GetSalaryBonuses()
        {
            return GetAll<SalaryBonuses>();
        }

        public IEnumerable<SalaryBonusTypes> GetSalaryBonusTypes()
        {
            return GetAll<SalaryBonusTypes>();
        }

        public IEnumerable<Taxes> GetTaxes()
        {
            return GetAll<Taxes>();
        }

        public IEnumerable<SalaryConverting> GetSalaryConvertings()
        {
            return GetAll<SalaryConverting>();
        }

        #endregion
    }
}
