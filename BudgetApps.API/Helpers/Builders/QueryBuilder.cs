using System;
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
    }
}
