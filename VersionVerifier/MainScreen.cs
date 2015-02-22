[assembly: XrmToolBox.Attributes.BackgroundColor("#000000")]

namespace Cinteros.Xrm.VersionVerifier
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
    using Cinteros.Xrm.VersionVerifier.Controls;
    using Cinteros.Xrm.VersionVerifier.Properties;
    using Cinteros.Xrm.VersionVerifier.SDK;
    using Cinteros.Xrm.VersionVerifier.Utils;
    using McTools.Xrm.Connection;
    using XrmToolBox;

    public partial class MainScreen : PluginBase, IUpdateToolStrip, IGitHubPlugin
    {
        #region Public Methods

        public void AssignToolStripButtonHandler(string name, EventHandler handler)
        {
            var button = this.GetToolStipButton(name);

            if (button != null)
            {
                if (this.toolStripHandlers.ContainsKey(name))
                {
                    button.Click -= this.toolStripHandlers[name];
                    this.toolStripHandlers.Remove(name);
                }
                button.Click += handler;
                this.toolStripHandlers.Add(name, handler);
            }
        }

        /// <summary>
        /// Enables or disables `back` button depending on the situation
        /// </summary>
        public void JustifyToolStrip()
        {
            if (this.UpdateToolStrip != null)
            {
                if (this.CurrentPage.GetType().Equals(typeof(ViewParameters)))
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
                //((ViewParameters)this.CurrentPage).Reference = this.ConnectionDetail;

                //this.OnConnectionUpdated(new ConnectionUpdatedEventArgs(null, this.ConnectionDetail));
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

        private ToolStripButton GetToolStipButton(string name)
        {
            var menu = this.Controls.Find("tsMenu", true).Cast<ToolStrip>().FirstOrDefault();

            var button = (menu != null) ? menu.Items.Find(name, true).Cast<ToolStripButton>().FirstOrDefault() : null;
            return button;
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            this.CurrentPage = new ViewParameters();
        }

        private void MainScreen_UpdateToolStrip(object sender, UpdateToolStripEventArgs e)
        {
            if (e != null)
            {
                var button = this.GetToolStipButton(e.ButtonName);

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
            var services = new List<ConnectionDetail>();

            WebRequest.GetSystemWebProxy();

            foreach (var organization in ((ViewParameters)this.CurrentPage).Organizations)
            {
                try
                {
                    services.Add(organization);
                }
                catch (ConfigurationErrorsException)
                {
                    // The specified user credentials are invalid.
                }
            }

            var snapshot = ((ViewParameters)this.CurrentPage).Snapshot;

            this.WorkAsync("Getting solutions information from organizations...",
                (e) => // Work To Do Asynchronously
                {
                    var matrix = new List<OrganizationSnapshot>();

                    matrix.Add(new OrganizationSnapshot
                    {
                        ConnectionDetail = this.ConnectionDetail,
                        Solutions = snapshot.Solutions,
                        Assemblies = snapshot.Assemblies
                    });

                    Parallel.ForEach(services, service =>
                    {
                        try
                        {
                            matrix.Add(new OrganizationSnapshot(service, snapshot));
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
            this.CurrentPage = new ViewParameters();
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

        #region Private Fields

        private Control control;

        private Dictionary<string, EventHandler> toolStripHandlers = new Dictionary<string, EventHandler>();

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

        /// <summary>
        /// Github repository name
        /// </summary>
        public string RepositoryName
        {
            get
            {
                return "SolutionVerifier";
            }
        }

        /// <summary>
        /// Github user name
        /// </summary>
        public string UserName
        {
            get
            {
                return "Cinteros";
            }
        }

        #endregion Public Properties
    }
}