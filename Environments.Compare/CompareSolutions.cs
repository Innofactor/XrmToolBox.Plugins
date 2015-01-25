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
                    var version = item.Value.Where(x => solution.Equals((string)x.Attributes["friendlyname"])).Select(x => (string)x.Attributes["version"]).FirstOrDefault();
                    if (i++ == 0)
                    {
                        reference.Add(solution, new Version(version));
                    }

                    row.SubItems.Add(this.CreateCell(row, reference[solution], version));
                }
                this.lvSolutions.Items.Add(row);
            }
        }

        private ListViewItem.ListViewSubItem CreateCell(ListViewItem row, Version reference, string version)
        {
            var cell = new ListViewItem.ListViewSubItem(row, version);

            if (version != null)
            {
                if (reference != new Version(version))
                {
                    cell.BackColor = Color.Red;
                }
                else
                {
                    cell.BackColor = Color.YellowGreen;
                }
            }
            else
            {
                cell.BackColor = Color.Gainsboro;
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