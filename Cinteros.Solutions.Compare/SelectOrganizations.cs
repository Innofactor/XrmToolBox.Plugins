﻿namespace Cinteros.Solutions.Compare
{
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

        private void lvOrganizations_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            var result1 = this.Parent.Controls.Find("tsMenu", true);

            if (result1.Length > 0)
            {
                var menu = (ToolStrip)result1[0];
                var result2 = menu.Items.Find("tsbCompareSolutions", true);

                if (result2.Length > 0)
                {
                    var listView = (ListView)sender;

                    var selected = listView.Items.Cast<ListViewItem>().Where(x => x.Selected == true);

                    if (selected.Count() > 0)
                    {
                        result2[0].Enabled = true;
                    }
                    else
                    {
                        result2[0].Enabled = false;
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

                lvOrganizations_ItemSelectionChanged(lvOrganizations, null);
            }
        }

        #endregion Private Methods
    }
}