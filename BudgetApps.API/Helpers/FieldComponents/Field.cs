using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApps.API.Helpers.FieldComponents
{
    public class Field
    {
        public Field() { }
        public Field(string name)
        {
            FieldName = name;
        }
        public string FieldName { get; set; }
    }
}
