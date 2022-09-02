using System;
using System.Collections.Generic;
using System.Linq;
using BudgetApps.API.DTOs;
using BudgetApps.API.DTOs.Delta;
using BudgetApps.API.DTOs.Flux;
using BudgetApps.API.DTOs.SalaryArea;
using BudgetApps.API.Entities.SalaryArea;
using BudgetApps.API.Helpers.Builders;
using BudgetApps.API.Interfaces;

namespace BudgetApps.API.Services.SalaryArea
{
    public class SalaryService : EntityBaseService
    {
        private readonly DeltaService _deltaService;
        private readonly StatisticService _statisticService;
        public SalaryService(IConnectionService connectionService, QueryBuilder queryBuilder, DeltaService deltaService, StatisticService statisticService) : base(connectionService, queryBuilder)
        {
            _deltaService = deltaService;
            _statisticService = statisticService;
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

        public IEnumerable<SalaryTotalByMonths> GetTotalSalaryByMonths()
        {
            var enrollments = GetSalaryEnrollments();
            var formations = GetSalaryFormations();
            var bonuses = GetSalaryBonuses();

            return formations.GroupBy(x => x.SeId)
                             .Select(x => new 
                                {
                                    Sum = x.Sum(y => y.Rate * y.HoursCount), 
                                    x.First().SeId,
                                })
                  .GroupJoin(bonuses.GroupBy(x => x.SeId)
                                    .Select(x => new 
                                    {
                                        Sum = x.Sum(y => y.UsdValue), 
                                        x.First().SeId,
                                    }), 
                             f => f.SeId, 
                             b => b.SeId, 
                             (form, bon) => new { form, bon })
                  .SelectMany(x => x.bon.DefaultIfEmpty(), (grouped, bonus) => new SalaryTotalByMonths() 
                             {
                                 SeId = grouped.form.SeId, 
                                 Sum = grouped.form.Sum + (bonus?.Sum ?? 0),
                                 Date = enrollments.FirstOrDefault(y => y.SeId == grouped.form.SeId)?.Date
                             });
        }

        public IEnumerable<DeltaResponse> GetDeltaSalaryByMonths()
        {
            var monthSalaries = GetTotalSalaryByMonths();
            var source = DeltaRequest.CreateFrom(monthSalaries);
            return _deltaService.EvaluateDelta(source, BinDefinition.Month);
        }

        public double GetPercentileRate(double percentile)
        {
            var formations = GetSalaryFormations();
            var rates = formations.Select(x => x.Rate);
            return _statisticService.GetPercentile(rates, percentile);
        }

        public double GetPercentileOfAverageRateByMonths(double percentile)
        {
            var avgRates = GetSalaryAverageRates();
            var rates = avgRates.Select(x => x.AvgRate);
            return _statisticService.GetPercentile(rates, percentile);
        }

        public double GetAverageRate()
        {
            //should be one value per month
            var avgRates = GetSalaryAverageRates();
            return avgRates.Select(x => x.AvgRate).Average();
        }

        public IEnumerable<double> GetPercentileOfTotalSalary(double percentile, DateTime? startPoint = null)
        {
            //Get total salary by months. Than calculate percentile of year range. Two options: from start working or by physical year
            var totalSalaryArray = GetTotalSalaryByMonths();

            var grouped = new List<double>();
            var group = new List<SalaryTotalByMonths>();

            int i = 0;
            do
            {
                group = totalSalaryArray.Skip(i * 12).Take(12).ToList();
                if (!group.Any()) break;
                var calculated = _statisticService.GetPercentile(group.Select(x => x.Sum), percentile);
                grouped.Add(calculated);
                i++;
            } while (group.Any());

            return grouped;
        }

        public IEnumerable<double> GetAverageOfTotalSalary()
        {
            var totalSalaryArray = GetTotalSalaryByMonths();

            var grouped = new List<double>();
            var group = new List<SalaryTotalByMonths>();

            int i = 0;
            do
            {
                group = totalSalaryArray.Skip(i * 12).Take(12).ToList();
                if (!group.Any()) break;
                var calculated = group.Average(x => x.Sum);
                grouped.Add(calculated);
                i++;
            } while (group.Any());

            return grouped;
        }

        public IEnumerable<double> GetInterquartile()
        {
            var q1 = GetPercentileOfTotalSalary(0.25).ToList();
            var q2 = GetPercentileOfTotalSalary(0.50).ToList();
            var q3 = GetPercentileOfTotalSalary(0.75).ToList();

            var result = new List<double>();
            for (int i = 0; i < q1.Count(); i++)
            {
                result.Add((q3[i] - q1[i]) / q2[i]);
            }

            return result;
        }

        public SalaryConverting Add(SalaryConverting salaryConverting) => Insert(salaryConverting);
    }
}
