namespace Cinteros.Xrm.StepsManipulator
{
    using System;
    using System.Linq;
    using Cinteros.Xrm.Utils;
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Query;

    public static class Extensions
    {
        #region Public Methods

        /// <summary>
        /// Gets all registered plugin assemblies in the current organization
        /// </summary>
        /// <param name="service"></param>
        /// <returns>Array of entitiies representing plugin assemblies</returns>
        public static Entity[] GetPluginAssemblies(this IOrganizationService service)
        {
            var query = new QueryExpression();

            query.EntityName = Constants.Crm.Entities.PLUGIN_ASSEMBLY;
            query.ColumnSet = new ColumnSet(new string[] { Constants.Crm.Attributes.NAME, Constants.Crm.Attributes.VERSION, Constants.Crm.Attributes.CULTURE, Constants.Crm.Attributes.PUBLIC_KEY_TOKEN });
            query.Criteria = new FilterExpression();
            query.Criteria.AddCondition("ishidden", ConditionOperator.Equal, false);

            return service.RetrieveMultiple(query).Entities.ToArray<Entity>();
        }

        /// <summary>
        /// Gets plugin assembly registered in current organization
        /// </summary>
        /// <param name="service"></param>
        /// <param name="name">Name of the plugin assembly to rertrieve</param>
        /// <returns>Plugin assembly entity</returns>
        public static Entity GetPluginAssembly(this IOrganizationService service, string name)
        {
            var query = new QueryExpression();

            query.EntityName = Constants.Crm.Entities.PLUGIN_ASSEMBLY;
            query.ColumnSet = new ColumnSet(true);
            query.Criteria = new FilterExpression();
            query.Criteria.AddCondition(Constants.Crm.Attributes.NAME, ConditionOperator.Equal, name);

            return service.RetrieveMultiple(query).Entities.FirstOrDefault();
        }

        public static Entity[] GetPluginTypes(this IOrganizationService service, Guid pluginAssemblyId)
        {
            var query = new QueryExpression();
            query.EntityName = Constants.Crm.Entities.PLUGIN_TYPE;
            query.ColumnSet = new ColumnSet(true);
            query.Criteria = new FilterExpression(LogicalOperator.Or);
            query.Criteria.AddCondition("pluginassemblyid", ConditionOperator.Equal, pluginAssemblyId);

            return service.RetrieveMultiple(query).Entities.ToArray<Entity>();
        }

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

        public static Entity[] GetSdkMessageProcessingSteps(this IOrganizationService service, Guid? pluginAssemblyId = null, Guid? pluginTypeId = null)
        {
            var query = new QueryExpression();
            query.EntityName = Constants.Crm.Entities.PROCESSING_STEP;
            query.ColumnSet = new ColumnSet(new string[] { Constants.Crm.Attributes.NAME, "sdkmessageprocessingstepid", "plugintypeid", "eventhandler" });
            query.Criteria = new FilterExpression(LogicalOperator.And);
            query.Criteria.AddCondition("ishidden", ConditionOperator.Equal, false);
            
            if (pluginTypeId != null)
            {
                query.Criteria.AddCondition("plugintypeid", ConditionOperator.Equal, pluginTypeId);
            }
            query.Orders.Add(new OrderExpression(Constants.Crm.Attributes.NAME, OrderType.Ascending));

            var link = new LinkEntity
            {
                LinkFromEntityName = Constants.Crm.Entities.PROCESSING_STEP,
                LinkToEntityName = Constants.Crm.Entities.PLUGIN_TYPE,
                LinkFromAttributeName = "plugintypeid",
                LinkToAttributeName = "plugintypeid",
                JoinOperator = JoinOperator.Natural,
                EntityAlias = "plugintype",
                Columns = new ColumnSet(new string[] { "friendlyname", "typename", "pluginassemblyid" }),
            };

            if (pluginAssemblyId != null)
            {
                link.LinkCriteria.AddCondition("pluginassemblyid", ConditionOperator.Equal, pluginAssemblyId);
            }

            query.LinkEntities.Add(link);

            return service.RetrieveMultiple(query).Entities.ToArray<Entity>();
        }

        #endregion Public Methods
    }
}