namespace Environments.Compare
{
    using McTools.Xrm.Connection;
    using Microsoft.Xrm.Sdk.Query;
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using XrmToolBox;

    public partial class StartingPoint : PluginBase
    {
        #region Public Constructors

        public StartingPoint()
        {
            InitializeComponent();
        }

        #endregion Public Constructors

        #region Private Methods

        private void EnvironmentsSelector_Load(object sender, EventArgs e)
        {
            this.InitializeControls();
        }

        private void FillOrganizations()
        {
            lvOrganizations.Items.Clear();

            foreach (var connection in new ConnectionManager().ConnectionsList.Connections.Where(x => x.ConnectionId != this.ConnectionDetail.ConnectionId))
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

        private void FillReference()
        {
            if (this.ConnectionDetail != null)
            {
                lvReference.Items.Add(new ListViewItem(
                    new string[] {
                    this.ConnectionDetail.OrganizationFriendlyName,
                    this.ConnectionDetail.OrganizationServiceUrl,
                    this.ConnectionDetail.OrganizationVersion
                }));
            }
        }

        private void InitializeControls()
        {
            this.MinimumSize = new System.Drawing.Size(600, 400);

            this.FillReference();
            this.FillOrganizations();
        }

        private void LoadSolutionMatrix()
        {
            this.WorkAsync("Retrieving your user id...",
                (e) => // Work To Do Asynchronously
                {
                    var query = new QueryExpression("solution");
                    query.Criteria = new FilterExpression();
                    query.Criteria.AddCondition("isvisible", ConditionOperator.Equal, true);
                    query.ColumnSet = new ColumnSet(new string[] { "friendlyname", "version", "ismanaged" });

                    e.Result = this.Service.RetrieveMultiple(query).Entities;
                },
                e =>  // Cleanup when work has completed
                {
                    this.ShowOrganizationSelector(false);
                    this.ShowBackButton(true);
                }
            );
        }

        private void ShowBackButton(bool status)
        {
            var items = this.tsMenu.Items.Cast<ToolStripItem>().Where(x => (x != tsbClose) & (x != tsbSelectOrganizations) & (!x.GetType().Equals(typeof(ToolStripSeparator))));

            foreach (var item in items)
            {
                item.Enabled = !status;
            }

            this.tsbSelectOrganizations.Enabled = status;
        }

        private void ShowOrganizationSelector(bool status)
        {
            this.gbReference.Visible = status;
            this.gbOrganizations.Visible = status;
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            base.CloseToolPrompt();
        }

        private void tsbCompareSolutions_Click(object sender, EventArgs e)
        {
            this.LoadSolutionMatrix();
        }

        private void tsbSelectOrganizations_Click(object sender, EventArgs e)
        {
            this.ShowOrganizationSelector(true);
            this.ShowBackButton(false);
        }

        #endregion Private Methods
    }
}