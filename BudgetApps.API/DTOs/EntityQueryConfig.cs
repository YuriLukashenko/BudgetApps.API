using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Attributes;
using BudgetApps.API.Helpers;

namespace BudgetApps.API.DTOs
{
    public class EntityQueryConfig
    {
        public string ClassName { get; set; }
        public string IdName { get; set; }
        public string SnakeCasedClassName { get; set; }
        public string SnakeCasedIdName { get; set; }

        public static EntityQueryConfig GetConfigByType<T>()
        {
            var className = typeof(T).Name;
            var idName = AttributeHelper.GetIdName<T>();

            return new EntityQueryConfig()
            {
                ClassName = className,
                IdName = idName,
                SnakeCasedClassName = NameMapper.ToSnakeCase(className),
                SnakeCasedIdName = NameMapper.ToSnakeCase(idName)
            };
        }
    }
}
