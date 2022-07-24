﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApps.API.Helpers.Builders
{
    public class QueryBuilder
    {
        public string BuildGetAllQuery(QueryContext context)
        {
            return PostgresStringBuilder.Create(context)
                .Command()
                .All()
                .From()
                .Table()
                .OrderBy()
                .Generate();
        }

        public string BuildGetByIdQuery(QueryContext context)
        {
            return PostgresStringBuilder.Create(context)
                .Command()
                .All()
                .From()
                .Table()
                .Where(context.Id)
                .Generate();
        }

        public string BuildUpdateByIdQuery(QueryContext context)
        {
            return PostgresStringBuilder.Create(context)
               .Command()
               .Table()
               .Set()
               .Property(context.Payload.PropertyName)
               .Equals()
               .Value(context.Payload.PropertyValue)
               .Where()
               .Property(context.Payload.KeyName)
               .Equals()
               .Value(context.Payload.KeyValue.ToString())
               .Generate();
        }
    }
}
