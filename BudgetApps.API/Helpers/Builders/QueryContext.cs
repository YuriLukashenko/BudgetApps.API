using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApps.API.Helpers.FieldComponents;

namespace BudgetApps.API.Helpers.Builders
{
    public class QueryContext
    {
        public enum CommandsDefinition { Select, Create, Update, Delete}
        public CommandsDefinition Command { get; set; }
        public string TableName { get; set; }
        public FieldOrder FieldOrder { get; set; }
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
            _ => throw new ArgumentOutOfRangeException(nameof(command), command, null)
        };

        #endregion
    }
}
