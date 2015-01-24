namespace Environments.Compare
{
    using Microsoft.Xrm.Sdk;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using System.Linq;

    public partial class CompareSolutions : UserControl
    {
        #region Public Constructors

        public CompareSolutions()
        {
            InitializeComponent();
        }

        #endregion Public Constructors

        #region Public Methods

        public void FillWithData(Dictionary<string, List<Entity>> matrix)
        {
            var reference = matrix.First();

            string[] solutions = new string[reference.Value.Count];
            string[] versions = new string[reference.Value.Count];
            string[] headers = new string[matrix.Keys.Count + 1];
            int[] sizes = new int [matrix.Keys.Count + 1];

            this.AddListViewHeaders(matrix);

            foreach (var value in reference.Value)
            {
                var item = new ListViewItem((string)value.Attributes["friendlyname"]);
                item.SubItems.Add((string)value.Attributes["version"]);
                this.lvSolutions.Items.Add(item);
            }

        }

        private void AddListViewHeaders(Dictionary<string, List<Entity>> matrix)
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

        #endregion Public Methods
    }
}