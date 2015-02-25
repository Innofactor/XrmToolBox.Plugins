namespace Cinteros.Xrm.VersionVerifier.Utils
{
    using System.Collections.Generic;
    using System.Drawing;
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
            // query.ColumnSet = new ColumnSet(new string[] { Constants.Crm.Attributes.NAME, Constants.Crm.Attributes.VERSION });

            return query;
        }

        /// <summary>
        /// Creates cell in resulting grid
        /// </summary>
        /// <param name="reference"></param>
        /// <param name="current"></param>
        /// <returns></returns>
        public static ListViewItem.ListViewSubItem CreateCell<T>(List<T> reference, T current)
            where T : IComparableEntity
        {
            var cell = new ListViewItem.ListViewSubItem();

            // Reference solution
            if (reference == null)
            {
                cell.Text = current.Version.ToString();
                cell.BackColor = Color.White;
                cell.Tag = "Reference version";
            }
            else
            {
                // Solution is not present on target system
                if (current == null)
                {
                    cell.Text = Constants.U_ITEM_NA;
                    cell.ForeColor = Color.LightGray;
                    cell.BackColor = Color.White;
                    cell.Tag = "Item is unavailable on the target organization";
                }
                else
                {
                    cell.Text = current.Version.ToString();
                    // Solutioin is the same on both systems
                    if (reference.Exists(x => x.Version == current.Version))
                    {
                        cell.BackColor = Color.YellowGreen;
                        cell.Tag = "Item is unavailable on the target organization";
                    }
                    else
                    {
                        cell.BackColor = Color.Orange;
                    }
                }
            }
            return cell;
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
            query.ColumnSet = new ColumnSet(true);
            // query.ColumnSet = new ColumnSet(new string[] { Constants.Crm.Attributes.UNIQUE_NAME, Constants.Crm.Attributes.FRIENDLY_NAME, Constants.Crm.Attributes.VERSION, Constants.Crm.Attributes.IS_MANAGED });

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

        public static Solution[] LoadSolutionFile(string filename)
        {
            var document = new XmlDocument();
            document.Load(filename);

            return document.ToArray();
        }

        #endregion Public Methods

        #region Private Methods

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

        #endregion Private Methods
    }
}