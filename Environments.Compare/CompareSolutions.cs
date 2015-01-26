namespace Environments.Compare
{
    using Environments.Compare.Utils;
    using Microsoft.Xrm.Sdk;
    using System;
    using System.Collections.Generic;
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

            foreach (var solution in matrix.First().Value.ToArray<Entity>().Select(x => (string)x.Attributes[Constants.A_FRIENDLYNAME]).ToArray<string>())
            {
                var row = new ListViewItem(solution);
                row.UseItemStyleForSubItems = false;

                var reference = new Dictionary<string, Version>();
                var i = 0;

                foreach (var item in matrix)
                {
                    var version = Helpers.CreateVersion(solution, item.Value);

                    if (i++ == 0)
                    {
                        reference.Add(solution, version);
                        row.SubItems.Add(Helpers.CreateCell(null, version));
                    }
                    else
                    {
                        row.SubItems.Add(Helpers.CreateCell(reference[solution], version));
                    }
                }
                this.lvSolutions.Items.Add(row);
            }
        }

        #endregion Public Methods

        #region Private Methods

        private void AddListViewHeaders(Dictionary<string, Entity[]> matrix)
        {
            var header = new ColumnHeader();
            header.Text = Constants.HEADER_MAINTEXT;
            header.Width = Constants.HEADER_MAINWIDTH;
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