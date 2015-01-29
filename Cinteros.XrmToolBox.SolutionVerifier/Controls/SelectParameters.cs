namespace Cinteros.XrmToolbox.SolutionVerifier.Controls
{
    using Cinteros.XrmToolbox.SolutionVerifier.Utils;
    using McTools.Xrm.Connection;
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using XrmToolBox;

    public partial class SelectParameters : UserControl
    {

        #region Public Constructors

        public SelectParameters()
        {
            InitializeComponent();

            this.ParentChanged += this.SelectParameters_ParentChanged;
        }

        #endregion Public Constructors

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
                    var row = new string[] {
                        connection.OrganizationFriendlyName,
                        connection.ServerName,
                    };

                    var item = new ListViewItem(row);
                    item.Tag = connection;

                    this.lvOrganizations.Items.Add(item);
                }
                this.lvOrganizations.ItemChecked += this.lvOrganizations_ItemChecked;
            }
        }

        public Solution[] Solutions
        {
            get
            {
                return this.lvSolutions.CheckedItems.Cast<ListViewItem>().ToArray().Select(x => (Solution)x.Tag).ToArray<Solution>();
            }
            set
            {
                this.lvSolutions.ItemChecked -= this.lvSolutions_ItemChecked;
                this.lvSolutions.Items.Clear();

                foreach (var solution in value)
                {
                    var row = new string[] {
                        solution.FriendlyName,
                        solution.Version.ToString(),
                    };

                    var item = new ListViewItem(row);
                    item.Tag = solution;

                    this.lvSolutions.Items.Add(item);
                }
                this.lvSolutions.ItemChecked += this.lvSolutions_ItemChecked;
            }
        }

        #endregion Public Properties

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

            this.UpdateCompareButton();
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

            this.UpdateCompareButton();
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

            this.UpdateCompareButton();
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

            this.UpdateCompareButton();
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

            this.UpdateCompareButton();
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

            this.UpdateCompareButton();
        }

        private void SelectParameters_ConnectionUpdated(object sender, PluginBase.ConnectionUpdatedEventArgs e)
        {
            if (e.ConnectionDetail != null && !string.IsNullOrEmpty(e.ConnectionDetail.OrganizationServiceUrl))
            {
                this.SetSolutions((MainScreen)sender);
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
                    this.SetSolutions(parent);

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
        /// Set reference organization information
        /// </summary>
        /// <param name="connection">Current connection</param>
        private void SetReference(ConnectionDetail connection)
        {
            var row = new string[] {
                connection.OrganizationFriendlyName,
                connection.OrganizationServiceUrl,
            };

            this.lvReference.Items.Clear();
            this.lvReference.Items.Add(new ListViewItem(row));
        }

        /// <summary>
        /// Updating list of solutions from connection provided by XrmToolBox plugin class
        /// </summary>
        /// <param name="plugin">XrmToolBox plugin class</param>
        private void SetSolutions(MainScreen plugin)
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
                        a.Result = plugin.Service.RetrieveMultiple(Helpers.CreateSolutionsQuery()).Entities.Select(x => new Solution(x)).ToArray<Solution>();
                    }
                },
                (a) =>  // Cleanup when work has completed
                {
                    this.Solutions = (Solution[])a.Result;
                }
            );

            this.SetReference(plugin.ConnectionDetail);
        }

        /// <summary>
        /// Updates button on tool depending on currently checked items
        /// </summary>
        private void UpdateCompareButton()
        {
            var button = Helpers.FindToolStripButton(this, "tsbCompare");

            if (button != null)
            {
                if (this.Solutions.Length > 0 && this.Organizations.Length > 0)
                {
                    button.Enabled = true;
                }
                else
                {
                    button.Enabled = false;
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

        #endregion Private Methods

    }
}