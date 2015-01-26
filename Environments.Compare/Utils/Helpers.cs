namespace Cinteros.Solutions.Compare.Utils
{
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Query;
    using System;
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
        /// <param name="version"></param>
        /// <returns></returns>
        public static ListViewItem.ListViewSubItem CreateCell(Version reference, Version version)
        {
            var cell = new ListViewItem.ListViewSubItem();

            // Reference solution
            if (reference == null)
            {
                cell.Text = version.ToString();
                cell.BackColor = Color.White;
            }
            else
            {
                // Solution is not present on target system
                if (version == null)
                {
                    cell.Text = Constants.SOLUTION_NA;
                    cell.ForeColor = Color.LightGray;
                    cell.BackColor = Color.White;
                }
                else
                {
                    cell.Text = version.ToString();
                    // Solutioin is the same on both systems
                    if (reference == version)
                    {
                        cell.BackColor = Color.YellowGreen;
                    }
                    else
                    {
                        cell.BackColor = Color.Orange;
                    }
                }
            }
            return cell;
        }

        public static QueryExpression CreateSolutionsQuery()
        {
            var query = new QueryExpression(Constants.E_SOLUTION);
            query.Criteria = new FilterExpression();
            query.Criteria.AddCondition(Constants.A_ISVISIBLE, ConditionOperator.Equal, true);
            query.Criteria.AddCondition(Constants.A_UNIQUENAME, ConditionOperator.NotEqual, Constants.SOLUTION_DEFAULT);
            query.ColumnSet = new ColumnSet(new string[] { Constants.A_UNIQUENAME, Constants.A_FRIENDLYNAME, Constants.A_VERSION, Constants.A_ISMANAGED });

            return query;
        }

        /// <summary>
        /// Searches for given solution in the collection of solutions in given system
        /// </summary>
        /// <param name="solution"></param>
        /// <param name="collection"></param>
        /// <returns>Instance of .NET version class</returns>
        public static Version CreateVersion(string solution, Entity[] collection)
        {
            Version version = null;

            try
            {
                var text = collection.Where(x => solution.Equals((string)x.Attributes[Constants.A_FRIENDLYNAME])).Select(x => (string)x.Attributes[Constants.A_VERSION]).FirstOrDefault();

                if (text != null)
                {
                    version = new Version(text);
                }
            }
            catch (ArgumentException ex)
            {
                // Hiding exception, in this case null will be returned
            }

            return version;
        }

        #endregion Public Methods
    }
}