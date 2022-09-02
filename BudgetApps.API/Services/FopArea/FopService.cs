using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.DTOs;
using BudgetApps.API.Entities.FopArea;
using BudgetApps.API.Helpers.Builders;
using BudgetApps.API.Interfaces;
using BudgetApps.API.Models.Locations;

namespace BudgetApps.API.Services.FopArea
{
    public class FopService : EntityBaseService
    {
        public FopService(IConnectionService connectionService, QueryBuilder queryBuilder) : base(connectionService, queryBuilder)
        {
        }

        #region Entities

        public IEnumerable<FopBalance> GetFopBalances()
        {
            return GetAll<FopBalance>();
        }

        #endregion

        public double GetWorkingBalance()
        {
            var fop = GetFopBalances();

            return fop.FirstOrDefault(x => x.Type == "Working")?.Value ?? double.NaN;
        }

        public IEnumerable<FopBalance> Update(IEnumerable<FopRequestDTO> dtos)
        {
            var balances = GetFopBalances();

            foreach (var balance in balances)
            {
                var toUpdate = dtos.FirstOrDefault(x => x.Type == balance.Type);

                if (toUpdate != null)
                {
                    balance.Value = toUpdate.Value;
                    UpdateById<FopBalance>(Payload.CreateFrom(balance));
                }
            }

            return balances;
        }

        public IEnumerable<FopBalance> Subtract(FopSubtractRequestDto request)
        {
            var currentFopBalance = GetFopBalances().FirstOrDefault(x => x.Type == request.Type);

            if (currentFopBalance == null)
                return null;

            var dto = new List<FopRequestDTO>()
            {
                new FopRequestDTO()
                {
                    Type = request.Type,
                    Value = currentFopBalance.Value - request.Value
                }
            };

            return Update(dto);
        }
    }
}
