using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApps.API.Helpers.Builders
{
    public class PostgresStringBuilder
    {
        private readonly StringBuilder _builder;
        private QueryContext _context;

        private PostgresStringBuilder()
        {
            _builder = new StringBuilder();
        }

        public static PostgresStringBuilder Create(QueryContext context)
        {
            var builder = new PostgresStringBuilder();
            builder._context = context;
            return builder;
        }

        public PostgresStringBuilder Command()
        {
            var command = _context.GetCommandName();
            _builder.Append(command);
            return this;
        }

        public PostgresStringBuilder All()
        {
            _builder.Append(" *");
            return this;
        }

        public PostgresStringBuilder From()
        {
            _builder.Append(" from");
            return this;
        }

        public PostgresStringBuilder Table()
        {
            _builder.Append($" dbo.{_context.TableName}");
            return this;
        }

        public PostgresStringBuilder OrderBy()
        {
            var order = _context.GetOrderName();
            _builder.Append($" order by {_context.TableName}.{_context.FieldOrder.FieldName} {order}");
            return this;
        }

        public PostgresStringBuilder Where()
        {
            _builder.Append($" where");
            return this;
        }

        public PostgresStringBuilder Where(int id)
        {
            _builder.Append($" where {_context.TableName}.{_context.Field.FieldName}={id}");
            return this;
        }

        public string Generate()
        {
            return _builder.ToString();
        }
    }
}
