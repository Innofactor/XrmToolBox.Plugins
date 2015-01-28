namespace Cinteros.XrmToolbox.SolutionVerifier.Controls
{
    using Cinteros.XrmToolbox.SolutionVerifier.Utils;
    using System.Collections.Generic;
    using System.Drawing;
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
                        row.SubItems.Add(this.CreateCell(null, current));
                    }
                    else
                    {
                        row.SubItems.Add(this.CreateCell(reference, current));
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

        /// <summary>
        /// Creates cell in resulting grid
        /// </summary>
        /// <param name="reference"></param>
        /// <param name="current"></param>
        /// <returns></returns>
        private ListViewItem.ListViewSubItem CreateCell(List<Solution> reference, Solution current)
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

        #endregion Private Methods
    }
}