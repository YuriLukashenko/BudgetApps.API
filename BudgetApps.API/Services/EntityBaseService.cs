using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Attributes;
using BudgetApps.API.DTOs;
using BudgetApps.API.Helpers;
using BudgetApps.API.Helpers.Builders;
using BudgetApps.API.Helpers.Extensions;
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

        private IEnumerable<T> SendRequest<T>(string query)
        {
            IEnumerable<T> response = null;

            using (var connection = _connectionService.Connect())
            {
                connection.Open();
                response = connection.Query<T>(query);
                connection.Close();
            }

            return response;
        }

        public IEnumerable<T> GetAll<T>()
        {
            var baseConfig = EntityQueryConfig.GetConfigByType<T>();

            var context = new QueryContext()
            {
                Command = QueryContext.CommandsDefinition.Select,
                FieldOrder = new FieldOrder()
                {
                    FieldName = baseConfig.SnakeCasedIdName,
                    Order = FieldOrder.OrderDefinition.Asc
                },
                TableName = baseConfig.SnakeCasedClassName
            };

            var query = _queryBuilder.BuildGetAllQuery(context);
            
            return SendRequest<T>(query);
        }

        public T GetById<T>(int id)
        {
            var baseConfig = EntityQueryConfig.GetConfigByType<T>();

            var context = new QueryContext()
            {
                Command = QueryContext.CommandsDefinition.Select,
                TableName = baseConfig.SnakeCasedClassName,
                Field = new Field()
                {
                    FieldName = baseConfig.SnakeCasedIdName,
                },
                Id = id
            };

            var query = _queryBuilder.BuildGetByIdQuery(context);

            var response = SendRequest<T>(query);

            return response.SingleOrDefault();
        }

        public T UpdateById<T>(Payload payload)
        {
            var baseConfig = EntityQueryConfig.GetConfigByType<T>();

            var context = new QueryContext()
            {
                Command = QueryContext.CommandsDefinition.Update,
                TableName = baseConfig.SnakeCasedClassName,
                Field = new Field()
                {
                    FieldName = baseConfig.SnakeCasedIdName,
                },
                Id = payload.KeyValue,
                Payload = payload
            };

            var query = _queryBuilder.BuildUpdateByIdQuery(context);

            var response = SendRequest<T>(query);

            return response.SingleOrDefault();
        }

        public T Insert<T>(QueryContext context)
        {
            var query = _queryBuilder.BuildInsertQuery(context);
            var response = SendRequest<T>(query);
            return response.SingleOrDefault();
        }

        public T SafeInsert<T>(T obj)
        {
            var baseConfig = EntityQueryConfig.GetConfigByType<T>();

            var context = new QueryContext()
            {
                Command = QueryContext.CommandsDefinition.InsertInto,
                TableName = baseConfig.SnakeCasedClassName,
                Field = new Field()
                {
                    FieldName = baseConfig.SnakeCasedIdName,
                },
                RawData = StructureConverter.GetRawData(obj)
            };

            try
            {
                return Insert<T>(context);
            }
            catch
            {
                ResetId<T>(context);
                return Insert<T>(context);
            }
        }

        public T ResetId<T>(QueryContext context)
        {
            var query = _queryBuilder.BuildResetIdQuery(context);
            var response = SendRequest<T>(query);
            return response.SingleOrDefault();
        }
    }
}
