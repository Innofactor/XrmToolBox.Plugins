namespace Cinteros.Xrm.SolutionVerifier.Utils
{
    using McTools.Xrm.Connection;
    using Microsoft.Xrm.Sdk.Query;
    using System;
    using System.Windows.Forms;
    using System.Xml;

    public static class Helpers
    {
        #region Public Methods

        /// <summary>
        /// Creates query expression that will get information about all solutions in the system
        /// </summary>
        /// <returns></returns>
        public static QueryExpression CreateSolutionsQuery()
        {
            var query = new QueryExpression(Constants.E_SOLUTION);
            query.Criteria = new FilterExpression();
            query.Criteria.AddCondition(Constants.A_IS_VISIBLE, ConditionOperator.Equal, true);
            query.Criteria.AddCondition(Constants.A_UNIQUE_NAME, ConditionOperator.NotEqual, Constants.U_SOLUTION_DEFAULT);
            query.ColumnSet = new ColumnSet(new string[] { Constants.A_UNIQUE_NAME, Constants.A_FRIENDLY_NAME, Constants.A_VERSION, Constants.A_IS_MANAGED });

            return query;
        }

        public static QueryExpression CreateAssembliesQuery(Guid solutionId)
        {
            var query = new QueryExpression(Constants.E_PLUGIN_ASSEMBLY);
            query.Criteria = new FilterExpression();
            query.Criteria.AddCondition(Constants.A_UNIQUE_NAME, ConditionOperator.NotEqual, Constants.U_SOLUTION_DEFAULT);
            query.ColumnSet = new ColumnSet(new string[] { Constants.A_UNIQUE_NAME, Constants.A_FRIENDLY_NAME, Constants.A_VERSION, Constants.A_IS_MANAGED });

            return query;
        }

        public static ListViewItem LoadItemConnection(ConnectionDetail connection)
        {
            var row = new string[] {
                connection.OrganizationFriendlyName,
                connection.ServerName,
            };

            var item = new ListViewItem(row);
            item.Tag = connection;

            return item;
        }

        public static Solution[] LoadSolutionFile(string filename)
        {
            var document = new XmlDocument();
            document.Load(filename);

            return document.ToArray();
        }

        #endregion Public Methods
    }
}