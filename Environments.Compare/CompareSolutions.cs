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

            var reference = matrix.First();

            foreach (var value in reference.Value)
            {
                var item = new ListViewItem(value.Attributes[]);
                item.SubItems.Add("ssssss");
                this.lvSolutions.Items.Add(item);
            }

        }

        #endregion Public Methods
    }
}