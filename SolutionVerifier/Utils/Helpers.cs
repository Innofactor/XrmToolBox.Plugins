namespace Cinteros.Xrm.SolutionVerifier.Utils
{
    using McTools.Xrm.Connection;
    using Microsoft.Xrm.Sdk.Query;
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
            query.Criteria.AddCondition(Constants.A_ISVISIBLE, ConditionOperator.Equal, true);
            query.Criteria.AddCondition(Constants.A_UNIQUENAME, ConditionOperator.NotEqual, Constants.U_SOLUTION_DEFAULT);
            query.ColumnSet = new ColumnSet(new string[] { Constants.A_UNIQUENAME, Constants.A_FRIENDLYNAME, Constants.A_VERSION, Constants.A_ISMANAGED });

            return query;
        }

        public static ListViewItem LoadItemConnection(ConnectionDetail connection)
        {
            var row = new string[] {
                connection.OrganizationFriendlyName,
                connection.OrganizationServiceUrl,
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