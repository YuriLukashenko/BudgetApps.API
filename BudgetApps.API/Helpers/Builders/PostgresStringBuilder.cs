using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApps.API.Helpers.Builders
{
    public class PostgresStringBuilder
    {
        private StringBuilder _builder;

        private PostgresStringBuilder()
        {
            _builder = new StringBuilder();
        }
    }
}
