namespace Cinteros.XrmToolbox.SolutionVerifier.Utils
{
    using Microsoft.Xrm.Sdk.Query;
    using System.Windows.Forms;
    using System.Xml;
    using System.Linq;
    using McTools.Xrm.Connection;

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
            query.Criteria.AddCondition(Constants.A_UNIQUENAME, ConditionOperator.NotEqual, Constants.SOLUTION_DEFAULT);
            query.ColumnSet = new ColumnSet(new string[] { Constants.A_UNIQUENAME, Constants.A_FRIENDLYNAME, Constants.A_VERSION, Constants.A_ISMANAGED });

            return query;
        }

        public static Solution[] LoadSolutionFile(string filename)
        {
            var document = new XmlDocument();
            document.Load(filename);

            return document.ToArray();
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

        public static ToolStripButton FindToolStripButton(Control sender, string name)
        {
            var menu = sender.Parent.Controls.Find("tsMenu", true).Cast<ToolStrip>().FirstOrDefault();

            return (menu != null) ? menu.Items.Find(name, true).Cast<ToolStripButton>().FirstOrDefault() : null;
        }

        #endregion Public Methods
    }
}