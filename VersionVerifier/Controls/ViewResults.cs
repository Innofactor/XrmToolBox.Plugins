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

                var solutionsGroup = new ListViewGroup(Constants.UI.Labels.SOLUTIONS);
                this.lvMatrix.Groups.Add(solutionsGroup);

                var assembliesGroup = new ListViewGroup(Constants.UI.Labels.ASSEMBLIES);
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
                            row.SubItems.Add(Helpers.CreateCell(null, current));
                        }
                        else
                        {
                            row.SubItems.Add(Helpers.CreateCell(reference, current));
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
                            row.SubItems.Add(Helpers.CreateCell(null, current));
                        }
                        else
                        {
                            row.SubItems.Add(Helpers.CreateCell(reference, current));
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
                this.UpdateToolStrip(this, new UpdateToolStripEventArgs(Constants.UI.Buttons.BACK, true));
                this.UpdateToolStrip(this, new UpdateToolStripEventArgs(Constants.UI.Buttons.SAVE, true, tsbSave_Click));
                this.UpdateToolStrip(this, new UpdateToolStripEventArgs(Constants.UI.Buttons.COMPARE, false));
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