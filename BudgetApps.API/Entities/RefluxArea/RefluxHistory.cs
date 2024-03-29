﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Attributes;

namespace BudgetApps.API.Entities.RefluxArea
{
    public class RefluxHistory
    {
        [Identifier]
        public int RhId { get; set; }
        public int RtId { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }

        public RefluxTypes RefluxTypes { get; set; }
    }
}
