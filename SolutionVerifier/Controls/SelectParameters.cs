namespace Cinteros.Xrm.SolutionVerifier.Controls
{
    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Forms;
    using Cinteros.Xrm.SolutionVerifier.SDK;
    using Cinteros.Xrm.SolutionVerifier.Utils;
    using McTools.Xrm.Connection;
    using XrmToolBox;

    public partial class SelectParameters : UserControl, IUpdateToolStrip
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectParameters"/> class.
        /// </summary>
        public SelectParameters()
        {
            InitializeComponent();

            this.ParentChanged += this.SelectParameters_ParentChanged;
        }

        #endregion Public Constructors

        #region Public Events

        public event EventHandler<UpdateToolStripEventArgs> UpdateToolStrip;

        #endregion Public Events

        #region Public Properties

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

                foreach (var connection in value)
                {
                    this.lvOrganizations.Items.Add(Helpers.LoadItemConnection(connection));
                }
                this.lvOrganizations.ItemChecked += this.lvOrganizations_ItemChecked;
            }
        }

        /// <summary>
        /// Reference connection (CRM organization or file)
        /// </summary>
        public ConnectionDetail Reference
        {
            get
            {
                return this.lvReference.Items.Cast<ListViewItem>().ToArray().Select(x => (ConnectionDetail)x.Tag).FirstOrDefault();
            }
            set
            {
                this.lvReference.Items.Clear();
                this.lvReference.Items.Add(Helpers.LoadItemConnection(value));
            }
        }

        public OrganizationSnapshot Snapshot
        {
            get
            {
                return (this.lvSolutions.Tag == null) ? new OrganizationSnapshot() : (OrganizationSnapshot)this.lvSolutions.Tag; 
            }
            set
            {
                this.lvSolutions.ItemChecked -= this.lvSolutions_ItemChecked;
                this.lvSolutions.Items.Clear();
                this.lvSolutions.Tag = value;

                var solutionsGroup = new ListViewGroup("Solutions:");
                this.lvSolutions.Groups.Add(solutionsGroup);

                var assembliesGroup = new ListViewGroup("Assemblies:");
                this.lvSolutions.Groups.Add(assembliesGroup);

                foreach (var solution in value.Solutions)
                {
                    var row = new string[] {
                        solution.FriendlyName,
                        solution.Version.ToString(),
                    };

                    var item = new ListViewItem(row);
                    item.Group = solutionsGroup;
                    item.Tag = solution;

                    this.lvSolutions.Items.Add(item);
                }

                foreach (var assembly in value.Assemblies)
                {
                    var row = new string[] {
                        assembly.Name,
                        assembly.Version.ToString(),
                    };

                    var item = new ListViewItem(row);
                    item.Group = assembliesGroup;
                    item.Tag = assembly;

                    this.lvSolutions.Items.Add(item);
                }
                    //if (solution.Assemblies.Length > 0)
                    //{
                    //    var group = new ListViewGroup("assemblies:");
                    //    this.lvSolutions.Groups.Add(group);

                    //    foreach (var assembly in solution.Assemblies)
                    //    {
                    //        row = new string[] {
                    //        assembly.Name,
                    //        assembly.Version.ToString(),
                    //    };

                    //        item = new ListViewItem(row);
                    //        item.Group = group;
                    //        item.Tag = assembly;

                    //        this.lvSolutions.Items.Add(item);
                    //    }
                    //}
                this.lvSolutions.ItemChecked += this.lvSolutions_ItemChecked;
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
                this.UpdateToolStrip(this, new UpdateToolStripEventArgs(Constants.U_SAVE_BUTTON, this.Snapshot.Solutions.Length > 0));
                this.UpdateToolStrip(this, new UpdateToolStripEventArgs(Constants.U_COMPARE_BUTTON, this.Snapshot.Solutions.Length > 0 && this.Organizations.Length > 0));
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

            this.lvSolutions.ItemChecked -= lvSolutions_ItemChecked;
            foreach (var item in this.lvSolutions.Items.Cast<ListViewItem>().ToArray())
            {
                item.Checked = cb.Checked;
            }
            this.lvSolutions.ItemChecked += lvSolutions_ItemChecked;

            this.JustifyToolStrip();
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
        private void lvSolutions_ItemChecked(object sender, ItemCheckedEventArgs e)
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
        private void lvSolutions_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            var list = (ListView)sender;

            foreach (var item in list.Items.Cast<ListViewItem>().Where(x => x.Selected == true))
            {
                item.Checked = !item.Checked;
            }

            this.JustifyToolStrip();
        }

        private void SelectParameters_ConnectionUpdated(object sender, PluginBase.ConnectionUpdatedEventArgs e)
        {
            if (e.ConnectionDetail != null && !string.IsNullOrEmpty(e.ConnectionDetail.OrganizationServiceUrl))
            {
                this.RetrieveSnapshot((MainScreen)sender);
            }
        }

        /// <summary>
        /// Event handler capturing when parent control is changed (current conntrol is beeing added
        /// to the plugin's main form)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectParameters_ParentChanged(object sender, EventArgs e)
        {
            var parent = (MainScreen)this.Parent;

            if (parent != null)
            {
                parent.ConnectionUpdated += SelectParameters_ConnectionUpdated;

                if (parent.ConnectionDetail != null)
                {
                    this.RetrieveSnapshot(parent);

                    // All connections except currently connected one
                    this.Organizations = (new ConnectionManager().ConnectionsList.Connections.Where(x => x.ConnectionId != parent.ConnectionDetail.ConnectionId).ToArray<ConnectionDetail>());
                }
                else
                {
                    // All connections
                    this.Organizations = (new ConnectionManager().ConnectionsList.Connections.ToArray<ConnectionDetail>());
                }

                this.lvOrganizations_ItemSelectionChanged(this.lvOrganizations, null);
                this.lvSolutions_ItemSelectionChanged(this.lvSolutions, null);
            }
        }

        /// <summary>
        /// Updating list of solutions from connection provided by XrmToolBox plugin class
        /// </summary>
        /// <param name="plugin">XrmToolBox plugin class</param>
        private void RetrieveSnapshot(MainScreen plugin)
        {
            plugin.WorkAsync(string.Format("Getting solutions information from '{0}'...", plugin.ConnectionDetail.OrganizationFriendlyName),
                (a) => // Work To Do Asynchronously
                {
                    if (string.IsNullOrEmpty(plugin.ConnectionDetail.ServerName))
                    {
                        a.Result = Helpers.LoadSolutionFile(plugin.ConnectionDetail.OrganizationServiceUrl);
                    }
                    else
                    {
                        a.Result = new OrganizationSnapshot(plugin.ConnectionDetail);
                    }
                },
                (a) =>  // Cleanup when work has completed
                {
                    this.Snapshot = (OrganizationSnapshot)a.Result;
                }
            );

            this.Reference = plugin.ConnectionDetail;
        }

        /// <summary>
        /// Sends event that changes enabled status of the given button on plugin toolstrip
        /// </summary>
        /// <param name="name"></param>
        /// <param name="status"></param>
        private void UpdateButton(string name, bool status)
        {
            if (status)
            {
                if (this.UpdateToolStrip != null)
                {
                    this.UpdateToolStrip(this, new UpdateToolStripEventArgs(name, status));
                }
            }
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


        private void save_FileOk(object sender, CancelEventArgs e)
        {
            if (!e.Cancel)
            {
                //if (this.CurrentPage.GetType() == typeof(SelectParameters))
                //{
                    // TODO: re-enable and fix
                    // ((SelectParameters)this.CurrentPage).Snapshot.ToXml().Save(((SaveFileDialog)sender).FileName);
                //}
            }
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            var save = new SaveFileDialog();
            save.FileOk += this.save_FileOk;

            save.FileName = "reference-solutions.xml";
            save.ShowDialog();
        }


        #endregion Private Methods
    }
}