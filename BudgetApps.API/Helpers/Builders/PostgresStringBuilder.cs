using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetApps.API.Helpers.FieldComponents;

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

        public PostgresStringBuilder Equals()
        {
            _builder.Append(" =");
            return this;
        }

        public PostgresStringBuilder From()
        {
            _builder.Append(" from");
            return this;
        }

        public PostgresStringBuilder Value(string value)
        {
            _builder.Append($" {value}");
            return this;
        }

        public PostgresStringBuilder Set()
        {
            _builder.Append(" set");
            return this;
        }
        public PostgresStringBuilder ValuesCommand()
        {
            _builder.Append(" values");
            return this;
        }

        public PostgresStringBuilder Property(string prop)
        {
            _builder.Append($" {prop}");
            return this;
        }
        
        public PostgresStringBuilder Table()
        {
            _builder.Append($" dbo.{_context.TableName}");
            return this;
        }

        public PostgresStringBuilder Open()
        {
            _builder.Append($" (");
            return this;
        }

        public PostgresStringBuilder Close()
        {
            _builder.Append($")");
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

        public PostgresStringBuilder Fields(IEnumerable<string> fields)
        {
            var count = fields.Count();
            var i = 0;
            foreach (var field in fields)
            {
                _builder.Append($"{field}");
                ++i;
                if (i != count)
                {
                    _builder.Append(", ");
                }
            }
            
            return this;
        }

        public PostgresStringBuilder Values(IEnumerable<string> values)
        {
            var count = values.Count();
            var i = 0;
            foreach (var value in values)
            {
                _builder.Append($"{value}");
                ++i;
                if (i != count)
                {
                    _builder.Append(", ");
                }
            }

            return this;
        }

        public string Generate()
        {
            return _builder.ToString();
        }

        public PostgresStringBuilder ResetId(string tableName, string idName)
        {
            _builder.Append("SELECT SETVAL(");
            _builder.Append($"(SELECT PG_GET_SERIAL_SEQUENCE('dbo.{tableName}', '{idName}')),");
            _builder.Append($"(SELECT (MAX({idName}) + 1) FROM dbo.{tableName})");
            _builder.Append(", FALSE);");
            return this;
        }
    }
}
