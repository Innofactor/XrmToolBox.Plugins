namespace Cinteros.Xrm.SolutionVerifier.Controls
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using Cinteros.Xrm.SolutionVerifier.SDK;
    using Cinteros.Xrm.SolutionVerifier.Utils;

    public partial class ViewResults : UserControl, IUpdateToolStrip
    {
        #region Public Constructors

        public ViewResults(OrganizationDetail[] matrix)
        {
            InitializeComponent();

            this.Matrix = matrix;

            this.JustifyToolStrip();
        }

        #endregion Public Constructors

        #region Public Events

        public event System.EventHandler<UpdateToolStripEventArgs> UpdateToolStrip;

        #endregion Public Events

        #region Public Properties

        public OrganizationDetail[] Matrix
        {
            set
            {
                this.AddListViewHeaders(value.Select(x => x.ConnectionDetail.OrganizationFriendlyName).ToArray<string>());

                foreach (var solution in value.First().Solutions)
                {
                    var row = new ListViewItem(solution.FriendlyName);
                    row.UseItemStyleForSubItems = false;

                    var reference = new List<Solution>();
                    var i = 0;

                    foreach (var item in value)
                    {
                        var current = item.Solutions.Where(x => solution.UniqueName.Equals(x.UniqueName)).FirstOrDefault<Solution>();

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
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Rises exceptions that updates buttons on toolbars
        /// </summary>
        public void JustifyToolStrip()
        {
            if (this.UpdateToolStrip != null)
            {
                this.UpdateToolStrip(this, new UpdateToolStripEventArgs(Constants.U_BACK_BUTTON, true));
                this.UpdateToolStrip(this, new UpdateToolStripEventArgs(Constants.U_SAVE_BUTTON, true));
                this.UpdateToolStrip(this, new UpdateToolStripEventArgs(Constants.U_COMPARE_BUTTON, false));
            }
        }

        #endregion Public Methods

        #region Private Methods

        private void AddListViewHeaders(string[] headers)
        {
            var header = new ColumnHeader();
            header.Text = Constants.U_HEADER_MAINTEXT;
            header.Width = Constants.U_HEADER_MAINWIDTH;
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
                    cell.Text = Constants.U_SOLUTION_NA;
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