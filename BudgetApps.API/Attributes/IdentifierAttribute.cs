﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BudgetApps.API.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class IdentifierAttribute : Attribute
    {
    }
}
