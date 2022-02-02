using System;
using System.Collections.Generic;
using System.Linq;
using BudgetApps.API.DTOs.Flux;
using BudgetApps.API.Entities.FluxArea;
using BudgetApps.API.Helpers.Builders;
using BudgetApps.API.Interfaces;
using BudgetApps.API.ViewModels;
using Dapper;

namespace BudgetApps.API.Services.FluxArea
{
    public class FluxService : EntityBaseService
    {
        private readonly IConnectionService _connectionService;
        public FluxService(IConnectionService connectionService, QueryBuilder queryBuilder) : base(connectionService, queryBuilder)
        {
            _connectionService = connectionService;
        }

        #region Entities

        public IEnumerable<Flux> GetFluxes()
        {
            return GetAll<Flux>();
        }

        public IEnumerable<FluxHistory> GetFluxHistories()
        {
            return GetAll<FluxHistory>();
        }

        public IEnumerable<FluxTypes> GetFluxTypes()
        {
            return GetAll<FluxTypes>();
        }

        #endregion

        public IEnumerable<FluxHistory> GetFluxesByYear(int id)
        {
            var fluxHistory = GetFluxHistories();

            return fluxHistory.Where(x => x.Date.Year == id);
        }
        public double GetFluxesSumByYear(int id)
        {
            var fluxByYear = GetFluxesByYear(id);

            return fluxByYear.Sum(x => x.Value);
        }

        public IEnumerable<MonthProfit> GetFluxesMonthProfits()
        {
            var fluxGrouped = GetCurrentFluxes();
            var fluxHistory = GetFluxHistories();

            var monthProfits = fluxHistory
                .GroupBy(x => new { x.Date.Year, x.Date.Month })
                .OrderBy(x => x.First().Date)
                .Select(x => new MonthProfit()
                {
                    Date = x.First().Date,
                    MonthSum = x.Sum(y => y.Value)
                })
                .ToList();

            monthProfits.AddRange(fluxGrouped);

            return monthProfits;
        }


        public IEnumerable<MonthProfit> GetFluxesMonthProfitsByYear(int id)
        {
            var currentYear = DateTime.Today.Year;

            if (id == currentYear)
                return GetCurrentFluxes();

            var fluxByYear = GetFluxesByYear(id);

            return fluxByYear
                .GroupBy(x => x.Date.Month)
                .OrderBy(x => x.Key)
                .Select(x => new MonthProfit()
                {
                    Date = x.First().Date,
                    MonthSum = x.Sum(y => y.Value)
                });
        }

        public IEnumerable<MonthProfit> GetCurrentFluxes()
        {
            var fluxes = GetFluxes();

            return fluxes
               .GroupBy(f => new { f.Date.Year, f.Date.Month })
               .OrderBy(f => f.First().Date)
               .Select(f => new MonthProfit()
               {
                   Date = f.First().Date,
                   //Ft is 9 ==> flux from last year. Kinda hack
                   MonthSum = f.Where(x => x.FtId != 9).Sum(y => y.Value)
               });
        }

        public IEnumerable<YearProfit> GetFluxesYearProfits()
        {
            var fluxHistory = GetFluxHistories();

            return fluxHistory
                .GroupBy(x => x.Date.Year)
                .OrderBy(x => x.First().Date)
                .Select(x => new YearProfit()
                {
                    Date = x.First().Date,
                    YearSum = x.Sum(y => y.Value)
                });
        }
    }
}
