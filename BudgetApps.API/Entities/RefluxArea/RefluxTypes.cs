﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Attributes;

namespace BudgetApps.API.Entities.RefluxArea
{
    public class RefluxTypes
    {
        [Identifier]
        public int RtId { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
    }
}
