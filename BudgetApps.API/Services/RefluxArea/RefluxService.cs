using System.Collections.Generic;
using System.Linq;
using BudgetApps.API.DTOs.RefluxArea;
using BudgetApps.API.Entities.RefluxArea;
using BudgetApps.API.Helpers.Builders;
using BudgetApps.API.Interfaces;

namespace BudgetApps.API.Services.RefluxArea
{
    public class RefluxService : EntityBaseService
    {
        private readonly IConnectionService _connectionService;
        public RefluxService(IConnectionService connectionService, QueryBuilder queryBuilder) : base(connectionService, queryBuilder)
        {
            _connectionService = connectionService;
        }   

        #region Entities

        public IEnumerable<Reflux> GetRefluxes()
        {
            return GetAll<Reflux>();
        }

        public IEnumerable<RefluxHistory> GetRefluxHistories()
        {
            return GetAll<RefluxHistory>();
        }

        public IEnumerable<RefluxTypes> GetRefluxTypes()
        {
            return GetAll<RefluxTypes>();
        }

        public IEnumerable<MonthReflux> GetRefluxesMonth()
        {
            var refluxHistory = GetRefluxHistories();

            return refluxHistory
                .GroupBy(x => new { x.Date.Year, x.Date.Month })
                .OrderBy(x => x.First().Date)
                .Select(x => new MonthReflux()
                {
                    RId = x.First().RhId,
                    Date = x.First().Date,
                    MonthSum = x.Sum(y => y.Value)
                });
        }

        public IEnumerable<MonthReflux> GetRefluxesMonthByYear(int year)
        {
            var refluxHistory = GetRefluxHistories();

            return refluxHistory
                .Where(x => x.Date.Year == year)
                .GroupBy(x => x.Date.Month)
                .OrderBy(x => x.First().Date)
                .Select(x => new MonthReflux()
                {
                    RId = x.First().RhId,
                    Date = x.First().Date,
                    MonthSum = x.Sum(y => y.Value)
                });
        }


        public IEnumerable<MonthReflux> GetRefluxesMonthCurrent()
        {
            var refluxes = GetRefluxes();

            return refluxes
                .GroupBy(x => x.Date.Month)
                .OrderBy(x => x.First().Date)
                .Select(x => new MonthReflux()
                {
                    RId = x.First().RId,
                    Date = x.First().Date,
                    MonthSum = x.Sum(y => y.Value)
                });
        }

        public IEnumerable<RefluxByCaterogies> GetRefluxByCaterogies()
        {
            var refluxHistory = GetRefluxHistories();

            var grouped = refluxHistory
                .GroupBy(x => new {x.RtId})
                .Select(x => new RefluxByCaterogies()
                {
                    RtId = x.First().RtId,
                    Sum = x.Sum(y => y.Value)
                })
                .OrderBy(x => x.Sum)
                .ToList();

            foreach (var group in grouped)
            {
                var type = GetById<RefluxTypes>(group.RtId);
                group.TypeName = type.Name;
            }

            return grouped;
        }

        public IEnumerable<RefluxByCaterogies> GetRefluxByCategoriesByYear(int year)
        {
            var refluxHistory = GetRefluxHistories();

            var grouped = refluxHistory
                .Where(x => x.Date.Year == year)
                .GroupBy(x => new { x.RtId })
                .Select(x => new RefluxByCaterogies()
                {
                    RtId = x.First().RtId,
                    Sum = x.Sum(y => y.Value)
                })
                .OrderBy(x => x.Sum)
                .ToList();

            foreach (var group in grouped)
            {
                var type = GetById<RefluxTypes>(group.RtId);
                group.TypeName = type.Name;
            }

            return grouped;
        }

        public IEnumerable<RefluxByCaterogies> GetRefluxByCategoriesByYears()
        {
            var refluxHistory = GetRefluxHistories();

            var grouped = refluxHistory
                .GroupBy(x => new { x.RtId })
                .Select(x => new RefluxByCaterogies()
                {
                    RtId = x.First().RtId,
                    Sum = x.Sum(y => y.Value),
                    Sum2019 = x.Where(y => y.Date.Year == 2019).Sum(y => y.Value),
                    Sum2020 = x.Where(y => y.Date.Year == 2020).Sum(y => y.Value),
                    Sum2021 = x.Where(y => y.Date.Year == 2021).Sum(y => y.Value),
                })
                .OrderBy(x => x.Sum)
                .ToList();

            foreach (var group in grouped)
            {
                var type = GetById<RefluxTypes>(group.RtId);
                group.TypeName = type.Name;
            }

            return grouped;
        }


        #endregion

        public IEnumerable<RefluxTypes> GetUsedRefluxTypesMonthCurrent()
        {
            var refluxTypes = GetRefluxTypes();
            var refluxes = GetRefluxes();
            var refluxesGrouped = refluxes.GroupBy(x => x.RtId).Select(g => g.Key);

            return refluxTypes.Where(x => refluxesGrouped.Contains(x.RtId));
        }

        public IEnumerable<RefluxTypes> GetUsedRefluxTypesByYear(int year)
        {
            var refluxTypes = GetRefluxTypes();
            var refluxesHistories = GetRefluxHistories();
            var refluxesGrouped = refluxesHistories.GroupBy(x => x.RtId).Select(g => g.Key);

            return refluxTypes.Where(x => refluxesGrouped.Contains(x.RtId));
        }

        public IEnumerable<MonthReflux> GetRefluxesMonthCurrentByType(int type)
        {
            var refluxes = GetRefluxes().Where(x => x.RtId == type);

            return refluxes
                .GroupBy(x => x.Date.Month)
                .OrderBy(x => x.First().Date)
                .Select(x => new MonthReflux()
                {
                    RId = x.First().RId,
                    Date = x.First().Date,
                    MonthSum = x.Sum(y => y.Value)
                });
        }

        public IEnumerable<MonthReflux> GetRefluxesMonthByYearByType(int year, int type)
        {
            var refluxHistory = GetRefluxHistories().Where(x => x.RtId == type);

            return refluxHistory
                .Where(x => x.Date.Year == year)
                .GroupBy(x => x.Date.Month)
                .OrderBy(x => x.First().Date)
                .Select(x => new MonthReflux()
                {
                    RId = x.First().RhId,
                    Date = x.First().Date,
                    MonthSum = x.Sum(y => y.Value)
                });
        }
    }
}
