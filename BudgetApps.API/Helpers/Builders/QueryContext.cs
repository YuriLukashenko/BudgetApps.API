using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.DTOs;
using BudgetApps.API.Helpers.FieldComponents;

namespace BudgetApps.API.Helpers.Builders
{
    public class QueryContext
    {
        public enum CommandsDefinition { Select, Create, Update, Delete, InsertInto}
        public CommandsDefinition Command { get; set; }
        public string TableName { get; set; }
        public FieldOrder FieldOrder { get; set; }
        public Field Field { get; set; }
        public IDictionary<string, string> RawData { get; set; }
        public int Id { get; set; }
        public Payload Payload { get; set; }
        public string GetCommandName() => GetCommandName(Command);

        public string GetOrderName() => GetOrderName(FieldOrder.Order);

        #region switchers
        public string GetOrderName(FieldOrder.OrderDefinition order) => order switch
        {
            FieldOrder.OrderDefinition.NotSet => "",
            FieldOrder.OrderDefinition.Asc => "asc",
            FieldOrder.OrderDefinition.Desc => "desc",
            _ => throw new ArgumentOutOfRangeException(nameof(order), order, null)
        };

        public string GetCommandName(CommandsDefinition command) => command switch
        {
            CommandsDefinition.Select => "select",
            CommandsDefinition.Create => "create",
            CommandsDefinition.Update => "update",
            CommandsDefinition.Delete => "delete",
            CommandsDefinition.InsertInto => "insert into",
            _ => throw new ArgumentOutOfRangeException(nameof(command), command, null)
        };

        #endregion
    }
}
