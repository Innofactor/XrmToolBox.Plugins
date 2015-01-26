namespace Cinteros.Solutions.Compare
{
    using Cinteros.Solutions.Compare.Utils;
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

            foreach (var solution in matrix.First().Value.ToArray<Entity>().Select(x => new Solution(x)).ToArray<Solution>())
            {
                var row = new ListViewItem(solution.FriendlyName);
                row.UseItemStyleForSubItems = false;

                var reference = new List<Solution>();
                var i = 0;

                foreach (var item in matrix)
                {
                    var current = item.Value.Where(x => solution.UniqueName.Equals((string)x.Attributes[Constants.A_UNIQUENAME])).Select(x => new Solution(x)).FirstOrDefault<Solution>();

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