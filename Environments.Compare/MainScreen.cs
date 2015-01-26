namespace Environments.Compare
{
    using Environments.Compare.Utils;
    using McTools.Xrm.Connection;
    using Microsoft.Xrm.Client;
    using Microsoft.Xrm.Client.Services;
    using Microsoft.Xrm.Sdk;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Windows.Forms;
    using XrmToolBox;

    public partial class MainScreen : PluginBase
    {
        #region Public Constructors

        public MainScreen()
        {
            InitializeComponent();
        }

        #endregion Public Constructors

        #region Public Properties

        public Control SubControl { get; set; }

        #endregion Public Properties

        #region Private Methods

        /// <summary>
        /// Adds subcontrol to the main plugin form
        /// </summary>
        /// <param name="control">Control to add</param>
        private void AddSubControl(Control control)
        {
            this.Controls.Remove(this.SubControl);

            control.Size = this.Size;
            control.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
            this.Controls.Add(control);

            this.SubControl = control;
        }

        private void EnvironmentsSelector_Load(object sender, EventArgs e)
        {
            this.AddSubControl(new SelectOrganizations());
        }

        private void LoadSolutionMatrix()
        {
            var query = Helpers.CreateSolutionsQuery();
            var matrix = new Dictionary<string, Entity[]>();
            var services = new Dictionary<string, OrganizationService>();
            services.Add(this.ConnectionDetail.OrganizationFriendlyName, (OrganizationService)this.Service);

            var result = this.SubControl.Controls.Find("lvOrganizations", true);

            if (result.Length > 0)
            {
                var selected = ((ListView)result[0]).Items.Cast<ListViewItem>().Where(x => x.Selected == true).Select(x => (ConnectionDetail)x.Tag).ToList();

                WebRequest.GetSystemWebProxy();

                foreach (var connection in selected)
                {
                    services.Add(connection.OrganizationFriendlyName, new OrganizationService(CrmConnection.Parse(connection.GetOrganizationCrmConnectionString())));
                }
            }

            this.WorkAsync("Getting solutions information from organizations...",
                (e) => // Work To Do Asynchronously
                {
                    foreach (var service in services)
                    {
                        try
                        {
                            matrix.Add(service.Key, service.Value.RetrieveMultiple(query).Entities.ToArray<Entity>());
                        }
                        catch (InvalidOperationException ex)
                        {
                            // Hiding exception, 
                        }
                    }

                    e.Result = matrix;
                },
                (e) =>  // Cleanup when work has completed
                {
                    var control = new CompareSolutions();
                    control.Set(matrix);
                    // Execution order is important here, due to rewriting status of tool strip of
                    // plugin main window
                    this.ShowBackButton(true);
                    this.AddSubControl(control);
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
            // Execution order is important here, due to rewriting status of tool strip of plugin
            // main window
            this.ShowBackButton(false);
            this.AddSubControl(new SelectOrganizations());
        }

        #endregion Private Methods
    }
}