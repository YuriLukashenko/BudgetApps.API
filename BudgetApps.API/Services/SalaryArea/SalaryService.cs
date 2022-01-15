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

        public IEnumerable<SalaryBonusesByType> GetSalaryBonusesByTypes()
        {
            var bonuses = GetSalaryBonuses();
            var types = GetSalaryBonusTypes();

            return bonuses
                .GroupBy(x => x.SbtId)
                .Select(x => new SalaryBonusesByType()
                {
                    Sum = x.Sum(y => y.UsdValue),
                    Name = types.FirstOrDefault(y => y.SbtId == x.First().SbtId)?.Name
                });
        }

        public IEnumerable<SalaryBonusesByMonth> GetSalaryBonusesByMonths()
        {
            var bonuses = GetSalaryBonuses();
            var enrollments = GetSalaryEnrollments();

            return bonuses
                .GroupBy(x => x.SeId)
                .Select(x => new SalaryBonusesByMonth()
                {
                    Sum = x.Sum(y => y.UsdValue),
                    SeId = x.First().SeId,
                    Date = enrollments.FirstOrDefault(y => y.SeId == x.First().SeId)?.Date
                });
        }

        public IEnumerable<SalaryWorkHours> GetSalaryWorkHours()
        {
            var formations = GetSalaryFormations();
            var enrollments = GetSalaryEnrollments();

            return formations
                .GroupBy(x => x.SeId)
                .Select(x => new SalaryWorkHours()
                {
                    Sum = x.Sum(y => y.HoursCount),
                    Date = enrollments.FirstOrDefault(y => y.SeId == x.First().SeId)?.Date
                });
        }
    }
}
