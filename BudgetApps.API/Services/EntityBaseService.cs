using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Attributes;
using BudgetApps.API.Helpers;
using BudgetApps.API.Helpers.Builders;
using BudgetApps.API.Helpers.FieldComponents;
using BudgetApps.API.Interfaces;
using Dapper;

namespace BudgetApps.API.Services
{
    public class EntityBaseService
    {
        private readonly IConnectionService _connectionService;
        private readonly QueryBuilder _queryBuilder;

        public EntityBaseService(IConnectionService connectionService, QueryBuilder queryBuilder)
        {
            _connectionService = connectionService;
            _queryBuilder = queryBuilder;
        }

        public IEnumerable<T> GetAll<T>()
        {
            IEnumerable<T> response = null;
            var className = typeof(T).Name;
            var idName = AttributeHelper.GetPropName<T>();

            var snakeCasedClassName = NameMapper.ToSnakeCase(className);
            var snakeCasedIdName = NameMapper.ToSnakeCase(idName);

            var context = new QueryContext()
            {
                Command = QueryContext.CommandsDefinition.Select,
                FieldOrder = new FieldOrder()
                {
                    FieldName = snakeCasedIdName,
                    Order = FieldOrder.OrderDefinition.Asc
                },
                TableName = snakeCasedClassName
            };

            var query = _queryBuilder.BuildGetAllQuery(context);
            
            using (var connection = _connectionService.Connect())
            {
                connection.Open();
                response = connection.Query<T>(query);
                connection.Close();
            }

            return response;
        }

    }
}
