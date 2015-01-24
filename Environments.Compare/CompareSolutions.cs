namespace Environments.Compare
{
    using Microsoft.Xrm.Sdk;
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

            foreach (var solution in matrix.First().Value.ToArray<Entity>().Select(x => (string)x.Attributes["friendlyname"]).ToArray<string>())
            {
                var row = new ListViewItem(solution);
                foreach (var item in matrix)
                {
                    row.SubItems.Add(item.Value.Where(x => solution.Equals((string)x.Attributes["friendlyname"])).Select(x => (string)x.Attributes["version"]).FirstOrDefault());
                }
                this.lvSolutions.Items.Add(row);
            }
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