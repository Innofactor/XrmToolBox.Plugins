namespace Environments.Compare
{
    using Microsoft.Xrm.Sdk;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;

    public partial class CompareSolutions : UserControl
    {
        #region Public Constructors

        public CompareSolutions()
        {
            InitializeComponent();
        }

        #endregion Public Constructors

        #region Public Methods

        public void Set(Dictionary<string, Entity[]> matrix)
        {
            this.AddListViewHeaders(matrix);

            foreach (var solution in matrix.First().Value.ToArray<Entity>().Select(x => (string)x.Attributes["friendlyname"]).ToArray<string>())
            {
                var row = new ListViewItem(solution);
                row.UseItemStyleForSubItems = false;

                var reference = new Dictionary<string, Version>();
                var i = 0;

                foreach (var item in matrix)
                {
                    Version version = this.CreateVersion(solution, item.Value);

                    if (i++ == 0)
                    {
                        reference.Add(solution, version);
                        row.SubItems.Add(this.CreateCell(null, version));
                    }
                    else
                    {
                        row.SubItems.Add(this.CreateCell(reference[solution], version));
                    }
                }
                this.lvSolutions.Items.Add(row);
            }
        }

        /// <summary>
        /// Searches for given solution in the collection of solutions in given system
        /// </summary>
        /// <param name="solution"></param>
        /// <param name="collection"></param>
        /// <returns>Instance of .NET version class</returns>
        private Version CreateVersion(string solution, Entity[] collection)
        {
            Version version = null;

            try
            {
                var text = collection.Where(x => solution.Equals((string)x.Attributes["friendlyname"])).Select(x => (string)x.Attributes["version"]).FirstOrDefault();

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

        private ListViewItem.ListViewSubItem CreateCell(Version reference, Version version)
        {
            var cell = new ListViewItem.ListViewSubItem();
            cell.Text = version.ToString();

            // Reference solution
            if (reference == null)
            {
                cell.BackColor = Color.White;
            }
            else
            {
                // Solution is not present on target system
                if (version == null)
                {
                    cell.BackColor = Color.Gainsboro;
                }
                else
                {
                    // Solutioin is the same on both systems
                    if (reference == version)
                    {
                        cell.BackColor = Color.YellowGreen;
                    }
                    // Solution on target system is older
                    else if (reference > version)
                    {
                        cell.BackColor = Color.Salmon;
                    }
                    // Solution on target system is 
                    else if (reference < version)
                    {
                        cell.BackColor = Color.Orange;
                    }
                }
            }
            return cell;
        }

        #endregion Public Methods

        #region Private Methods

        private void AddListViewHeaders(Dictionary<string, Entity[]> matrix)
        {
            var header = new ColumnHeader();
            header.Text = "Solution Name / Organization";
            header.Width = 200;
            this.lvSolutions.Columns.Add(header);

            foreach (var key in matrix.Keys)
            {
                header = new ColumnHeader();
                header.Text = key;
                header.Width = 150;
                this.lvSolutions.Columns.Add(header);
            }
        }

        #endregion Private Methods
    }
}