namespace Cinteros.Solutions.Compare
{
    using Cinteros.Solutions.Compare.Utils;
    using McTools.Xrm.Connection;
    using Microsoft.Xrm.Sdk;
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
                parent.WorkAsync(string.Format("Getting solutions information from '{0}'...", parent.ConnectionDetail.OrganizationFriendlyName),
                    (a) => // Work To Do Asynchronously
                    {
                        a.Result = parent.Service.RetrieveMultiple(Helpers.CreateSolutionsQuery()).Entities.Select(x => new Solution(x)).ToArray<Solution>();
                    },
                    (a) =>  // Cleanup when work has completed
                    {
                        foreach (var solution in (Solution[])a.Result)
                        {
                            var row = new string[] {
                                solution.FriendlyName,
                                solution.Version.ToString(),
                            };

                            lvSolutions.Items.Add(new ListViewItem(row));
                        }
                    }
                );


                if (parent.ConnectionDetail != null)
                {
                    var row = new string[] {
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

                        lvOrganizations.Items.Add(new ListViewItem(row));
                    }
                }

                onItemSelectionChanged(lvOrganizations, null);
            }
        }

        #endregion Private Methods
    }
}