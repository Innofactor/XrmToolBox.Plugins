namespace Cinteros.Xrm.Common.Utils
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Xml;
    using Cinteros.Xrm.Common.SDK;
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Query;

    public static class Extensions
    {
        #region Public Methods

        public static Solution[] ToArray(this XmlDocument document)
        {
            var solutions = new List<Solution>();

            foreach (XmlElement element in document.DocumentElement.ChildNodes)
            {
                var solution = new Solution
                {
                    Version = new Version(element.Attributes[Constants.Xml.VERSION].Value),
                    UniqueName = element.Attributes[Constants.Xml.UNIQUE_NAME].Value,
                    FriendlyName = element.Attributes[Constants.Xml.FRIENDLY_NAME].Value
                };

                solutions.Add(solution);
            }

            return solutions.ToArray();
        }

        public static XmlDocument ToXml(this OrganizationSnapshot[] matrix)
        {
            var document = new XmlDocument();

            document.AppendChild(document.CreateXmlDeclaration("1.0", "UTF-8", "yes"));
            document.AppendChild(document.CreateComment("Comparison matrix"));

            var root = document.CreateElement("matrix");
            document.AppendChild(root);

            XmlElement element;
            XmlAttribute attribute;

            var solutions = document.CreateElement(Constants.Xml.SOLUTIONS);
            root.AppendChild(solutions);

            foreach (var solution in matrix[0].Solutions)
            {
                element = document.CreateElement(Constants.Xml.SOLUTION);

                attribute = document.CreateAttribute(Constants.Xml.UNIQUE_NAME);
                attribute.Value = solution.UniqueName;
                element.Attributes.Append(attribute);

                attribute = document.CreateAttribute(Constants.Xml.FRIENDLY_NAME);
                attribute.Value = solution.FriendlyName;
                element.Attributes.Append(attribute);

                attribute = document.CreateAttribute(Constants.Xml.VERSION);
                attribute.Value = solution.Version.ToString();
                element.Attributes.Append(attribute);

                solutions.AppendChild(element);
            }

            var assemblies = document.CreateElement(Constants.Xml.ASSEMBLIES);
            root.AppendChild(assemblies);

            foreach (var assembly in matrix[0].Assemblies)
            {
                element = document.CreateElement(Constants.Xml.ASSEMBLY);

                attribute = document.CreateAttribute(Constants.Xml.FRIENDLY_NAME);
                attribute.Value = assembly.FriendlyName;
                element.Attributes.Append(attribute);

                attribute = document.CreateAttribute(Constants.Xml.VERSION);
                attribute.Value = assembly.Version.ToString();
                element.Attributes.Append(attribute);

                assemblies.AppendChild(element);
            }

            return document;
        }

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
            query.Criteria.AddCondition(Constants.Crm.Attributes.IS_HIDDEN, ConditionOperator.Equal, false);

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
            //var attributes = new string[]
            //{
            //    Constants.Crm.Attributes.NAME,
            //    Constants.Crm.Attributes.STATE_CODE,
            //    Constants.Crm.Attributes.STATUS_CODE,
            //    "sdkmessageprocessingstepid",
            //    Constants.Crm.Attributes.PLUGIN_TYPE_ID,
            //    Constants.Crm.Attributes.EVENT_HANDLER
            //};

            var query = new QueryExpression();
            query.EntityName = Constants.Crm.Entities.PROCESSING_STEP;
            query.ColumnSet = new ColumnSet(true);
            query.Criteria = new FilterExpression(LogicalOperator.And);
            query.Criteria.AddCondition("ishidden", ConditionOperator.Equal, false);

            var sdkmessage = query.AddLink(Constants.Crm.Entities.MESSAGE, "sdkmessageid", "sdkmessageid");
            var sdkmessagefilter = query.AddLink(Constants.Crm.Entities.MESSAGE_FILTER, "sdkmessageid", "sdkmessageid");

            sdkmessage.Columns.AddColumns(Constants.Crm.Attributes.NAME, "sdkmessageid");
            sdkmessage.EntityAlias = "message";

            sdkmessagefilter.Columns.AddColumns(Constants.Crm.Attributes.PRIMARY_OBJECT_TYPE_CODE, "sdkmessagefilterid");
            sdkmessagefilter.EntityAlias = "filter";

            if (pluginTypeId != null && pluginTypeId != Guid.Empty)
            {
                query.Criteria.AddCondition(Constants.Crm.Attributes.PLUGIN_TYPE_ID, ConditionOperator.Equal, pluginTypeId);
            }

            query.Orders.Add(new OrderExpression(Constants.Crm.Attributes.NAME, OrderType.Ascending));

            if (pluginAssemblyId != null && pluginAssemblyId != Guid.Empty)
            {
                var link = new LinkEntity
                {
                    LinkFromEntityName = Constants.Crm.Entities.PROCESSING_STEP,
                    LinkToEntityName = Constants.Crm.Entities.PLUGIN_TYPE,
                    LinkFromAttributeName = Constants.Crm.Attributes.PLUGIN_TYPE_ID,
                    LinkToAttributeName = Constants.Crm.Attributes.PLUGIN_TYPE_ID,
                    JoinOperator = JoinOperator.Natural,
                    EntityAlias = Constants.Crm.Entities.PLUGIN_TYPE,
                    Columns = new ColumnSet(new string[] { Constants.Crm.Attributes.FRIENDLY_NAME, "typename", "pluginassemblyid" }),
                };

                link.LinkCriteria.AddCondition("pluginassemblyid", ConditionOperator.Equal, pluginAssemblyId);

                query.LinkEntities.Add(link);
            }

            return service.RetrieveMultiple(query).Entities.ToArray<Entity>();
        }


        #endregion Public Methods
    }
}