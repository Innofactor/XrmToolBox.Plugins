namespace Cinteros.Xrm.VersionVerifier.Controls
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using Cinteros.Xrm.VersionVerifier.SDK;
    using Cinteros.Xrm.VersionVerifier.Utils;

    public partial class ViewResults : UserControl, IUpdateToolStrip
    {
        #region Public Constructors

        public ViewResults(OrganizationSnapshot[] matrix)
        {
            InitializeComponent();

            this.Matrix = matrix;

            this.JustifyToolStrip();
        }

        #endregion Public Constructors

        #region Public Events

        public event EventHandler<UpdateToolStripEventArgs> UpdateToolStrip;

        #endregion Public Events

        #region Public Properties

        public OrganizationSnapshot[] Matrix
        {
            get
            {
                return (OrganizationSnapshot[])this.lvMatrix.Tag;
            }
            set
            {
                this.AddListViewHeaders(value.Select(x => x.ConnectionDetail.OrganizationFriendlyName).ToArray<string>());
                this.lvMatrix.Tag = value;

                var solutionsGroup = new ListViewGroup(Constants.U_SOLUTIONS);
                this.lvMatrix.Groups.Add(solutionsGroup);

                var assembliesGroup = new ListViewGroup(Constants.U_ASSEMBLIES);
                this.lvMatrix.Groups.Add(assembliesGroup);

                foreach (var solution in value.First().Solutions)
                {
                    var row = new ListViewItem(solution.FriendlyName);
                    row.Group = solutionsGroup;
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
                    this.lvMatrix.Items.Add(row);
                }

                foreach (var assembly in value.First().Assemblies)
                {
                    var row = new ListViewItem(assembly.FriendlyName);
                    row.Group = assembliesGroup;
                    row.UseItemStyleForSubItems = false;

                    var reference = new List<PluginAssembly>();
                    var i = 0;

                    foreach (var item in value)
                    {
                        var current = item.Assemblies.Where(x => assembly.FriendlyName.Equals(x.FriendlyName)).FirstOrDefault<PluginAssembly>();

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
                    this.lvMatrix.Items.Add(row);
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
                this.UpdateToolStrip(this, new UpdateToolStripEventArgs(Constants.U_SAVE_BUTTON, true, tsbSave_Click));
                this.UpdateToolStrip(this, new UpdateToolStripEventArgs(Constants.U_COMPARE_BUTTON, false));
            }
        }

        #endregion Public Methods

        #region Private Methods

        private void AddListViewHeaders(string[] headers)
        {
            var header = new ColumnHeader();
            header.Width = Constants.U_HEADER_MAINWIDTH;
            this.lvMatrix.Columns.Add(header);

            foreach (var text in headers)
            {
                header = new ColumnHeader();
                header.Text = text;
                header.Width = 150;
                this.lvMatrix.Columns.Add(header);
            }
        }

        /// <summary>
        /// Creates cell in resulting grid
        /// </summary>
        /// <param name="reference"></param>
        /// <param name="current"></param>
        /// <returns></returns>
        private ListViewItem.ListViewSubItem CreateCell<T>(List<T> reference, T current)
            where T : IComparableEntity
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
                    cell.Text = Constants.U_ITEM_NA;
                    cell.ForeColor = Color.LightGray;
                    cell.BackColor = Color.White;
                    cell.Tag = "Item is unavailable on the target organization";
                }
                else
                {
                    cell.Text = current.Version.ToString();
                    // Solutioin is the same on both systems
                    if (reference.Exists(x => x.Version == current.Version))
                    {
                        cell.BackColor = Color.YellowGreen;
                        cell.Tag = "Item is unavailable on the target organization";
                    }
                    else
                    {
                        cell.BackColor = Color.Orange;
                    }
                }
            }
            return cell;
        }

        private void FileOk(object sender, CancelEventArgs e)
        {
            if (!e.Cancel)
            {
                this.Matrix.ToXml().Save(((SaveFileDialog)sender).FileName);
            }
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            var save = new SaveFileDialog();
            save.FileOk += this.FileOk;

            save.FileName = "comparison-matrix.xml";
            save.ShowDialog();
        }

        #endregion Private Methods
    }
}