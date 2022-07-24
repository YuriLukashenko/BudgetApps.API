using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BudgetApps.API.Attributes
{
    public class AttributeHelper
    {
        public static string GetIdName<T>()
        {
            var prop = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .FirstOrDefault(p => p.GetCustomAttributes(typeof(IdentifierAttribute), false).Count() == 1);

            return prop?.Name;
        }

        public static string GetValueName<T>()
        {
            var prop = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .FirstOrDefault(p => p.GetCustomAttributes(typeof(ValueAttribute), false).Count() == 1);

            return prop?.Name;
        }
    }
}
