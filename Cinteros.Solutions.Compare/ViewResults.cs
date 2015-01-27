namespace Cinteros.Solutions.Compare
{
    using Cinteros.Solutions.Compare.Utils;
    using Microsoft.Xrm.Sdk;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;

    public partial class ViewResults : UserControl
    {

        #region Public Constructors

        public ViewResults()
        {
            InitializeComponent();
        }

        #endregion Public Constructors

        #region Public Methods

        public void Set(Dictionary<string, Solution[]> matrix)
        {
            this.AddListViewHeaders(matrix.Keys.ToArray<string>());

            foreach (var solution in matrix.First().Value)
            {
                var row = new ListViewItem(solution.FriendlyName);
                row.UseItemStyleForSubItems = false;

                var reference = new List<Solution>();
                var i = 0;

                foreach (var item in matrix)
                {
                    var current = item.Value.Where(x => solution.UniqueName.Equals(x.UniqueName)).FirstOrDefault<Solution>();

                    if (i++ == 0)
                    {
                        reference.Add(current);
                        row.SubItems.Add(Helpers.CreateCell(null, current));
                    }
                    else
                    {
                        row.SubItems.Add(Helpers.CreateCell(reference, current));
                    }
                    
                }
                this.lvSolutions.Items.Add(row);
            }
        }

        #endregion Public Methods

        #region Private Methods

        private void AddListViewHeaders(string[] headers)
        {
            var header = new ColumnHeader();
            header.Text = Constants.HEADER_MAINTEXT;
            header.Width = Constants.HEADER_MAINWIDTH;
            this.lvSolutions.Columns.Add(header);

            foreach (var text in headers)
            {
                header = new ColumnHeader();
                header.Text = text;
                header.Width = 150;
                this.lvSolutions.Columns.Add(header);
            }
        }

        #endregion Private Methods

    }
}