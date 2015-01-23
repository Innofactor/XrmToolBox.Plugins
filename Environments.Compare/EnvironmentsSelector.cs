namespace Environments.Compare
{
    using McTools.Xrm.Connection;
    using Microsoft.Xrm.Sdk.Query;
    using System;
    using System.Windows.Forms;
    using XrmToolBox;

    public partial class EnvironmentsSelector : PluginBase
    {
        #region Private Methods

        private void InitializeControls()
        {
            this.MinimumSize = new System.Drawing.Size(600, 400);

            // base.ConnectionDetail.
            if (base.ConnectionDetail != null)
            {
                lvReference.Items.Add(new ListViewItem(
                    new string[] {
                    this.ConnectionDetail.OrganizationFriendlyName,
                    this.ConnectionDetail.OrganizationServiceUrl,
                    this.ConnectionDetail.OrganizationVersion
                }));
            }

            foreach (var connection in new ConnectionManager().ConnectionsList.Connections)
            {
                lvOrganizations.Items.Add(new ListViewItem(
                    new string[] {
                    connection.OrganizationFriendlyName,
                    connection.OrganizationServiceUrl,
                    connection.OrganizationVersion
                }));
            }
        }

        private void LoadRefereceSolutions()
        {
            this.WorkAsync("Retrieving your user id...",
                (e) => // Work To Do Asynchronously
                {
                    var query = new QueryExpression("solution");
                    query.Criteria = new FilterExpression();
                    query.Criteria.AddCondition("isvisible", ConditionOperator.Equal, true);
                    query.ColumnSet = new ColumnSet(new string[] { "friendlyname", "version" });

                    e.Result = this.Service.RetrieveMultiple(query).Entities;
                },
                e =>  // Cleanup when work has completed
                {
                    // MessageBox.Show(string.Format("You are {0}", (Guid)e.Result));
                }
            );
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            base.CloseToolPrompt();
        }

        private void tsbCompare_Click(object sender, EventArgs e)
        {
            this.LoadRefereceSolutions();
        }

        #endregion Private Methods

        #region Public Constructors

        public EnvironmentsSelector()
        {
            InitializeComponent();
        }

        #endregion Public Constructors

        private void EnvironmentsSelector_Load(object sender, EventArgs e)
        {
            this.InitializeControls();
        }
    }
}