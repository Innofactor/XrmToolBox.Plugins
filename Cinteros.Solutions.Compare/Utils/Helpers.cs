namespace Cinteros.Solutions.Compare.Utils
{
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Query;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;

    public static class Helpers
    {
        #region Public Methods

        /// <summary>
        /// Creates cell in resulting grid
        /// </summary>
        /// <param name="reference"></param>
        /// <param name="current"></param>
        /// <returns></returns>
        public static ListViewItem.ListViewSubItem CreateCell(List<Solution> reference, Solution current)
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
                    cell.Text = Constants.SOLUTION_NA;
                    cell.ForeColor = Color.LightGray;
                    cell.BackColor = Color.White;
                    cell.Tag = "Solution is unavailable on the target organization";
                }
                else
                {
                    cell.Text = current.Version.ToString();
                    // Solutioin is the same on both systems
                    if (reference.Exists(x => x.Version == current.Version))
                    {
                        cell.BackColor = Color.YellowGreen;
                        cell.Tag = "Solution is unavailable on the target organization";
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
            var query = new QueryExpression(Constants.E_SOLUTION);
            query.Criteria = new FilterExpression();
            query.Criteria.AddCondition(Constants.A_ISVISIBLE, ConditionOperator.Equal, true);
            query.Criteria.AddCondition(Constants.A_UNIQUENAME, ConditionOperator.NotEqual, Constants.SOLUTION_DEFAULT);
            query.ColumnSet = new ColumnSet(new string[] { Constants.A_UNIQUENAME, Constants.A_FRIENDLYNAME, Constants.A_VERSION, Constants.A_ISMANAGED });

            return query;
        }

        public static ToolStripButton GetCompareSolutionButton(UserControl sender)
        {
            var menu = sender.Parent.Controls.Find("tsMenu", true).Cast<ToolStrip>().FirstOrDefault();

            if (menu != null)
            {
                return menu.Items.Find("tsbCompareSolutions", true).Cast<ToolStripButton>().FirstOrDefault();
            }

            return null;
        }

        #endregion Public Methods
    }
}