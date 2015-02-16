[assembly: XrmToolBox.Attributes.BackgroundColor("#000000")]

namespace Cinteros.Xrm.SolutionVerifier
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Configuration;
    using System.Drawing;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Xml;
    using Cinteros.Xrm.SolutionVerifier.Controls;
    using Cinteros.Xrm.SolutionVerifier.Properties;
    using Cinteros.Xrm.SolutionVerifier.SDK;
    using Cinteros.Xrm.SolutionVerifier.Utils;
    using McTools.Xrm.Connection;
    using Microsoft.Xrm.Client;
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

            this.UpdateToolStrip += this.MainScreen_UpdateToolStrip;
        }

        #endregion Public Constructors

        #region Public Events

        public event EventHandler<UpdateToolStripEventArgs> UpdateToolStrip;

        #endregion Public Events

        #region Public Properties

        /// <summary>
        /// Gets or sets control, that would be seen as current page
        /// </summary>
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

                ((IUpdateToolStrip)this.control).UpdateToolStrip += this.MainScreen_UpdateToolStrip;
                ((IUpdateToolStrip)this.control).JustifyToolStrip();
                this.JustifyToolStrip();
            }
        }

        /// <summary>
        /// Gets plugin logo
        /// </summary>
        public override Image PluginLogo
        {
            get
            {
                return Resources.Cinteros;
            }
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Enables or disables `back` button depending on the situation
        /// </summary>
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
            open.FileOk += this.open_FileOk;

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

                // TODO: re-enable and fix ((SelectParameters)this.CurrentPage).Snapshot = Helpers.LoadSolutionFile(dialog.FileName);

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
                try
                {
                    services.Add(organization, CrmConnection.Parse(organization.GetOrganizationCrmConnectionString()));
                }
                catch (ConfigurationErrorsException)
                {
                    // The specified user credentials are invalid.
                }
            }

            var snapshot = ((SelectParameters)this.CurrentPage).Snapshot;

            this.WorkAsync("Getting solutions information from organizations...",
                (e) => // Work To Do Asynchronously
                {
                    var matrix = new List<OrganizationSnapshot>();

                    matrix.Add(new OrganizationSnapshot { ConnectionDetail = this.ConnectionDetail, Solutions = snapshot.Solutions });

                    Parallel.ForEach(services, service =>
                    {
                        try
                        {
                            matrix.Add(new OrganizationSnapshot(service.Key, snapshot.Solutions));
                        }
                        catch (InvalidOperationException)
                        {
                            // Hiding exception,
                        }
                    });
                    e.Result = matrix.ToArray<OrganizationSnapshot>();
                },
                (e) =>  // Cleanup when work has completed
                {
                    if (e.Result != null)
                    {
                        this.CurrentPage = new ViewResults((OrganizationSnapshot[])e.Result);
                    }
                }
            );
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

        #endregion Private Methods

    }
}