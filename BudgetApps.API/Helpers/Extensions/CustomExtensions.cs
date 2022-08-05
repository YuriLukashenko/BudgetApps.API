using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Attributes;
using BudgetApps.API.Helpers.FieldComponents;

namespace BudgetApps.API.Helpers.Extensions
{
    public static class CustomExtensions
    {
        public static IEnumerable<Field> ExceptId<T>(this IEnumerable<Field> fields)
        {
            var idName = AttributeHelper.GetIdName<T>();
            return fields.Where(x => x.FieldName != idName);
        }

        public static IEnumerable<Field> GetSnakeCasedFields(this IEnumerable<Field> fields)
        {
            return fields.Select(x => new Field(NameMapper.ToSnakeCase(x.FieldName)));
        }
    }
}
