namespace Cinteros.Xrm.StepsManipulator
{
    using System;
    using System.Linq;
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Query;

    public static class Extensions
    {
        public static Entity[] GetSdkMessageProcessingStepImages(this IOrganizationService service, Entity[] steps)
        {
            var query = new QueryExpression();
            query.EntityName = "sdkmessageprocessingstepimage";
            query.ColumnSet = new ColumnSet(true);
            query.Criteria = new FilterExpression(LogicalOperator.Or);

            foreach (var step in steps)
            {
                query.Criteria.AddCondition("sdkmessageprocessingstepid", ConditionOperator.Equal, (Guid)step["sdkmessageprocessingstepid"]);
            }

            return service.RetrieveMultiple(query).Entities.ToArray<Entity>();
        }

        public static Entity[] GetSdkMessageProcessingSteps(this IOrganizationService service)
        {
            var query = new QueryExpression();
            query.EntityName = "sdkmessageprocessingstep";
            query.ColumnSet = new ColumnSet(new string[] { "name", "sdkmessageprocessingstepid", "plugintypeid", "eventhandler" });
            query.Criteria = new FilterExpression(LogicalOperator.Or);
            query.Criteria.AddCondition("ishidden", ConditionOperator.Equal, false);
            query.Orders.Add(new OrderExpression("name", OrderType.Ascending)); 

            var link = new LinkEntity
                {
                    LinkFromEntityName = "sdkmessageprocessingstep",
                    LinkToEntityName = "plugintype",
                    LinkFromAttributeName = "plugintypeid",
                    LinkToAttributeName = "plugintypeid",
                    JoinOperator = JoinOperator.LeftOuter,
                    EntityAlias = "plugintype",
                    Columns = new ColumnSet(new string[] { "friendlyname", "typename" })
                };

            query.LinkEntities.Add(link);

            return service.RetrieveMultiple(query).Entities.ToArray<Entity>();
        }

        public static Entity[] GetPluginTypes(this IOrganizationService service, Entity plugin)
        {
            var query = new QueryExpression();
            query.EntityName = "plugintype";
            query.ColumnSet = new ColumnSet(true);
            query.Criteria = new FilterExpression(LogicalOperator.Or);
            query.Criteria.AddCondition("pluginassemblyid", ConditionOperator.Equal, (Guid)plugin["pluginassemblyid"]);

            return service.RetrieveMultiple(query).Entities.ToArray<Entity>();
        }

        public static Entity GetPluginAssembly(this IOrganizationService service, string name)
        {
            var query = new QueryExpression();

            query.EntityName = "pluginassembly";
            query.ColumnSet = new ColumnSet(true);
            query.Criteria = new FilterExpression();
            query.Criteria.AddCondition("name", ConditionOperator.Equal, name);

            return service.RetrieveMultiple(query).Entities.FirstOrDefault();
        }

        /// <summary>
        /// Gets all registered plugin assemblies in the current organization
        /// </summary>
        /// <param name="service"></param>
        /// <returns>Array of entitiies</returns>
        public static Entity[] GetPluginAssemblies(this IOrganizationService service)
        {
            var query = new QueryExpression();

            query.EntityName = "pluginassembly";
            query.ColumnSet = new ColumnSet(true);

            return service.RetrieveMultiple(query).Entities.ToArray<Entity>();
        }
    }
}
