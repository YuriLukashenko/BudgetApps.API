using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Attributes;

namespace BudgetApps.API.Helpers
{
    public class StructureConverter
    {
        public static IDictionary<string, string> GetRawData<T>(T obj)
        {
            var raw = new Dictionary<string, string>();

            var propertyInfos = typeof(T).GetProperties();
            var idName = AttributeHelper.GetIdName<T>();

            foreach (var property in propertyInfos)
            {
                if (property.Name != idName)
                {
                    var key = NameMapper.ToSnakeCase(property.Name);
                    var value = GetPropValue(obj, property.Name);
                    var convertedValue = ConvertValue(value, property.PropertyType);
                    if (convertedValue != null)
                    {
                        raw.Add(key, convertedValue);
                    }
                }
            }

            return raw;
        }

        private static string ConvertValue(object value, Type propertyPropertyType)
        {
            switch (propertyPropertyType.Name)
            {
                case "String":
                    return $"'{value}'";
                case "Int32":
                    return $"{(int)value}";
                case "Double":
                    return $"{((double)value).ToString(CultureInfo.InvariantCulture)}";
                case "DateTime":
                    return $"'{((DateTime) value):yyyy-MM-dd}'";
                default:
                    return value?.ToString();
            }
        }

        public static object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName)?.GetValue(src, null);
        }
    }
}
