using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BudgetApps.API.Attributes
{
    public class AttributeHelper
    {
        public static string GetPropName<T>()
        {
            var prop = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .FirstOrDefault(p => p.GetCustomAttributes(typeof(IdentifierAttribute), false).Count() == 1);

            return prop?.Name;
        }
    }
}
