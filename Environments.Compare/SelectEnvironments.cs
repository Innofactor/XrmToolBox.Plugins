namespace Environments.Compare
{
    using McTools.Xrm.Connection;
    using System;
    using System.Linq;
    using System.Windows.Forms;

    public partial class SelectEnvironments : UserControl
    {
        public SelectEnvironments()
        {
            InitializeComponent();

            this.ParentChanged += delegate(object sender, EventArgs e)
            {
                var parent = (MainScreen)this.Parent;

                if (parent != null)
                {
                    lvReference.Items.Clear();

                    if (parent.ConnectionDetail != null)
                    {
                        var row = new string[] {
                            parent.ConnectionDetail.OrganizationFriendlyName,
                            parent.ConnectionDetail.OrganizationServiceUrl,
                            parent.ConnectionDetail.OrganizationVersion
                        };

                        lvReference.Items.Add(new ListViewItem(row));
                    }

                    lvOrganizations.Items.Clear();

                    foreach (var connection in new ConnectionManager().ConnectionsList.Connections.Where(x => x.ConnectionId != parent.ConnectionDetail.ConnectionId))
                    {
                        var row = new string[] {
                            connection.OrganizationFriendlyName,
                            connection.OrganizationServiceUrl,
                            connection.OrganizationVersion
                        };

                        var item = new ListViewItem(row);

                        item.Tag = connection;
                        lvOrganizations.Items.Add(item);
                    }
                }
            };
        }
    }
}