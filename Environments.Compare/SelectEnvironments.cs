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
                        lvReference.Items.Add(new ListViewItem(
                            new string[] {
                        parent.ConnectionDetail.OrganizationFriendlyName,
                        parent.ConnectionDetail.OrganizationServiceUrl,
                        parent.ConnectionDetail.OrganizationVersion
                    }));
                    }

                    lvOrganizations.Items.Clear();

                    foreach (var connection in new ConnectionManager().ConnectionsList.Connections.Where(x => x.ConnectionId != parent.ConnectionDetail.ConnectionId))
                    {
                        var item = new ListViewItem(
                            new string[] {
                        connection.OrganizationFriendlyName,
                        connection.OrganizationServiceUrl,
                        connection.OrganizationVersion
                    });

                        item.Tag = connection;
                        lvOrganizations.Items.Add(item);
                    }
                }
            };
        }
    }
}