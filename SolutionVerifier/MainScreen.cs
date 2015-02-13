[assembly: XrmToolBox.Attributes.BackgroundColor("#000000")]

namespace Cinteros.Xrm.SolutionVerifier
{
    using Cinteros.Xrm.SolutionVerifier.Controls;
    using Cinteros.Xrm.SolutionVerifier.Properties;
    using Cinteros.Xrm.SolutionVerifier.Utils;
    using McTools.Xrm.Connection;
    using Microsoft.Xrm.Client;
    using Microsoft.Xrm.Client.Services;
    using Microsoft.Xrm.Sdk;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Linq;
    using System.Net;
    using System.Reflection;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Xml;
    using XrmToolBox;

    public partial class MainScreen : PluginBase, IUpdateToolStrip
    {

        #region Private Fields

        private Control control;

        #endregion Private Fields

        #region Public Constructors

        public MainScreen()
        {
            InitializeComponent();

            this.UpdateToolStrip += MainScreen_UpdateToolStrip;
        }

        #endregion Public Constructors

        #region Public Events

        public event EventHandler<UpdateToolStripEventArgs> UpdateToolStrip;

        #endregion Public Events

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

                ((IUpdateToolStrip)this.control).UpdateToolStrip += MainScreen_UpdateToolStrip;
                ((IUpdateToolStrip)this.control).JustifyToolStrip();
                this.JustifyToolStrip();
            }
        }

        public override Image PluginLogo
        {
            get
            {
                return Resources.Cinteros;
            }
        }

        #endregion Public Properties

        #region Public Methods

        public void JustifyToolStrip()
        {
            if (this.UpdateToolStrip != null)
            {
                if (this.CurrentPage.GetType().Equals(typeof(SelectParameters)))
                {
                    this.UpdateToolStrip(this, new UpdateToolStripEventArgs(Constants.U_BACK_BUTTON, false));
                }
                else
                {
                    this.UpdateToolStrip(this, new UpdateToolStripEventArgs(Constants.U_BACK_BUTTON, true));
                }
            }
        }

        #endregion Public Methods

        #region Private Methods

        private void fromConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ConnectionDetail != null)
            {
                ((SelectParameters)this.CurrentPage).Reference = this.ConnectionDetail;

                this.OnConnectionUpdated(new ConnectionUpdatedEventArgs(null, this.ConnectionDetail));
            }
            else
            {
            }
        }

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

        private void MainScreen_UpdateToolStrip(object sender, UpdateToolStripEventArgs e)
        {
            if (e != null)
            {
                var menu = this.Controls.Find("tsMenu", true).Cast<ToolStrip>().FirstOrDefault();

                var button = (menu != null) ? menu.Items.Find(e.ButtonName, true).Cast<ToolStripButton>().FirstOrDefault() : null;

                if (button != null)
                {
                    button.Enabled = e.ButtonStatus;
                }
            }
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
            var services = new Dictionary<ConnectionDetail, CrmConnection>();

            WebRequest.GetSystemWebProxy();

            foreach (var organization in ((SelectParameters)this.CurrentPage).Organizations)
            {
                services.Add(organization, CrmConnection.Parse(organization.GetOrganizationCrmConnectionString()));
            }

            var reference = ((SelectParameters)this.CurrentPage).Solutions;

            this.WorkAsync("Getting solutions information from organizations...",
                (e) => // Work To Do Asynchronously
                {
                    var solutionsQuery = Helpers.CreateSolutionsQuery();
                    var assembliesQuery = Helpers.CreateAssembliesQuery();

                    var matrix = new Dictionary<ConnectionDetail, Solution[]>();

                    matrix.Add(this.ConnectionDetail, reference);

                    Parallel.ForEach(services, service =>
                    {
                        var instance = new OrganizationService(service.Value);
                        try
                        {
                            Solution[] solutions = null;
                            PluginAssembly[] assemblies = null;

                            var entities = instance.RetrieveMultiple(solutionsQuery).Entities;
                            solutions = entities.ToArray<Entity>().Select(x => new Solution(x)).ToArray<Solution>();
                            solutions = solutions.Where(x => reference.Where(y => y.UniqueName == x.UniqueName).Count() > 0).ToArray<Solution>();

                            entities = instance.RetrieveMultiple(assembliesQuery).Entities;
                            assemblies = entities.ToArray<Entity>().Select(x => new PluginAssembly(x)).ToArray<PluginAssembly>();
                            assemblies = assemblies.Where(x => solutions.Where(y => y.Id == x.SolutionId).Count() > 0).ToArray<PluginAssembly>();

                            foreach (var solution in solutions)
                            {
                                solution.Assemblies = assemblies.Where(x => x.SolutionId == solution.Id).ToArray<PluginAssembly>();
                            }

                            matrix.Add(service.Key, solutions);
                        }
                        catch (InvalidOperationException ex)
                        {
                            // Hiding exception,
                        }
                        finally
                        {
                            instance.Dispose();
                        }
                    });
                    e.Result = matrix;
                },
                (e) =>  // Cleanup when work has completed
                {
                    if (e.Result != null)
                    {
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

        private void tsbBack_Click(object sender, EventArgs e)
        {
            this.CurrentPage = new SelectParameters();
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

        #endregion Private Methods

    }
}