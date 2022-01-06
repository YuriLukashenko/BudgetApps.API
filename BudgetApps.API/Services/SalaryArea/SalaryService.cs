using System.Collections.Generic;
using System.Linq;
using BudgetApps.API.DTOs.SalaryArea;
using BudgetApps.API.Entities.SalaryArea;
using BudgetApps.API.Helpers.Builders;
using BudgetApps.API.Interfaces;

namespace BudgetApps.API.Services.SalaryArea
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

        public IEnumerable<SalaryAverageRate> GetSalaryAverageRates()
        {
            var enrollments = GetSalaryEnrollments();
            var formations = GetSalaryFormations();

            return formations
                .GroupBy(x => x.SeId)
                .Select(x => new SalaryAverageRate()
                {
                    AvgRate = x.Average(y => y.Rate),
                    Date = enrollments.FirstOrDefault(y => y.SeId == x.First().SeId)?.Date
                });
        }
    }
}
