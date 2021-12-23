using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;

namespace BudgetApps.API.Helpers
{
    public static class NameMapper
    {
        public static string ToSnakeCase(string input)
        {
            return 
                new DefaultContractResolver()
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                }
                .GetResolvedPropertyName(input);
        }
    }
}
