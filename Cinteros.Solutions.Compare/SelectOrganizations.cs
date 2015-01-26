namespace Cinteros.Solutions.Compare
{
    using Cinteros.Solutions.Compare.Utils;
    using McTools.Xrm.Connection;
    using System;
    using System.Linq;
    using System.Windows.Forms;

    public partial class SelectOrganizations : UserControl
    {
        #region Public Constructors

        public SelectOrganizations()
        {
            InitializeComponent();

            this.ParentChanged += SelectEnvironments_ParentChanged;
        }

        #endregion Public Constructors

        #region Private Methods

        private void onItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            var result1 = this.Parent.Controls.Find("tsMenu", true);

            if (result1.Length > 0)
            {
                var menu = (ToolStrip)result1[0];
                var button = menu.Items.Find("tsbCompareSolutions", true).FirstOrDefault();

                if (button != null)
                {
                    var listView = (ListView)sender;

                    var selected = listView.Items.Cast<ListViewItem>().Where(x => x.Selected == true);

                    foreach (var item in selected)
                    {
                        item.Checked = !item.Checked;
                    }

                    if (this.lvSolutions.CheckedItems.Count > 0 && this.lvOrganizations.CheckedItems.Count > 0)
                    {
                        button.Enabled = true;
                    }
                    else
                    {
                        button.Enabled = false;
                    }
                }
            }
        }

        private void SelectEnvironments_ParentChanged(object sender, EventArgs e)
        {
            var parent = (MainScreen)this.Parent;

            if (parent != null)
            {
                if (parent.ConnectionDetail != null)
                {
                    string[] row;
                    ListViewItem item;

                    parent.WorkAsync(string.Format("Getting solutions information from '{0}'...", parent.ConnectionDetail.OrganizationFriendlyName),
                        (a) => // Work To Do Asynchronously
                        {
                            a.Result = parent.Service.RetrieveMultiple(Helpers.CreateSolutionsQuery()).Entities.Select(x => new Solution(x)).ToArray<Solution>();
                        },
                        (a) =>  // Cleanup when work has completed
                        {
                            lvSolutions.Items.Clear();
                            foreach (var solution in (Solution[])a.Result)
                            {
                                row = new string[] {
                                    solution.FriendlyName,
                                    solution.Version.ToString(),
                                };

                                item = new ListViewItem(row);
                                item.Tag = solution;

                                lvSolutions.Items.Add(item);
                            }
                        }
                    );

                    row = new string[] {
                        parent.ConnectionDetail.OrganizationFriendlyName,
                        parent.ConnectionDetail.ServerName,
                    };

                    lvReference.Items.Clear();
                    lvReference.Items.Add(new ListViewItem(row));

                    lvOrganizations.Items.Clear();

                    foreach (var connection in new ConnectionManager().ConnectionsList.Connections.Where(x => x.ConnectionId != parent.ConnectionDetail.ConnectionId))
                    {
                        row = new string[] {
                            connection.OrganizationFriendlyName,
                            connection.ServerName,
                        };

                        item = new ListViewItem(row);
                        item.Tag = connection;

                        lvOrganizations.Items.Add(item);
                    }
                }

                onItemSelectionChanged(lvOrganizations, null);
            }
        }

        #endregion Private Methods

        private void cbToggleSolutions_CheckedChanged(object sender, EventArgs e)
        {
            var cb = (CheckBox)sender;

            foreach (var item in this.lvSolutions.Items.Cast<ListViewItem>().ToArray())
            {
                item.Checked = cb.Checked;
            }

            onItemSelectionChanged(this.lvSolutions, null);
        }

        private void cbToggleOrganizations_CheckedChanged(object sender, EventArgs e)
        {
            var cb = (CheckBox)sender;

            foreach (var item in this.lvOrganizations.Items.Cast<ListViewItem>().ToArray())
            {
                item.Checked = cb.Checked;
            }

            onItemSelectionChanged(this.lvOrganizations, null);
        }
    }
}