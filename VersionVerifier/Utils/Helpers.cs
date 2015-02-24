namespace Cinteros.Xrm.VersionVerifier.Utils
{
    using System.Security.Principal;
    using System.Text;
    using System.Windows.Forms;
    using System.Xml;
    using Cinteros.Xrm.VersionVerifier.SDK;
    using McTools.Xrm.Connection;
    using Microsoft.Xrm.Sdk.Query;

    public static class Helpers
    {
        #region Public Methods

        public static QueryExpression CreateAssembliesQuery()
        {
            var query = new QueryExpression(Constants.Crm.Entities.PLUGIN_ASSEMBLY);
            query.Criteria = new FilterExpression();
            query.Criteria.AddCondition(Constants.Crm.Attributes.IS_HIDDEN, ConditionOperator.Equal, false);
            query.ColumnSet = new ColumnSet(true);
            query.ColumnSet = new ColumnSet(new string[] { Constants.Crm.Attributes.NAME, Constants.Crm.Attributes.SOLUTION_ID, Constants.Crm.Attributes.VERSION });

            return query;
        }

        /// <summary>
        /// Creates query expression that will get information about all solutions in the system
        /// </summary>
        /// <returns></returns>
        public static QueryExpression CreateSolutionsQuery()
        {
            var query = new QueryExpression(Constants.Crm.Entities.SOLUTION);
            query.Criteria = new FilterExpression();
            query.Criteria.AddCondition(Constants.Crm.Attributes.IS_VISIBLE, ConditionOperator.Equal, true);
            query.Criteria.AddCondition(Constants.Crm.Attributes.UNIQUE_NAME, ConditionOperator.NotEqual, Constants.U_SOLUTION_DEFAULT);
            query.ColumnSet = new ColumnSet(new string[] { Constants.Crm.Attributes.UNIQUE_NAME, Constants.Crm.Attributes.FRIENDLY_NAME, Constants.Crm.Attributes.VERSION, Constants.Crm.Attributes.IS_MANAGED });

            return query;
        }

        public static void FillListView<T>(T[] sourceItems, ListView listView, ListViewGroup listViewGroup) where T : IComparableEntity
        {
            foreach (var sourceItem in sourceItems)
            {
                var row = new string[] {
                        sourceItem.FriendlyName,
                        sourceItem.Version.ToString(),
                    };

                var item = new ListViewItem(row);
                item.Group = listViewGroup;
                item.Tag = sourceItem;

                listView.Items.Add(item);
            }
        }

        public static ListViewItem LoadItemConnection(ConnectionDetail connection)
        {
            var row = new string[] {
                connection.OrganizationFriendlyName,
                Helpers.GetCredentials(connection),
            };

            var item = new ListViewItem(row);
            item.Tag = connection;

            return item;
        }

        private static string GetCredentials(ConnectionDetail connection)
        {
            if (string.IsNullOrEmpty(connection.UserName))
            {
                return WindowsIdentity.GetCurrent().Name;
            }
            else
            {
                var builder = new StringBuilder();

                if (!string.IsNullOrEmpty(connection.UserDomain))
                {
                    builder.Append(connection.UserDomain);
                    builder.Append("\\");
                }
                builder.Append(connection.UserName);

                return builder.ToString();
            }
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