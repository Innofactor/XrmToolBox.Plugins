namespace Cinteros.Xrm.VersionVerifier.Controls
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Forms;
    using Cinteros.Xrm.VersionVerifier.SDK;
    using Cinteros.Xrm.VersionVerifier.Utils;
    using McTools.Xrm.Connection;
    using XrmToolBox;

    public partial class ViewParameters : UserControl, IUpdateToolStrip
    {

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewParameters"/> class.
        /// </summary>
        public ViewParameters()
        {
            InitializeComponent();

            this.ParentChanged += this.ViewParameters_ParentChanged;
        }

        #endregion Public Constructors

        #region Public Events

        public event EventHandler<UpdateToolStripEventArgs> UpdateToolStrip;

        #endregion Public Events

        #region Public Properties

        /// <summary>
        /// Gets or sets array of organization to compare
        /// </summary>
        public ConnectionDetail[] Organizations
        {
            get
            {
                return this.lvOrganizations.CheckedItems.Cast<ListViewItem>().ToArray().Select(x => (ConnectionDetail)x.Tag).ToArray<ConnectionDetail>();
            }
            set
            {
                this.lvOrganizations.ItemChecked -= this.lvOrganizations_ItemChecked;
                this.lvOrganizations.Items.Clear();

                var servers = value.GroupBy(x => x.ServerName).Select(x => new ListViewGroup(x.Key)).ToArray();
                this.lvOrganizations.Groups.AddRange(servers);

                foreach (var connection in value)
                {
                    var item = Helpers.LoadItemConnection(connection);
                    item.Group = servers.Where(x => x.Header == connection.ServerName).FirstOrDefault();

                    this.lvOrganizations.Items.Add(item);
                }
                this.lvOrganizations.ItemChecked += this.lvOrganizations_ItemChecked;
            }
        }

        /// <summary>
        /// Gets or sets organization snapshot
        /// </summary>
        public OrganizationSnapshot Snapshot
        {
            get
            {
                return (this.lvSnapshot.Tag == null) ? new OrganizationSnapshot() : (OrganizationSnapshot)this.lvSnapshot.Tag;
            }
            set
            {
                this.lvSnapshot.ItemChecked -= this.lvSnapshot_ItemChecked;
                this.lvSnapshot.Items.Clear();
                this.lvSnapshot.Tag = value;

                var solutionsGroup = new ListViewGroup(Constants.UI.Labels.SOLUTIONS);
                this.lvSnapshot.Groups.Add(solutionsGroup);

                var assembliesGroup = new ListViewGroup(Constants.UI.Labels.ASSEMBLIES);
                this.lvSnapshot.Groups.Add(assembliesGroup);

                Helpers.FillListView(value.Solutions, this.lvSnapshot, solutionsGroup);
                Helpers.FillListView(value.Assemblies, this.lvSnapshot, assembliesGroup);

                this.lvSnapshot.ItemChecked += this.lvSnapshot_ItemChecked;
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
                this.UpdateToolStrip(this, new UpdateToolStripEventArgs(Constants.UI.Buttons.OPEN, true));
                this.UpdateToolStrip(this, new UpdateToolStripEventArgs(Constants.UI.Buttons.OPEN_CURRENT_CONNECTION, false));
                this.UpdateToolStrip(this, new UpdateToolStripEventArgs(Constants.UI.Buttons.SAVE, this.lvSnapshot.CheckedItems.Count > 0, tsbSave_Click));
                this.UpdateToolStrip(this, new UpdateToolStripEventArgs(Constants.UI.Buttons.COMPARE, this.lvSnapshot.CheckedItems.Count > 0 && this.lvOrganizations.CheckedItems.Count > 0));
            }
        }

        #endregion Public Methods

        #region Private Methods

        private void cbToggleOrganizations_CheckedChanged(object sender, EventArgs e)
        {
            var cb = (CheckBox)sender;

            this.lvOrganizations.ItemChecked -= lvOrganizations_ItemChecked;
            foreach (var item in this.lvOrganizations.Items.Cast<ListViewItem>().ToArray())
            {
                item.Checked = cb.Checked;
            }
            this.lvOrganizations.ItemChecked += lvOrganizations_ItemChecked;

            this.JustifyToolStrip();
        }

        private void cbToggleSolutions_CheckedChanged(object sender, EventArgs e)
        {
            var cb = (CheckBox)sender;

            this.lvSnapshot.ItemChecked -= lvSnapshot_ItemChecked;
            foreach (var item in this.lvSnapshot.Items.Cast<ListViewItem>().ToArray())
            {
                item.Checked = cb.Checked;
            }
            this.lvSnapshot.ItemChecked += lvSnapshot_ItemChecked;

            this.JustifyToolStrip();
        }

        private void FileOk(object sender, CancelEventArgs e)
        {
            if (!e.Cancel)
            {
                this.Snapshot.ToXml().Save(((SaveFileDialog)sender).FileName);
            }
        }

        /// <summary>
        /// Event handler capturing changes in organization selections
        /// </summary>
        /// <param name="sender">Organizations list view</param>
        /// <param name="e">Event arguments</param>
        private void lvOrganizations_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            this.cbToggleOrganizations.CheckedChanged -= this.cbToggleOrganizations_CheckedChanged;
            this.UpdateSwitcher((ListView)sender, this.cbToggleOrganizations, e.Item.Checked);
            this.cbToggleOrganizations.CheckedChanged += this.cbToggleOrganizations_CheckedChanged;

            this.JustifyToolStrip();
        }

        /// <summary>
        /// Event handler capturing changes in organization selections
        /// </summary>
        /// <param name="sender">Organizations list view</param>
        /// <param name="e">Event arguments</param>
        private void lvOrganizations_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            var list = (ListView)sender;

            foreach (var item in list.Items.Cast<ListViewItem>().Where(x => x.Selected == true))
            {
                item.Checked = !item.Checked;
            }

            this.JustifyToolStrip();
        }

        /// <summary>
        /// Event handler capturing changes in solution selections
        /// </summary>
        /// <param name="sender">Solutions list view</param>
        /// <param name="e">Event arguments</param>
        private void lvSnapshot_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            this.cbToggleSolutions.CheckedChanged -= this.cbToggleSolutions_CheckedChanged;
            this.UpdateSwitcher((ListView)sender, this.cbToggleSolutions, e.Item.Checked);
            this.cbToggleSolutions.CheckedChanged += this.cbToggleSolutions_CheckedChanged;

            this.JustifyToolStrip();
        }

        /// <summary>
        /// Event handler capturing changes in solution selections
        /// </summary>
        /// <param name="sender">Solutions list view</param>
        /// <param name="e">Event arguments</param>
        private void lvSnapshot_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            var list = (ListView)sender;

            foreach (var item in list.Items.Cast<ListViewItem>().Where(x => x.Selected == true))
            {
                item.Checked = !item.Checked;
            }

            this.JustifyToolStrip();
        }

        /// <summary>
        /// Updating list of solutions from connection provided by XrmToolBox plugin class
        /// </summary>
        /// <param name="plugin">XrmToolBox plugin class</param>
        private void RetrieveSnapshot(MainControl plugin)
        {
            plugin.WorkAsync(string.Format("Getting solutions information from '{0}'...", plugin.ConnectionDetail.OrganizationFriendlyName),
                (e) => // Work To Do Asynchronously
                {
                    if (string.IsNullOrEmpty(plugin.ConnectionDetail.ServerName))
                    {
                        e.Result = new OrganizationSnapshot(plugin.ConnectionDetail.OrganizationServiceUrl); //Helpers.LoadSolutionFile(plugin.ConnectionDetail.OrganizationServiceUrl);
                    }
                    else
                    {
                        e.Result = new OrganizationSnapshot(plugin.ConnectionDetail);
                    }
                },
                (a) =>  // Cleanup when work has completed
                {
                    this.Snapshot = (OrganizationSnapshot)a.Result;
                }
            );
        }
        private void tsbSave_Click(object sender, EventArgs e)
        {
            var save = new SaveFileDialog();
            save.FileOk += this.FileOk;

            save.FileName = "reference-snapshot.xml";
            save.ShowDialog();
        }

        /// <summary>
        /// Updates 'Select all' button, depending on currently checked items
        /// </summary>
        /// <param name="list"></param>
        /// <param name="switcher"></param>
        /// <param name="status"></param>
        private void UpdateSwitcher(ListView list, CheckBox switcher, bool status)
        {
            if (!status)
            {
                switcher.Checked = false;
            }
            else
            {
                if (list.CheckedItems.Count == list.Items.Count)
                {
                    switcher.Checked = true;
                }
            }
        }

        private void ViewParameters_ConnectionUpdated(object sender, PluginBase.ConnectionUpdatedEventArgs e)
        {
            if (e.ConnectionDetail != null && !string.IsNullOrEmpty(e.ConnectionDetail.OrganizationServiceUrl))
            {
                this.RetrieveSnapshot((MainControl)sender);
                if (e.ConnectionDetail != null)
                {
                    this.gbSnapshot.Text = e.ConnectionDetail.OrganizationFriendlyName;
                }
            }
        }

        /// <summary>
        /// Event handler capturing when parent control is changed (current conntrol is beeing added
        /// to the plugin's main form)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewParameters_ParentChanged(object sender, EventArgs e)
        {
            var parent = (MainControl)this.Parent;

            if (parent != null)
            {
                parent.ConnectionUpdated += ViewParameters_ConnectionUpdated;

                if (parent.ConnectionDetail != null)
                {
                    this.RetrieveSnapshot(parent);

                    // All connections except currently connected one
                    this.Organizations = (ConnectionManager.Instance.ConnectionsList.Connections.Where(x => x.ConnectionId != parent.ConnectionDetail.ConnectionId).ToArray<ConnectionDetail>());
                }
                else
                {
                    // All connections
                    this.Organizations = (ConnectionManager.Instance.ConnectionsList.Connections.ToArray<ConnectionDetail>());
                }

                this.lvOrganizations_ItemSelectionChanged(this.lvOrganizations, null);
                this.lvSnapshot_ItemSelectionChanged(this.lvSnapshot, null);
                if (parent.ConnectionDetail != null)
                {
                    this.gbSnapshot.Text = parent.ConnectionDetail.OrganizationFriendlyName;
                }
            }
        }

        #endregion Private Methods

    }
}