namespace Cinteros.XrmToolbox.SolutionVerifier
{
    using Cinteros.XrmToolbox.SolutionVerifier.Controls;
    using Cinteros.XrmToolbox.SolutionVerifier.Utils;
    using McTools.Xrm.Connection;
    using Microsoft.Xrm.Client;
    using Microsoft.Xrm.Client.Services;
    using Microsoft.Xrm.Sdk;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Windows.Forms;
    using XrmToolBox;

    public partial class MainScreen : PluginBase
    {
        #region Private Methods

        private void tsbSelectOrganizations_Click(object sender, EventArgs e)
        {
            // Execution order is important here, due to rewriting status of tool strip of plugin
            // main window
            this.ShowBackButton(false);
            this.AddSubControl(new SelectParameters());
        }

        #endregion Private Methods

        #region Public Constructors

        public MainScreen()
        {
            InitializeComponent();
        }

        #endregion Public Constructors

        #region Public Properties

        public Control SubControl { get; set; }

        #endregion Public Properties

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
            this.AddSubControl(new SelectParameters());
        }

        private void LoadSolutionMatrix()
        {
            Solution[] solutions = null;
            var services = new Dictionary<string, OrganizationService>();
            services.Add(this.ConnectionDetail.OrganizationFriendlyName, (OrganizationService)this.Service);

            var result = this.SubControl.Controls.Find("lvSolutions", true);

            if (result.Length > 0)
            {
                solutions = ((ListView)result[0]).Items.Cast<ListViewItem>().Where(x => x.Checked == true).Select(x => (Solution)x.Tag).ToArray();
            }

            result = this.SubControl.Controls.Find("lvOrganizations", true);

            if (result.Length > 0)
            {
                var connections = ((ListView)result[0]).Items.Cast<ListViewItem>().Where(x => x.Checked == true).Select(x => (ConnectionDetail)x.Tag).ToList();

                WebRequest.GetSystemWebProxy();

                foreach (var connection in connections)
                {
                    services.Add(connection.OrganizationFriendlyName, new OrganizationService(CrmConnection.Parse(connection.GetOrganizationCrmConnectionString())));
                }
            }

            this.WorkAsync("Getting solutions information from organizations...",
                (e) => // Work To Do Asynchronously
                {
                    var query = Helpers.CreateSolutionsQuery();
                    var matrix = new Dictionary<string, Solution[]>();

                    foreach (var service in services)
                    {
                        try
                        {
                            var entities = service.Value.RetrieveMultiple(query).Entities;
                            var response = entities.ToArray<Entity>().Select(x => new Solution(x)).ToArray<Solution>();
                            response = response.Where(x => solutions.Where(y => y.UniqueName == x.UniqueName).Count() > 0).ToArray<Solution>();
                            var res = response.Intersect(solutions).ToArray<Solution>();

                            matrix.Add(service.Key, response);
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
                    if (e.Result != null)
                    {
                        var control = new ViewResults();
                        control.Set((Dictionary<string, Solution[]>)e.Result);
                        // Execution order is important here, due to rewriting status of tool strip
                        // of plugin main window
                        this.ShowBackButton(true);
                        this.AddSubControl(control);
                    }
                }
            );
        }

        private void save_FileOk(object sender, CancelEventArgs e)
        {
            if (!e.Cancel)
            {
                if (this.SubControl.GetType() == typeof(SelectParameters))
                {
                    ((SelectParameters)this.SubControl).Solutions.ToXml().Save(((SaveFileDialog)sender).FileName);
                }
            }
        }

        private void ShowBackButton(bool status)
        {
            var items = this.tsMenu.Items.Cast<ToolStripItem>().Where(x => (x != tsbClose) & (x != tsbBack) & (!x.GetType().Equals(typeof(ToolStripSeparator))));

            foreach (var item in items)
            {
                item.Enabled = !status;
            }

            this.tsbBack.Enabled = status;
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            base.CloseToolPrompt();
        }

        private void tsbCompareSolutions_Click(object sender, EventArgs e)
        {
            this.LoadSolutionMatrix();
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            var save = new SaveFileDialog();
            save.FileOk += save_FileOk;

            save.FileName = "solutions.csv";
            save.ShowDialog();
        }
    }
}