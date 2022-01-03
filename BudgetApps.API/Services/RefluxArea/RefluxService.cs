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

        public IEnumerable<RefluxByCaterogies> GetRefluxByCaterogies()
        {
            var refluxHistory = GetRefluxHistories();

            var grouped = refluxHistory
                .Where(x => x.Date.Year >= 2021)
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


        #endregion
    }
}
