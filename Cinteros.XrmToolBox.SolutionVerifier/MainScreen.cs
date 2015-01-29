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
    using System.Xml;
    using XrmToolBox;

    public partial class MainScreen : PluginBase
    {

        #region Private Methods

        private void tsbBack_Click(object sender, EventArgs e)
        {
            // Execution order is important here, due to rewriting status of tool strip of plugin
            // main window
            this.ShowBackButton(false);
            this.CurrentPage = new SelectParameters();
        }

        #endregion Private Methods

        #region Private Fields

        private Control control;

        #endregion Private Fields

        #region Public Constructors

        public MainScreen()
        {
            InitializeComponent();
        }

        #endregion Public Constructors

        #region Public Properties

        public Control CurrentPage
        {
            get
            {
                return this.control;
            }
            set
            {
                value.Size = this.Size;
                value.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;

                this.Controls.Remove(this.control);
                this.Controls.Add(value);

                this.control = value;
            }
        }

        #endregion Public Properties

        private void fromReferenceFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var open = new OpenFileDialog();
            open.FileOk += open_FileOk;

            open.ShowDialog();
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            this.CurrentPage = new SelectParameters();
        }

        private void open_FileOk(object sender, CancelEventArgs e)
        {
            var dialog = (OpenFileDialog)sender;

            if (!e.Cancel)
            {
                var document = new XmlDocument();
                document.Load(dialog.FileName);

                ((SelectParameters)this.CurrentPage).Solutions = Helpers.LoadSolutionFile(dialog.FileName);

                var connection = new ConnectionDetail
                {
                    Organization = "ReferenceFile",
                    OrganizationFriendlyName = "Reference File",
                    OrganizationServiceUrl = dialog.FileName
                };

                this.ConnectionDetail = connection;

                this.OnConnectionUpdated(new ConnectionUpdatedEventArgs(null, connection));
            }
        }

        private void Process()
        {
            var services = new Dictionary<ConnectionDetail, OrganizationService>();

            WebRequest.GetSystemWebProxy();

            foreach (var organization in ((SelectParameters)this.CurrentPage).Organizations)
            {
                services.Add(organization, new OrganizationService(CrmConnection.Parse(organization.GetOrganizationCrmConnectionString())));
            }

            var reference = ((SelectParameters)this.CurrentPage).Solutions;

            this.WorkAsync("Getting solutions information from organizations...",
                (e) => // Work To Do Asynchronously
                {
                    var query = Helpers.CreateSolutionsQuery();
                    var matrix = new Dictionary<ConnectionDetail, Solution[]>();

                    matrix.Add(this.ConnectionDetail, reference);

                    foreach (var service in services)
                    {
                        try
                        {
                            var entities = service.Value.RetrieveMultiple(query).Entities;
                            var response = entities.ToArray<Entity>().Select(x => new Solution(x)).ToArray<Solution>();
                            response = response.Where(x => reference.Where(y => y.UniqueName == x.UniqueName).Count() > 0).ToArray<Solution>();

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
                        // Execution order is important here, due to rewriting status of tool strip
                        // of plugin main window
                        this.ShowBackButton(true);
                        this.CurrentPage = new ViewResults((Dictionary<ConnectionDetail, Solution[]>)e.Result);
                    }
                }
            );
        }

        private void save_FileOk(object sender, CancelEventArgs e)
        {
            if (!e.Cancel)
            {
                if (this.CurrentPage.GetType() == typeof(SelectParameters))
                {
                    ((SelectParameters)this.CurrentPage).Solutions.ToXml().Save(((SaveFileDialog)sender).FileName);
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
            base.CloseTool();
        }

        private void tsbCompare_Click(object sender, EventArgs e)
        {
            this.Process();
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            var save = new SaveFileDialog();
            save.FileOk += save_FileOk;

            save.FileName = "reference-solutions.xml";
            save.ShowDialog();
        }
    }
}