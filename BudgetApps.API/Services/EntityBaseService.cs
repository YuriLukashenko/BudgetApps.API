using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Helpers;
using BudgetApps.API.Interfaces;
using Dapper;

namespace BudgetApps.API.Services
{
    public class EntityBaseService
    {
        private readonly IConnectionService _connectionService;
        
        public EntityBaseService(IConnectionService connectionService)
        {
            _connectionService = connectionService;
        }

        public IEnumerable<T> GetAll<T>()
        {
            IEnumerable<T> response = null;
            var name = typeof(T).Name;
            var snakeCasedName = NameMapper.ToSnakeCase(name);
            
            using (var connection = _connectionService.Connect())
            {
                connection.Open();
                response = connection.Query<T>($"select * from dbo.{snakeCasedName}");
                connection.Close();
            }

            return response;
        }

    }
}
